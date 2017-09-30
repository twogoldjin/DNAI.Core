﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePackage.Entity.Type
{
    /// <summary>
    /// This class represents an enumeration type used
    /// </summary>
    public class EnumType : DataType
    {
        /// <summary>
        /// Contains enumeration values which are variable declarations
        /// Those variables can be of any type
        /// </summary>
        private Dictionary<string, Global.Declaration<Variable>> values = new Dictionary<string, Global.Declaration<Variable>>();

        /// <summary>
        /// Contains the type of the variables stored in the enumeration
        /// </summary>
        private DataType stored;

        /// <summary>
        /// Constructor that forces to given the enumeration values' type
        /// </summary>
        /// <param name="stored">Type of the stored enumeration values</param>
        public EnumType(DataType stored)
        {
            this.stored = stored;
        }

        /// <summary>
        /// Allow to add a value to the enumeration
        /// </summary>
        /// <param name="name">Represents the name of the value</param>
        /// <param name="definition">Represents the variable definition of the value</param>
        public void AddValue(string name, Entity.Variable definition)
        {
            //check given definition validity
            this.values[name] = new Global.Declaration<Variable> { name = name, definition = definition };
        }

        /// <see cref="DataType.Instanciate"/>
        public override dynamic Instanciate()
        {
            throw new NotImplementedException();
        }

        /// <see cref="Global.Definition.IsValid"/>
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }

        /// <see cref="DataType.IsValueOfType(dynamic)"/>
        public override bool IsValueOfType(dynamic value)
        {
            throw new NotImplementedException();
        }
    }
}