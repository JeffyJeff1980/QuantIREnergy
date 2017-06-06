import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { sharedConfig } from './app.module.shared';
import { InjectionToken } from '@angular/core';

export const ORIGIN_URL = new InjectionToken<string>('ORIGIN_URL');

@NgModule({
    bootstrap: sharedConfig.bootstrap,
    declarations: sharedConfig.declarations,
    imports: [
      BrowserModule,
      FormsModule,
      HttpModule,
      //...sharedConfig.imports
      sharedConfig.imports
    ],
    providers: [
      //{ provide: 'ORIGIN_URL', useValue: location.origin },
      { provide: 'ORIGIN_URL', useValue: ORIGIN_URL },
        sharedConfig.providers
    ]
})
export class AppModule {
}
