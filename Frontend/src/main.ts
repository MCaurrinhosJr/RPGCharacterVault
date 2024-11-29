import { bootstrapApplication } from '@angular/platform-browser';
import { environment } from './environments/environment';
import { enableProdMode } from '@angular/core';
import { AppModule } from './app/app.module';

if(environment.production){
    enableProdMode();
}

bootstrapApplication(AppModule).catch((err) => console.error(err));