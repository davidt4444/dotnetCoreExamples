import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { provideRouter, Routes, RouterLink } from '@angular/router';
import { PostListComponent } from './app/post-list/post-list.component';
import { PostCreateComponent } from './app/post-create/post-create.component';
import { PostEditComponent } from './app/post-edit/post-edit.component';
import { PostService } from './app/post.service';
import { HttpClient } from '@angular/common/http';
import { provideHttpClient } from '@angular/common/http';

const routes: Routes = [
  { path: '', component: PostListComponent },
  { path: 'create', component: PostCreateComponent },
  { path: 'edit/:id', component: PostEditComponent }
];

bootstrapApplication(AppComponent, {
  providers: [
    HttpClient,
    RouterLink,
    provideRouter(routes),
    provideHttpClient(), 
    PostService // Provide the service here if it's not already injected elsewhere with useClass or useFactory
  ]
});

// import { bootstrapApplication } from '@angular/platform-browser';
// import { appConfig } from './app/app.config';
// import { AppComponent } from './app/app.component';

// bootstrapApplication(AppComponent, appConfig)
//   .catch((err) => console.error(err));
