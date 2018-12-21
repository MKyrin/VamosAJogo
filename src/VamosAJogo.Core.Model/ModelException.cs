using System;

namespace VamosAJogo.Core.Model
{
    public class ModelException : ArgumentException
    {
        public ModelException(string message) : base(message)
        {

        }
        public ModelException(string message, string paramName) : base(message, paramName)
        {

        }
    }
}
