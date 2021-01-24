using BlogNet.Api.Contracts;
using BlogNet.Api.DAL;
using BlogNet.Api.Models;
using BlogNet.Api.Services;
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
        public async Task<ActionResult<IEnumerable<Post>>> Get() {
            //return new string[] { "value1", "value2" };
            //return _blogContext.Posts;
            
            var posts = await _blogService.GetAllAsync();
            return posts;
        }

        // GET api/<BlogController>/5
        [HttpGet("{id}")]
        public ActionResult<Post> Get(int id) {
            //return _blogContext.Posts.FirstOrDefault(e => e.PostId == id);
            return null;
        }

        // POST api/<BlogController>
        [HttpPost]
        public void Post([FromBody] Post value) {
            //_blogContext.Posts.Add(value);
            //_blogContext.SaveChanges();
        }

        // PUT api/<BlogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<BlogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
