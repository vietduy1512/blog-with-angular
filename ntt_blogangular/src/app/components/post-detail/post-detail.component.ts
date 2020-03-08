import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PostService } from '../../services/post.service';
import { CommentService } from '../../services/comment.service';
import { AuthService } from '../../services/auth.service';
import { Post } from '../../models/Post';
import { Comment } from '../../models/Comment';

@Component({
  selector: 'app-post-detail',
  templateUrl: './post-detail.component.html',
  styleUrls: ['./post-detail.component.css']
})
export class PostDetailComponent implements OnInit {

  post: Post;

  comments;
  id: number;
  slug: string;

  constructor(
    private route: ActivatedRoute,
    private postService: PostService,
    private commentService: CommentService,
    private auth: AuthService
  ) {}

  ngOnInit() {
    this.route.params.subscribe(params => {
      window.scroll(0, 0);
      this.id = +params['id'];
      this.slug = params['slug'];
      this.getPostDetail(this.id, this.slug);
      this.commentService.updateComments(this.id);
    });
    this.commentService.commentSubject.subscribe(comments => {
      this.comments = comments;
    });
  }

  getPostDetail(id, slug) {
    this.postService.getPostDetail(id, slug)
      .subscribe(post => this.post = post);
  }


  onDelete() {
    this.postService.deletePost(this.id);
  }
}
