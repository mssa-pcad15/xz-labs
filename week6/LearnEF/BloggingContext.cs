using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace LearnEF
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; } = new();

        public int AuthorId { get; set; }

        public Author? Author { get; set; }
    }

    public class Author
    {
        public int? AuthorId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public List<Blog> Blogs { get; } = new();
    }
        public class BloggingContext : DbContext
        {
            public DbSet<Blog> Blogs { get; set; }
            public DbSet<Post> Posts { get; set; }

            public string DbPath { get; }

            public BloggingContext()
            {
                var folder = Environment.SpecialFolder.LocalApplicationData;
                var path = Environment.GetFolderPath(folder);
                DbPath = System.IO.Path.Join(path, "blogging.db");
            }

            // The following configures EF to create a Sqlite database file in the
            // special "local" folder for your platform.
            protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite($"Data Source={DbPath}");
        }
    }
    
