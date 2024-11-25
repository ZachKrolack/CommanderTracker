import { CommonModule } from '@angular/common';
import {
    AfterViewInit,
    Component,
    EventEmitter,
    Input,
    OnInit,
    Output,
    ViewChild
} from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatMenu, MatMenuModule } from '@angular/material/menu';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { RouterLink } from '@angular/router';
import { BaseDeck } from 'src/app/core/models/deck.model';
import { PlayGroup } from 'src/app/core/models/playGroup.model';
import { PlayGroupDeck } from 'src/app/core/models/playGroupDeck.model';
import { ColorIdentityDisplayComponent } from 'src/app/shared/components/color-identity-display/color-identity-display.component';
import { IsCreatedByPipe } from 'src/app/shared/pipes/is-created-by.pipe';
import { ToColorIdentityStringPipe } from 'src/app/shared/pipes/to-color-identity-string.pipe';

@Component({
    selector: 'app-play-group-decks-table',
    standalone: true,
    imports: [
        CommonModule,
        MatTableModule,
        MatSortModule,
        MatMenuModule,
        MatButtonModule,
        MatIconModule,
        RouterLink,
        ColorIdentityDisplayComponent,
        ToColorIdentityStringPipe,
        IsCreatedByPipe
    ],
    templateUrl: './play-group-decks-table.component.html',
    styleUrl: './play-group-decks-table.component.scss'
})
export class PlayGroupDecksTableComponent implements OnInit, AfterViewInit {
    @Input() playGroupDecks!: PlayGroupDeck[];
    dataSource!: MatTableDataSource<PlayGroupDeck>;
    @Input() playGroup: PlayGroup | null = null;
    @Input() userId: string | null = null;

    @Output() handleEditDeck: EventEmitter<BaseDeck> =
        new EventEmitter<BaseDeck>();
    @Output() handleRemoveDeckFromPlayGroup: EventEmitter<string> =
        new EventEmitter<string>();

    displayedColumns: string[] = ['name', 'colorIdentity', 'owner', 'actions'];

    @ViewChild(MatSort) sort!: MatSort;

    constructor() {}

    ngOnInit(): void {
        this.dataSource = new MatTableDataSource<PlayGroupDeck>(
            this.playGroupDecks
        );

        // TODO
        this.dataSource.sortingDataAccessor = (
            data: PlayGroupDeck,
            sortHeaderId: string
        ) => {
            switch (sortHeaderId) {
                case 'name':
                    return data.deck.name;
                case 'colorIdentity':
                    return data.deck.colorIdentity;
                default:
                    return data[sortHeaderId as keyof PlayGroupDeck] as
                        | string
                        | number;
            }
        };
    }

    ngAfterViewInit(): void {
        this.dataSource.sort = this.sort;
    }

    editDeck(deck: BaseDeck): void {
        this.handleEditDeck.emit(deck);
    }

    removeDeckFromPlayGroup(deckId: string): void {
        this.handleRemoveDeckFromPlayGroup.emit(deckId);
    }

    test(a: MatMenu) {
        console.log(a._allItems);
    }
}
