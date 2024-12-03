import { FormArray, FormControl, FormGroup } from '@angular/forms';
import { GameCreateRequest } from 'src/app/core/models/game.model';
import { PlayGroupDeck } from 'src/app/core/models/playGroupDeck.model';
import { PlayInstanceCreateRequest } from 'src/app/core/models/playInstance.model';

export type GameForm = {
    turns: FormControl<number | null>;
    notes: FormControl<string>;
    playInstances: FormArray<FormGroup<PlayInstanceForm>>;
};

export type PlayInstanceForm = {
    playGroupDeck: FormControl<PlayGroupDeck | null>;
    pilotId: FormControl<string | null>;
    turnOrder: FormControl<number | null>;
    endPosition: FormControl<number | null>;
    notes: FormControl<string>;
};

export function parseGameCreateRequest(
    form: FormGroup<GameForm>
): GameCreateRequest {
    const { turns, notes } = form.value;

    form.controls.playInstances.length;

    return {
        turns: turns!,
        notes: notes ?? '',
        playInstances: form.controls.playInstances.controls.map(
            (playInstanceForm) =>
                parsePlayInstanceCreateRequest(playInstanceForm)
        )
    };
}

export function parsePlayInstanceCreateRequest(
    form: FormGroup<PlayInstanceForm>
): PlayInstanceCreateRequest {
    const { playGroupDeck, pilotId, turnOrder, endPosition, notes } =
        form.value;

    return {
        deckId: playGroupDeck!.deck!.id,
        playGroupDeckId: playGroupDeck!.id,
        pilotId: pilotId!,
        turnOrder: turnOrder!,
        endPosition: endPosition!,
        notes: notes ?? ''
    };
}
