﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNet.Web.DTO
{
    public class DTOPostStatus
    {
        public int PostId { get; set; }        
        public int StatusId { get; set; }
        public int Reviewer { get; set; }
    }
}
