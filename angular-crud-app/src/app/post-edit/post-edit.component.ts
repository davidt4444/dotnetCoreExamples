import { Component, OnInit } from '@angular/core';
import { PostService } from '../post.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Post } from '../models/post.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-post-edit',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './post-edit.component.html',
  styleUrls: ['./post-edit.component.css']
})
export class PostEditComponent implements OnInit {
  post: Post = {
    id: 0,
    title: '',
    content: '',
    createdAt: new Date(),
    isPublished: true,
    likesCount: 0,
    views: 0
  };

  constructor(
    private postService: PostService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      const id = +params['id'];
      this.postService.getPost(id).subscribe(post => this.post = post);
    });
  }

  onSubmit() {
    this.postService.updatePost(this.post.id, this.post).subscribe(() => {
      this.router.navigate(['/']);
    });
  }
}

