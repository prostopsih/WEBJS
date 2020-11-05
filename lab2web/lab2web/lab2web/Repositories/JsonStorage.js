const fs = require('fs');
class JsonStorage {
    
    constructor(filePath) {
       this.filePath_ = filePath;
    }

    get nextId() {
        const id = (JSON.parse(fs.readFileSync(this.filePath_))).nextId;
        return id;
    }

    incrementNextId() {
        const file = (JSON.parse(fs.readFileSync(this.filePath_)));
        file.nextId = file.nextId + 1;
        fs.writeFileSync(this.filePath_, JSON.stringify(file));
    }

    readItems() {
        const items = (JSON.parse(fs.readFileSync(this.filePath_))).items;
        return items;
    }

    writeItems(items) {
        const file = (JSON.parse(fs.readFileSync(this.filePath_)));
        file.items = items;
        fs.writeFileSync(this.filePath_, JSON.stringify(file, null, 4));
    }
};

module.exports = JsonStorage;