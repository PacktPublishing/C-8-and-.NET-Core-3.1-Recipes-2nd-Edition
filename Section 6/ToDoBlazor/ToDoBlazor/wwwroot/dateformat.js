function getTodayFormatted() {
    var today = moment();
    var formatted = today.format("YYYY-MM-DD");
    console.log(formatted);
}