const TourRepository = require('./../Repositories/TourRepository');
const Tour = require('./../Models/Tour')
const readlineSync = require('readline-sync')

const tourRepo = new TourRepository('./Data/Tours.json');

const commandsHandler = [];
commandsHandler['get_tours'] = () => {
    const tours = tourRepo.GetTours();
    for (const tour of tours) {
        console.log(tour.id, tour.name, tour.country);
    }
};
commandsHandler['get_tourbyid'] = () => {
    const input = readlineSync.question('Enter id: ');
    const tour = tourRepo.GetTourById(input);
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
        tourRepo.DeleteTour(input);
        console.log('Deleted');
    }
    catch {
        console.log('Nothing changed...');
    }
    
}
commandsHandler['update_tour'] = () => {
    const input = readlineSync.question('Enter id: ');
    const tour = tourRepo.GetTourById(input);
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
                    tourRepo.UpdateTour(tour);

                    console.log('the value is changed');
                }
                catch (err){
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
                tourRepo.AddTour(tour);

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