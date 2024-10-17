import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayGroupGameComponent } from './play-group-game.component';

describe('PlayGroupGameComponent', () => {
  let component: PlayGroupGameComponent;
  let fixture: ComponentFixture<PlayGroupGameComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PlayGroupGameComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PlayGroupGameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
