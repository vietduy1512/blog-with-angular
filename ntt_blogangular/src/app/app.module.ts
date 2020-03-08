import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './routes/app-routing.module';
import { CKEditorModule } from 'ng2-ckeditor';
import { AuthInterceptor } from './auth.interceptor';

import { AppComponent } from './app.component';
import { PostsComponent } from './components/posts/posts.component';
import { SidebarComponent } from './shared/sidebar/sidebar.component';
import { PostDetailComponent } from './components/post-detail/post-detail.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { NavComponent } from './shared/nav/nav.component';
import { PostCreateComponent } from './components/post-create/post-create.component';
import { CommentCreateComponent } from './components/comment-create/comment-create.component';
import { CommentsComponent } from './components/comments/comments.component';
import { RecentCommentsComponent } from './shared/recent-comments/recent-comments.component';
import { RecentPostsComponent } from './shared/recent-posts/recent-posts.component';
import { NotFoundComponent } from './shared/not-found/not-found.component';

@NgModule({
  declarations: [
    AppComponent,
    PostsComponent,
    SidebarComponent,
    PostDetailComponent,
    RegisterComponent,
    LoginComponent,
    NavComponent,
    PostCreateComponent,
    CommentCreateComponent,
    CommentsComponent,
    RecentCommentsComponent,
    RecentPostsComponent,
    NotFoundComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule,
    CKEditorModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
