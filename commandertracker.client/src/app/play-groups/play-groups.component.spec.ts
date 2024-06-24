import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayGroupsComponent } from './play-groups.component';

describe('PlayGroupsComponent', () => {
  let component: PlayGroupsComponent;
  let fixture: ComponentFixture<PlayGroupsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PlayGroupsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PlayGroupsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
