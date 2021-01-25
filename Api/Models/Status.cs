using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNet.Api.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public string Description { get; set; }
    }
}
