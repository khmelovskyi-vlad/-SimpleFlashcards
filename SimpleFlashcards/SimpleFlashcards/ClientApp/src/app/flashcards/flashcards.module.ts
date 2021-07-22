import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FlashcardsRoutingModule } from './flashcards-routing.module';
import { FlashcardsComponent } from './flashcards/flashcards.component';
import { FlashcardsHeaderComponent } from './flashcards-header/flashcards-header.component';


@NgModule({
  declarations: [FlashcardsComponent, FlashcardsHeaderComponent],
  imports: [
    CommonModule,
    FlashcardsRoutingModule
  ]
})
export class FlashcardsModule { }
