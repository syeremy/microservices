using System;
using System.Collections.Generic;
using System.Text;

namespace ElCavernas.Govrnz.Registry.Backend.Responses
{
    public class Response<T>
    {
        public Response(T result)
        {
            Result = result;
        }

        public Response(T result, string description)
        {
            Result = result;
            Description = description;
        }

        public T Result { get; set; }
        public string Description { get; set; }
    }
}
