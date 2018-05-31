//Documentation articles: https://docs.sitefinity.com/tutorial-manage-custom-control-templates-through-the-designer

Type.registerNamespace("SitefinityWebApp.WebFormWidgetsSamples.ManageTemplatesInDesigner");

SitefinityWebApp.WebFormWidgetsSamples.ManageTemplatesInDesigner.CustomWidgetDesigner = function (element) {
    this._tempSelector = null;

    /* Calls the base constructor */
    SitefinityWebApp.WebFormWidgetsSamples.ManageTemplatesInDesigner.CustomWidgetDesigner.initializeBase(this, [element]);
};

SitefinityWebApp.WebFormWidgetsSamples.ManageTemplatesInDesigner.CustomWidgetDesigner.prototype = {

    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {

        /* Here you can attach to events or do other initialization */
        SitefinityWebApp.WebFormWidgetsSamples.ManageTemplatesInDesigner.CustomWidgetDesigner.callBaseMethod(this, 'initialize');
    },

    dispose: function () {

        /* this is the place to unbind/dispose the event handlers created in the initialize method */
        SitefinityWebApp.WebFormWidgetsSamples.ManageTemplatesInDesigner.CustomWidgetDesigner.callBaseMethod(this, 'dispose');
    },

    /* --------------------------------- public methods ---------------------------------- */
    /* Called when the designer window gets opened and here is place to "bind" your designer to the control properties */
    refreshUI: function () {
        var controlData = this._propertyEditor.get_control(); /* JavaScript clone of your control - all the control properties will be properties of the controlData too */

        /* RefreshUI Message */
        this.get_tempSelector().refreshUI();
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        /* ApplyChanges Message */
        this.get_tempSelector().applyChanges();
    },

    /* --------------------------------- properties -------------------------------------- */
    get_tempSelector: function () { return this._tempSelector; },
    set_tempSelector: function (value) { this._tempSelector = value; }
};

SitefinityWebApp.WebFormWidgetsSamples.ManageTemplatesInDesigner.CustomWidgetDesigner.registerClass('SitefinityWebApp.WebFormWidgetsSamples.ManageTemplatesInDesigner.CustomWidgetDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);