using System;
using System.Collections.Generic;

namespace Blog.Domain.Commands
{
    public interface ICommand
    {
    }

    public class CreatePostCommand : ICommand
    {
        public CreatePostCommand(string title, string content, List<string> tags)
        {
            Title = title;
            Content = content;
            Tags = tags;
        }

        public string Title { get; }
        public string Content { get; }
        public List<string> Tags { get; }
    }

    public class DeletePostCommand : ICommand
    {
        public DeletePostCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}