import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Comment } from '../models/Comment';
import { Observable, Subject } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { CommentsComponent } from '../components/comments/comments.component';

@Injectable({
  providedIn: 'root'
})
export class CommentService {
  private _COMMENT_LIST_URL = 'http://localhost:45111/api/Comments/List?postId={postId}';
  private _RECENT_COMMENT_URL = 'http://localhost:45111/api/Comments/Recent';
  private _COMMENT_CREATE_URL = 'http://localhost:45111/api/Comments/Create';

  commentsComponent: CommentsComponent;

  private commentStore: Comment[];
  commentSubject = new Subject();

  private recentCommentStore: Comment[];
  recentCommentSubject = new Subject();

  constructor(private _http: HttpClient) { }


  updateComments(postId) {
    const commentListUrl = this._COMMENT_LIST_URL.replace('{postId}', postId.toString());
    this._http.get<Comment[]>(commentListUrl).subscribe(res => {
      this.commentStore = res;
      this.commentSubject.next(this.commentStore);
    });
  }


  updateRecentComments() {
    this._http.get<Comment[]>(this._RECENT_COMMENT_URL).subscribe(res => {
      this.recentCommentStore = res;
      this.recentCommentSubject.next(this.recentCommentStore);
    });
  }


  createComment(formValue) {
    return this._http.post(this._COMMENT_CREATE_URL, formValue);
  }
}
