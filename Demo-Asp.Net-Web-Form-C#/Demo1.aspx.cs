using System;
using System.Collections.Generic;
using GoC.WebTemplate;
using System.Web.UI.WebControls;
using MergeServerClientErrors.App_GlobalResources;
using MergeServerClientErrors.UserControls;
using System.Web.UI;

namespace MergeServerClientErrors.Pages
{
    public partial class Demo1 : BasePage //System.Web.UI.Page
    {
        private void Page_Init(object sender, EventArgs e)
        {
            #region Load CSS and Script

            //Common CSS to WET in the Header
            //We load CSS in case Javascript is disabled.
            WebTemplateMaster.WebTemplateCore.HTMLHeaderElements.Add("<link rel='stylesheet' type='text/css' href='" + ResolveClientUrl("~/Styles/wb-server-error.css") + "'>");
            //WebTemplateMaster.WebTemplateCore.HTMLHeaderElements.Add("<link rel='stylesheet' type='text/css' href='" + ResolveClientUrl("http://localhost/Wet-Boew/theme-wet-boew/css/theme.css") + "'>");

            //Common JS to WET in the body
            WebTemplateMaster.WebTemplateCore.HTMLBodyElements.Add("<script type='text/javascript' src='" + ResolveClientUrl("~/Scripts/Common/Common.js") + "'></script>");

            #endregion

            #region Populate List

            //Populate radioButtonList
            //Use required on the first checkbox to validates the group with Wet-Boew
            wbRadioButtonList0.RadioButtonList = new List<RadioButtonItem>();
            wbRadioButtonList0.RadioButtonList.Add(new RadioButtonItem("radioButtonList0_0", "radioButtonList0", Resources.CanadianCitizen, "radioButtonList0_0v", "required"));
            wbRadioButtonList0.RadioButtonList.Add(new RadioButtonItem("radioButtonList0_1", "radioButtonList0", Resources.PermanentResident, "radioButtonList0_1v"));
            wbRadioButtonList0.RadioButtonList.Add(new RadioButtonItem("radioButtonList0_2", "radioButtonList0", Resources.WorkPermit, "radioButtonList0_2v", "", null));

            //Populate checkboxList
            //Use required on the first checkbox to validates the group with Wet-Boew
            wbCheckBoxList0.CheckBoxList = new List<CheckBoxItem>();
            wbCheckBoxList0.CheckBoxList.Add(new CheckBoxItem("checkBoxList0_0", "checkBoxList0", Resources.ContactEmail, "checkBoxList0_0v", "required", ""));
            wbCheckBoxList0.CheckBoxList.Add(new CheckBoxItem("checkBoxList0_1", "checkBoxList0", Resources.ContactPhone, "checkBoxList0_1v", "", ""));
            wbCheckBoxList0.CheckBoxList.Add(new CheckBoxItem("checkBoxList0_2", "checkBoxList0", Resources.ContactMessaging, "checkBoxList0_2v", "", ""));

            //Use required_me parameter to validate an individual checkbox
            wbCheckBoxList1.CheckBoxList = new List<CheckBoxItem>();            
            wbCheckBoxList1.CheckBoxList.Add(new CheckBoxItem("checkBoxList1_0", "checkBoxList1", Resources.PrintPage, "checkBoxList1_0v", "required", ""));
            wbCheckBoxList1.CheckBoxList.Add(new CheckBoxItem("checkBoxList1_1", "checkBoxList1", Resources.MoreInformation, "checkBoxList1_1v", "", ""));
            wbCheckBoxList1.CheckBoxList.Add(new CheckBoxItem("checkBoxList1_2", "checkBoxList1", Resources.AgreeDirectives, "checkBoxList1_2v", "required_me", ""));

            #endregion
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Wet Configuration
            WebTemplateMaster.WebTemplateCore.ApplicationTitle.Text = Resources.ApplicationTitle;
            WebTemplateMaster.WebTemplateCore.ApplicationTitle.Href = ResolveClientUrl("http://wet-boew.github.io/wet-boew/index-en.html");
            WebTemplateMaster.WebTemplateCore.HeaderTitle = Resources.HeaderTitle;
            WebTemplateMaster.WebTemplateCore.ContactLink = new Link() { Href = "https://www.canada.ca/en.html" };
            WebTemplateMaster.WebTemplateCore.ScreenIdentifier = "0001";
            WebTemplateMaster.WebTemplateCore.DateModified = Convert.ToDateTime("2019-01-01");
            WebTemplateMaster.WebTemplateCore.ShowSignInLink = true;
            WebTemplateMaster.WebTemplateCore.SignInLinkURL = "about:blank";
            WebTemplateMaster.WebTemplateCore.AppSettingsURL = "http://tempuri.com";
            WebTemplateMaster.WebTemplateCore.FeedbackLinkURL = "https://wet-boew.github.io/v4.0-ci/demos/feedback/feedback-en.html";

            //Language
            WebTemplateMaster.WebTemplateCore.ShowLanguageLink = true;
            if (WebTemplateMaster.WebTemplateCore.TwoLetterCultureLanguage == "en")
            {
                WebTemplateMaster.WebTemplateCore.LanguageLink.Href = "Demo1.aspx?GoCTemplateCulture=fr-CA";
            }
            else
            {
                WebTemplateMaster.WebTemplateCore.LanguageLink.Href = "Demo1.aspx?GoCTemplateCulture=en-CA";
            }

            //Breadcrumbs
            WebTemplateMaster.WebTemplateCore.Breadcrumbs = new List<Breadcrumb>
                {
                    new Breadcrumb{ Href = "https://www.canada.ca/en.html", Title =  Resources.BreadCrumbTitle1, Acronym =  Resources.BreadCrumbAcronym1 },
                    new Breadcrumb { Title = Resources.ApplicationTitle }
                };

            //FooterLinks
            WebTemplateMaster.WebTemplateCore.CustomFooterLinks = new List<FooterLink>
                {
                    new FooterLink
                    {
                        Href = "about:blank",
                        NewWindow = true,
                        Text = Resources.FooterLink1
                    }
                };

            #endregion

            #region SetUserControls
                      
            if (Page.IsPostBack) {
                SetUserControls(Page.Controls);                
            }  // end postback

            #endregion

            # region Enable RequiredFieldValidators after a postback
            foreach (System.Web.UI.IValidator val in Page.Validators)
            {
                if (val.GetType().Equals(typeof(RequiredFieldValidator)))
                {
                    RequiredFieldValidator valRFV = (RequiredFieldValidator)val;
                    valRFV.Enabled = Page.IsPostBack;
                }
            }

            #endregion
        }

        #region Set UserControls
        public void SetUserControls(ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl.Controls.Count > 0) SetUserControls(ctrl.Controls);

                // wbRadioButtonList
                if ("usercontrols_wbradiobuttonlist_ascx".Equals(ctrl.GetType().Name, StringComparison.OrdinalIgnoreCase))
                {                    
                    var checkedRadioButtons = Page.Request.Form[((wbRadioButtonList)ctrl).RadioButtonList[0].Name];                    
                    if (checkedRadioButtons != null)
                    {
                        foreach (RadioButtonItem radioButtonItem in ((wbRadioButtonList)ctrl).RadioButtonList)                        
                        {
                            if (checkedRadioButtons.Contains(radioButtonItem.Value))
                            {
                                radioButtonItem.Checked = "checked";
                            }
                            else
                            {
                                radioButtonItem.Checked = null;
                            }
                        }
                    }
                }

                // wbCheckBoxList
                if ("usercontrols_wbcheckboxlist_ascx".Equals(ctrl.GetType().Name, StringComparison.OrdinalIgnoreCase))
                {
                    var checkedCheckBoxes = Page.Request.Form[((wbCheckBoxList)ctrl).CheckBoxList[0].Name];
                    if (checkedCheckBoxes != null)
                    {
                        foreach (CheckBoxItem checkBoxItem in ((wbCheckBoxList)ctrl).CheckBoxList)
                        {
                            if (checkedCheckBoxes.Contains(checkBoxItem.Value))
                            {
                                checkBoxItem.Checked = "checked";
                            }
                            else
                            {
                                checkBoxItem.Checked = null;
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Validation        

        protected void TypeOfPrestationCvServer(Object source, ServerValidateEventArgs args)
        {
            args.IsValid = (args.Value == "ChildrenHelp" ||
                            args.Value == "Retirement" ||
                            args.Value == "Invalidity");
        }

        protected void BeneficiaryNameCvServer(Object source, ServerValidateEventArgs args)
        {
            args.IsValid = (args.Value.ToUpper().StartsWith("SUPER"));
        }

        protected void BeneficiaryNameCvServer2(Object source, ServerValidateEventArgs args)
        {
            args.IsValid = (args.Value.ToUpper().Length>6);
        }

        protected void BeneficiaryAgeCvServer(Object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            try
            {
                int intValue = Int32.Parse(args.Value);
                switch (TypeOfPrestation.SelectedValue)
                {
                    case "ChildrenHelp":
                        if (intValue > 0 && intValue < 19) 
                            args.IsValid=true;
                        else
                            BeneficiaryAgeCv.ErrorMessage = Resources.BeneficiaryAgeCvChildrenHelp;                        
                        break;

                    case "Retirement":
                        if (intValue > 64 && intValue < 201)
                            args.IsValid = true;
                        else
                            BeneficiaryAgeCv.ErrorMessage = Resources.BeneficiaryAgeCvRetirement;
                        break;

                    case "Invalidity":
                        if (intValue > 0 && intValue < 65)
                            args.IsValid = true;
                        else
                            BeneficiaryAgeCv.ErrorMessage = Resources.BeneficiaryAgeCvInvalidity;
                        break;
                }                
            }
            catch (Exception)
            {
                args.IsValid = false;
                BeneficiaryAgeCv.ErrorMessage = Resources.BeneficiaryAgeCvUnexpected;
            }
        }

        public void wbRadioButtonList0CvServer(Object source, ServerValidateEventArgs args)
        {
            if (Page.IsPostBack)
            {
                int checked_ = 0;
                foreach (RadioButtonItem radioButtonItem in wbRadioButtonList0.RadioButtonList)
                {
                    if (radioButtonItem.Checked == "checked")
                    {
                        checked_ += 1;
                    }                   
                }

                if (checked_ < 1)
                {
                    args.IsValid = false;
                     wbRadioButtonList0Cv.ErrorMessage = Resources.ChooseOneRadioButton;
                }
            }
        }

        protected void wbCheckBoxList0CvServer(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            if (Page.IsPostBack)
            {
                int checkedCount = 0;
                foreach (CheckBoxItem checkBoxItem in wbCheckBoxList0.CheckBoxList)
                {
                    if (checkBoxItem.Checked == "checked")
                    {
                        checkedCount += 1;
                    }
                }
           
                if (checkedCount < 1)
                {
                    args.IsValid = false;
                    wbCheckBoxList0Cv.ErrorMessage = Resources.ChooseOneCheckbox;
                }
                
                //add another verification
                else if (checkedCount > 2)
                {
                    args.IsValid = false;
                    wbCheckBoxList0Cv.ErrorMessage = Resources.ChooseMoreThan;
                }
            }
        }
        
        protected void wbCheckBoxList1CvServer(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            if (Page.IsPostBack)
            {
                int checkedCount = 0;
                foreach (CheckBoxItem checkBoxItem in wbCheckBoxList1.CheckBoxList)
                {
                    if (checkBoxItem.Checked == "checked")
                    {
                        checkedCount += 1;
                    }
                }

                if (checkedCount < 1)
                {
                    args.IsValid = false;
                    wbCheckBoxList1Cv.ErrorMessage = Resources.ChooseOneCheckbox;
                }
            }
        }
        #endregion

    }

}
