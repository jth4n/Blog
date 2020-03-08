using System;
using System.Threading.Tasks;
using Blog.Frontend.Infrastructure;
using Blog.Frontend.Models;
using Blog.Frontend.Models.V1;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Frontend.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;
        private readonly ICommandHandler<CreatePostRequest> _createPostCreatePostCommandHandler;
        private readonly ICommandHandler<DeletePostRequest> _deletePostCommandHandler;

        public PostsController(IBlogRepository blogRepository, ICommandHandler<CreatePostRequest> createPostCommandHandler, ICommandHandler<DeletePostRequest> deletePostCommandHandler)
        {
            _blogRepository = blogRepository;
            _createPostCreatePostCommandHandler = createPostCommandHandler;
            _deletePostCommandHandler = deletePostCommandHandler;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreatePost([FromBody]CreatePostRequest request)
        {
            await _createPostCreatePostCommandHandler.Handle(request);
            return Ok();
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllPosts()
        {
            return Ok(await _blogRepository.GetAllPosts());
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeletePost([FromRoute]DeletePostRequest request)
        {
            await _deletePostCommandHandler.Handle(request);
            return Ok();
        }
    }
}