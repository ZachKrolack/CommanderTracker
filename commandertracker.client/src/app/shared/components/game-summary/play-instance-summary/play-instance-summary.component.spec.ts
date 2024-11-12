import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayInstanceSummaryComponent } from './play-instance-summary.component';

describe('PlayInstanceSummaryComponent', () => {
    let component: PlayInstanceSummaryComponent;
    let fixture: ComponentFixture<PlayInstanceSummaryComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            imports: [PlayInstanceSummaryComponent]
        }).compileComponents();

        fixture = TestBed.createComponent(PlayInstanceSummaryComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
