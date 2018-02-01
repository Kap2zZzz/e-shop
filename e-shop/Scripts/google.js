window.dataLayer = window.dataLayer || [];
function gtag() { dataLayer.push(arguments); }
gtag('js', new Date());
gtag('config', 'UA-113314059-1');

$.ajax({
    type: "GET",
    url: "https://www.google-analytics.com/analytics.js",
    success: function () { },
    dataType: "script",
    cache: true
});