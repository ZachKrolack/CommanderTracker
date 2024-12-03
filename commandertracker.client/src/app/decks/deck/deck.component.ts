import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { DeckApiService } from 'src/app/core/api/deck.api.service';
import { Deck } from 'src/app/core/models/deck.model';
import { GameSummaryComponent } from 'src/app/shared/components/game-summary/game-summary.component';
import { PageContainerComponent } from 'src/app/shared/components/page/page-container/page-container.component';
import { PageHeaderComponent } from 'src/app/shared/components/page/page-header/page-header.component';

@Component({
    selector: 'app-deck',
    standalone: true,
    imports: [
        CommonModule,
        PageContainerComponent,
        PageHeaderComponent,
        GameSummaryComponent
    ],
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
