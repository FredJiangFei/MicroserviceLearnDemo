import { BrowserModule, DomSanitizer } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { ShareModule } from './_shared/share.module';
import { RouterModule } from '@angular/router';
import { routes } from './app-routing';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [AppComponent, HomeComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ShareModule,
    RouterModule.forRoot(routes)
  ],
  providers: [ErrorInterceptorProvider],
  bootstrap: [AppComponent]
})
export class AppModule {}
