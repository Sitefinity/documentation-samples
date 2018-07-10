// Documentation articles: https://docs.sitefinity.com/tutorial-build-a-form-widget

Type.registerNamespace("SitefinityWebApp.WebFormWidgetsSamples.FormWidget");

SitefinityWebApp.WebFormWidgetsSamples.FormWidget.FormWidget = function (element) {
    this._textbox = null;
    this._dataFieldName = null;
    SitefinityWebApp.WebFormWidgetsSamples.FormWidget.FormWidget.initializeBase(this, [element]);
};

SitefinityWebApp.WebFormWidgetsSamples.FormWidget.FormWidget.prototype = {
    /* --------------------------------- set up and tear down ---------------------------- */

    // Gets the value of the field control.
    get_value: function () {
        return jQuery(this._textbox).val();
    },

    // Sets the value of the text field control depending on DisplayMode.
    set_value: function (value) {
        jQuery(this._textbox).val(value);
    }
};

SitefinityWebApp.FormWidget.FormWidget.registerClass('SitefinityWebApp.WebFormWidgetsSamples.FormWidget.FormWidget', Telerik.Sitefinity.Web.UI.Fields.FieldControl);