﻿using CorePackage.Entity;
using CorePackage.Entity.Type;
using CorePackage.Execution;
using CorePackage.Execution.Operators;
using CorePackage.Global;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreControl
{
    /// <summary>
    /// Class that is used to instanciate instructions
    /// </summary>
    public static class InstructionFactory
    {
        /// <summary>
        /// Enumeration for each possible instruction
        /// </summary>
        public enum INSTRUCTION_ID
        {
            AND,
            OR,
            DIFFERENT,
            EQUAL,
            GREATER,
            GREATER_EQUAL,
            LOWER,
            LOWER_EQUAL,
            ACCESS,
            BINARY_AND,
            BINARY_OR,
            XOR,
            ADD,
            SUB,
            DIV,
            MUL,
            MOD,
            LEFT_SHIFT,
            RIGHT_SHIFT,
            BINARY_NOT,
            NOT,
            INVERSE,
            ENUM_SPLITTER,
            GETTER,
            SETTER,
            FUNCTION_CALL,
            IF,
            WHILE,
            APPEND, //ICI
            INSERT,
            REMOVE,
            REMOVE_INDEX,
            SIZE,
            FOREACH,
            GET_ATTRIBUTES,
            SET_ATTRIBUTES
        };

        /// <summary>
        /// Dictionary that associates an instruction to the number of arguments that takes its constructor
        /// </summary>
        private static readonly Dictionary<INSTRUCTION_ID, uint> number_of_arguments = new Dictionary<INSTRUCTION_ID, uint>
        {
            { INSTRUCTION_ID.AND, 0 },
            { INSTRUCTION_ID.OR, 0 },
            { INSTRUCTION_ID.DIFFERENT, 2 },
            { INSTRUCTION_ID.EQUAL, 2 },
            { INSTRUCTION_ID.GREATER, 2 },
            { INSTRUCTION_ID.GREATER_EQUAL, 2 },
            { INSTRUCTION_ID.LOWER, 2 },
            { INSTRUCTION_ID.LOWER_EQUAL, 2 },
            { INSTRUCTION_ID.ACCESS, 3 },
            { INSTRUCTION_ID.BINARY_AND, 3 },
            { INSTRUCTION_ID.BINARY_OR, 3 },
            { INSTRUCTION_ID.XOR, 3 },
            { INSTRUCTION_ID.ADD, 3 },
            { INSTRUCTION_ID.SUB, 3 },
            { INSTRUCTION_ID.DIV, 3 },
            { INSTRUCTION_ID.MUL, 3 },
            { INSTRUCTION_ID.MOD, 3 },
            { INSTRUCTION_ID.LEFT_SHIFT, 3 },
            { INSTRUCTION_ID.RIGHT_SHIFT, 3 },
            { INSTRUCTION_ID.BINARY_NOT, 2 },
            { INSTRUCTION_ID.NOT, 1 },
            { INSTRUCTION_ID.INVERSE, 2 },
            { INSTRUCTION_ID.ENUM_SPLITTER, 1 },
            { INSTRUCTION_ID.GETTER, 1 },
            { INSTRUCTION_ID.SETTER, 1 },
            { INSTRUCTION_ID.FUNCTION_CALL, 1 },
            { INSTRUCTION_ID.IF, 0 },
            { INSTRUCTION_ID.WHILE, 0 },
            { INSTRUCTION_ID.APPEND, 0 },
            { INSTRUCTION_ID.INSERT, 0 },
            { INSTRUCTION_ID.REMOVE, 0 },
            { INSTRUCTION_ID.REMOVE_INDEX, 0 },
            { INSTRUCTION_ID.SIZE, 0 },
            { INSTRUCTION_ID.FOREACH, 1 },
            { INSTRUCTION_ID.GET_ATTRIBUTES, 1 },
            { INSTRUCTION_ID.SET_ATTRIBUTES, 1 }
        };

        /// <summary>
        /// Dictionary that associates an instruction to its creator delegate
        /// </summary>
        private static readonly Dictionary<INSTRUCTION_ID, Func<List<IDefinition>, Instruction>> creators = new Dictionary<INSTRUCTION_ID, Func<List<CorePackage.Global.IDefinition>, CorePackage.Execution.Instruction>>
        {
            {
                INSTRUCTION_ID.AND, (List<IDefinition> arguments) =>
                {
                    return new And();
                }
            },
            { INSTRUCTION_ID.OR, (List<IDefinition> arguments) =>
                {
                    return new Or();
                }
            },
            { INSTRUCTION_ID.DIFFERENT, (List<IDefinition> arguments) =>
                {
                    return new Different(
                        (DataType)arguments.ElementAt(0),
                        (DataType)arguments.ElementAt(1));
                }
            },
            { INSTRUCTION_ID.EQUAL, (List<IDefinition> arguments) =>
                {
                    return new Equal(
                        (DataType)arguments.ElementAt(0),
                        (DataType)arguments.ElementAt(1));
                }
            },
            { INSTRUCTION_ID.GREATER, (List<IDefinition> arguments) =>
                {
                    return new Greater(
                        (DataType)arguments.ElementAt(0),
                        (DataType)arguments.ElementAt(1));
                }
            },
            { INSTRUCTION_ID.GREATER_EQUAL, (List<IDefinition> arguments) =>
                {
                    return new GreaterEqual(
                        (DataType)arguments.ElementAt(0),
                        (DataType)arguments.ElementAt(1));
                }
            },
            { INSTRUCTION_ID.LOWER, (List<IDefinition> arguments) =>
                {
                    return new Less(
                        (DataType)arguments.ElementAt(0),
                        (DataType)arguments.ElementAt(1));
                }
            },
            { INSTRUCTION_ID.LOWER_EQUAL, (List<IDefinition> arguments) =>
                {
                    return new LessEqual(
                        (DataType)arguments.ElementAt(0),
                        (DataType)arguments.ElementAt(1));
                } },
            { INSTRUCTION_ID.ACCESS, (List<IDefinition> arguments) =>
                {
                    return new Access(
                        (DataType)arguments.ElementAt(0),
                        (DataType)arguments.ElementAt(1),
                        (DataType)arguments.ElementAt(2));
                }
            },
            { INSTRUCTION_ID.BINARY_AND, (List<IDefinition> arguments) =>
                {
                    return new BinaryAnd(
                        (DataType)arguments.ElementAt(0),
                        (DataType)arguments.ElementAt(1),
                        (DataType)arguments.ElementAt(2));
                }
            },
            { INSTRUCTION_ID.BINARY_OR, (List<IDefinition> arguments) =>
                {
                    return new BinaryOr(
                        (DataType)arguments.ElementAt(0),
                        (DataType)arguments.ElementAt(1),
                        (DataType)arguments.ElementAt(2));
                }
            },
            { INSTRUCTION_ID.XOR, (List<IDefinition> arguments) =>
                {
                    return new Xor(
                        (DataType)arguments.ElementAt(0),
                        (DataType)arguments.ElementAt(1),
                        (DataType)arguments.ElementAt(2));
                }
            },
            { INSTRUCTION_ID.ADD, (List<IDefinition> arguments) =>
                {
                    return new Add(
                        (DataType)arguments.ElementAt(0),
                        (DataType)arguments.ElementAt(1),
                        (DataType)arguments.ElementAt(2));
                }
            },
            { INSTRUCTION_ID.SUB, (List<IDefinition> arguments) =>
                {
                    return new Substract(
                        (DataType)arguments.ElementAt(0),
                        (DataType)arguments.ElementAt(1),
                        (DataType)arguments.ElementAt(2));
                }
            },
            { INSTRUCTION_ID.DIV, (List<IDefinition> arguments) =>
                {
                    return new Divide(
                        (DataType)arguments.ElementAt(0),
                        (DataType)arguments.ElementAt(1),
                        (DataType)arguments.ElementAt(2));
                }
            },
            { INSTRUCTION_ID.MUL, (List<IDefinition> arguments) =>
                {
                    return new Multiplicate(
                        (DataType)arguments.ElementAt(0),
                        (DataType)arguments.ElementAt(1),
                        (DataType)arguments.ElementAt(2));
                }
            },
            { INSTRUCTION_ID.MOD, (List<IDefinition> arguments) =>
                {
                    return new Modulo(
                        (DataType)arguments.ElementAt(0),
                        (DataType)arguments.ElementAt(1),
                        (DataType)arguments.ElementAt(2));
                }
            },
            { INSTRUCTION_ID.LEFT_SHIFT, (List<IDefinition> arguments) =>
                {
                    return new LeftShift(
                        (DataType)arguments.ElementAt(0),
                        (DataType)arguments.ElementAt(1),
                        (DataType)arguments.ElementAt(2));
                }
            },
            { INSTRUCTION_ID.RIGHT_SHIFT, (List<IDefinition> arguments) =>
                {
                    return new RightShift(
                        (DataType)arguments.ElementAt(0),
                        (DataType)arguments.ElementAt(1),
                        (DataType)arguments.ElementAt(2));
                }
            },
            { INSTRUCTION_ID.BINARY_NOT, (List<IDefinition> arguments) =>
                {
                    return new BinaryNot(
                        (DataType)arguments.ElementAt(0),
                        (DataType)arguments.ElementAt(1));
                }
            },
            { INSTRUCTION_ID.NOT, (List<IDefinition> arguments) =>
                {
                    return new Not((DataType)arguments.ElementAt(0));
                }
            },
            { INSTRUCTION_ID.INVERSE, (List<IDefinition> arguments) =>
                {
                    return new Inverse(
                        (DataType)arguments.ElementAt(0),
                        (DataType)arguments.ElementAt(1));
                }
            },
            { INSTRUCTION_ID.ENUM_SPLITTER, (List<IDefinition> arguments) =>
                {
                    return new EnumSplitter((EnumType)arguments.ElementAt(0));
                }
            },
            { INSTRUCTION_ID.GETTER, (List<IDefinition> arguments) =>
                {
                    return new Getter((Variable)arguments.ElementAt(0));
                }
            },
            { INSTRUCTION_ID.SETTER, (List<IDefinition> arguments) =>
                {
                    return new Setter((Variable)arguments.ElementAt(0));
                }
            },
            { INSTRUCTION_ID.FUNCTION_CALL, (List<IDefinition> arguments) =>
                {
                    return new FunctionCall((Function)arguments.ElementAt(0));
                }
            },
            { INSTRUCTION_ID.IF, (List<IDefinition> arguments) =>
                {
                    return new If();
                }
            },
            {
                INSTRUCTION_ID.WHILE, (List<IDefinition> arguments) =>
                {
                    return new While();
                }
            },
            {
                INSTRUCTION_ID.APPEND, (List<IDefinition> args) =>
                {
                    return new Append();
                }
            },
            {
                INSTRUCTION_ID.INSERT, (List<IDefinition> args) =>
                {
                    return new Insert();
                }
            },
            {
                INSTRUCTION_ID.REMOVE, (List<IDefinition> args) =>
                {
                    return new Remove();
                }
            },
            {
                INSTRUCTION_ID.REMOVE_INDEX, (List<IDefinition> args) =>
                {
                    return new RemoveIndex();
                }
            },
            {
                INSTRUCTION_ID.SIZE, (List<IDefinition> args) =>
                {
                    return new Size();
                }
            },
            {
                INSTRUCTION_ID.FOREACH, (List<IDefinition> args) =>
                {
                    return new Foreach((DataType)args[0]);
                }
            },
            {
                INSTRUCTION_ID.OBJECT_ATTRIBUTES, (List<IDefinition> args) =>
                {
                    return new GetAttributes((ObjectType)(args[0]));
                }
            },
            {
                INSTRUCTION_ID.SET_ATTRIBUTES, (List<Definition> args) =>
                {
                    return new SetAttribute((Variable)args[0]);
                }
            }
        };

        /// <summary>
        /// Create an instruction from an id and a list of arguments
        /// </summary>
        /// <param name="to_create">Type of the instruction to create</param>
        /// <param name="arguments">List of arguments to pass to the instruction at construction</param>
        /// <returns>An instruction of type represented by the give id</returns>
        public static Instruction CreateInstruction(INSTRUCTION_ID to_create, List<IDefinition> arguments)
        {
            if (!number_of_arguments.ContainsKey(to_create) || !creators.ContainsKey(to_create))
                throw new KeyNotFoundException("Given instruction isn't referenced in factory");
            if (arguments.Count < number_of_arguments[to_create])
                throw new InvalidProgramException("Not enought arguments to construct intruction");
            return creators[to_create](arguments);
        }
    }
}