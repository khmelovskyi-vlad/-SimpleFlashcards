import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FlashcardsRoutingModule } from './flashcards-routing.module';
import { FlashcardsComponent } from './flashcards/flashcards.component';
import { FlashcardsHeaderComponent } from './flashcards-header/flashcards-header.component';
import { CreateFlashcardModalComponent } from './create-flashcard-modal/create-flashcard-modal.component';
import { FormsModule } from '@angular/forms';
import { AudiosModule } from '../audios/audios.module';
import { ModalsModule } from '../modals/modals.module';


@NgModule({
  declarations: [FlashcardsComponent, FlashcardsHeaderComponent, CreateFlashcardModalComponent],
  imports: [
    CommonModule,
    FormsModule,
    FlashcardsRoutingModule,
    AudiosModule,
    ModalsModule
  ]
})
export class FlashcardsModule { }
