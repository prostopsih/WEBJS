const MediaRepository = require('./../Repositories/MediaRepository');
const Media = require('../Models/Media');

const mediaRepo = new MediaRepository('./Data/Media');

module.exports = {
    getMediaById(req, res) {
        const media = mediaRepo.GetMediaPathById(req.params.id);
        if (media != null) {
            res.download(media.path);
            res.send(media);
            res.end();
        }
        else {
            res.sendStatus(404);
        }


    },
    addMedia(req, res) {
        try {
            const id = mediaRepo.AddMedia(new Media(req.file.path));
            res.status(201).json(id);
            res.end();
        }
        catch {
            res.sendStatus(400);
        }
    }
};