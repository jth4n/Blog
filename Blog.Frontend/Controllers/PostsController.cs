using System;
using System.Threading.Tasks;
using Blog.Domain.Commands;
using Blog.Domain.Interfaces;
using Blog.Frontend.Data;
using Blog.Frontend.Models;
using Blog.Frontend.Models.V1;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Frontend.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;
        private readonly ICommandHandler<CreatePostCommand> _createPostCreatePostCommandHandler;
        private readonly ICommandHandler<DeletePostCommand> _deletePostCommandHandler;

        public PostsController(IBlogRepository blogRepository, 
            ICommandHandler<CreatePostCommand> createPostCommandHandler, 
            ICommandHandler<DeletePostCommand> deletePostCommandHandler)
        {
            _blogRepository = blogRepository;
            _createPostCreatePostCommandHandler = createPostCommandHandler;
            _deletePostCommandHandler = deletePostCommandHandler;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreatePost([FromBody]CreatePostRequest request)
        {
            await _createPostCreatePostCommandHandler.Handle(new CreatePostCommand(request.Title, request.Content, request.Tags));
            return Ok();
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllPosts()
        {
            return Ok(await _blogRepository.GetAllPosts());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetPost(Guid id)
        {
            return Ok(await _blogRepository.GetPost(id));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeletePost([FromRoute]DeletePostRequest request)
        {
            await _deletePostCommandHandler.Handle(new DeletePostCommand(request.Id));
            return Ok();
        }
    }
}