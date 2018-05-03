using System;
using System.Collections.Generic;
using System.Text;

namespace ElCavernas.Govrnz.Registry.Backend.Responses
{
    public class GetResponse<T>
    {
        public GetResult Result { get; set; }
        public T Data { get; set; }
    }

    public enum GetResult
    {
        NotFound,
        Retrieved
    }
}
