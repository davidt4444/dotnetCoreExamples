using System;
using System.Windows;
using BCS.Api.Services; // Assuming IPostService is here
using BCS.Api.Models; // Assuming Post is here

namespace BCE.Native
{
    public partial class BlogPostEditor : Window
    {
        private readonly IPostService _postService;
        private Post _post;

        // public BlogPostEditor(IPostService postService)
        public BlogPostEditor(IPostService postService, Post post = null)
        {
            InitializeComponent();
            _postService = postService;
            if (post != null)
            {
                _post = post;
                txtTitle.Text = post.title;
                txtContent.Text = post.content;
            }
        }

        private async void SavePost_Click(object sender, RoutedEventArgs e)
        {
            // var newPost = new Post
            // {
            //     Title = txtTitle.Text,
            //     Content = txtContent.Text,
            //     CreatedAt = DateTime.UtcNow
            // };

            // await _postService.AddPostAsync(newPost);
            // MessageBox.Show("Post saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            // this.Close();
            if (_post == null)
            {
                // Create new post
                var newPost = new Post
                {
                    title = txtTitle.Text,
                    content = txtContent.Text,
                    createdAt = DateTime.UtcNow
                };
                await _postService.AddPostAsync(newPost);
            }
            else
            {
                // Update existing post
                _post.title = txtTitle.Text;
                _post.content = txtContent.Text;
                _post.updatedAt = DateTime.UtcNow;
                await _postService.UpdatePostAsync(_post);
            }
            MessageBox.Show("Post saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
