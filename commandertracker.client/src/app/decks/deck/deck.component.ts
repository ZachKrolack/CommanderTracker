import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { DeckService } from 'src/app/core/api/deck.service';
import { Deck } from 'src/app/core/models/deck.model';
import { GameSummaryComponent } from 'src/app/shared/components/game-summary/game-summary.component';
import { PlayInstanceAggregatorPipe } from './play-instance-aggregator.pipe';

@Component({
    selector: 'app-deck',
    standalone: true,
    imports: [CommonModule, GameSummaryComponent, PlayInstanceAggregatorPipe],
    templateUrl: './deck.component.html',
    styleUrl: './deck.component.scss'
})
export class DeckComponent implements OnInit {
    @Input() id!: string;

    deck$!: Observable<Deck>;

    constructor(private deckService: DeckService) {}

    ngOnInit(): void {
        this.deck$ = this.getDeck(this.id);
    }

    private getDeck(id: string): Observable<Deck> {
        return this.deckService.getDeck(id);
    }
}
