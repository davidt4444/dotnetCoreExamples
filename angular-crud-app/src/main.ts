import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { PostService } from './app/post.service';
import { HttpClient } from '@angular/common/http';
import { provideHttpClient } from '@angular/common/http';

import { routes } from './app/app.routes';
import { provideRouter, RouterLink } from '@angular/router';



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
