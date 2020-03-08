import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Validators } from '@angular/forms';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CommentService } from '../../services/comment.service';
import { PostDetailComponent } from '../post-detail/post-detail.component';

@Component({
  selector: 'app-comment-create',
  templateUrl: './comment-create.component.html',
  styleUrls: ['./comment-create.component.css']
})
export class CommentCreateComponent implements OnInit {

  @Input() postId: string;

  newCommentForm: FormGroup;

  get content() { return this.newCommentForm.get('content'); }

  constructor(private fb: FormBuilder, private commentService: CommentService, private auth: AuthService) {}

  ngOnInit() {
    this.createForm();
  }


  createForm() {
    this.newCommentForm = this.fb.group({
      content: ['', Validators.required],
      postId: ['', Validators.required]
    });
  }


  onSubmit() {
    this.newCommentForm.patchValue({ postId: this.postId });
    this.commentService.createComment(this.newCommentForm.value)
      .subscribe(res => {
        this.commentService.updateComments(this.postId);
        this.commentService.updateRecentComments();
        this.content.setValue('');
        // TODO: just add to list (not update the whole list)
      });
  }
}
