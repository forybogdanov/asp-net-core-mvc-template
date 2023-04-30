﻿namespace ExamApplication.Data.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Post> Posts { get; set; }
    }
}