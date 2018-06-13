interface Date {
    plusToDate(unit: string, howMuch: number): Date,
    getMonthName(full?: boolean): string
  }

Date.prototype.plusToDate = function (unit: string, howMuch: number): Date {
  var config = {
    second: 1000, // 1000 miliseconds
    minute: 60000,
    hour: 3600000,
    day: 86400000,
    week: 604800000,
    month: 2592000000, // Assuming 30 days in a month
    year: 31536000000 // Assuming 365 days in year
  };
  var now = new Date(this).valueOf();
  return new Date(now + (config[unit] * howMuch));
}

Date.prototype.getMonthName = function (full: boolean = false): string {
  let months = ['Enero', "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
    monthsShort = ['Ene', "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"];
  return full ? months[this.getMonth()] : monthsShort[this.getMonth()];
}