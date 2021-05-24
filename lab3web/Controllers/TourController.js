const TourRepository = require('./../Repositories/TourRepository');

const tourRepo = new TourRepository('./Data/Tours.json');

const tourProperty = Symbol('tour');

module.exports = {
    GetTours(req, res) {
        const page = req.query.page;
        const per_page = req.query.per_page;
        if (page && per_page) {
            res.send(tourRepo.GetTours().slice((page - 1) * per_page, page * per_page));
        }
        else {
            res.send(tourRepo.GetTours());
        }
        res.end();
    },
    GetTourById(req, res, next) {
        res.send(req[tourProperty]);
        res.end();
    },
    DeleteTourById(req, res, next) {
        tourRepo.DeleteTour(req[tourProperty].id);
        res.send(req[tourProperty]);
    },
    AddTour(req, res, next) {
        const id = tourRepo.AddTour(req.body);
        res.status(201);
        res.send(tourRepo.GetTourById(id));
        res.end();
    },
    UpdateTour(req, res, next) {
        const tour = tourRepo.GetTourById(req.body.id);
        if (tour) {
            tourRepo.UpdateTour(req.body);

            res.send(tourRepo.GetTourById(req.body.id));
        }
        else {
            res.sendStatus(404);
        }
        res.end();
        
        
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