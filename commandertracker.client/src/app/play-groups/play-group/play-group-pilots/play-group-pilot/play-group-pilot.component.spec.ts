import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayGroupPilotComponent } from './play-group-pilot.component';

describe('PlayGroupPilotComponent', () => {
  let component: PlayGroupPilotComponent;
  let fixture: ComponentFixture<PlayGroupPilotComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PlayGroupPilotComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PlayGroupPilotComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
