import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
// bootstrap import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';

import { ComponentsModule } from './components/components.module';


@NgModule({
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    ComponentsModule,
    //NgbModule,
    RouterModule//,
    //AppRoutingModule
  ],
  declarations: [
    //AppComponent,
    //AdminLayoutComponent,
    //AuthLayoutComponent
  ],
  providers: [],
  //bootstrap: [AppComponent]
})
export class AppModule { }
