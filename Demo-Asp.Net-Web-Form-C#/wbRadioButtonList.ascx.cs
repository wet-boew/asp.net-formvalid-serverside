using MergeServerClientErrors.App_GlobalResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MergeServerClientErrors.UserControls
{
    //[ValidationPropertyAttribute("RadioButtonList")]
    public partial class wbRadioButtonList : System.Web.UI.UserControl
    {
        //Property
        public List<RadioButtonItem> RadioButtonList { get; set; }

        //Constructor
        public wbRadioButtonList() { }

        public wbRadioButtonList(List<RadioButtonItem> radioButtonList)
        {
            RadioButtonList = radioButtonList;
        }

        #region Events
        private void Page_Load(object sender, EventArgs e)
        {
            //Dynamically construct Html
            foreach (RadioButtonItem rb in RadioButtonList)
            {
                //rb1
                System.Web.UI.HtmlControls.HtmlGenericControl rb1 = new System.Web.UI.HtmlControls.HtmlGenericControl();
                rb1.TagName = "input type='radio' name='" + rb.Name + "' value='" + rb.Value + "'";
                rb1.ID = rb.Id;
                rb1.Attributes.Add("runat", "server");
                if (rb.Checked == "checked")
                {
                    rb1.Attributes.Add("checked", "checked");
                }                
                if (rb.Required == "required" || rb.Required == "required_me")
                {
                    rb1.Attributes.Add("required", "required");
                }   
                
                //lbl1_1
                Label lbl1_1 = new Label();
                lbl1_1.Text = "&#160;&#160;" + rb.LabelText;

                //lb1
                Label lbl1 = new Label();
                lbl1.AssociatedControlID = rb.Id;
                lbl1.Controls.Add(rb1);
                lbl1.Controls.Add(lbl1_1);
                
                //div1
                System.Web.UI.HtmlControls.HtmlGenericControl div1 = new System.Web.UI.HtmlControls.HtmlGenericControl();
                if (rb.Required == "required" || rb.Required == "required_me")
                    div1.TagName = "Div class='radio required'";
                else
                    div1.TagName = "Div class='radio'";
                div1.Controls.Add(lbl1);

                //Add to placeHolder
                phWbRadioButtonList.Controls.Add(div1);


            }
        } //foreach                        
    }
    #endregion

    //Related Class
    public class RadioButtonItem
    {
        //Property
        public string Id { get; set; }
        public string LabelText { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Required { get; set; }
        public string Checked { get; set; }

        //Constructor
        public RadioButtonItem() { }

        /// <summary>
        /// Define a RadioButton item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="labelText"></param>
        /// <param name="value"></param>
        /// <param name="required">Use 'required' as value</param>
        /// <param name="checked">Use 'checked' as value</param>                 
        public RadioButtonItem(string id, string name, string labelText, string value, string required = null, string checked_ = null)
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
