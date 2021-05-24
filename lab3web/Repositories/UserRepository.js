const User = require('./../Models/User');
const JsonStorage = require('./JsonStorage')


class UserRepository {

    constructor(filePath) {
        this.userStorage_ = new JsonStorage(filePath);
    }

    getUsers() {
        const items = this.userStorage_.readItems();
        const users = [];
        for (const item of items) {
            users.push(new User(item.id, item.login, item.fullname, item.Bio, item.media));
        }
        return users;
    }

    getUserById(id) {
        const items = this.userStorage_.readItems();
        for (const item of items) {
            if (item.id == id) {
                return new User(item.id, item.login, item.fullname, item.Bio, item.media);
            }
        }
        return null;
    }
};

module.exports = UserRepository;
