class Tour {
    //constructor(id = -1, name = null, country = null, price = null, maxTouristsCount = null, startDate = null) {
    //    this.id = id;
    //    this.name = name;
    //    this.country = country;
    //    this.price = price;
    //    this.maxTouristsCount = maxTouristsCount;
    //    this.startDate = startDate;
    //}
    constructor(item = null) {
        if (item != null) {
            this.id = item.id;
            this.name = item.name;
            this.country = item.country;
            this.price = item.price;
            this.maxTouristsCount = item.maxTouristsCount;
            this.startDate = item.startDate;
        }
        else {
            this.id = -1;
            this.name = null;
            this.country = null;
            this.price = null;
            this.maxTouristsCount = null;
            this.startDate = null;
        }
    }
}

module.exports = Tour;