import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PilotFormDialogComponent } from './pilot-form-dialog.component';

describe('PilotFormDialogComponent', () => {
    let component: PilotFormDialogComponent;
    let fixture: ComponentFixture<PilotFormDialogComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            imports: [PilotFormDialogComponent]
        }).compileComponents();

        fixture = TestBed.createComponent(PilotFormDialogComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
