const UserStorage = require('./../Repositories/UserRepository')
const readlineSync = require('readline-sync')


const userRepo = new UserStorage('./Data/Users.json')


const commandsHandler = [];
commandsHandler['get_users'] = () => {
    const users = userRepo.getUsers();
    for (const user of users) {
        console.log(user.id, user.login, user.fullname);
    }
}
commandsHandler['get_userbyid'] = () => {
    const input = readlineSync.question('Enter id: ');
    const user = userRepo.getUserById(input);
    if (user != undefined) {
        console.log(user.id, user.login, user.fullname, user.avaUrl, user.role, user.registeredAt, user.isEnabled);
    }
    else {
        console.log('incorrect index...');
    }
}
commandsHandler['exit'] = () => {
    process.exit();
}

module.exports = commandsHandler;