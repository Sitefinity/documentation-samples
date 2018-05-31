<!-- // Documentation articles: https://docs.sitefinity.com/tutorial-add-a-radcaptcha-to-the-login-widget -->

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomLoginControl.ascx.cs" Inherits="SitefinityWebApp.WebFormWidgetsSamples.CustomLoginControl.CustomLoginControl" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sitefinity" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI.Fields" TagPrefix="sfFields" %>

<sfFields:FormManager id="formManager" runat="server" />

<fieldset id="sfLoginWidgetWrp">
    <asp:Panel ID="loginWidgetPanel" runat="server" DefaultButton="LoginButton">
        <ol class="sfLoginFieldsWrp">
			<sfFields:TextField ID="UserName" AccessKey="u" runat="server" DisplayMode="Write" WrapperTag="li">
                <ValidatorDefinition Required="true" 
                            MessageCssClass="sfError" 
                            RequiredViolationMessage="<%$ Resources:Labels, UsernameCannotBeEmpty %>"/>  
            </sfFields:TextField>
            <sfFields:TextField ID="Password" IsPasswordMode="true" AccessKey="p" runat="server" DisplayMode="Write" WrapperTag="li">
                <ValidatorDefinition Required="true" 
                            MessageCssClass="sfError" 
                            RequiredViolationMessage="<%$ Resources:Labels, PasswordCannotBeEmpty %>"/>  
            </sfFields:TextField>
            <li class="sfCheckBoxWrapper">
                <asp:CheckBox runat="server" ID="rememberMeCheckbox" Checked="true" />
                <asp:Label runat="server" AssociatedControlID="rememberMeCheckbox" Text="<%$ Resources:Labels, RememberMe %>" />
            </li>
	    </ol>
	    <div class="sfSubmitBtnWrp">
		     <asp:LinkButton ID="LoginButton" CssClass="sfSubmitBtn" ValidationGroup="LoginBox" runat="server">
			    <asp:Literal ID="LoginButtonLiteral" runat="server"></asp:Literal>
		    </asp:LinkButton>
            <asp:LinkButton ID="lostPasswordBtn" runat="server" Text="<%$ Resources:Labels, ForgotYourPassword %>" CssClass="sfLostPassword" />
            <asp:LinkButton ID="RegisterUserBtn" runat="server" CssClass="sfLostPassword">
                <asp:Literal ID="RegisterUserText" runat="server" />
            </asp:LinkButton>
	    </div>
        <sitefinity:SitefinityLabel ID="ErrorMessageLabel" WrapperTagName="div" runat="server" CssClass="sfError" />
    </asp:Panel>
    <asp:HiddenField Id="hEmail" runat="server" />
    <asp:Panel ID="enterSecurityAnswerPanel" runat="server" Visible="false" CssClass="sfLoginFieldsWrp sfLostPasswordWrp">
        <h2 class="sfLoginFieldsTitle"><asp:Literal runat="server" Text="<%$ Resources:Labels, ForgotYourPassword %>" /></h2>
        <p class="sfLoginFieldsNote"><asp:Literal runat="server" Text="<%$ Resources:Labels, ToResetYourPasswordEnterYourSecurityAnswer %>" /></p>
        <div>
            <asp:Label ID="securityQuestion" runat="server" AssociatedControlID="answerTextBox" CssClass="sfTxtLbl" />
            <asp:TextBox ID="answerTextBox" runat="server" ValidationGroup="loginWidget" CssClass="sfTxt" />
            <asp:RequiredFieldValidator 
                id="answerRequiredFieldValidator" runat="server" Display="Dynamic"
                ValidationGroup="loginWidget"
                ControlToValidate="answerTextBox">
                <div class="sfError"><asp:Literal runat="server" ID="lTheAnswerFieldIsRequired" Text="<%$Resources:ErrorMessages, PasswordAnswerRequired%>" /></div>                
            </asp:RequiredFieldValidator>
            <sitefinity:SitefinityLabel ID="lostPasswordEnterAnswerError" WrapperTagName="div" runat="server" CssClass="sfError" />
        </div>
        <div class="sfSubmitBtnWrp">
            <asp:Button ID="enterSecurityAnswerBtn" runat="server" Text="<%$ Resources:Labels, Submit %>" ValidationGroup="loginWidget" CssClass="sfSubmitBtn" />
        </div>
    </asp:Panel>
    <div class="sfLoginFieldsWrp sfLostPasswordWrp" id="captchaPanel" runat="server" style="display: none">
        <p><strong>Please enter the code below to continue</strong> </p>
        <telerik:RadCaptcha
            Skin="Office2007"
            ID="RadCaptcha"
            runat="server"
            ErrorMessage="You have entered an invalid code"
            ValidationGroup="myLoginWidget"
            ForeColor="Red"
	        EnableRefreshImage="true"
            CaptchaImage-EnableCaptchaAudio="true"
            Display="Dynamic">
        </telerik:RadCaptcha>
        <div class="sfSubmitBtnWrp">
            <asp:Button ID="ValidateCaptchaBtn"
                runat="server"
                Text="Validate"
                CssClass="sfSubmitBtn"
                ValidationGroup="myLoginWidget"
                CausesValidation="true"
                Visible="true" />
        </div>
        <asp:HiddenField Id="hfCaptcha" runat="server" />
    </div>
    <asp:Panel ID="lostPasswordPanel" runat="server" Visible="false" CssClass="sfLoginFieldsWrp sfLostPasswordWrp" DefaultButton="sendRecoveryMailBtn">
        <h2 class="sfLoginFieldsTitle"><asp:Literal runat="server" Text="<%$ Resources:Labels, ForgotYourPassword %>" /></h2>
        <p class="sfLoginFieldsNote"><asp:Literal runat="server" Text="<%$ Resources:Labels, ToResetYourPasswordEnterYourEmail %>" /></p>
        <div>
            <asp:Label runat="server" Text="<%$ Resources:Labels, EmailAddress %>" AssociatedControlID="mailTextBox" CssClass="sfTxtLbl" />
            <asp:TextBox ID="mailTextBox" runat="server" ValidationGroup="loginWidget" CssClass="sfTxt" />
            <asp:RequiredFieldValidator 
                id="mailRequiredFieldValidator" runat="server" Display="Dynamic"
                ValidationGroup="loginWidget"
                ControlToValidate="mailTextBox">
                <div class="sfError"><asp:Literal runat="server" ID="lTheMailFieldIsRequired" Text="<%$Resources:Labels, Required%>" /></div>                
            </asp:RequiredFieldValidator>
            <sitefinity:SitefinityLabel ID="lostPasswordError" WrapperTagName="div" runat="server" CssClass="sfError" />
        </div>
        <div class="sfSubmitBtnWrp">
            <asp:Button ID="sendRecoveryMailBtn" runat="server" Text="<%$ Resources:Labels, Submit %>" ValidationGroup="loginWidget" CssClass="sfSubmitBtn" />
        </div>
    </asp:Panel>
    <asp:Panel ID="passwordResetSentPanel" runat="server" Visible="false" CssClass="sfLoginFieldsWrp sfLostPasswordWrp">
         <h2 class="sfLoginFieldsTitle"><asp:Literal runat="server" Text="<%$ Resources:Labels, ForgotYourPassword %>" /></h2>
        <asp:Literal ID="passwordResetSentLiteral" runat="server"/>
    </asp:Panel>
    <asp:Panel ID="externalLoginPanel" runat="server" Visible="true" CssClass=""> </asp:Panel>
</fieldset>