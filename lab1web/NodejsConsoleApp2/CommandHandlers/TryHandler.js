const EntityRepository = require('./../Repositories/EntityRepository');
const Tour = require('./../Models/Tour')
const readlineSync = require('readline-sync')

const tourRepo = new EntityRepository('./Data/Tours.json', Tour);

const commandsHandler = [];
commandsHandler['get_tours'] = () => {
    const tours = tourRepo.GetEntities();
    for (const tour of tours) {
        console.log(tour.id, tour.name, tour.country);
    }
};
commandsHandler['get_tourbyid'] = () => {
    const input = readlineSync.question('Enter id: ');
    const tour = tourRepo.GetEntityById(input);
    if (tour != null) {
        console.log(tour.id, tour.name, tour.country, tour.price, tour.maxTouristsCount, tour.startDate)
    }
    else {
        console.log('incorrect index...');
    }
}
commandsHandler['delete_tour'] = () => {
    const input = readlineSync.question('Enter id: ');
    try {
        tourRepo.DeleteEntity(input);
        console.log('Deleted');
    }
    catch {
        console.log('Nothing changed...');
    }

}
commandsHandler['update_tour'] = () => {
    const input = readlineSync.question('Enter id: ');
    const tour = tourRepo.GetEntityById(input);
    if (tour != null) {
        console.log('Tour: ', tour.id, tour.name, tour.country, tour.price, tour.maxTouristsCount, tour.startDate);
        const name = readlineSync.question('Enter tour name: ');
        tour.name = name;
        const country = readlineSync.question('Enter tour country: ');
        tour.country = country;
        const price = readlineSync.question('Enter tour price: ');
        const numPrice = Number(price);
        if (numPrice.toString() != 'NaN' && numPrice.toFixed() > 0) {
            tour.price = numPrice;
            const maxTouristsCount = readlineSync.question('Enter tour maxTouristsCount: ');
            const numMaxTouristsCount = Number(maxTouristsCount);
            if (numMaxTouristsCount.toString() != 'NaN' && numMaxTouristsCount.toFixed() > 0) {
                tour.maxTouristsCount = numMaxTouristsCount.toFixed();
                const startDate = readlineSync.question('Enter tour startDate: ');
                try {
                    const dateStartDate = new Date(startDate);
                    const strStartDate = dateStartDate.toISOString();
                    tour.startDate = strStartDate;
                    console.log('ok');
                    tourRepo.UpdateEntity(tour);
                    console.log('ok');

                    console.log('the value is changed');
                }
                catch (err) {
                    console.log('incorrect startDate format');
                    console.log('nothing changed...');
                }
            }
            else {
                console.log('incorrect maxTouristsCount format');
                console.log('nothing changed...');
            }
        }
        else {
            console.log('incorrect price format');
            console.log('nothing changed...');
        }
    }
    else {
        console.log('incorrect index...');
    }
}
commandsHandler['post_tour'] = () => {
    tour = new Tour();
    const name = readlineSync.question('Enter tour name: ');
    tour.name = name;
    const country = readlineSync.question('Enter tour country: ');
    tour.country = country;
    const price = readlineSync.question('Enter tour price: ');
    const numPrice = Number(price);
    if (numPrice.toString() != 'NaN' && numPrice.toFixed() > 0) {
        tour.price = numPrice;
        const maxTouristsCount = readlineSync.question('Enter tour maxTouristsCount: ');
        const numMaxTouristsCount = Number(maxTouristsCount);
        if (numMaxTouristsCount.toString() != 'NaN' && numMaxTouristsCount.toFixed() > 0) {
            tour.maxTouristsCount = numMaxTouristsCount.toFixed();
            const startDate = readlineSync.question('Enter tour startDate: ');
            try {
                const dateStartDate = new Date(startDate);
                const strStartDate = dateStartDate.toISOString();
                tour.startDate = strStartDate;
                tourRepo.AddEntity(tour);

                console.log('the value is added');
            }
            catch (err) {
                console.log('incorrect startDate format');
                console.log('nothing changed...');
            }
        }
        else {
            console.log('incorrect maxTouristsCount format');
            console.log('nothing changed...');
        }
    }
    else {
        console.log('incorrect price format');
        console.log('nothing changed...');
    }
}


module.exports = commandsHandler;