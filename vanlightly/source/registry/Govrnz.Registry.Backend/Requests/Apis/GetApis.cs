using ElCavernas.Govrnz.Registry.Backend.Responses;
using ElCavernas.Govrnz.Registry.Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElCavernas.Govrnz.Registry.Backend.Requests.Apis
{
    public class GetApis : IRequest<Response<IEnumerable<Api>>>
    {
        public string ApiName { get; set; }
    }
}
