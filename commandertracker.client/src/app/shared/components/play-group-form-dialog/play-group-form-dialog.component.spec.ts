import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayGroupFormDialogComponent } from './play-group-form-dialog.component';

describe('PlayGroupFormDialogComponent', () => {
  let component: PlayGroupFormDialogComponent;
  let fixture: ComponentFixture<PlayGroupFormDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PlayGroupFormDialogComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PlayGroupFormDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
