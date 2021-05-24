const path = require('path');
const fs = require('fs');
const TourRepository = require('./../Repositories/TourRepository');
const tourRepo = new TourRepository('./Data/Tours.json');
const tourProperty = Symbol('tour');

const MediaRepository = require(path.resolve(__dirname, '../Repositories/MediaRepository'));
const mediaRepo = new MediaRepository(path.resolve(__dirname, '../Data/Media'));
const Media = require('../Models/Media');


module.exports = {
    GetTours(req, res) {
        let page;

        if (req.query.page && isNaN(req.query.page)) {
            res.status(400).send({ mess: 'page and per_page should be a number' });
            return;
        }

        if (!req.query.page) {
            page = 1;
        } else {
            page = parseInt(req.query.page);
        }

        const per_page = 4;
        let class_prev;
        let class_next;

        if (page > 1) {
            class_prev = "";
        } else {
            class_prev = "disabled_link";
        }
        let Tours;
        let name = "";
        if (req.query.name) {
            Tours = tourRepo.GetToursByName(req.query.name);
            name = req.query.name;
        } else {
            Tours = tourRepo.GetTours();
        }
        if (page * per_page < Tours.length) {
            class_next = "";
        } else {
            class_next = "disabled_link";
        }


        let max_page = Math.ceil(parseInt(Tours.length) / (per_page));
        if (max_page == 0) {
            max_page = 1;
        }
        res.render('tours',
            {
                tours: Tours.slice((page - 1) * per_page, page * per_page),
                search_name: name, tour_current: 'current', next_page: page + 1,
                previous_page: page - 1, page, class_prev, class_next, max_page, tour_link: 'disabled_link'
            });
    },
    GetTourById(req, res, next) {
        res.render('tour', { tour: req[tourProperty], tour_current: 'current' });
    },
    NewTour(req, res) {
        res.render('add_tour');
    },
    DeleteTourById(req, res, next) {
        tourRepo.DeleteTour(req[tourProperty].id);
        res.redirect('/tours');
    },
    AddTour(req, res, next) {
        let media_path = "";
        if (req.files['photo']) {
            const media_id = mediaRepo.AddMedia(req.files['photo']);
            media_path = mediaRepo.GetMediaPathById(media_id);
        }
        req.body.media = media_path;
        const id = tourRepo.AddTour(req.body);
        res.status(201);
        res.redirect('/tours/' + id);
    },
    GetTourHandler(req, res, next) {
        const tour = tourRepo.GetTourById(parseInt(req.params.id));
        if (tour) {
            req[tourProperty] = tour;
            next();
        }
        else {
            res.sendStatus(404);
        }
    }
};