using BlogNet.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using BlogNet.Web.DTO;

namespace BlogNet.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string apiUrl = "https://localhost:44314/api";

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;            
        }

        public async Task<IActionResult> Index() {
            
            List<BlogPost> posts = new List<BlogPost>();
            using (var httpClient = new HttpClient()) {
                using (var response = await httpClient.GetAsync($"{apiUrl}/blog")) {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    posts = JsonConvert.DeserializeObject<List<BlogPost>>(apiResponse);
                }
            }
            return View(posts);
        }

        public ViewResult AddPost() => View();

        [HttpPost]
        public async Task<IActionResult> AddPost(BlogPost post)
        {
            BlogPost createdPost = new BlogPost();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync($"{apiUrl}/blog", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    createdPost = JsonConvert.DeserializeObject<BlogPost>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdatePost(int postId)
        {
            BlogPost blogPost = new BlogPost();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{apiUrl}/blog/{postId}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    blogPost = JsonConvert.DeserializeObject<BlogPost>(apiResponse);
                }
            }
            return View(blogPost);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePost(BlogPost post)
        {
            BlogPost updatedPost = new BlogPost();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync($"{apiUrl}/blog", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    updatedPost = JsonConvert.DeserializeObject<BlogPost>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }        
        public async Task<IActionResult> ApproveRejectPost(int postId, int statusId)
        {
            var postStatus = new PostStatus {
                PostId = postId,
                StatusId = statusId
            };
            BlogPost updatedPost = new BlogPost();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(postStatus), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync($"{apiUrl}/blog/{postId}", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    updatedPost = JsonConvert.DeserializeObject<BlogPost>(apiResponse);
                }
            }            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int postId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync($"{apiUrl}/blog/{postId}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
