using Newtonsoft.Json;
using NTT_BlogEngine.DAL.Interfaces;
using NTT_BlogEngine.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace NTT_BlogEngine.Controllers
{
    [Authorize]
    [RoutePrefix("api/Comments")]
    public class CommentsController : ApiController
    {
        private readonly IRepository repo;

        public CommentsController(IRepository repo)
        {
            this.repo = repo;
        }


        [AllowAnonymous]
        [HttpGet, Route("List")]
        public IHttpActionResult GetCommentsList(int postId)
        {
            var commentList = repo.GetEntities<Comment>()
                                .Where(x => x.PostId == postId)
                                .OrderByDescending(x => x.Date)
                                .ToList();

            if (commentList.Count == 0)
            {
                return NotFound();
            }
            return Ok(commentList);
        }


        [AllowAnonymous]
        [HttpGet, Route("Recent")]
        public IHttpActionResult GetRecentComments()
        {
            var commentList = repo.GetEntities<Comment>()
                                .OrderByDescending(x => x.Date)
                                .Take(5)
                                .ToList();

            if (commentList.Count == 0)
            {
                return NotFound();
            }
            return Ok(commentList);
        }


        [HttpPost, Route("Create")]
        public IHttpActionResult Create(Comment comment)
        {
            if (User.Identity.IsAuthenticated)
            {
                comment.UserId = User.Identity.GetUserId();  // Get User from Token
            }
            Validate(comment);

            if (ModelState.IsValid)
            {
                comment.Date = DateTime.Now;
                repo.Add<Comment>(comment);
                repo.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
