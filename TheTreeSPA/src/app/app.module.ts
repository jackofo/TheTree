import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginScreenComponent } from './_components/login-screen/login-screen.component';
import { PersonComponent } from './_components/person/person.component';
import { RelationshipComponent } from './_components/relationship/relationship.component';
import { HttpClientJsonpModule, HttpClientModule } from '@angular/common/http';
import { PersonInsertComponent } from './_components/person-insert/person-insert.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginScreenComponent,
    PersonComponent,
    RelationshipComponent,
    PersonInsertComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
