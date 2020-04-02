using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Domain;
using Blog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Frontend.Data
{
    class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _context;

        public BlogRepository(BlogDbContext context)
        {
            _context = context;
        }
        public async Task Save(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task<Post> Load(Guid id)
        {
            var post = await _context.Posts.FindAsync(id);
            return post;
        }

        public async Task Delete(Guid id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetPost(Guid id)
        {
            var post = await _context.Posts.Include(t => t.Tags).FirstOrDefaultAsync(p => p.Id == id);
            return post;
        }
    }
}