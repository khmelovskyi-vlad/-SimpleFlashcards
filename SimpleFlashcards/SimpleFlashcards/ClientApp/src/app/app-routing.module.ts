import { NgModule } from '@angular/core';
import { Routes, RouterModule, UrlSegment } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren:() => import('./main/main.module').then(m => m.MainModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GoodRoutingModule { }
