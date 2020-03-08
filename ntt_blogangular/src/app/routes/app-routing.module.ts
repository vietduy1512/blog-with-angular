import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from '../components/register/register.component';
import { LoginComponent } from '../components/login/login.component';
import { PostsComponent } from '../components/posts/posts.component';
import { PostDetailComponent } from '../components/post-detail/post-detail.component';
import { PostCreateComponent } from '../components/post-create/post-create.component';
import { AuthGuardService } from '../guards/auth-guard.service';
import { NotFoundComponent } from '../shared/not-found/not-found.component';

const routes: Routes = [
  { path: '', redirectTo: 'posts/page/1', pathMatch: 'full' },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'posts/page/:page', component: PostsComponent },
  { path: 'detail/:id/:slug', component: PostDetailComponent },
  { path: 'posts/create', component: PostCreateComponent, canActivate: [AuthGuardService] },
  { path: '404', component: NotFoundComponent },
  { path: '**', redirectTo: '/404' }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
