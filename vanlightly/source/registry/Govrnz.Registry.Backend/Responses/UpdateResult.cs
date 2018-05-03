using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElCavernas.Govrnz.Registry.Backend.Responses
{
    public enum UpdateResult
    {
        NotFound,
        Updated,
        NotUpdated,
        Inserted
    }
}
