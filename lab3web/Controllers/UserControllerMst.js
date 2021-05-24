const path = require('path');
const User = require('../Models/User');
const userRepository = require(path.resolve(__dirname, '../Repositories/UserRepository'));
const userRepo = new userRepository(path.resolve(__dirname, '../Data/Users.json'));


function pagination(items, page, per_page) {
    const startInd = (page - 1) * per_page;
    const endInd = page * per_page;
    return (items.slice(startInd, endInd));

}

function ToUserFriendlyDate(Users) {
    Users.forEach(element => {
        date = new Date(element.registeredAt);
        element.registeredAt = date.toUTCString().replace('GMT', '');
    });
    return Users;

}

module.exports = {
    GetUsers(req, res) {
        let page, per_page;
        if (req.query.per_page && isNaN(req.query.per_page)) {
            res.status(400).send({ mess: 'per_page and page should be a number' });
            return;
        }

        if (req.query.page && isNaN(req.query.page)) {
            res.status(400).send({ mess: 'page and per_page should be a number' });
            return;
        }
        if (!req.query.per_page) {
            per_page = 4;
        } else if (parseInt(req.query.per_page) > 10 || parseInt(req.query.per_page) < 1) {
            res.status(400).send({ mess: 'per_page should`n be more than 10 and less then 1' });
            return;
        } else {
            per_page = parseInt(req.query.per_page);
        }

        if (!req.query.page) {
            page = 1;
        } else if (parseInt(req.query.page) < 0) {
            res.status(400).send({ mess: 'page should`n be less then 0' });
            return;
        } else {
            page = parseInt(req.query.page);
        }

        const Users = userRepo.getUsers();
        const Pag_Users = pagination(Users, page, per_page);
        const User_friendly = ToUserFriendlyDate(Pag_Users);
        res.status(200).render('users', { users: User_friendly, user_current: 'current', user_link: 'disabled_link' });
    },

    GetUserById(req, res) {
        if (isNaN(req.params.id)) {
            res.status(400).send({ mess: 'Wrong id' })
            return;
        }
        const User = userRepo.getUserById(parseInt(req.params.id));
        if (User == null) {
            res.status(404).send({ mess: 'No user with such id' });
            return;
        }
        date = new Date(User.registeredAt);
        User.registeredAt = date.toUTCString().replace('GMT', '');

        res.status(200).render('user', { user: User, user_current: 'current' });
    },
};