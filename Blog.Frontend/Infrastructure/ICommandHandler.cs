using System.Threading.Tasks;
using Blog.Domain;
using Blog.Frontend.Models.V1;

namespace Blog.Frontend.Infrastructure
{
    public interface ICommandHandler<in T> where T: class
    {
        Task Handle(T command);
    }

    class PostCommandHandler : ICommandHandler<CreatePostRequest>, ICommandHandler<DeletePostRequest>
    {
        private readonly IBlogRepository _blogRepository;

        public PostCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task Handle(CreatePostRequest command)
        {
            var post = Post.Create(command.Title, command.Content, "Jonathan");
            await _blogRepository.Save(post);
        }

        public async Task Handle(DeletePostRequest command)
        {
            await _blogRepository.Delete(command.Id);
        }
    }
}