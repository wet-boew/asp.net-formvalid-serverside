using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using MergeServerClientErrors.App_GlobalResources;

namespace MergeServerClientErrors.UserControls
{
    //[ValidationPropertyAttribute("CheckBoxList")]
    public partial class wbCheckBoxList : System.Web.UI.UserControl
    {
        //Property
        public List<CheckBoxItem> CheckBoxList { get; set; }

        //Constructor
        public wbCheckBoxList() { }

        public wbCheckBoxList(List<CheckBoxItem> checkBoxList)
        {
            CheckBoxList = checkBoxList;
        }

        #region Events
        private void Page_Load(object sender, EventArgs e)
        {
            //Dynamically construct Html
            foreach (CheckBoxItem chk in CheckBoxList)
            {
                //ck1
                System.Web.UI.HtmlControls.HtmlGenericControl ck1 = new System.Web.UI.HtmlControls.HtmlGenericControl();
                ck1.TagName = "input type='checkbox' name='" + chk.Name + "' value='" + chk.Value + "'";
                ck1.ID = chk.Id;                
                ck1.Attributes.Add("runat", "server");                
                if (chk.Checked == "checked")
                {
                    ck1.Attributes.Add("checked", "checked");
                }
                if (chk.Required == "required")
                {
                     ck1.Attributes.Add("class", "required_js");
                }
                if (chk.Required == "required_me")
                {
                    ck1.Attributes.Add("required", "required");
                }

                //lbl1_1
                Label lbl1_1 = new Label();
                string lblRequired = "";
                if (chk.Required == "required_me")
                {
                    lblRequired = "<strong class='required'> " + Resources.RequiredField + "</strong>";
                }
                lbl1_1.Text = "&#160;&#160;" + "<span class='field-name'>" + chk.LabelText + "</span>" + lblRequired;

                //cv1
                CustomValidator cv1 = new CustomValidator();
                cv1.ID = chk.Id + "Cv";
                cv1.EnableClientScript = false;
                cv1.CssClass = "label label-danger wb-server-error";
                cv1.Display = ValidatorDisplay.Dynamic;
                cv1.ServerValidate += new ServerValidateEventHandler(wbCheckBoxList1UcCvServer);
                cv1.Text = Resources.MandatoryField;
                cv1.ErrorMessage = Resources.MandatoryField;
                cv1.Attributes.Add("runat", "server");
                cv1.Attributes.Add("UcHref", ck1.ClientID);
                cv1.Attributes.Add("UcText", chk.LabelText);
                
                //lb1
                Label lbl1 = new Label();
                lbl1.AssociatedControlID = chk.Id;
                lbl1.Controls.Add(ck1);
                lbl1.Controls.Add(lbl1_1);
                lbl1.Controls.Add(cv1);
                
                //div1
                System.Web.UI.HtmlControls.HtmlGenericControl div1 = new System.Web.UI.HtmlControls.HtmlGenericControl();
                if (chk.Required == "required_me")
                    div1.TagName = "Div class='checkbox required'";
                else
                    div1.TagName = "Div class='checkbox'";                
                div1.Controls.Add(lbl1);

                //Add to placeHolder
                phWbCheckBoxList.Controls.Add(div1);

            } //foreach                        
        }
        #endregion

       //CustomValidator Method
        public void wbCheckBoxList1UcCvServer(object source, ServerValidateEventArgs args)
        {
            var sourceCv = (CustomValidator)source;
            args.IsValid = true;
            if (Page.IsPostBack)
            {               
                foreach (CheckBoxItem checkBoxItem in CheckBoxList)
                {
                    if (sourceCv.Attributes["UcHref"] == checkBoxItem.Id && checkBoxItem.Required == "required_me") {
                        args.IsValid = checkBoxItem.Checked == "checked";                        
                    }
                }
            }
        }
    }

    //Related Class
    public class CheckBoxItem
    {
        //Property
        public string Id { get; set; }
        public string LabelText { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Required { get; set; }
        public string Checked { get; set; }

        //Constructor
        public CheckBoxItem() { }

        /// <summary>
        /// Define a CheckBox item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="labelText"></param>
        /// <param name="value"></param>
        /// <param name="required">Use 'required' as value</param>
        /// <param name="checked">Use 'checked' as value</param>      
        public CheckBoxItem(string id, string name, string labelText, string value, string required = null, string checked_ = null)
        {
            Id = id;
            Name = name;
            LabelText = labelText;
            Value = value;
            Required = required;
            Checked = checked_;
        }
    }    
}
