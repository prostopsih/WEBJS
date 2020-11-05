const JsonStorage = require('./JsonStorage')


class EntityRepository {
    constructor(filePath, entity) {
        this.entityStorage_ = new JsonStorage(filePath);
        this.Entity = entity;
    }
    AddEntity(entity) {
        const entities = this.GetEntities();

        entity.id = this.tourStorage_.nextId;
        this.entityStorage_.incrementNextId();
        entities.push(entity);
        this.entityStorage_.writeItems(entities);
    }
    DeleteEntity(id) {
        const entities = this.GetEntities();
        const entity = this.GetEntityById(id);

        if (entity != null) {

            const index = entities.findIndex((x) => {
                return x.id == id;
            });
            entities.splice(index, 1);
            this.entityStorage_.writeItems(entities);
        }
        else {
            throw new Error('there is no entity like this');
        }


    }
    GetEntities() {
        const items = this.entityStorage_.readItems();
        const entities = [];
        for (const item of items) {
            entities.push(new this.Entity(item));
        }
        return entities;
    }
    GetEntityById(id) {
        const items = this.entityStorage_.readItems();
        for (const item of items) {
            if (item.id == id) {
                return new this.Entity(item);
            }
        }
        return null;
    }
    UpdateEntity(entity) {
        const entities = this.GetEntities();
        const entity_ = this.GetEntityById(entity.id);
        if (entity_ != null) {
            const index = entities.findIndex((x) => {
                return x.id == entity_.id;
            });
            entities.splice(index, 1);
            entities.push(entity);
            this.entityStorage_.writeItems(entities);
        }
    }
}

module.exports = EntityRepository;