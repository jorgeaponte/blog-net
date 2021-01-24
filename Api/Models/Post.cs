using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNet.Api.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }        
        public string Content { get; set; }
        public int UserId { get; set; }
        public int? ApproverId { get; set; }
        public User Author  { get; set; }
        public User Approver { get; set; }
    }
}
