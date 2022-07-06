$(document).ready(function (e) {
    function ShowAlertByStatusCode(statusCode) {
        if (statusCode == 1) {
            swal("خطا", "خطایی رخ داده است.", "warning")
                .then((value) => { });
        }
        if (statusCode == 2) {
            swal("خطا", "سرویس در دسترس نیست.", "warning")
                .then((value) => { });
        }
        if (statusCode == 3) {
            swal("خطا", "اطلاعات وارد شده معتبر نمیباشد.", "warning")
                .then((value) => { });
        }
        if (statusCode == 4) {
            swal("خطا", "کوکی های شما در دسترس نمیباشد.", "warning")
                .then((value) => { });
        }
        if (statusCode == 5) {
            swal("خطا", "فایل مورد نظر یافت نشد.", "warning")
                .then((value) => { });
        }
    }
});