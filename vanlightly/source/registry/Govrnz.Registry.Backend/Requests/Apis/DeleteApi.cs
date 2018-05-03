using ElCavernas.Govrnz.Registry.Backend.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElCavernas.Govrnz.Registry.Backend.Requests.Apis
{
    public class DeleteApi : IRequest<Response<DeleteResult>>
    {
        public DeleteApi()
        {
            RequestId = Guid.NewGuid();
        }

        public Guid RequestId { get; private set; }
        public string ApiName { get; set; }
    }
}
