using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNet.Web.Models
{
    public class User
    {       
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Rol { get; set; }

    }
}
