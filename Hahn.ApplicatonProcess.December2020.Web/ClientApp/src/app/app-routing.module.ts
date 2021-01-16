import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { AppPageComponent } from './pages/app-page/app-page.component';
import { ApplyDataComponent } from './pages/apply-data/apply-data.component';
import { AddEditDataComponent } from './pages/apply-data/add-edit-data/add-edit-data.component';

const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'apps',
    component: AppPageComponent
  },
  {
    path: 'applydata',
    component: ApplyDataComponent
  },
  {
    path: 'adddata',
    component: AddEditDataComponent
  },
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
