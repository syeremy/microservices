using ElCavernas.Govrnz.Registry.Backend.Responses;
using ElCavernas.Govrnz.Registry.Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElCavernas.Govrnz.Registry.Backend.Requests.BusinessDomains
{
    public class DeleteDomain : IRequest<Response<DeleteResult>>
    {
        public string Name { get; set; }
    }
}
