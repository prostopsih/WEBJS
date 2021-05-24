const express = require('express');
const Router = express.Router();
const userRouter = require('./UserRouter');
const tourRouter = require('./TourRouter');
const mediaRouter = require('./MediaRouter');

Router.use('/users', userRouter);
Router.use('/tours', tourRouter);
Router.use('/media', mediaRouter);

module.exports = Router;