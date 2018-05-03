﻿using ElCavernas.Govrnz.Registry.Backend.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElCavernas.Govrnz.Registry.Backend.Requests.BusinessDomains
{
    public class CreateSubDomain : IRequest<Response<CreateResult>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ParentDomainName { get; set; }
    }
}
