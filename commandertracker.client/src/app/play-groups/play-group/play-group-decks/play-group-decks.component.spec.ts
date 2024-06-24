import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayGroupDecksComponent } from './play-group-decks.component';

describe('PlayGroupDecksComponent', () => {
  let component: PlayGroupDecksComponent;
  let fixture: ComponentFixture<PlayGroupDecksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PlayGroupDecksComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PlayGroupDecksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
