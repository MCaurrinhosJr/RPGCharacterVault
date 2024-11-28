import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { User } from './user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private httpClient: HttpClient
  ) { }

  getAll() {
    const url = `${environment.api}/user`;
    return this.httpClient.get<User[]>(url);
  }

  getById(id: string) {
    const url = `${environment.api}/user/${id}`;
    return this.httpClient.get<User>(url);
  }

  getByEmail(email: string) {
    const url = `${environment.api}/user/${email}`;
    return this.httpClient.get<User>(url);
  }
}