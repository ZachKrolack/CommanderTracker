import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayGroupGamesComponent } from './play-group-games.component';

describe('PlayGroupGamesComponent', () => {
  let component: PlayGroupGamesComponent;
  let fixture: ComponentFixture<PlayGroupGamesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PlayGroupGamesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PlayGroupGamesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
