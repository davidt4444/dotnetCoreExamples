using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection; // For dependency injection
using BCS.Api.Services; // Assuming IPostService is here

namespace BCE.Native
{
    public partial class MainWindow : Window
    {
        private readonly IPostService _postService;

        public MainWindow()
        {
            InitializeComponent();
            // If you're not using constructor injection, you can resolve services like this:
            if (Application.Current is App app)
            {
                _postService = app.Services.GetRequiredService<IPostService>();
            }
            else
            {
                throw new InvalidOperationException("Application.Current is not of type App");
            }

            // Assuming you've set up dependency injection in App.xaml.cs or similar
            // var serviceProvider = App.Current.Services;
            // _postService = serviceProvider.GetRequiredService<IPostService>();
        }

        private void NewBlogPost_Click(object sender, RoutedEventArgs e)
        {
            var editor = new BlogPostEditor(_postService);
            editor.ShowDialog();
        }
    }
}