import { Injectable } from '@angular/core';

class StorageProvider {
    protected storage;

    constructor() {}

    set(key, value) { return this.storage.setItem(key, JSON.stringify(value)); }

    get(key) { return JSON.parse(this.storage.getItem(key)); }

    remove(key) { return this.storage.removeItem(key); }

    clear() { return this.storage.clear(); }
}

class LocalStorageProvider extends StorageProvider {
    constructor() {
        super();
        this.storage = window.localStorage;
    }
}

class SessionStorageProvider extends StorageProvider {
    constructor() {
        super();
        this.storage = window.sessionStorage;
    }
}

@Injectable()
export class StorageService {
    private storage;

    constructor() { this.storage = new LocalStorageProvider(); }

    set(key, value) { return this.storage.set(key, value); }

    get(key) { return this.storage.get(key); }

    remove(key) { return this.storage.remove(key); }

    clear() { return this.storage.clear(); }
}
