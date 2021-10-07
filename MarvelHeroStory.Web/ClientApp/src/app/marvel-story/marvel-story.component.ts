import { Component, OnInit } from '@angular/core';
import { IStory } from '../model/story.model';
import { StoryService } from '../services/story.service';

@Component({
  selector: 'app-marvel-story',
  templateUrl: './marvel-story.component.html',
  styleUrls: ['./marvel-story.component.css']
})
export class MarvelStoryComponent implements OnInit {
  isLoading = true;
  story?: IStory;
  constructor(private storyService: StoryService) { }

  ngOnInit(): void {
    this.storyService.getStory().subscribe(r => {
      this.story = r
      this.isLoading = false;
    });
  }

}
