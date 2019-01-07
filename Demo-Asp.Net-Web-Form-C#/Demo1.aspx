<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GoC.WebTemplate/GoCWebTemplate.Application.Master"
    CodeBehind="Demo1.aspx.cs" Inherits="MergeServerClientErrors.Pages.Demo1"  %>

<%@ Register TagPrefix="uc" TagName="wbDisplayErrors" Src="~/UserControls/wbDisplayErrors.ascx" %>
<%@ Register TagPrefix="uc" TagName="wbCheckBoxList" Src="~/UserControls/wbCheckBoxList.ascx" %>
<%@ Register TagPrefix="uc" TagName="wbRadioButtonList" Src="~/UserControls/wbRadioButtonList.ascx" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

<h1 id="wb-cont">
    <asp:Label ID="lblTitle" property="name" Text="<%$ Resources: Resources, Title %>" runat="server"></asp:Label>    
</h1>

<div class="wb-frmvld">
<form id="frmMain" runat="server">   
    
    <uc:wbDisplayErrors runat="server" />

    <asp:PlaceHolder ID="phdEnterInfo" runat="server" Visible="true">
         <section class="panel panel-info">
            <header class="panel-heading">
                <h2 class="panel-title">
                    <asp:Literal Text="Section 1" runat="server"></asp:Literal>
                </h2>
            </header>            
            <div class="panel-body">
                
<%--DropDownList--%>

                <div class="form-group">      
                    <asp:Label class="required" AssociatedControlID="TypeOfPrestation" runat="server">
                        <span class="field-name"><%= Resources.Resources.TypeOfPrestationLbl %></span>
                        <strong class="required"><%= Resources.Resources.RequiredField %></strong>                        
                                                
                        <asp:RequiredFieldValidator ID="TypeOfPrestationRfv"  ErrorMessage = "<%$ Resources: Resources, TypeOfPrestationRfv %>" ControlToValidate="TypeOfPrestation"
                                                    Display="Dynamic" EnableClientScript="false" CssClass="label label-danger wb-server-error" runat="server"></asp:RequiredFieldValidator>
                        
                                                    <%--Attributes UcHref and UcText are used when JavaScript is disabled.--%>
                        <asp:CustomValidator        ID="TypeOfPrestationCv" ErrorMessage = "<%$ Resources: Resources, TypeOfPrestationCv %>" ControlToValidate="TypeOfPrestation" 
                                                    OnServerValidate="TypeOfPrestationCvServer" UcHref="TypeOfPrestation" UcText="<%$ Resources: Resources, TypeOfPrestationLbl %>"
                                                    Display="Dynamic" EnableClientScript="false" Cssclass="label label-danger wb-server-error" runat="server"></asp:CustomValidator>
                    </asp:Label>

    <%-- input outside the label with a "FOR" attribute--%> 

                    <div>
                        <asp:DropDownList id="TypeOfPrestation" required="required" runat="server">                           
                            <asp:ListItem Text="<%$ Resources: Resources, SelectAPrestation %>" Value="" />
                            <asp:ListItem Text="<%$ Resources: Resources, ChildrenHelp  %>" Value="ChildrenHelp" />
                            <asp:ListItem Text="<%$ Resources: Resources, Invalidity %>" Value="Invalidity" />
                            <asp:ListItem Text="<%$ Resources: Resources, Retirement %>" Value="Retirement" />                           
                        </asp:DropDownList>  
                    </div>
                </div>

<%--TextBox--%>

                <fieldset>
                <legend><%=Resources.Resources.BeneficiaryLegend %></legend>                    
                     <div class="form-group">
                         <asp:Label class="required" AssociatedControlID="BeneficiaryName" runat="server">                            
                            <span class="field-name"><%= Resources.Resources.BeneficiaryNameLbl %></span>
                            <strong class="required"><%= Resources.Resources.RequiredField %></strong>
                            
                            <asp:RequiredFieldValidator ID="BeneficiaryNameRfv" ErrorMessage = "<%$ Resources: Resources, BeneficiaryNameRfv %>" ControlToValidate="BeneficiaryName"
                                                        Display="Dynamic" EnableClientScript="false" CssClass="label label-danger wb-server-error" runat="server"></asp:RequiredFieldValidator>

                            <asp:CustomValidator ID="BeneficiaryNameCv" ErrorMessage = "<%$ Resources: Resources, BeneficiaryNameCv %>" ControlToValidate="BeneficiaryName" 
                                                 OnServerValidate="BeneficiaryNameCvServer" UcHref="BeneficiaryName" UcText="<%$ Resources: Resources, BeneficiaryNameLbl %>"
                                                 Display="Dynamic" EnableClientScript="false" CssClass="label label-danger wb-server-error" runat="server"></asp:CustomValidator>
                            
                            <%--<asp:CustomValidator ID="BeneficiaryNameCv2" ErrorMessage = "<%$ Resources: Resources, BeneficiaryNameCv2 %>" ControlToValidate="BeneficiaryName" 
                                                 OnServerValidate="BeneficiaryNameCvServer2" UcHref="BeneficiaryName" UcText="<%$ Resources: Resources, BeneficiaryNameLbl %>"
                                                 Display="Dynamic" EnableClientScript="false" CssClass="label label-danger wb-server-error" runat="server"></asp:CustomValidator>--%>
                         </asp:Label>

    <%--input outside the label with a "FOR" attribute--%>
                                 
                         <asp:TextBox ID="BeneficiaryName" required="required" MaxLength="16" class="form-control" runat="server"></asp:TextBox>                    
                    </div>

                    <div class="form-group">
                         <label class="required">                            
                            <span class="field-name"><%= Resources.Resources.BeneficiaryAgeLbl %></span>
                            <strong class="required"><%= Resources.Resources.RequiredField %></strong>

                            <asp:RequiredFieldValidator ID="BeneficiaryAgeRfv" ErrorMessage = "<%$ Resources: Resources, BeneficiaryAgeRfv %>" ControlToValidate="BeneficiaryAge"
                                                        Display="Dynamic" EnableClientScript="false" CssClass="label label-danger wb-server-error" runat="server"></asp:RequiredFieldValidator>

                            <asp:CustomValidator        ID="BeneficiaryAgeCv" ErrorMessage = "<%$ Resources: Resources, BeneficiaryAgeCv %>" ControlToValidate="BeneficiaryAge" 
                                                        OnServerValidate="BeneficiaryAgeCvServer"  UcHref="BeneficiaryAge" UcText="<%$ Resources: Resources, BeneficiaryAgeRfv %>"
                                                        Display="Dynamic" EnableClientScript="false" CssClass="label label-danger wb-server-error" runat="server"></asp:CustomValidator>
                            
    <%-- input inside the label without a "FOR" attribute with css-implicite-input --%>

                            <asp:TextBox ID="BeneficiaryAge" required="required" class="form-control css-implicite-input" type="number" min="1" max="200" step="1" runat="server"></asp:TextBox>
                         </label>                            
                    </div>
                    
                </fieldset>
                
<%--RadioButton--%>

        		<fieldset class="legend-brdr-bttm">                 
		    	<legend class="required"><span class="field-name"><%= Resources.Resources.CitizenStatus %></span> <strong class="required"><%= Resources.Resources.RequiredField %></strong>
                    <%--Attributes UcHref and UcText are used when JavaScript is disabled.--%> 
                    <asp:CustomValidator ID="wbRadioButtonList0Cv" ErrorMessage = "<%$ Resources: Resources, DefaultErrorMessage %>" OnServerValidate="wbRadioButtonList0CvServer" UcHref="wbRadioButtonList0_radioButtonList0_0" UcText="<%$ Resources: Resources, CitizenStatus %>"
                                         Display="Dynamic" EnableClientScript="false" CssClass="label label-danger wb-server-error" runat="server"></asp:CustomValidator>
		    	</legend>                    			
                    <uc:wbRadioButtonList ID="wbRadioButtonList0" runat="server" />
		        </fieldset>

<%--Checkbox--%>

                <fieldset class="legend-brdr-bttm">            
			    <legend class="required"><span class="field-name"><%= Resources.Resources.ContactInformation %></span> <strong class="required"><%= Resources.Resources.RequiredField %></strong>
                    <%--Attributes UcHref and UcText are used when JavaScript is disabled.--%>
                    <asp:CustomValidator ID="wbCheckBoxList0Cv" ErrorMessage = "<%$ Resources: Resources, DefaultErrorMessage %>" OnServerValidate="wbCheckBoxList0CvServer" UcHref="wbCheckBoxList0_checkBoxList0_0" UcText="<%$ Resources: Resources, ContactInformation %>"
                                         Display="Dynamic" EnableClientScript="false" CssClass="label label-danger wb-server-error" runat="server"></asp:CustomValidator>
 			    </legend>                        
                    <uc:wbCheckBoxList ID="wbCheckBoxList0" runat="server" />                                         
                </fieldset>

                <fieldset class="legend-brdr-bttm">
                <legend class="required"><span class="field-name"><%= Resources.Resources.Signature %></span> <strong class="required"><%= Resources.Resources.RequiredField %></strong>
                    <%--Attributes UcHref and UcText are used when JavaScript is disabled.--%>
                    <asp:CustomValidator ID="wbCheckBoxList1Cv" ErrorMessage = "<%$ Resources: Resources, DefaultErrorMessage %>" OnServerValidate="wbCheckBoxList1CvServer" UcHref="wbCheckBoxList1_checkBoxList1_0" UcText="<%$ Resources: Resources, Signature %>"
 			                             Display="Dynamic" EnableClientScript="false" CssClass="label label-danger wb-server-error" runat="server"></asp:CustomValidator>
                </legend>
                    <uc:wbCheckBoxList ID="wbCheckBoxList1" runat="server" />                                         
                </fieldset>

<%--Submit--%>

                <ul class="list-inline">
                    <li><asp:Button ID="btnSubmit" Text="<%$ Resources: Resources, btnSubmit %>" class="btn btn-primary" runat="server"></asp:Button></li>                    
                    <%--<li><asp:Button ID="btnReset" Text="<%$ Resources: Resources, btnReset %>" OnClientClick="location.reload(true);" class="btn btn-default" runat="server"></asp:Button></li>                    --%>
                </ul>

            </div>                  
        </section>
    </asp:PlaceHolder>
    
</form>
</div>
</asp:Content>
