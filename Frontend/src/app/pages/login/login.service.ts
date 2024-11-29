import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  
  private apiUrl = `${environment.api}/auth`;

  constructor(
    private httpClient: HttpClient
  ) { }

  login(email: string, password: string): Observable<any> {
    const credentials = { email, password };
    return this.httpClient.post<any>(this.apiUrl, credentials);
  }

  storeToken(token: string): void{
    localStorage.setItem('authToken', token);
  }

  getToken(): string | null{
    return localStorage.getItem('authToken');
  }

  isAuthenticated(): boolean {
    return this.getToken() !== null;
  }
}