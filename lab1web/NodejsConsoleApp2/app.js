'start point'

const readlineSync = require('readline-sync')
const UserCommandsHandler = require('./CommandHandlers/UserCommandsHandler')
const TourCommandsHandler = require('./CommandHandlers/TryHandler')


while (true) {
    const input = readlineSync.question('Enter command: ').trim().toLowerCase();
    try {
        UserCommandsHandler[input]();
    }
    catch (ex) {
        try {
            TourCommandsHandler[input]();
        }
        catch (ex) {
            console.log('Wrong command');
        }
    }
}
