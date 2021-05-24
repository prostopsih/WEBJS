const UserRepositpory = require('./../Repositories/UserRepository')

const userRepo = new UserRepositpory('./Data/Users.json');

module.exports = {
    getUsers(req, res) {
        const page = req.query.page;
        const per_page = req.query.per_page;
        if (page && per_page) {
            res.send(userRepo.getUsers().slice((page - 1) * per_page, page * per_page));
        }
        else {
            res.send(userRepo.getUsers());
        }
        res.end();
    },
    getUserById(req, res) {
        const user = userRepo.getUserById(req.params.id);
        if (user) {
            res.send(user);
        }
        else {
            res.sendStatus(404);
        }
        res.end();
    },
};
