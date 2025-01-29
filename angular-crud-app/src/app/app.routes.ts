import { Routes } from '@angular/router';
import { PostListComponent } from './post-list/post-list.component';
import { PostAdminComponent } from './post-admin/post-admin.component';
import { PostCreateComponent } from './post-create/post-create.component';
import { PostEditComponent } from './post-edit/post-edit.component';

export const routes: Routes = [
    { path: '', component: PostListComponent },
    { path: 'admin', component: PostAdminComponent },
    { path: 'create', component: PostCreateComponent },
  { path: 'edit/:id', component: PostEditComponent }
];

