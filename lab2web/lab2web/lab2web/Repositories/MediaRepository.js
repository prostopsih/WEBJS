const fs = require('fs');
const path = require('path');
const Media = require('./../Models/Media');

class MediaRepository {
    constructor(storage) {
        this.storage = storage;
    }
    AddMedia(media) {
        const file = JSON.parse(fs.readFileSync(`${this.storage}/NextId.json`));
        const storagepath = path.join(this.storage, `${file.id}`)

        fs.renameSync(media.path, storagepath);
        file.id += 1;
        fs.writeFileSync(`${this.storage}/NextId.json`, JSON.stringify(file));
        return file.id - 1;
    }
    GetMediaPathById(id) {
        const filepath = path.join(this.storage, id);
        if (fs.existsSync(filepath)) {
            return new Media(filepath);
        }
        return null;
    }
}
module.exports = MediaRepository;