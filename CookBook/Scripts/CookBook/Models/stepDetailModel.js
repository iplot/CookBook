function StepDetail(detail) {
    if (typeof this !== 'StepDetails') {
        return new StepDetail(detail);
    }

    this.detail = detail;
}