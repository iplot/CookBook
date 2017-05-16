function Recipe(id, title, description, cookTime, creationDate) {
    if (typeof this !== 'Recipe') {
        return new Recipe(id, title, description, cookTime, creationDate);
    }

    this.id = id;
    this.title = title;
    this.description = description;
    this.cookTime = cookTime;
    this.creationDate = creationDate;
    this.ingredients = [];
    this.stepDetails = [];
}