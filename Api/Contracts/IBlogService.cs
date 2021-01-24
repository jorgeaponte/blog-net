using BlogNet.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNet.Api.Contracts
{
    public interface IBlogService
    {
        Task<List<Post>> GetAllAsync();
        /*
        Task<Post> GetByIdAsync(int postId);
        Task<Post> CreateAsync(Post post);
        Task<Post> UpdateAsync(Post post);
        Task<Post> AddCommentAsync(Post post);
        */
    }
}
