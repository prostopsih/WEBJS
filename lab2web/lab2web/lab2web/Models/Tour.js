
/**
 * @typedef Tour
 * @property {integer} id
 * @property {string} name
 * @property {string} country
 * @property {int} price
 * @property {int} maxTouristsCount
 * @property {date} startDate
 */
class Tour {
    constructor(id = -1, name = null, country = null, price = null, maxTouristsCount = null, startDate = null) {
        this.id = id;
        this.name = name;
        this.country = country;
        this.price = price;
        this.maxTouristsCount = maxTouristsCount;
        this.startDate = startDate;
    }
}

module.exports = Tour;