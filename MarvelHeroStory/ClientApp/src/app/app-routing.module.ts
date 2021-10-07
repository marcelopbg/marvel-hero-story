import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MarvelStoryComponent } from './marvel-story/marvel-story.component';

const routes: Routes = [
  { path: 'story', component: MarvelStoryComponent },
  { path: '', redirectTo: '/story', pathMatch: 'full' },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
