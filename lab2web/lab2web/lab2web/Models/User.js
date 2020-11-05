
/**
 * @typedef User
 * @property {integer} id
 * @property {string} login.required - unique username
 * @property {string} fullname
 * @property {int} role
 * @property {date} registeredAt
 * @property {string} avaUrl
 * @property {bool} isEnabled
 */
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