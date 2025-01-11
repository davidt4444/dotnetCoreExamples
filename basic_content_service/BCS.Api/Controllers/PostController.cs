using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
//add in the service interface
// add Swashbuckle.AspNetCore.Annotations nuget package
using Swashbuckle.AspNetCore.Annotations;
using BCS.Api.Models;
using BCS.Api.Services;

/*
Notes:
IPostService: You'll need to implement this interface for handling data operations related to Post.
Post Model: Ensure you have a Post class defined with appropriate properties like Id, Title, Content, etc.
Routing: The route [Route("api/[controller]")] will route requests to /api/post.

To use Swagger/OpenAPI:

You need to have the Swashbuckle.AspNetCore package installed in your project.
Configure it in your Startup.cs or Program.cs for .NET 6+:

csharp
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
});

And in your middleware configuration:

csharp
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name v1"));

This will give you interactive documentation for your Post controller through Swagger UI.
*/

namespace BCS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        // Assuming you have a service or repository for post operations
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        /// <summary>
        /// Retrieves all posts from the database.
        /// </summary>
        /// <returns>A list of all posts</returns>
        /// <response code="200">Returns the list of posts</response>
        [HttpGet]
        [SwaggerOperation(Summary = "Get all posts", Description = "Retrieves all posts from the database")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }

        /// <summary>
        /// Retrieves a specific post by its ID.
        /// </summary>
        /// <param name="id">The ID of the post to retrieve</param>
        /// <returns>The post with the specified ID</returns>
        /// <response code="200">Returns the requested post</response>
        /// <response code="404">If the post is not found</response>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get post by ID", Description = "Retrieves a post based on its ID")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        /// <summary>
        /// Creates a new post.
        /// </summary>
        /// <param name="newPost">The post to create</param>
        /// <returns>The newly created post</returns>
        /// <response code="201">Returns the newly created post</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Create a new post", Description = "Adds a new post to the database")]
        public async Task<ActionResult<Post>> PostPost([FromBody] Post newPost)
        {
            await _postService.AddPostAsync(newPost);
            return CreatedAtAction(nameof(GetPost), new { id = newPost.Id }, newPost);
        }

        /// <summary>
        /// Updates an existing post.
        /// </summary>
        /// <param name="id">The ID of the post to update</param>
        /// <param name="postToUpdate">The updated post data</param>
        /// <returns>No content if successful</returns>
        /// <response code="204">If the update was successful</response>
        /// <response code="400">If the ID does not match the post's ID</response>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an existing post", Description = "Updates a post with new data")]
        public async Task<IActionResult> PutPost(int id, [FromBody] Post postToUpdate)
        {
            if (id != postToUpdate.Id)
            {
                return BadRequest();
            }

            await _postService.UpdatePostAsync(postToUpdate);
            return NoContent();
        }

        /// <summary>
        /// Deletes a specific post by its ID.
        /// </summary>
        /// <param name="id">The ID of the post to delete</param>
        /// <returns>No content if successful</returns>
        /// <response code="204">If the deletion was successful</response>
        /// <response code="404">If the post was not found</response>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a post", Description = "Removes a post from the database")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            await _postService.DeletePostAsync(id);
            return NoContent();
        }
    }
}