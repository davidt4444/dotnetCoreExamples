using System;
using System.Windows;
using System.Collections.ObjectModel;
using BCS.Api.Models; // Assuming Post is here
using BCS.Api.Services; // Assuming IPostService is here
using Microsoft.Extensions.DependencyInjection; // For dependency injection

namespace BCE.Native
{
    public partial class MainWindow : Window
    {
        private readonly IPostService _postService;
        private ObservableCollection<Post> _posts;

        public MainWindow()
        {
            InitializeComponent();
            // _postService = postService;
            // If you're not using constructor injection, you can resolve services like this:
            if (Application.Current is App app)
            {
                _postService = app.Services.GetRequiredService<IPostService>();
            }
            else
            {
                throw new InvalidOperationException("Application.Current is not of type App");
            }

            _posts = new ObservableCollection<Post>();
            lstPosts.ItemsSource = _posts;
            RefreshPosts();

            // Assuming you've set up dependency injection in App.xaml.cs or similar
            // var serviceProvider = App.Current.Services;
            // _postService = serviceProvider.GetRequiredService<IPostService>();
        }
        private async void RefreshPosts_Click(object sender, RoutedEventArgs e)
        {
            RefreshPosts();
        }

        private async void RefreshPosts()
        {
            var posts = await _postService.GetAllPostsAsync();
            _posts.Clear();
            foreach (var post in posts)
            {
                _posts.Add(post);
            }
        }

        private void NewPost_Click(object sender, RoutedEventArgs e)
        {
            var editor = new BlogPostEditor(_postService);
            editor.Closed += (sender, args) => RefreshPosts();
            editor.ShowDialog();
        }

        private async void EditPost_Click(object sender, RoutedEventArgs e)
        {
            if (lstPosts.SelectedItem is Post selectedPost)
            {
                var editor = new BlogPostEditor(_postService, selectedPost);
                editor.Closed += (sender, args) => RefreshPosts();
                editor.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a post to edit.", "Edit Post", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async void DeletePost_Click(object sender, RoutedEventArgs e)
        {
            if (lstPosts.SelectedItem is Post selectedPost)
            {
                if (MessageBox.Show("Are you sure you want to delete this post?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    await _postService.DeletePostAsync(selectedPost.Id);
                    RefreshPosts();
                }
            }
            else
            {
                MessageBox.Show("Please select a post to delete.", "Delete Post", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // private void NewBlogPost_Click(object sender, RoutedEventArgs e)
        // {
        //     var editor = new BlogPostEditor(_postService);
        //     editor.ShowDialog();
        // }
    }
}