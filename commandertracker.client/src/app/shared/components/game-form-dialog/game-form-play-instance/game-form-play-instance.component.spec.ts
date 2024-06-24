import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GameFormPlayInstanceComponent } from './game-form-play-instance.component';

describe('GameFormPlayInstanceComponent', () => {
  let component: GameFormPlayInstanceComponent;
  let fixture: ComponentFixture<GameFormPlayInstanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GameFormPlayInstanceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GameFormPlayInstanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
