import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  constructor(public postService: PostService, private router: Router) {}

  ngOnInit(): void {
    this.postService.AddFeed('Title', 'new Body').subscribe({
      next: (res: any) => {
        console.log(res);
      },
    });
    // this.postService.GetFeed().subscribe({
    //   next: (res: any) => {
    //     console.log(res);
    //   },
    // });

    // this.postService.GetAllFeed().subscribe({
    //   next: (res: any) => {
    //     console.log(res);
    //   },
    // });

    // this.postService.DeleteFeed(10).subscribe({
    //   next: (res: any) => {
    //     console.log(res);
    //   },
    // });

    // this.postService.UpdateFeed(10, 'Title', 'new Body').subscribe({
    //   next: (res: any) => {
    //     console.log(res);
    //   },
    // });

    // this.postService.LikeFeed(12, 12).subscribe({
    //   next: (res: any) => {
    //     console.log(res);
    //   },
    // });

    // this.postService.UnlikeFeed(12).subscribe({
    //   next: (res: any) => {
    //     console.log(res);
    //   },
    // });

    this.postService.AddTag(3, 12).subscribe({
      next: (res: any) => {
        console.log(res);
      },
    });
  }
}
