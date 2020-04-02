using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Domain.Interfaces
{
    public interface IBlogRepository
    {
        Task Save(Post post);
        Task<Post> Load(Guid id);
        Task Delete(Guid id);
        Task<IEnumerable<Post>> GetAllPosts();
        Task<Post> GetPost(Guid id);
    }
}