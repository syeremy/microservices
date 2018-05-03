using ElCavernas.Govrnz.Registry.Backend.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElCavernas.Govrnz.Registry.Backend.Requests.Tags
{
    public class DeleteTag : IRequest<Response<DeleteResult>>
    {
        public string TagName { get; set; }
        public string ApiName { get; set; }
        public bool ForceDelete { get; set; }
    }
}
