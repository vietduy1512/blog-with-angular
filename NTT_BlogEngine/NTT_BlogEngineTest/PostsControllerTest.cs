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
    public class PostsControllerTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetPostsList_Valid(int page)
        {
            // Arrange
            var repo = new EntityRepository(new TestStoreDbContext());
            PostsController postsController = new PostsController(repo);

            // Act
            IHttpActionResult actionResult = postsController.GetPostsList(page);
            var contentResult = actionResult as OkNegotiatedContentResult<List<Post>>;
            
            // Assert
            Assert.IsType<OkNegotiatedContentResult<List<Post>>>(actionResult);
            Assert.Equal(contentResult.Content.Count, 5);
            Assert.NotNull(contentResult.Content[0].Title);
            Assert.NotNull(contentResult.Content[0].Description);
            Assert.NotNull(contentResult.Content[0].ImagePath);
            Assert.NotNull(contentResult.Content[0].Date);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(99)]
        public void GetPostsList_NotFound(int page)
        {
            // Arrange
            var repo = new EntityRepository(new TestStoreDbContext());
            PostsController postsController = new PostsController(repo);

            // Act
            IHttpActionResult actionResult = postsController.GetPostsList(page);

            // Assert
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Theory]
        [InlineData(13, "Phan-da-bun-co-nien-dai-len-den-3-ty-nam-tuoi-o-mieng-nui-lua-Gale-sao-Hoa")]
        [InlineData(33, "Khoang-hanh-ly-tren-xe-hoi-co-may-de-o-giua")]
        [InlineData(34, "Tim-duoc-bang-chung-cho-thay-tung-co-su-song-tren-sao-Hoa")]
        public void GetPostDetail_Valid(int id, string slug)
        {
            // Arrange
            var repo = new EntityRepository(new TestStoreDbContext());
            PostsController postsController = new PostsController(repo);

            // Act
            IHttpActionResult actionResult = postsController.GetPostDetail(id, slug);
            var contentResult = actionResult as OkNegotiatedContentResult<Post>;

            // Assert
            Assert.IsType<OkNegotiatedContentResult<Post>>(actionResult);
            Assert.NotNull(contentResult.Content.Title);
            Assert.NotNull(contentResult.Content.Description);
            Assert.NotNull(contentResult.Content.Content);
            Assert.NotNull(contentResult.Content.Slug);
            Assert.NotNull(contentResult.Content.ImagePath);
            Assert.NotNull(contentResult.Content.Date);
        }

        [Theory]
        [InlineData(13, "")]
        [InlineData(33, "")]
        [InlineData(34, "")]
        public void GetPostDetail_NotFound(int id, string slug)
        {
            // Arrange
            var repo = new EntityRepository(new TestStoreDbContext());
            PostsController postsController = new PostsController(repo);

            // Act
            IHttpActionResult actionResult = postsController.GetPostDetail(id, slug);

            // Assert
            Assert.IsType<NotFoundResult>(actionResult);
        }

        // TODO:
        /*
        [Fact]
        public void Create_IsSuccess(int id, string slug)
        {
            // Arrange
            var repo = new EntityRepository(new TestStoreDbContext());
            PostsController postsController = new PostsController(repo);

            
            
            // Act
            IHttpActionResult actionResult = postsController.GetPostDetail(id, slug);

            // Assert
            Assert.IsType<NotFoundResult>(actionResult);
        }
        */

        [Theory]
        [InlineData(13)]
        [InlineData(33)]
        public void Delete_Success(int id)
        {
            // Arrange
            var repo = new EntityRepository(new TestStoreDbContext());
            PostsController postsController = new PostsController(repo);

            // Act
            IHttpActionResult actionResult = postsController.Delete(id);

            // Assert
            Assert.IsType<OkResult>(actionResult);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(99)]
        public void Delete_NotFound(int id)
        {
            // Arrange
            var repo = new EntityRepository(new TestStoreDbContext());
            PostsController postsController = new PostsController(repo);

            // Act
            IHttpActionResult actionResult = postsController.Delete(id);

            // Assert
            Assert.IsType<NotFoundResult>(actionResult);
        }
    }
}
