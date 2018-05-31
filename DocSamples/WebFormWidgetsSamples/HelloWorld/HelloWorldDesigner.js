//Documentation articles: https://docs.sitefinity.com/link-widget-components
Type.registerNamespace("SitefinityWebApp.WebFormWidgetsSamples.HelloWorld.HelloWorld");

SitefinityWebApp.WebFormWidgetsSamples.HelloWorld.HelloWorldDesigner = function (element) {
    SitefinityWebApp.WebFormWidgetsSamples.HelloWorld.HelloWorldDesigner.initializeBase(this, [element]);
};

SitefinityWebApp.WebFormWidgetsSamples.HelloWorld.HelloWorldDesigner.prototype = {
    initialize: function () {
        SitefinityWebApp.Widgets.HelloWorldDesigner.callBaseMethod(this, 'initialize');
    },
    dispose: function () {
        SitefinityWebApp.WebFormWidgetsSamples.HelloWorld.HelloWorldDesigner.callBaseMethod(this, 'dispose');
    },
    refreshUI: function () {
        var controlData = this._propertyEditor.get_control();

        // bind widget properites to designer
        jQuery("#txtName").val(controlData.Name);
    },
    applyChanges: function () {

        var controlData = this._propertyEditor.get_control();

        // bind designer properties back to widget
        controlData.Name = jQuery("#txtName").val();
    }
};

SitefinityWebApp.WebFormWidgetsSamples.HelloWorld.HelloWorldDesigner.registerClass('SitefinityWebApp.WebFormWidgetsSamples.HelloWorld.HelloWorldDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);