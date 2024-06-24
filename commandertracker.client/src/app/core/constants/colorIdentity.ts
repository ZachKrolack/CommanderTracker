import {
    ColorIdentity,
    ColorIdentityStringWubrgOrder
} from '../enums/colorIdentity.enum';
import { BidirectionalMap } from '../utils/BidirectionalMap';

export const WHITE: Readonly<string> = 'w';
export const BLUE: Readonly<string> = 'u';
export const BLACK: Readonly<string> = 'b';
export const RED: Readonly<string> = 'r';
export const GREEN: Readonly<string> = 'g';

export const COLOR_INDENTITY_ORDER: ReadonlyArray<string> = [
    WHITE,
    BLUE,
    BLACK,
    RED,
    GREEN
];

export const ColorIdentityMap: BidirectionalMap<
    ColorIdentity,
    ColorIdentityStringWubrgOrder
> = new BidirectionalMap([
    [ColorIdentity.Colorless, ColorIdentityStringWubrgOrder.Colorless],
    [ColorIdentity.MonoWhite, ColorIdentityStringWubrgOrder.MonoWhite],
    [ColorIdentity.MonoBlue, ColorIdentityStringWubrgOrder.MonoBlue],
    [ColorIdentity.MonoBlack, ColorIdentityStringWubrgOrder.MonoBlack],
    [ColorIdentity.MonoRed, ColorIdentityStringWubrgOrder.MonoRed],
    [ColorIdentity.MonoGreen, ColorIdentityStringWubrgOrder.MonoGreen],
    [ColorIdentity.Azorius, ColorIdentityStringWubrgOrder.Azorius],
    [ColorIdentity.Dimir, ColorIdentityStringWubrgOrder.Dimir],
    [ColorIdentity.Rakdos, ColorIdentityStringWubrgOrder.Rakdos],
    [ColorIdentity.Gruul, ColorIdentityStringWubrgOrder.Gruul],
    [ColorIdentity.Selesnya, ColorIdentityStringWubrgOrder.Selesnya],
    [ColorIdentity.Orzhov, ColorIdentityStringWubrgOrder.Orzhov],
    [ColorIdentity.Izzet, ColorIdentityStringWubrgOrder.Izzet],
    [ColorIdentity.Golgari, ColorIdentityStringWubrgOrder.Golgari],
    [ColorIdentity.Boros, ColorIdentityStringWubrgOrder.Boros],
    [ColorIdentity.Simic, ColorIdentityStringWubrgOrder.Simic],
    [ColorIdentity.Esper, ColorIdentityStringWubrgOrder.Esper],
    [ColorIdentity.Grixis, ColorIdentityStringWubrgOrder.Grixis],
    [ColorIdentity.Jund, ColorIdentityStringWubrgOrder.Jund],
    [ColorIdentity.Naya, ColorIdentityStringWubrgOrder.Naya],
    [ColorIdentity.Bant, ColorIdentityStringWubrgOrder.Bant],
    [ColorIdentity.Abzan, ColorIdentityStringWubrgOrder.Abzan],
    [ColorIdentity.Jeskai, ColorIdentityStringWubrgOrder.Jeskai],
    [ColorIdentity.Sultai, ColorIdentityStringWubrgOrder.Sultai],
    [ColorIdentity.Mardu, ColorIdentityStringWubrgOrder.Mardu],
    [ColorIdentity.Temur, ColorIdentityStringWubrgOrder.Temur],
    [ColorIdentity.YoreTiller, ColorIdentityStringWubrgOrder.YoreTiller],
    [ColorIdentity.GlintEye, ColorIdentityStringWubrgOrder.GlintEye],
    [ColorIdentity.DuneBrood, ColorIdentityStringWubrgOrder.DuneBrood],
    [ColorIdentity.InkTreader, ColorIdentityStringWubrgOrder.InkTreader],
    [ColorIdentity.WitchMaw, ColorIdentityStringWubrgOrder.WitchMaw],
    [ColorIdentity.FiveColor, ColorIdentityStringWubrgOrder.FiveColor]
]);
