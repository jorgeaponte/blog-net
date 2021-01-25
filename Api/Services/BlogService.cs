using BlogNet.Api.Contracts;
using BlogNet.Api.DAL;
using BlogNet.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlogNet.Web.DTO;

namespace BlogNet.Api.Services
{
    public class BlogService: IBlogService
    {
        private readonly BlogContext _blogContext;
        public BlogService(BlogContext context) 
        {
            _blogContext = context;
        }

        public async Task<List<BlogPost>> GetAllAsync()
        {
            var posts = await _blogContext.BlogPosts.Select(p => new BlogPost
               {
                   PostId = p.PostId,
                   Title = p.Title,
                   Content = p.Content,
                   UserId = p.UserId,
                   Author = p.Author,
                   Reviewer = p.Reviewer,
                   Status = p.Status,
                   StatusId = p.StatusId,
                   ApprovalDate = p.ApprovalDate
               }).ToListAsync();
            return posts;
        }

        public async Task<List<BlogPost>> GetPendingAsync()
        {
            var posts = await _blogContext.BlogPosts.Where(p => p.StatusId == 1).Select(p => new BlogPost
            {
                PostId = p.PostId,
                Title = p.Title,
                Content = p.Content,
                UserId = p.UserId,
                Author = p.Author,
                Reviewer = p.Reviewer,
                Status = p.Status,
                StatusId = p.StatusId,
                ApprovalDate = p.ApprovalDate
            }).ToListAsync();   //ToDo: Mejorar esto del valor quemado (con un Enum)
            return posts;
        }
        public async Task<BlogPost> CreateAsync(BlogPost post)
        {
            var newPost = new BlogPost
            {
                Title = post.Title,
                Content = post.Content,
                UserId = 2,
                StatusId = 1
            };

            _blogContext.Add(newPost);
            await _blogContext.SaveChangesAsync();
            return post;
        }

        public async Task<BlogPost> UpdateAsync(BlogPost post)
        {
            var dbPost = _blogContext.BlogPosts.Find(post.PostId); 
            dbPost.Title = post.Title;
            dbPost.Content = post.Content;
            await _blogContext.SaveChangesAsync();            
            return dbPost;
        }

        public async Task<int> DeleteAsync(int postId)
        {
            var dbPost = _blogContext.BlogPosts.Find(postId);            
            _blogContext.Remove(dbPost);
            await _blogContext.SaveChangesAsync();
            return postId;
        }

        public async Task<BlogPost> ApproveReject(DTOPostStatus postStatus)
        {
            var dbPost = _blogContext.BlogPosts.Find(postStatus.PostId);
            dbPost.StatusId = postStatus.StatusId;            
            dbPost.ApprovalDate = DateTime.Now;
            await _blogContext.SaveChangesAsync();
            return dbPost;
        }

        public async Task<BlogPost> GetByIdAsync(int postId)        
        {
            
            var dbPost = await _blogContext.BlogPosts.Where(p => p.PostId == postId).Select(p => new BlogPost
            {
                PostId = p.PostId,
                Title = p.Title,
                Content = p.Content,
                UserId = p.UserId,
                Author = p.Author,
                Reviewer = p.Reviewer,
                Status = p.Status
            }).FirstOrDefaultAsync();

            return dbPost;
        }
        
    }
}
