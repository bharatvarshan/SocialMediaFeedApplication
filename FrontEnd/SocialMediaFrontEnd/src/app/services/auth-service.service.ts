import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthServiceService {
  constructor(private http: HttpClient, private route: Router) {}
  Login(username: string, password: string): Observable<any> {
    console.log(username, password);
    return this.http.post('https://localhost:7070/api/Auth/login', {
      email: username,
      password: password,
    });
  }
  Register(username: string, email: string, password: string): Observable<any> {
    return this.http.post('https://localhost:7070/api/Auth/register', {
      username,
      email,
      password,
    });
  }
  getToken() {
    return localStorage.getItem('token');
  }

  setToken(token: string, id: any) {
    localStorage.setItem('token', token);
    localStorage.setItem('uid', id);
  }
}
