using System;

namespace Blog.Frontend.Models.V1
{
    public class CreatePostRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class DeletePostRequest
    {
        public Guid Id { get; set; }
    }
}