import { Component, Input, OnDestroy, OnInit, TemplateRef } from '@angular/core';
import { Subject, Subscription } from 'rxjs';
import { TopicsApiService } from '../../../services/api/topics/topics-api.service';
import { GeneralDataService } from '../../../services/general-data/general-data.service';
import { Topic } from '../../../models/topics/topic';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

import * as conformityModal from '../../../../assets/conformities/conformity-modal.json';
import { CloseModalsService } from '../../../services/modals/close-modals/close-modals.service';

@Component({
  selector: 'app-edit-topics',
  templateUrl: './edit-topics.component.html',
  styleUrls: ['./edit-topics.component.scss']
})
export class EditTopicsComponent implements OnInit  {

  @Input() closeModalId?: number;
  private searchTopics = new Subject<string>();
  searchEditTopic: string = '';
  receivedTopics: Topic[];
  modalRef: BsModalRef;
  modalId = conformityModal.EditTopicsComponent;
  subscriptions: Subscription[] = [];
  
  config = {
    backdrop: true,
    class: 'modal-lg',
    id: this.modalId
  };

  constructor(private generalData: GeneralDataService, 
    private topicsApiService: TopicsApiService, 
    private modalService: BsModalService,
    private closeModalsService: CloseModalsService) { }

  ngOnInit(): void {
    this.generalData.topics.selectedTopics.subscribe(topics => {
      if (topics && topics.length > 0) {
        this.searchEditTopic = topics[0].value;
      }
    });
    
    this.searchTopics.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      switchMap((part: string) => this.topicsApiService.getTopics(part)),
    ).subscribe(topics => this.receivedTopics = topics);
  }
  
  onSearchTopics(part: string): void {
    this.searchTopics.next(part);
  }

  openModal(template: TemplateRef<any>) {
    this.closeModalsService.openModal(template, this.subscriptions, this.modalRef,this. modalId, this.closeModalId);

    // this.subscriptions.push(
    //   this.modalService.onHidden.subscribe((reason: string | any) => {
    //     if (this.closeModalId == reason.id) {
    //       this.modalRef = this.modalService.show(template, this.config );
    //     }
    //     else{
    //       this.unsubscribe(); 
    //     }
    //   })
    // );
    // if (this.closeModalId) {
    //   this.modalService.hide(this.closeModalId);
    // }
    // else {
    //   this.modalRef = this.modalService.show(template, this.config );
    // }
  }

  unsubscribe() {
    this.subscriptions.forEach((subscription: Subscription) => {
      subscription.unsubscribe();
    });
    this.subscriptions = [];
  }

}
