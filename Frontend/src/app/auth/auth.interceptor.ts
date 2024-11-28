import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginService } from '../pages/login/login.service';

@Injectable({
  providedIn: 'root'
})

export class authInterceptor implements HttpInterceptor {
  constructor(
    private LoginService: LoginService
  ){}

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const name = this.LoginService.getLocalStorageKey();
    const user = this.LoginService.getUserLoggedIn();
    return next.handle(
      req.clone({
        headers: req.headers.append(name, user.email)
      })
    );
    
  }
}
