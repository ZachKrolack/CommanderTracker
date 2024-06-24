export class BidirectionalMap<Key, Value> {
    private readonly map: Map<Key, Value>;
    private readonly inverseMap: Map<Value, Key>;

    constructor(colorIdentities: [Key, Value][]) {
        this.map = new Map();
        this.inverseMap = new Map();

        colorIdentities.forEach(([key, value]) => {
            this.set(key, value);
        });
    }

    getKey(value: Value): Key | undefined {
        return this.inverseMap.get(value);
    }

    getValue(key: Key): Value | undefined {
        return this.map.get(key);
    }

    private hasKey(key: Key): boolean {
        return this.map.has(key);
    }

    private hasValue(value: Value): boolean {
        return this.inverseMap.has(value);
    }

    private set(key: Key, value: Value): void {
        if (this.hasKey(key)) {
            throw new Error(`Key '${key}' already exists.`);
        }

        if (this.hasValue(value)) {
            throw new Error(`Value '${value}' already exists.`);
        }

        this.map.set(key, value);
        this.inverseMap.set(value, key);
    }
}
