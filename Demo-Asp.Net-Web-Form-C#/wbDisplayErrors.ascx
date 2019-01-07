<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wbDisplayErrors.ascx.cs" Inherits="MergeServerClientErrors.UserControls.wbDisplayErrors" %>

        <%=""%> <!-- Fix Error cs0103 -->
        
        <%-- Execute if JS is disabled--%>
        <noscript>        
            <% Page.Validate(); MyValidationSummary.Visible = !Page.IsValid; %>
            <asp:PlaceHolder ID="MyValidationSummary" runat="server">
                <section class="alert alert-danger" >
                    <h2><%=Resources.Resources.ValidationSummaryTitle %></h2>
                    <ul>                    
                        <% int i = 0;
                            foreach (IValidator val in Page.Validators)
                            {
                                if (!val.IsValid)
                                {
                                    String fieldName = "";
                                    MyValidationSummary.Visible = true;
                                    i += 1;

                                    if (val.GetType().Equals(typeof(RequiredFieldValidator)))
                                    {
                                        RequiredFieldValidator valRFV = (RequiredFieldValidator)val;
                                        if (!string.IsNullOrEmpty(valRFV.ControlToValidate))
                                        {
                                            fieldName = valRFV.ControlToValidate + " - ";
                                        }%>
                                        <li><a href="#<%=valRFV.NamingContainer.ClientID + "_" + valRFV.ControlToValidate %>"><span class='prefix'><%=Resources.Resources.Error%>&nbsp;<%= i%>: </span><%= fieldName %><%= val.ErrorMessage%> - <%=Resources.Resources.CorrectAndResubmit%></a></li>
                                  <%}
                                      else if (val.GetType().Equals(typeof(CustomValidator)))
                                      {
                                          CustomValidator valCV = (CustomValidator)val;
                                          if (!string.IsNullOrEmpty(valCV.Attributes["UcHref"]))
                                          {
                                              fieldName = (valCV.Attributes["UcText"] + " - ");
                                              %><li><a href="#<%=valCV.NamingContainer.ClientID + "_" + valCV.Attributes["UcHref"] %>"><span class='prefix'><%=Resources.Resources.Error%>&nbsp;<%= i%>: </span><%= fieldName %><%= val.ErrorMessage%> - <%=Resources.Resources.CorrectAndResubmit%></a></li>
                                          <%}
                                          else if (!string.IsNullOrEmpty(valCV.ControlToValidate))
                                          {
                                              fieldName = valCV.ControlToValidate + " - ";
                                              %><li><a href="#<%=valCV.NamingContainer.ClientID + "_" + valCV.ControlToValidate %>"><span class='prefix'><%=Resources.Resources.Error%>&nbsp;<%= i%>: </span><%= fieldName %><%= val.ErrorMessage%> - <%=Resources.Resources.CorrectAndResubmit%></a></li>
                                          <%}
                                          else
                                          {                                              
                                              %><li><span class='prefix'><%=Resources.Resources.Error%>&nbsp;<%= i%>: </span><%= val.ErrorMessage%> - <%=Resources.Resources.CorrectAndResubmit%></a></li>
                                          <%}%>                                    
                                        
                                    <%}
                                      val.ErrorMessage = "<span class='prefix'>" + Resources.Resources.Error + " " + i + ": </span>" + val.ErrorMessage;
                                }
                            }%>                    
                    </ul>
                </section>
            </asp:PlaceHolder>
        </noscript>
