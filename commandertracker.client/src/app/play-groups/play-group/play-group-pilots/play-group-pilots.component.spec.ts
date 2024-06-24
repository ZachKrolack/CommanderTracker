import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayGroupPilotsComponent } from './play-group-pilots.component';

describe('PlayGroupPilotsComponent', () => {
  let component: PlayGroupPilotsComponent;
  let fixture: ComponentFixture<PlayGroupPilotsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PlayGroupPilotsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PlayGroupPilotsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
