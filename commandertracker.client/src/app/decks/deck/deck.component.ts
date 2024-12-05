import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { DeckApiService } from 'src/app/core/api/deck.api.service';
import { Deck } from 'src/app/core/models/deck.model';
import { GameSummaryComponent } from 'src/app/shared/components/game-summary/game-summary.component';
import { PageModule } from 'src/app/shared/components/page/page.module';

@Component({
    selector: 'app-deck',
    standalone: true,
    imports: [CommonModule, PageModule, GameSummaryComponent],
    templateUrl: './deck.component.html',
    styleUrl: './deck.component.scss'
})
export class DeckComponent implements OnInit {
    @Input() id!: string;

    deck$!: Observable<Deck>;

    constructor(private deckApiService: DeckApiService) {}

    ngOnInit(): void {
        this.deck$ = this.getDeck(this.id);
    }

    private getDeck(id: string): Observable<Deck> {
        return this.deckApiService.getDeck(id);
    }
}
