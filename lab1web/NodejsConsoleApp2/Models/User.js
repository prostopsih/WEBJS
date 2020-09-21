class User {

    constructor(id, login, fullname, role = 0, registeredAt = null, avaUrl = null, isEnabled = false) {
        this.id = id;  // number
        this.login = login;  // string
        this.fullname = fullname;  // string
        this.role = role; //int
        this.registeredAt = registeredAt; //date
        this.avaUrl = avaUrl; //string
        this.isEnabled = isEnabled; //bool
    }
};

module.exports = User;