using System;
using System.Collections.Generic;

namespace Blog.Domain.ReadModel
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
        public List<Tag> Tags { get; set; }
    }

    public class Tag
    {
        public string TagName { get; set; }
    }
}