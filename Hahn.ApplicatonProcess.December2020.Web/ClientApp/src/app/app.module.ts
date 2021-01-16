import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SideNavComponent } from './components/side-nav/side-nav.component';
import { HeaderComponent } from './components/header/header.component';
import { SideNavContentComponent } from './components/side-nav-content/side-nav-content.component';
import { AppPageComponent } from './pages/app-page/app-page.component';
import { ApplyDataComponent } from './pages/apply-data/apply-data.component';
import {MatCardModule} from '@angular/material/card';
import { httpCaller } from './services/sharedServices/httpCaller.service';
import { ApplyDataService } from './services/apply-data-service/apply-data-service';
import { MaterialModule } from 'src/material.module';
import { HttpClient, HttpClientModule, HttpHandler } from '@angular/common/http';
import { AddEditDataComponent } from './pages/apply-data/add-edit-data/add-edit-data.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    SideNavComponent,
    HeaderComponent,
    SideNavContentComponent,
    AppPageComponent,
    ApplyDataComponent,
    AddEditDataComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatCardModule,
    MaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [httpCaller,
              ApplyDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
