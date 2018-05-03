using ElCavernas.Govrnz.Registry.Backend.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElCavernas.Govrnz.Registry.Backend.Requests.Tags
{
    public class ChangeTagName : IRequest<Response<UpdateResult>>
    {
        public string TagName { get; set; }

        public string NewTagName { get; set; }
    }
}
