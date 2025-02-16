using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
Notes:
Key: The Id is used as the primary key for the Post entity.
Required: Ensures that the field must have a value.
StringLength: Limits the length of string properties to prevent overly long inputs.
DateTime: CreatedAt and UpdatedAt track when the post was created and last updated, respectively. CreatedAt defaults to the current UTC time when a new post is created.
ForeignKey: If you have a User or Author model, you might want to link the author to the post. The AuthorId is nullable to allow for posts where the author might not be set or known.
Navigation Property: Commented out for now, but you can uncomment if you have an Author model to link users to posts. Same for Comments if you decide to implement comments for posts.
IsPublished: Helps in managing draft or unpublished posts.
Views and LikesCount: Simple counters for tracking engagement, though for a production system, you might want to consider using a separate table for likes and views for scalability.

Remember to adjust the model according to your specific requirements, such as adding or removing fields, changing data types, or adding additional constraints. If you're using Entity Framework Core, these attributes will help in defining your database schema. If you're just doing simple data transfer, you might not need all these attributes.
*/

namespace BCS.Api.Models
{
    public class Post
    {
        [Key]
        public int id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(36)]
        public string uniqueId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string title { get; set; }

        [Required]
        [StringLength(10000)] // Adjust the length according to your needs
        public string content { get; set; }

        public DateTime createdAt { get; set; } = DateTime.UtcNow;

        [StringLength(200)]
        public string author { get; set; }

        // If posts can have categories
        [StringLength(100)]
        public string category { get; set; }

        // If you want to track when a post was last updated
        public DateTime? updatedAt { get; set; }

        // If you need to track likes (this could be a separate table for better scalability)
        public int likesCount { get; set; } = 0;

        // Navigation property if you have a relationship with a User or Author model
        [ForeignKey("Author")]
        public int? authorId { get; set; }
        //public virtual User Author { get; set; } // uncomment if you have a User model

        // If posts can have comments
        //public virtual ICollection<Comment> Comments { get; set; }

        // If you want to track whether the post is published or not
        public bool isPublished { get; set; } = true;

        // If you want to track post views
        public int views { get; set; } = 0;
    }
}