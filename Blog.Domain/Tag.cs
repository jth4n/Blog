using System;

namespace Blog.Domain
{
    public class Tag
    {
        public Guid Id { get; private set; }
        public string TagName { get; private set; }

        public static Tag FromString(string tag)
        {
            return new Tag(tag);
        }

        private Tag(string tag)
        {
            Id = new Guid();
            TagName = tag;
        }

        //EF needs a default constructor
        private Tag()
        {
        }
    }
}