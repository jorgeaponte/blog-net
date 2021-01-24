using BlogNet.Api.Contracts;
using BlogNet.Api.DAL;
using BlogNet.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlogNet.Api.Services
{
    public class BlogService: IBlogService
    {
        private readonly BlogContext _blogContext;
        public BlogService(BlogContext context) 
        {
            _blogContext = context;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            /*
            var posts = await _blogContext.Posts.ToListAsync();
            return posts;
            */
            var posts = await _blogContext.Posts.Select(p => new Post
               {
                   PostId = p.PostId,
                   Title = p.Title,
                   Content = p.Content,
                   UserId = p.UserId,
                   Author = p.Author 
               }).ToListAsync();
            return posts;


            /*
             var result = employees.Where(e => e.Id == id).Select(e => new Employee
            {
                Id = e.Id,
                Projects = e.Projects.SingleOrDefault(p => p.Key == projectKey)
            }).SingleOrDefault();
             */
        }
        //Task<Post> GetByIdAsync(int postId);
    }
}
