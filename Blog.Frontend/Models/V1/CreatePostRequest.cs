using System;
using System.Collections.Generic;

namespace Blog.Frontend.Models.V1
{
    public class CreatePostRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }
    }

    public class DeletePostRequest
    {
        public Guid Id { get; set; }
    }
}