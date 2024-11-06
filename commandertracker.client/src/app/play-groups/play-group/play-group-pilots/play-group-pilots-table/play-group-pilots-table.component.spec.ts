import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayGroupPilotsTableComponent } from './play-group-pilots-table.component';

describe('PlayGroupPilotsTableComponent', () => {
  let component: PlayGroupPilotsTableComponent;
  let fixture: ComponentFixture<PlayGroupPilotsTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PlayGroupPilotsTableComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PlayGroupPilotsTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
