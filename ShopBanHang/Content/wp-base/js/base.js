(function (html) { html.className = html.className.replace(/\bno-js\b/, 'js') })(document.documentElement);

window._wpemojiSettings = { "baseUrl": "https:\/\/s.w.org\/images\/core\/emoji\/12.0.0-1\/72x72\/", "ext": ".png", "svgUrl": "https:\/\/s.w.org\/images\/core\/emoji\/12.0.0-1\/svg\/", "svgExt": ".svg", "source": { "concatemoji": "https:\/\/shoplamdep.haiphongweb.com\/wp-includes\/js\/wp-emoji-release.min.js?ver=5.2.1" } };
!function (a, b, c) { function d(a, b) { var c = String.fromCharCode; l.clearRect(0, 0, k.width, k.height), l.fillText(c.apply(this, a), 0, 0); var d = k.toDataURL(); l.clearRect(0, 0, k.width, k.height), l.fillText(c.apply(this, b), 0, 0); var e = k.toDataURL(); return d === e } function e(a) { var b; if (!l || !l.fillText) return !1; switch (l.textBaseline = "top", l.font = "600 32px Arial", a) { case "flag": return !(b = d([55356, 56826, 55356, 56819], [55356, 56826, 8203, 55356, 56819])) && (b = d([55356, 57332, 56128, 56423, 56128, 56418, 56128, 56421, 56128, 56430, 56128, 56423, 56128, 56447], [55356, 57332, 8203, 56128, 56423, 8203, 56128, 56418, 8203, 56128, 56421, 8203, 56128, 56430, 8203, 56128, 56423, 8203, 56128, 56447]), !b); case "emoji": return b = d([55357, 56424, 55356, 57342, 8205, 55358, 56605, 8205, 55357, 56424, 55356, 57340], [55357, 56424, 55356, 57342, 8203, 55358, 56605, 8203, 55357, 56424, 55356, 57340]), !b }return !1 } function f(a) { var c = b.createElement("script"); c.src = a, c.defer = c.type = "text/javascript", b.getElementsByTagName("head")[0].appendChild(c) } var g, h, i, j, k = b.createElement("canvas"), l = k.getContext && k.getContext("2d"); for (j = Array("flag", "emoji"), c.supports = { everything: !0, everythingExceptFlag: !0 }, i = 0; i < j.length; i++)c.supports[j[i]] = e(j[i]), c.supports.everything = c.supports.everything && c.supports[j[i]], "flag" !== j[i] && (c.supports.everythingExceptFlag = c.supports.everythingExceptFlag && c.supports[j[i]]); c.supports.everythingExceptFlag = c.supports.everythingExceptFlag && !c.supports.flag, c.DOMReady = !1, c.readyCallback = function () { c.DOMReady = !0 }, c.supports.everything || (h = function () { c.readyCallback() }, b.addEventListener ? (b.addEventListener("DOMContentLoaded", h, !1), a.addEventListener("load", h, !1)) : (a.attachEvent("onload", h), b.attachEvent("onreadystatechange", function () { "complete" === b.readyState && c.readyCallback() })), g = c.source || {}, g.concatemoji ? f(g.concatemoji) : g.wpemoji && g.twemoji && (f(g.twemoji), f(g.wpemoji))) }(window, document, window._wpemojiSettings);

WebFontConfig = {
    google: { families: ["Roboto:regular,700", "Roboto:regular,regular", "Roboto:regular,500", "Dancing+Script:regular,400",] }
};
(function () {
    var wf = document.createElement('script');
    wf.src = 'https://ajax.googleapis.com/ajax/libs/webfont/1/webfont.js';
    wf.type = 'text/javascript';
    wf.async = 'true';
    var s = document.getElementsByTagName('script')[0];
    s.parentNode.insertBefore(wf, s);
})();

var woof_is_permalink = 1;

var woof_shop_page = "";

var woof_really_curr_tax = {};
var woof_current_page_link = location.protocol + '//' + location.host + location.pathname;
//***lets remove pagination from woof_current_page_link
woof_current_page_link = woof_current_page_link.replace(/\page\/[0-9]+/, "");
woof_current_page_link = "https://shoplamdep.haiphongweb.com/mua/";
var woof_link = 'https://shoplamdep.haiphongweb.com/wp-content/plugins/woocommerce-products-filter/';

var woof_ajaxurl = "https://shoplamdep.haiphongweb.com/wp-admin/admin-ajax.php";
var woof_lang = {
    'orderby': "orderby",
    'date': "date",
    'perpage': "per page",
    'pricerange': "price range",
    'menu_order': "menu order",
    'popularity': "popularity",
    'rating': "rating",
    'price': "price low to high",
    'price-desc': "price high to low"
};

if (typeof woof_lang_custom == 'undefined') {
    var woof_lang_custom = {};//!!important
}

//***

var woof_is_mobile = 0;

var woof_show_price_search_button = 0;
var woof_show_price_search_type = 0;

var woof_show_price_search_type = 2;

var swoof_search_slug = "swoof";


var icheck_skin = {};
icheck_skin.skin = "flat";
icheck_skin.color = "green";

var is_woof_use_chosen = 1;

var woof_current_values = '[]';
//+++
var woof_lang_loading = "Loading ...";


var woof_lang_show_products_filter = "show products filter";
var woof_lang_hide_products_filter = "hide products filter";
var woof_lang_pricerange = "price range";

//+++

var woof_use_beauty_scroll = 0;
//+++
var woof_autosubmit = 1;
var woof_ajaxurl = "https://shoplamdep.haiphongweb.com/wp-admin/admin-ajax.php";
var woof_submit_link = "";
var woof_is_ajax = 0;
var woof_ajax_redraw = 0;
var woof_ajax_page_num = 1;
var woof_ajax_first_done = false;
var woof_checkboxes_slide_flag = true;


//toggles
var woof_toggle_type = "text";

var woof_toggle_closed_text = "-";
var woof_toggle_opened_text = "+";

var woof_toggle_closed_image = "https://shoplamdep.haiphongweb.com/wp-content/plugins/woocommerce-products-filter/img/plus3.png";
var woof_toggle_opened_image = "https://shoplamdep.haiphongweb.com/wp-content/plugins/woocommerce-products-filter/img/minus3.png";


//indexes which can be displayed in red buttons panel
var woof_accept_array = ["min_price", "orderby", "perpage", , "pwb-brand", "product_visibility", "product_cat", "product_tag"];

//***
//for extensions

var woof_ext_init_functions = null;



var woof_overlay_skin = "default";


(function () {
    woof_current_values = jQuery.parseJSON(woof_current_values);
    if (woof_current_values.length == 0) {
        woof_current_values = {};
    }

});

function woof_js_after_ajax_done() {
    jQuery(document).trigger('woof_ajax_done');
}