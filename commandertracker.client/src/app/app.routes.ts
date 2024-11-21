import { Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';
import { NoAuthGuard } from './core/guards/no-auth.guard';
import { DeckComponent } from './decks/deck/deck.component';
import { DecksComponent } from './decks/decks.component';
import { GameComponent } from './games/game/game.component';
import { GamesComponent } from './games/games.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { PilotComponent } from './pilot/pilot.component';
import { PlayGroupDeckComponent } from './play-groups/play-group/play-group-decks/play-group-deck/play-group-deck.component';
import { PlayGroupDecksComponent } from './play-groups/play-group/play-group-decks/play-group-decks.component';
import { PlayGroupGamesComponent } from './play-groups/play-group/play-group-games/play-group-games.component';
import { PlayGroupPilotsComponent } from './play-groups/play-group/play-group-pilots/play-group-pilots.component';
import { PlayGroupComponent } from './play-groups/play-group/play-group.component';
import { PlayGroupsComponent } from './play-groups/play-groups.component';
import { RegisterComponent } from './register/register.component';

export const routes: Routes = [
    {
        path: 'login',
        component: LoginComponent,
        canActivate: [NoAuthGuard],
        title: 'Login | CT'
    },
    {
        path: 'register',
        component: RegisterComponent,
        canActivate: [NoAuthGuard],
        title: 'Register | CT'
    },
    {
        path: '',
        component: HomeComponent,
        canActivate: [AuthGuard],
        title: 'CT'
    },
    {
        path: 'play-groups',
        component: PlayGroupsComponent,
        canActivate: [AuthGuard],
        title: 'Your Play Groups | CT'
    },
    {
        path: 'play-groups/:playGroupId',
        component: PlayGroupComponent,
        // canActivate: [AuthGuard], // TODO
        children: [
            {
                path: '',
                pathMatch: 'full',
                redirectTo: 'games'
            },
            {
                path: 'decks',
                component: PlayGroupDecksComponent
            },
            {
                path: 'decks/:deckId',
                component: PlayGroupDeckComponent
            },
            {
                path: 'games',
                component: PlayGroupGamesComponent
            },
            {
                path: 'pilots',
                component: PlayGroupPilotsComponent
            }
        ]
    },
    {
        path: 'decks',
        component: DecksComponent,
        canActivate: [AuthGuard],
        title: 'Your Decks | CT'
    },
    {
        path: 'decks/:id',
        component: DeckComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'games',
        component: GamesComponent,
        canActivate: [AuthGuard],
        title: 'Your Games | CT'
    },
    {
        path: 'games/:id',
        component: GameComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'pilots/:id',
        component: PilotComponent,
        canActivate: [AuthGuard]
    },
    {
        path: '**',
        redirectTo: '/'
    }
];
