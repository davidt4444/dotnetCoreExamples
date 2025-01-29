import { Component, OnInit } from '@angular/core';
import { PostService } from '../post.service';
import { Post } from '../models/post.model';
import { CommonModule } from '@angular/common';
import { RouterLink, Router } from '@angular/router';

@Component({
  selector: 'app-post-admin',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './post-admin.component.html',
  styleUrls: ['./post-admin.component.css']
})
export class PostAdminComponent implements OnInit {
  posts: Post[] = [];

  constructor(private postService: PostService) { }

  ngOnInit() {
    this.loadPosts();
  }

  loadPosts() {
    this.postService.getPosts().subscribe(posts => this.posts = posts);
  }

  deletePost(id: number) {
    if (confirm('Are you sure you want to delete this post?')) {
      this.postService.deletePost(id).subscribe(() => this.loadPosts());
    }
  }
}

// import { Component } from '@angular/core';

// @Component({
//   selector: 'app-post-admin',
//   imports: [],
//   templateUrl: './post-admin.component.html',
//   styleUrl: './post-admin.component.css'
// })
// export class PostAdminComponent {

// }
