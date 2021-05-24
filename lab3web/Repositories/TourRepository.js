const Tour = require('./../Models/Tour');
const JsonStorage = require('./JsonStorage')


class TourRepository {
    constructor(filePath) {
        this.tourStorage_ = new JsonStorage(filePath);
    }
    AddTour(tour) {
        const tours = this.GetTours();

        tour.id = this.tourStorage_.nextId;
        this.tourStorage_.incrementNextId();
        tours.push(tour);
        this.tourStorage_.writeItems(tours);
        return tour.id;
    }
    DeleteTour(id) {
        const tours = this.GetTours();
        const tour = this.GetTourById(id);

        if (tour != null) {

            const index = tours.findIndex((x) => {
                return x.id == id;
            });
            tours.splice(index, 1);
            this.tourStorage_.writeItems(tours);
        }
        else {
            throw new Error('there is no tour like this');
        }


    }
    GetTours() {
        const items = this.tourStorage_.readItems();
        const tours = [];
        for (const item of items) {
            tours.push(new Tour(item.id, item.name, item.country, item.price, item.maxTouristsCount, item.startDate, item.media));
        }
        return tours;
    }
    GetToursByName(name) {
        const items = this.tourStorage_.readItems();
        const tours = [];
        for (const item of items) {
            if (item.name.includes(name)) {
                tours.push(new Tour(item.id, item.name, item.country, item.price, item.maxTouristsCount, item.startDate, item.media));
            }
        }
        return tours;
    }
    GetTourById(id) {
        const items = this.tourStorage_.readItems();
        for (const item of items) {
            if (item.id == id) {
                return new Tour(item.id, item.name, item.country, item.price, item.maxTouristsCount, item.startDate, item.media);
            }
        }
        return null;
    }
    UpdateTour(tour) {
        const tours = this.GetTours();
        const tour_ = this.GetTourById(tour.id);

        if (tour_ != null) {
            const index = tours.findIndex((x) => {
                return x.id == tour.id;
            });
            tours.splice(index, 1);
            tours.push(tour);
            this.tourStorage_.writeItems(tours);
        }
    }
}

module.exports = TourRepository;