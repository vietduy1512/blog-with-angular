using Newtonsoft.Json;
using NTT_BlogEngine.BlogEngineHelpers;
using NTT_BlogEngine.DAL.Interfaces;
using NTT_BlogEngine.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace NTT_BlogEngine.Controllers
{
    [Authorize]
    [RoutePrefix("api/Posts")]
    public class PostsController : ApiController
    {
        private readonly IRepository repo;

        public PostsController(IRepository repo)
        {
            this.repo = repo;
        }


        [AllowAnonymous]
        [HttpGet, Route("List")]
        public IHttpActionResult GetPostsList(int page = 1)
        {
            if (page < 1)
            {
                return NotFound();
            }

            var skipAmmount = 5 * (page - 1);
            var takeAmmount = 5;
            var postList = repo.GetEntities<Post>()
                            .OrderByDescending(x => x.Date)
                            .Skip(skipAmmount)
                            .Take(takeAmmount)
                            .ToList();

            if (postList.Count == 0)
            {
                return NotFound();
            }
            return Ok(postList);
        }


        [AllowAnonymous]
        [HttpGet, Route("Recent")]
        public IHttpActionResult GetRecentPosts()
        {
            var postList = repo.GetEntities<Post>()
                            .OrderByDescending(x => x.Date)
                            .Take(5)
                            .ToList();

            if (postList.Count == 0)
            {
                return NotFound();
            }
            return Ok(postList);
        }


        [AllowAnonymous]
        [HttpGet, Route("Detail/{id}/{slug}")]
        public IHttpActionResult GetPostDetail(int? id, string slug)
        {
            Post post = repo.GetEntities<Post>().SingleOrDefault(x => x.Id == id && x.Slug.Equals(slug));

            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }


        [HttpPost, Route("Create")]
        public IHttpActionResult Create()
        {
            var request = HttpContext.Current.Request;
            var uploaded_image = request.Files["uploaded_image"];

            Post post = new Post();

            post.Title = request.Form["title"];
            post.Description = request.Form["description"];
            post.Content = request.Form["content"];

            if (User.Identity.IsAuthenticated)
            {
                post.AuthorId = User.Identity.GetUserId();  // Get User from Token
            }

            // Create additional data
            post.Slug = RegexHelper.CreateSlug(post.Title);
            post.Date = DateTime.Now;

            Validate(post);

            if (ModelState.IsValid)
            {
                if (uploaded_image != null)
                {
                    string pic = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(uploaded_image.FileName);
                    string path = System.IO.Path.Combine(
                        System.Web.HttpContext.Current.Server.MapPath(NTT_BlogEngine.DAL.Identifier.UploadedImagePath), pic);

                    post.ImagePath = NTT_BlogEngine.DAL.Identifier.UploadedImagePath + "/" + pic;

                    // File is Uploaded at 'path'
                    uploaded_image.SaveAs(path);
                }
                repo.Add<Post>(post);
                repo.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState);
        }


        [HttpDelete, Route("{id}/Delete")]
        public IHttpActionResult Delete(int id)
        {
            Post post = repo.GetEntities<Post>().SingleOrDefault(x => x.Id == id);

            if (post == null)
            {
                return NotFound();
            }
            repo.Remove(post);
            repo.SaveChanges();
            return Ok();
        }
    }
}
