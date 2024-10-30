import { FormArray, FormControl, FormGroup } from '@angular/forms';
import { GameCreateRequest } from 'src/app/core/models/game.model';
import { PlayInstanceCreateRequest } from 'src/app/core/models/playInstance.model';

export type GameForm = {
    turns: FormControl<number | null>;
    notes: FormControl<string>;
    playInstances: FormArray<FormGroup<PlayInstanceForm>>;
};

export type PlayInstanceForm = {
    playGroupDeckId: FormControl<string | null>;
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
    const { playGroupDeckId, pilotId, turnOrder, endPosition, notes } =
        form.value;

    return {
        playGroupDeckId: playGroupDeckId!,
        pilotId: pilotId!,
        turnOrder: turnOrder!,
        endPosition: endPosition!,
        notes: notes ?? ''
    };
}
