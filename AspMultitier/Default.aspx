<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AspMultitier.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-8 offset-2">
                    <div class="card">
                        <div class="card-header">
                            <h4>Create Employee</h4>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-12">
                                    <asp:Label Text="" ID="txt_message" runat="server" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6">
                                    
                                    <div class="form-group">
                                        <label>Your Name</label>
                                        <asp:HiddenField  runat="server" Id="txt_id"  />
                                        <asp:TextBox runat="server" ID="txt_name" CssClass="form-control" />
                                    </div>
                                </div>

                                <div class="col-6">
                                    <div class="form-group">
                                        <label>Salary</label>
                                        <asp:TextBox runat="server" ID="txt_salary" TextMode="Number" CssClass="form-control" />
                                    </div>
                                </div>
                            </div>


                              <div class="row">
                                <div class="col-6">
                                    <div class="form-group">
                                        <label>Department</label>
                                        <asp:DropDownList runat="server" ID="ddl_dept" CssClass="form-control" DataTextField="name" DataValueField="id">
                                            <asp:ListItem Text="Select" />
                                          
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-6">
                                    <div class="form-group">
                                        <label>Email</label>
                                        <asp:TextBox runat="server" ID="txt_email" TextMode="Email" CssClass="form-control" />
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <label>Gender</label>
                                <asp:DropDownList runat="server" ID="ddl_gender" CssClass="form-control">
                                    <asp:ListItem Text="Select" Value="" />
                                    <asp:ListItem Text="Male" Value="Male" />
                                    <asp:ListItem Text="Female" Value="Female" />
                                    <asp:ListItem Text="Other" Value="Other" />

                                </asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <asp:TextBox runat="server" TextMode="MultiLine" CssClass="form-control" ID="txt_address" />
                                    </div>


                            <div class="form-group">
                                <asp:Button Text="Submit" CssClass="btn btn-success" ID="btn_submit" runat="server" OnClick="btn_submit_Click" />
                                    </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:GridView runat="server" ID="GV_Emp" AutoGenerateColumns="false" CssClass="table table-bordered">
                <Columns>
                    <asp:TemplateField HeaderText="Id">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbl_id" Text='<%# Eval("id") %>'><%# Eval("id") %></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label runat="server"><%# Eval("name") %></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label runat="server"><%# Eval("email") %></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                      <asp:TemplateField HeaderText="Department">
                        <ItemTemplate>
                            <asp:Label runat="server"><%# Eval("dept") %></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Salary">
                        <ItemTemplate>
                            <asp:Label runat="server"><%# Eval("salary") %></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>
                            <asp:Label runat="server"><%# Eval("gender") %></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Address">
                        <ItemTemplate>
                            <asp:Label runat="server"><%# Eval("address") %></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button Text="Edit" ID="btn_edit" OnClick="btn_edit_Click" CssClass="btn btn-info" runat="server" />
                            <asp:Button Text="Del" ID="btn_delete" OnClientClick="return confirm('Are you sure ?')" OnClick="btn_delete_Click" CssClass="btn btn-danger" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
