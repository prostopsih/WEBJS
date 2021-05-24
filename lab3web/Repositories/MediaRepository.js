const fs = require('fs');
const path = require('path');
const JsonStorage = require('./JsonStorage');
const Media = require('./../Models/Media');

class MediaRepository {
    constructor(filePath) {
        this.storage = new JsonStorage(filePath + '/NextId.json');
        this.filePath = filePath;
    }
    AddMedia(media) {
        const fileFormat = media.mimetype.split('/')[1];
        const file = this.storage.readAll();
        fs.writeFileSync(path.resolve(__dirname, '../Data/Media/' + file.id + '.' + fileFormat), media.data, (err) => {
            if (err) {
                throw Error("Err with loading photo");
            }
        });
        file.id += 1;
        fs.writeFileSync(`${this.filePath}/NextId.json`, JSON.stringify(file));
        return file.id - 1;
    }
    GetMediaPathById(id) {
        const file = this.storage.readAll();
        for (const format of file.fileFormat) {
            const media_path = path.resolve(__dirname, '../Data/Media/' + (file.id - 1) + '.' + format);
            if (fs.existsSync(media_path)) {
                return new Media('/Media/' + (file.id - 1) + '.' + format);
            }
        }
        return null;
    }

}
module.exports = MediaRepository;