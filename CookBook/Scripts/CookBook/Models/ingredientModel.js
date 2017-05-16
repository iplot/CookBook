function Ingredient(amount, measurement, name) {
    if (typeof this !== 'Ingredient') {
        return new Ingredient(amount, measurement, name);
    }

    this.name = name;
    this.amount = amount;
    this.measurement = measurement;
}