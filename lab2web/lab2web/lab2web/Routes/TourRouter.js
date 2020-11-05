const express = require('express');
const tourController = require('./../Controllers/TourController');

const Router = express.Router();

/**
 * returns all tours
 * @route GET /api/tours/
 * @group Tours - tour operations
 * @param {integer} page.query - page number
 * @param {integer} per_page.query - items per page
 * @returns {Array.<Tour>} Tours - all tours
 */
Router.get('/', tourController.GetTours)
/**
* return tour by id
* @route GET /api/tours/{id}
* @group Tours - tour operations
* @param {integer} id.path.required - id of the Tour - eg: 1
* @returns {Tour.model} 200 - Tour object
* @returns {Error} 404 - Tour not found
*/
    .get('/:id', tourController.GetTourHandler, tourController.GetTourById)
/**
* add tour
* @route POST /api/tours/
* @group Tours - tour operations
* @param {Tour.model} id.body.required - new Tour object
* @returns {Tour.model} 201 - added Tour object
*/
    .post('/', tourController.AddTour)
/**
* update tour
* @route PUT /api/tours/
* @group Tours - tour operations
* @param {Tour.model} id.body.required - new Tour object
* @returns {Tour.model} 200 - changed Tour object
*/
    .put('/', tourController.UpdateTour)
/**
* delete tour
* @route DELETE /api/tours/{id}
* @group Tours - tour operations
* @param {integer} id.path.required - id of the Tour - eg: 1
* @returns {Tour.model} 200 - deleted Tour object
* @returns {Error} 404 - Tour not found
*/
    .delete('/:id', tourController.GetTourHandler, tourController.DeleteTourById);


module.exports = Router;