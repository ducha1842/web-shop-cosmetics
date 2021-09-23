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


jQuery(function () {
	woof_current_values = jQuery.parseJSON(woof_current_values);
	if (woof_current_values.length == 0) {
		woof_current_values = {};
	}

});

function woof_js_after_ajax_done() {
	jQuery(document).trigger('woof_ajax_done');
}


.woof_price_search_container .price_slider_amount button.button {
	display: none;
}

.woof_price_search_container .price_slider_amount .price_label {
	text-align: left !important;
}

.woof .widget_price_filter .price_slider_amount .button {
	float: left;
}

/***** END: hiding submit button of the price slider ******/

.woof_edit_view {
	display: none;
}