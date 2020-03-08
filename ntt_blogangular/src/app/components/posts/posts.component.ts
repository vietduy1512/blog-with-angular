import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PostService } from '../../services/post.service';
import { Post } from '../../models/Post';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {

  posts: Post[];

  page = +this.route.snapshot.paramMap.get('page');

  constructor(
    private route: ActivatedRoute,
    private postService: PostService
  ) {}

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.page = +params['page'];
      this.getPostsList(this.page);
    });
  }

  getPostsList(page: number): void {
    this.postService.getPosts(page)
      .subscribe(posts => this.posts = posts);
  }
}
