Date.prototype.plusToDate = function (unit, howMuch) {
    var config = {
        second: 1000,
        minute: 60000,
        hour: 3600000,
        day: 86400000,
        week: 604800000,
        month: 2592000000,
        year: 31536000000 // Assuming 365 days in year
    };
    var now = new Date(this).valueOf();
    return new Date(now + (config[unit] * howMuch));
};
Date.prototype.getMonthName = function (full) {
    if (full === void 0) { full = false; }
    var months = ['Enero', "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"], monthsShort = ['Ene', "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"];
    return full ? months[this.getMonth()] : monthsShort[this.getMonth()];
};
//# sourceMappingURL=date.extensions.js.map