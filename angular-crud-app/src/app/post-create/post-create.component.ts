import { Component } from '@angular/core';
import { PostService } from '../post.service';
import { Router } from '@angular/router';
import { Post } from '../models/post.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-post-create',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './post-create.component.html',
  styleUrls: ['./post-create.component.css']
})
export class PostCreateComponent {
  post: Post = {
    id: 0,
    title: '',
    content: '',
    createdAt: new Date(),
    isPublished: true,
    likesCount: 0,
    views: 0
  };

  constructor(private postService: PostService, private router: Router) { }

  onSubmit() {
    this.postService.createPost(this.post).subscribe(() => {
      this.router.navigate(['/']);
    });
  }
}

// import { Component } from '@angular/core';

// @Component({
//   selector: 'app-post-create',
//   imports: [],
//   templateUrl: './post-create.component.html',
//   styleUrl: './post-create.component.css'
// })
// export class PostCreateComponent {

// }
