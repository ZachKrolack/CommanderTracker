import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GamePlayInstanceCardComponent } from './game-play-instance-card.component';

describe('GamePlayInstanceCardComponent', () => {
    let component: GamePlayInstanceCardComponent;
    let fixture: ComponentFixture<GamePlayInstanceCardComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            imports: [GamePlayInstanceCardComponent]
        }).compileComponents();

        fixture = TestBed.createComponent(GamePlayInstanceCardComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
