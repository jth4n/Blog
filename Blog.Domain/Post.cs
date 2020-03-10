using System;
using System.Collections.Generic;

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
        public List<Tag> Tags { get; private set; }

        public static Post Create(string title, string content, string author, List<string> tags)
        {
            return new Post(title, content, author, tags);
        }

        private Post(string title, string content, string author, List<string> tags)
        {
            Id = Guid.NewGuid();
            Title = title;
            Content = content;
            Author = author;
            Status = PostStatus.Draft;
            Created = DateTime.Now;
            Tags = new List<Tag>();

            foreach (var tag in tags)
            {
                Tags.Add(Tag.FromString(tag));
            }
        }

        private Post() { }
    }
}
