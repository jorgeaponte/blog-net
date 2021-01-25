using BlogNet.Api.Contracts;
using BlogNet.Api.DAL;
using BlogNet.Api.Models;
using BlogNet.Api.Services;
using BlogNet.Web.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogNet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService) {
            _blogService = blogService;
        }


        // GET: api/<BlogController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPost>>> Get() {
            //return _blogContext.Posts;

            var posts = await _blogService.GetAllAsync();
            return posts;
        }

        [HttpGet("GetPending")]
        public async Task<ActionResult<IEnumerable<BlogPost>>> GetPending()
        {
            //return _blogContext.Posts;

            var posts = await _blogService.GetPendingAsync();
            return posts;
        }

        // GET api/<BlogController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPost>> Get(int id) {
            var blogPost = await _blogService.GetByIdAsync(id);
            return blogPost;
        }

        // POST api/<BlogController>
        [HttpPost]
        public async Task<BlogPost> Post([FromBody] BlogPost post) {
            var newPost = await _blogService.CreateAsync(post);
            return newPost;
        }

        // PUT api/<BlogController>
        [HttpPut()]
        public async Task<BlogPost> Put([FromBody] BlogPost post) {
            var updatedPost = await _blogService.UpdateAsync(post);
            return updatedPost;

        }

        // PUT api/<BlogController>
        [HttpPut("{id}")]
        public async Task<BlogPost> Put(int id, DTOPostStatus postStatus)
        {
            var updatedPost = await _blogService.ApproveReject(postStatus);
            return updatedPost;

        }

        // DELETE api/<BlogController>/5
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id) {
            int deteledId = await _blogService.DeleteAsync(id);
            return deteledId;
        }
    }
}
