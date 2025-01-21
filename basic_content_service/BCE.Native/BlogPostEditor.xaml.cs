using System;
using System.Windows;
using BCS.Api.Services; // Assuming IPostService is here
using BCS.Api.Models; // Assuming Post is here

namespace BCE.Native
{
    public partial class BlogPostEditor : Window
    {
        private readonly IPostService _postService;

        public BlogPostEditor(IPostService postService)
        {
            InitializeComponent();
            _postService = postService;
        }

        private async void SavePost_Click(object sender, RoutedEventArgs e)
        {
            var newPost = new Post
            {
                Title = txtTitle.Text,
                Content = txtContent.Text,
                CreatedAt = DateTime.UtcNow
            };

            await _postService.AddPostAsync(newPost);
            MessageBox.Show("Post saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
