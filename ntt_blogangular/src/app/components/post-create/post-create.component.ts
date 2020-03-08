import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Validators } from '@angular/forms';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PostService } from '../../services/post.service';

@Component({
  selector: 'app-post-create',
  templateUrl: './post-create.component.html',
  styleUrls: ['./post-create.component.css']
})
export class PostCreateComponent implements OnInit {

  submitted = false;
  newPostForm: FormGroup;

  previewImage;

  get title() { return this.newPostForm.get('title'); }
  get uploaded_image() { return this.newPostForm.get('uploaded_image'); }
  get description() { return this.newPostForm.get('description'); }
  get content() { return this.newPostForm.get('content'); }
  get authorId() { return this.newPostForm.get('authorId'); }


  constructor(private fb: FormBuilder, private postService: PostService, private auth: AuthService) {}

  ngOnInit() {
    this.createForm();
  }

  createForm() {
    this.newPostForm = this.fb.group({
      title: ['', Validators.required],
      uploaded_image: [null, Validators.required],
      description: ['', Validators.required],
      content: ['', Validators.required]
    });
  }


  fileChange(event) {
    const fileList: FileList = event.target.files;
    if (fileList.length > 0) {
      this.uploaded_image.setValue(fileList[0]);

      // preview image
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.previewImage = e.target.result;
      };
      reader.readAsDataURL(event.target.files[0]);
    }
  }


  onSubmit(event) {
    this.submitted = true;
    const formData: FormData = new FormData();

    // Append FormGroup's data to FormData
    const formValue = this.newPostForm.value;
    for (const key in formValue) {
      if (formValue[key]) {
        formData.append(key, formValue[key]);
      }
    }
    this.postService.createPost(formData);
  }
}
