const MIN_KEY: Readonly<string> = createReplacementKey('min');
const MAX_KEY: Readonly<string> = createReplacementKey('max');

const REQUIRED: Readonly<string> = 'Field is required';
const MIN: Readonly<string> = `Field value must be ${MIN_KEY} or more`;
const MAX: Readonly<string> = `Field value must be ${MAX_KEY} or less`;

export const FORM_ERROR_CONSTANTS = Object.freeze({
    REQUIRED,
    MIN,
    MAX
});

export const FORM_ERROR_REPLACEMENT_KEYS = Object.freeze({
    MIN: MIN_KEY,
    MAX: MAX_KEY
});

function createReplacementKey(key: string): string {
    return '${' + key + '}';
}
