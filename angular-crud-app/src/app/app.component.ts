import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterOutlet } from '@angular/router';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterLink, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
// template: `
//     <h1>CRUD App</h1>
//     <nav>
//       <a routerLink="/">List Posts</a> |
//       <a routerLink="/create">Create Post</a>
//     </nav>
//     <router-outlet></router-outlet>
//   `
})
// export class AppComponent {}
// import { Component } from '@angular/core';
// import { RouterOutlet } from '@angular/router';

// @Component({
//   selector: 'app-root',
//   imports: [RouterOutlet],
//   templateUrl: './app.component.html',
//   styleUrl: './app.component.css'
// })
export class AppComponent {
  title = 'angular-crud-app';
}
