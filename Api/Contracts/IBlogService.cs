using BlogNet.Api.Models;
using BlogNet.Web.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNet.Api.Contracts
{
    public interface IBlogService
    {
        Task<List<BlogPost>> GetAllAsync();
        Task<BlogPost> CreateAsync(BlogPost post);
        Task<BlogPost> UpdateAsync(BlogPost post);
        Task<int> DeleteAsync(int postid);
        Task<BlogPost> ApproveReject(DTOPostStatus postStatus);                
        Task<BlogPost> GetByIdAsync(int postId);
        /*
        Task<Post> AddCommentAsync(Post post);
        
        */
    }
}
