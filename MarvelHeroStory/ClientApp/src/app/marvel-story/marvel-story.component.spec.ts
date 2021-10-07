import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarvelStoryComponent } from './marvel-story.component';

describe('MarvelStoryComponent', () => {
  let component: MarvelStoryComponent;
  let fixture: ComponentFixture<MarvelStoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MarvelStoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MarvelStoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
