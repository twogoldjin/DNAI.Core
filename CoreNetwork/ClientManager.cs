﻿using CoreCommand;
using EventClient.Communication;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreNetwork
{
    public class ClientManager
    {
        /// <summary>
        /// Client that handle the event protocol
        /// </summary>
        private TcpManager eventProtocolClient = new TcpManager();

        /// <summary>
        /// Command manager to handle call controller commands
        /// </summary>
        private IManager commandManager;

        /// <summary>
        /// Constructor that asks for the manager to handle
        /// </summary>
        /// <param name="manager">Manager that handle consumer data</param>
        public ClientManager(IManager manager)
        {
            commandManager = manager;
        }

        /// <summary>
        /// Connect to a specific IP:port through event protocol
        /// </summary>
        /// <param name="ip">Ip adress of the server</param>
        /// <param name="port">Port of the server</param>
        public void Connect(string ip, int port)
        {
            eventProtocolClient.Connect(ip, port);
        }

        /// <summary>
        /// Register all events needed by the CoreCommand.Manager
        /// </summary>
        public void RegisterEvents()
        {
            foreach (KeyValuePair<String, String> command in commandManager.GetRegisteredCommands())
            {
                Console.WriteLine("Registering event: " + command.Key);
                Register(command.Key, command.Value);
            }
        }

        /// <summary>
        /// Update client => will read on network and call each events
        /// </summary>
        public void Update()
        {
            eventProtocolClient.Update();
        }

        /// <summary>
        /// Tells if the client is still connected
        /// </summary>
        /// <returns>True if the client is connected, false either</returns>
        public bool isConnected()
        {
            return eventProtocolClient.isConnected();
        }

        /// <summary>
        /// Will call the callback with the input stream filled with data and send a reply event
        /// </summary>
        /// <remarks>Generic method to handle CoreCommand.Manager event with byte[]</remarks>
        /// <param name="data">Command body that correspond to consumer data</param>
        /// <param name="callback">Manager command to call</param>
        /// <param name="replyEventName">Name of the event to reply</param>
        private void HandleEvent(byte[] data, string command, string replyEventName)
        {
            MemoryStream inStream = new MemoryStream(data);
            MemoryStream outStream = new MemoryStream();

            Console.WriteLine("");

            Console.WriteLine("==Network.Receiving(" + command + ")==");
            if (commandManager.CallCommand(command, inStream, outStream))
            {
                eventProtocolClient.SendEvent(replyEventName, outStream.ToArray());
                Console.WriteLine("==Network.Replied(" + replyEventName + ")==");
            }
            else
            {
                Console.WriteLine("==Network.Error==");
                eventProtocolClient.SendEvent(command + ".ERROR", outStream.ToArray());
            }
        }

        private void Register(String command, String reply)
        {
            eventProtocolClient.RegisterEvent(command, (byte[] data) =>
            {
                HandleEvent(data, command, reply);
            }, 0);
        }
    }
}
