using System;

namespace AnimalRescue.Exceptions
{
    public class ExistUserExeption : Exception
    {
        public ExistUserExeption(string message)
                                       : base(message)
        {
        }
    }
}
