using System;

namespace Blog.Domain
{
    public class Post
    {
        
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public string Author { get; private set; }
        public PostStatus Status { get; private set; }
        public DateTime Created { get; private set; }

        public static Post Create(string title, string content, string author)
        {
            return new Post(title, content, author);
        }
        private Post(string title, string content, string author)
        {
            Id = Guid.NewGuid();
            Title = title;
            Content = content;
            Author = author;
            Status = PostStatus.Draft;
            Created = DateTime.Now;
        }
    }

    public enum PostStatus
    {
        Draft = 0,
        Published = 1,
        Retracted = 2
    }
}
