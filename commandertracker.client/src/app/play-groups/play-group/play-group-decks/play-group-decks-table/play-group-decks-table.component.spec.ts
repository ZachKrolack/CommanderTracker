import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayGroupDecksTableComponent } from './play-group-decks-table.component';

describe('PlayGroupDecksTableComponent', () => {
  let component: PlayGroupDecksTableComponent;
  let fixture: ComponentFixture<PlayGroupDecksTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PlayGroupDecksTableComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PlayGroupDecksTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
