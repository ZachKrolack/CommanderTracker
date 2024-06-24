import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, switchMap } from 'rxjs';
import { DeckService } from 'src/app/core/api/deck.service';
import { Deck } from 'src/app/core/models/deck.model';
import { GameCardComponent } from 'src/app/shared/components/game-card/game-card.component';

@Component({
    selector: 'app-deck',
    standalone: true,
    imports: [CommonModule, GameCardComponent],
    templateUrl: './deck.component.html',
    styleUrl: './deck.component.scss'
})
export class DeckComponent implements OnInit {
    deck$!: Observable<Deck>;

    constructor(
        private deckService: DeckService,
        private route: ActivatedRoute
    ) {}

    ngOnInit(): void {
        this.deck$ = this.route.params.pipe(
            switchMap(({ id }) => this.getDeck(id))
        );
    }

    private getDeck(id: string): Observable<Deck> {
        return this.deckService.getDeck(id);
    }
}
