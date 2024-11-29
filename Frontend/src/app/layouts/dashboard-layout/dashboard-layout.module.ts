import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DashboeardLayoutRoutes } from './dashboard-layout.routing';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(DashboeardLayoutRoutes),
    FormsModule,
    ReactiveFormsModule
  ]
})
export class DashboardLayoutModule { }
