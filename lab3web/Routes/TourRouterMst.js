const express = require('express');
const tourController = require('./../Controllers/TourControllerMst');

const Router = express.Router();

Router
    .get('/', tourController.GetTours)
    .get("/new", tourController.NewTour)
    .get('/:id', tourController.GetTourHandler, tourController.GetTourById)
    .post('/', tourController.AddTour)
    .post('/:id', tourController.GetTourHandler, tourController.DeleteTourById);
module.exports = Router;