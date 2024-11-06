import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayGroupTableComponent } from './play-group-table.component';

describe('PlayGroupTableComponent', () => {
  let component: PlayGroupTableComponent;
  let fixture: ComponentFixture<PlayGroupTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PlayGroupTableComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PlayGroupTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
