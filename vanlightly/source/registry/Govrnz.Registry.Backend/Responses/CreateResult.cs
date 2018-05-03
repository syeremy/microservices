using System;
using System.Collections.Generic;
using System.Text;

namespace ElCavernas.Govrnz.Registry.Backend.Responses
{
    public enum CreateResult
    {
        Created,
        NotCreated,
        DependentObjectNotFound
    }
}
