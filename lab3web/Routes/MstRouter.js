const userRouter = require('./UserRouterMst');
const tourRouter = require('./TourRouterMst');
const Router = require('express').Router();

Router.use('/users', userRouter);
Router.use('/tours', tourRouter);
Router.get('/', function (req, res) {
    res.render('index', { index_current: 'current', home_link: 'disabled_link' });
});

Router.get('/about', function (req, res) {
    res.render('about', { about_current: 'current', about_link: 'disabled_link' });
});


module.exports = Router;