using System.Threading.Tasks;
using Blog.Domain;
using Blog.Domain.Commands;
using Blog.Domain.Interfaces;

namespace Blog.Services.CommandHandlers
{
    public class PostCommandHandler : ICommandHandler<CreatePostCommand>, ICommandHandler<DeletePostCommand>
    {
        private readonly IBlogRepository _blogRepository;

        public PostCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task Handle(CreatePostCommand cmd)
        {
            var post = Post.Create(cmd.Title, cmd.Content, "Jonathan", cmd.Tags);
            await _blogRepository.Save(post);
        }

        public async Task Handle(DeletePostCommand cmd)
        {
            await _blogRepository.Delete(cmd.Id);
        }
    }
}