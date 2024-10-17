import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayGroupDeckComponent } from './play-group-deck.component';

describe('PlayGroupDeckComponent', () => {
  let component: PlayGroupDeckComponent;
  let fixture: ComponentFixture<PlayGroupDeckComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PlayGroupDeckComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PlayGroupDeckComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
