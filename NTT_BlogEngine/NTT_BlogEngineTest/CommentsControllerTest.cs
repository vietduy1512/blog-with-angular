using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using NTT_BlogEngine.Controllers;
using NTT_BlogEngine.DAL;
using NTT_BlogEngine.DAL.Data;
using NTT_BlogEngine.DAL.Model;
using Xunit;
using Moq;
using System.Net.Http;
using System.Web.Http.Routing;

namespace NTT_BlogEngineTest
{
    public class CommentsControllerTest
    {
        [Theory]
        [InlineData(13)]
        [InlineData(33)]
        [InlineData(34)]
        public void GetCommentsList_Valid(int postId)
        {
            // Arrange
            var repo = new EntityRepository(new TestStoreDbContext());
            CommentsController commentsController = new CommentsController(repo);

            // Act
            IHttpActionResult actionResult = commentsController.GetCommentsList(postId);
            var contentResult = actionResult as OkNegotiatedContentResult<List<Comment>>;
            
            // Assert
            Assert.IsType<OkNegotiatedContentResult<List<Comment>>>(actionResult);
            Assert.NotNull(contentResult.Content[0].Content);
            Assert.NotNull(contentResult.Content[0].Date);
            Assert.NotNull(contentResult.Content[0].PostId);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(99)]
        public void GetCommentsList_NotFound(int postId)
        {
            // Arrange
            var repo = new EntityRepository(new TestStoreDbContext());
            CommentsController commentsController = new CommentsController(repo);

            // Act
            IHttpActionResult actionResult = commentsController.GetCommentsList(postId);

            // Assert
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public void GetRecentComments_Valid()
        {
            // Arrange
            var repo = new EntityRepository(new TestStoreDbContext());
            CommentsController commentsController = new CommentsController(repo);

            // Act
            IHttpActionResult actionResult = commentsController.GetRecentComments();
            var contentResult = actionResult as OkNegotiatedContentResult<List<Comment>>;

            // Assert
            Assert.IsType<OkNegotiatedContentResult<List<Comment>>>(actionResult);
            Assert.Equal(contentResult.Content.Count, 5);
            Assert.NotNull(contentResult.Content[0].Content);
            Assert.NotNull(contentResult.Content[0].Date);
            Assert.NotNull(contentResult.Content[0].PostId);
        }

        [Fact]
        public void Create_Valid()
        {
            // Arrange
            var repo = new EntityRepository(new TestStoreDbContext());
            CommentsController commentsController = new CommentsController(repo);

            Comment comment = new Comment
            {
                Content = "hello world",
                UserId = "a9fcef18-356f-4aec-9c89-e468d7ca940b",
                PostId = 13
            };

            // Act
            commentsController.Request = new HttpRequestMessage();
            commentsController.Request.Properties["MS_HttpConfiguration"] = new HttpConfiguration();

            IHttpActionResult actionResult = commentsController.Create(comment);

            // Assert
            Assert.IsType<OkResult>(actionResult);
        }

        [Fact]
        public void Create_BadRequest()
        {
            // Arrange
            var repo = new EntityRepository(new TestStoreDbContext());
            CommentsController commentsController = new CommentsController(repo);

            Comment comment = new Comment
            {
                PostId = 13
            };

            // Act
            commentsController.Request = new HttpRequestMessage();
            commentsController.Request.Properties["MS_HttpConfiguration"] = new HttpConfiguration();

            IHttpActionResult actionResult = commentsController.Create(comment);

            // Assert
            Assert.IsType<InvalidModelStateResult>(actionResult);
        }
    }
}
