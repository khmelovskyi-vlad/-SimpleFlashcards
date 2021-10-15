import { TemplateRef } from "@angular/core";

export class ParentModalData {
  constructor(public event: any, public closeModalId?: number){

  }
  open(){
    if (this.event) {
      this.event();
    }
  }
}