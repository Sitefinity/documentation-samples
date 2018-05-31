// Documentation articles: https://docs.sitefinity.com/tutorial-add-a-radcaptcha-to-the-login-widget

using System;
using System.Web.UI;

namespace SitefinityWebApp.WebFormWidgetsSamples.CustomLoginControl
{
    public partial class CustomLoginControl : System.Web.UI.UserControl
    {
        private bool showPanel = false;

        public bool ValidRadCaptcha
        {
            get
            {
                bool value;

                if (!bool.TryParse(this.hfCaptcha.Value, out value))
                    value = false;

                return value;
            }
            set
            {
                this.hfCaptcha.Value = value.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lostPasswordBtn.Click += new EventHandler(LostPasswordButton_Click);
            this.ValidateCaptchaBtn.Click += new EventHandler(ValidateCaptchaButton_Click);
        }

        protected override void Render(HtmlTextWriter output)
        {
            if (this.showPanel)
            {
                this.loginWidgetPanel.Visible = false;
                this.lostPasswordPanel.Visible = true;
            }
            else
            {
                if (this.passwordResetSentPanel.Visible)
                {
                    this.lostPasswordPanel.Visible = false;
                }
                else
                {
                    this.lostPasswordPanel.Visible = this.enterSecurityAnswerPanel.Visible ? false : this.ValidRadCaptcha;
                }
            }

            base.Render(output);
        }

        public void ValidateCaptchaButton_Click(object sender, System.EventArgs e)
        {
            this.RadCaptcha.Validate();

            if (this.RadCaptcha.IsValid)
            {
                this.lostPasswordPanel.Visible = true;
                this.captchaPanel.Style.Value = "display:none";
                this.showPanel = true;
                this.ValidRadCaptcha = true;
            }
            else
            {
                this.captchaPanel.Style.Value = "display:block";
                this.loginWidgetPanel.Visible = false;
                this.ValidRadCaptcha = false;
            }
        }

        public void LostPasswordButton_Click(object sender, System.EventArgs e)
        {
            this.showPanel = false;
            this.captchaPanel.Style.Value = "display:block";
        }
    }
}