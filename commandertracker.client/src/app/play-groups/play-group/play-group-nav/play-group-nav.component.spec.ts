import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayGroupNavComponent } from './play-group-nav.component';

describe('PlayGroupNavComponent', () => {
  let component: PlayGroupNavComponent;
  let fixture: ComponentFixture<PlayGroupNavComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PlayGroupNavComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PlayGroupNavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
