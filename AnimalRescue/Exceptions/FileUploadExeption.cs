using System;

namespace AnimalRescue.Exceptions
{
    public class FileUploadExeption: Exception
    {
        public FileUploadExeption(string message)
                                        :base(message)
        {

        }
    }
}
