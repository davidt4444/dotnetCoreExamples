using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BCS.Api.Models;

namespace BCS.Api.Services
{
    public interface IPostService
    {
        /// <summary>
        /// Retrieves all posts from the data source.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of posts.</returns>
        Task<IEnumerable<Post>> GetAllPostsAsync();
        IEnumerable<Post> GetAllPosts();

        /// <summary>
        /// Retrieves a specific post by its ID.
        /// </summary>
        /// <param name="id">The ID of the post to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the post if found, otherwise null.</returns>
        Task<Post> GetPostByIdAsync(int id);

        /// <summary>
        /// Adds a new post to the data source.
        /// </summary>
        /// <param name="post">The post to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddPostAsync(Post post);

        /// <summary>
        /// Updates an existing post in the data source.
        /// </summary>
        /// <param name="post">The updated post data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdatePostAsync(Post post);

        /// <summary>
        /// Deletes a post from the data source by its ID.
        /// </summary>
        /// <param name="id">The ID of the post to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeletePostAsync(int id);
    }
}