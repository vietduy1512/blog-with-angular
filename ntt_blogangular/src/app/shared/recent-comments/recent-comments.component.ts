import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommentService } from '../../services/comment.service';
import { Comment } from '../../models/Comment';

@Component({
  selector: 'app-recent-comments',
  templateUrl: './recent-comments.component.html',
  styleUrls: ['./recent-comments.component.css']
})
export class RecentCommentsComponent implements OnInit {

  comments;

  constructor(private route: ActivatedRoute, private commentService: CommentService) {}

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.commentService.updateRecentComments();
    });
    this.commentService.recentCommentSubject.subscribe(comments => {
      this.comments = comments;
    });
  }
}
