import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayGroupsTableComponent } from './play-groups-table.component';

describe('PlayGroupsTableComponent', () => {
  let component: PlayGroupsTableComponent;
  let fixture: ComponentFixture<PlayGroupsTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PlayGroupsTableComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PlayGroupsTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
