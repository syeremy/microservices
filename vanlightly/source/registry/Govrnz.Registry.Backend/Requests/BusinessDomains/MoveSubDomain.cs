using ElCavernas.Govrnz.Registry.Backend.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElCavernas.Govrnz.Registry.Backend.Requests.BusinessDomains
{
    public class MoveSubDomain : IRequest<Response<MoveResult>>
    {
        public string SubDomainName { get; set; }
        public string DestinationDomainName { get; set; }
    }
}
