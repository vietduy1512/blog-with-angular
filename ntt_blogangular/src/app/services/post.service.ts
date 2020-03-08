import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Post } from '../models/Post';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  private _POST_LIST_URL = 'http://localhost:45111/api/Posts/List?page={page}';
  private _POST_DETAIL_URL = 'http://localhost:45111/api/Posts/Detail/{id}/{slug}';
  private _POST_CREATE_URL = 'http://localhost:45111/api/Posts/Create';
  private _POST_DELETE_URL = 'http://localhost:45111/api/Posts/{id}/Delete';

  constructor(private _http: HttpClient, private router: Router) { }


  getPosts(page: number): Observable<Post[]> {
    const postList = this._POST_LIST_URL.replace('{page}', page.toString());

    return this._http.get<Post[]>(postList)
    .pipe(
      // Replace server domain in ImagePath
      map(result => {
        const items = <any[]>result;
        items.forEach(item => {
          if (item.ImagePath) {
            item.ImagePath = this.replaceUrl(item.ImagePath);
          }
        });
        return items;
    }));
  }


  getPostDetail(id: number, slug: string): Observable<Post> {
    let postDetailUrl = this._POST_DETAIL_URL;
    postDetailUrl = postDetailUrl.replace('{id}', id.toString());
    postDetailUrl = postDetailUrl.replace('{slug}', slug.toString());

    return this._http.get<Post>(postDetailUrl)
    .pipe(
      // Replace server domain in ImagePath
      map(item => {
        if (item.ImagePath) {
          item.ImagePath = this.replaceUrl(item.ImagePath);
        }
        return item;
    }));
  }


  createPost(formData) {
    this._http.post(this._POST_CREATE_URL, formData).subscribe(_ => {
      this.router.navigate(['/']);

    }, errors => {
      this.router.navigate(['/posts/create']);
      window.location.reload();
    });
  }


  deletePost(id) {
    const postDeleteUrl = this._POST_DELETE_URL.replace('{id}', id.toString());

    this._http.delete(postDeleteUrl).subscribe(_ => {
      this.router.navigate(['/']);
    });
  }


  private replaceUrl(url: string) {
    return url.replace('~', 'http://localhost:45111');
  }
}
