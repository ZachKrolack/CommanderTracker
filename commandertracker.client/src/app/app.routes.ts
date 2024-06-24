import { Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';
import { NoAuthGuard } from './core/guards/no-auth.guard';
import { DeckComponent } from './decks/deck/deck.component';
import { DecksComponent } from './decks/decks.component';
import { GamesComponent } from './games/games.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
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
        canActivate: [NoAuthGuard]
    },
    {
        path: 'register',
        component: RegisterComponent,
        canActivate: [NoAuthGuard]
    },
    {
        path: '',
        component: HomeComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'play-groups',
        component: PlayGroupsComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'play-groups/:id',
        component: PlayGroupComponent,
        canActivate: [AuthGuard],
        children: [
            {
                path: 'decks',
                component: PlayGroupDecksComponent
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
        canActivate: [AuthGuard]
    },
    {
        path: 'decks/:id',
        component: DeckComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'games',
        component: GamesComponent,
        canActivate: [AuthGuard]
    },
    // {
    //     path: 'pilots',
    //     component: PilotsComponent,
    //     canActivate: [AuthGuard]
    // },
    // {
    //     path: 'pilots/:id',
    //     component: PilotComponent,
    //     canActivate: [AuthGuard]
    // },
    {
        path: '**',
        redirectTo: '/'
    }
];
