const Router = require('express').Router();

const userController = require('../Controllers/UserControllerMst');

Router
    .get("/:id", userController.GetUserById)
    .get("/", userController.GetUsers);


module.exports = Router;