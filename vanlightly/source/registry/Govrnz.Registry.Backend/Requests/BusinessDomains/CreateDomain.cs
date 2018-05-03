using ElCavernas.Govrnz.Registry.Backend.Responses;
using ElCavernas.Govrnz.Registry.Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElCavernas.Govrnz.Registry.Backend.Requests.BusinessDomains
{
    public class CreateDomain : IRequest<Response<CreateResult>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<CreateSubDomain> SubDomains { get; set; }
    }
}
