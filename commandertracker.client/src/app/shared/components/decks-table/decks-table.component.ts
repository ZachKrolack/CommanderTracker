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
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { RouterLink } from '@angular/router';
import { Deck } from 'src/app/core/models/deck.model';
import { ToColorIdentityStringPipe } from '../../pipes/to-color-identity-string.pipe';
import { ColorIdentityDisplayComponent } from '../color-identity-display/color-identity-display.component';

@Component({
    selector: 'app-decks-table',
    standalone: true,
    imports: [
        CommonModule,
        MatTableModule,
        MatSortModule,
        MatButtonModule,
        MatIconModule,
        RouterLink,
        ColorIdentityDisplayComponent,
        ToColorIdentityStringPipe
    ],
    templateUrl: './decks-table.component.html',
    styleUrl: './decks-table.component.scss'
})
export class DecksTableComponent implements OnInit, AfterViewInit {
    @Input() decks!: Deck[];
    dataSource!: MatTableDataSource<Deck>;

    @Output() handleEditDeck: EventEmitter<Deck> = new EventEmitter<Deck>();
    @Output() handleDeleteDeck: EventEmitter<string> =
        new EventEmitter<string>();

    displayedColumns: string[] = ['name', 'colorIdentity', 'actions'];

    @ViewChild(MatSort) sort!: MatSort;

    constructor() {}

    ngOnInit(): void {
        this.dataSource = new MatTableDataSource<Deck>(this.decks);
    }

    ngAfterViewInit(): void {
        this.dataSource.sort = this.sort;
    }

    editDeck(deck: Deck): void {
        this.handleEditDeck.emit(deck);
    }

    deleteDeck(id: string): void {
        this.handleDeleteDeck.emit(id);
    }
}