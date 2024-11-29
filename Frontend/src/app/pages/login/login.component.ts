import { Component } from '@angular/core';
import { LoginService } from './login.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-login',
  imports: [CommonModule, FormsModule, HttpClientModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})

export class LoginComponent {
  email: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(private loginService: LoginService, private router: Router){}

  onLogin(): void{
    if(this.email && this.password){
      this.loginService.login(this.email, this.password).subscribe({
        next: (response) => {
          if(response?.token) {
            this.loginService.storeToken(response.token);
            this.router.navigate(['/home']);
          }
        },
        error: (err) => {
          this.errorMessage = err.error || 'Erro ao Realizar Login. Tente Novamente.';
        }
      });
    } else {
      this.errorMessage = 'Preencha todos os campos.';
    }
  }

}
