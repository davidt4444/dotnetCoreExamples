using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BCS.Api.Models;
using BCS.Api.Data;
/*
Notes:
Dependency Injection: The service uses constructor injection to receive an instance of YourDbContext, which is assumed to be your Entity Framework Core DbContext.
Error Handling: Basic null checks and argument validation are included to ensure the integrity of operations.
Asynchronous Methods: All methods are asynchronous to support non-blocking operations, which is crucial for scalability in applications, particularly web applications.
Timestamps: The AddPostAsync method sets CreatedAt to the current UTC time when adding a new post, and UpdatePostAsync updates the UpdatedAt timestamp when modifying a post.
Database Operations: 
GetAllPostsAsync fetches all posts and orders them by creation date (most recent first).
GetPostByIdAsync uses FindAsync, which is optimized for looking up entities by their primary key.
AddPostAsync adds a new entity to the context and saves changes.
UpdatePostAsync marks the entity as modified and saves changes.
DeletePostAsync removes the entity from the context after ensuring it exists.

Make sure to handle exceptions in a way that suits your application's error handling strategy (e.g., logging, custom exception handling, etc.). Also, adjust YourDbContext to reflect the actual name of your DbContext class, and ensure it includes a DbSet<Post> named Posts for this implementation to work correctly.

*/

namespace BCS.Api.Services
{
    public class PostService : IPostService
    {
        private readonly YourDbContext _context;

        public PostService(YourDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _context.Posts
                .OrderByDescending(p => p.createdAt)
                .ToListAsync();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts
                .OrderByDescending(p => p.createdAt)
                .ToList();
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task AddPostAsync(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException(nameof(post));
            }

            post.uniqueId = Guid.NewGuid().ToString();
            post.createdAt = DateTime.UtcNow;
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException(nameof(post));
            }

            post.updatedAt = DateTime.UtcNow;
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                throw new ArgumentException("Post not found.", nameof(id));
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
}