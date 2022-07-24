import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class PostService {
  constructor(private http: HttpClient, private route: Router) {}

  AddFeed(Title: any, FeedBody: any): Observable<any> {
    // console.log(username, password);
    return this.http.post(`https://localhost:7070/api/Feed/AddFeed`, {
      Title,
      FeedBody,
    });
  }

  GetFeed(): Observable<any> {
    // console.log(username, password);
    return this.http.get('https://localhost:7070/api/Feed/GetFeed');
  }

  GetAllFeed(): Observable<any> {
    // console.log(username, password);
    return this.http.get('https://localhost:7070/api/Feed/GetAllFeed');
  }

  DeleteFeed(feedId: any): Observable<any> {
    // console.log(username, password);
    return this.http.delete(
      `https://localhost:7070/api/Feed/DeleteFeed/${feedId}`
    );
  }

  UpdateFeed(feedId: any, Title: any, FeedBody: any): Observable<any> {
    // console.log(username, password);
    return this.http.put(
      `https://localhost:7070/api/Feed/UpdateFeed/${feedId}`,
      {
        Title,
        FeedBody,
      }
    );
  }

  LikeFeed(feedId: any, fid: any): Observable<any> {
    // console.log(username, password);
    return this.http.post(
      `https://localhost:7070/api/Like/LikeFeed/${feedId}`,
      fid
    );
  }

  UnlikeFeed(feedId: any): Observable<any> {
    // console.log(username, password);
    return this.http.delete(
      `https://localhost:7070/api/Like/UnlikeFeed/${feedId}`
    );
  }

  AddComment(Title: any, FeedBody: any): Observable<any> {
    // console.log(username, password);
    return this.http.post(`https://localhost:7070/api/Feed/AddFeed`, {
      Title,
      FeedBody,
    });
  }

  AddTag(userId: any, feedId: any): Observable<any> {
    // console.log(username, password);
    return this.http.post(
      `https://localhost:7070/api/Tag/TagFeed/${userId}/${feedId}`,
      {
        userId,
        feedId,
      }
    );
  }
}
