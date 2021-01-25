using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNet.Api.Models
{
    public class BlogPost
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }        
        public string Content { get; set; }
        public int UserId { get; set; }
        public int? ReviewerId { get; set; }
        public int StatusId { get; set; }
        //ToDo: Otro enfoque es con DTOs
        public User Author  { get; set; }
        public User Reviewer { get; set; }
        public Status Status { get; set; }

    }
}
