﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePackage.Entity.Type
{
    /// <summary>
    /// Represents a basic type
    /// </summary>
    public class ScalarType : DataType
    {
        /// <summary>
        /// Contains the real C# associated type
        /// </summary>
        private System.Type real_type;

        /// <summary>
        /// Constructor that asks for the real C# type
        /// </summary>
        /// <param name="real_type">Real C# type</param>
        public ScalarType(System.Type real_type)
        {
            this.real_type = real_type;
        }

        /// <see cref="DataType.Instanciate"/>
        public override dynamic Instanciate()
        {
            if (real_type == typeof(string))
                return "";
            return Activator.CreateInstance(real_type);
        }

        /// <see cref="Global.Definition.IsValid"/>
        public override bool IsValid()
        {
            return real_type != null;
        }

        /// <see cref="DataType.IsValueOfType(dynamic)"/>
        public override bool IsValueOfType(dynamic value)
        {
            return real_type == value.GetType();
        }
    }

    /// <summary>
    /// Static class that declares few basic types
    /// </summary>
    public static class Scalar
    {
        /// <summary>
        /// Represents a boolean type
        /// </summary>
        public static ScalarType Boolean = new ScalarType(typeof(bool));

        /// <summary>
        /// Represents an integer type
        /// </summary>
        public static ScalarType Integer = new ScalarType(typeof(int));

        /// <summary>
        /// Represents a floating type
        /// </summary>
        public static ScalarType Floating = new ScalarType(typeof(double));

        /// <summary>
        /// Represents a character type
        /// </summary>
        public static ScalarType Character = new ScalarType(typeof(char));

        /// <summary>
        /// Represents a string type
        /// </summary>
        public static ScalarType String = new ScalarType(typeof(string));
    }
}
