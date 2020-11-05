const express = require('express');
const userController = require('./../Controllers/UserController');
const User = require('../Models/User');
const Router = express.Router();

/**
 * returns all users
 * @route GET /api/users/
 * @group Users - user operations
 * @param {integer} page.query - page number
 * @param {integer} per_page.query - items per page
 * @returns {Array.<User>} User - all users
 */
Router.get('/', userController.getUsers)
/**
* return user by id
* @route GET /api/users/{id}
* @group Users - user operations
* @param {integer} id.path.required - id of the User - eg: 1
* @returns {User.model} 200 - User object
* @returns {Error} 404 - User not found
*/
    .get('/:id', userController.getUserById);

module.exports = Router;