const express = require('express');
const mediaController = require('./../Controllers/MediaController');
const Router = express.Router();
const multer = require('multer');

const upload = multer({ dest: 'uploads/' });
/**
* return media by id
* @route GET /api/media/{id}
* @group Media - upload and get images
* @param {integer} id.path.required - id of the media - eg: 1
* @returns 200 - media object
* @returns {Error} 404 - Media not found
*/
Router.get('/:id', mediaController.getMediaById)
/**
* return media file
* @route POST /api/media
* @group Media - upload and get images
* @consumes multipart/form-data
* @param {file} image.formData.required - uploaded image
* @returns {integer} 200 - added image id
*/
    .post('/', upload.single('image'), mediaController.addMedia);

module.exports = Router;