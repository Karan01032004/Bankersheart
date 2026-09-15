<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ckeditor.ascx.cs" Inherits="bankersheart.Poweradmin.ckeditor.ckeditor" %>

<script src="<%=ConfigurationManager.AppSettings["CMSPath"].ToString() %>/ckeditor/ckeditor.js"></script>
<textarea name="editor1" id="editor1" runat="server" rows="50" cols="80"></textarea>
<script>
    // Replace the <textarea id="editor1"> with a CKEditor
    // instance, using default configuration.
    CKEDITOR.replace('<%=editor1.ClientID%>', {
        filebrowserBrowseUrl: '<%=ConfigurationManager.AppSettings["CMSPath"].ToString() %>/CKeditor/filemanager/browser/default/browser.html?Connector=<%=ConfigurationManager.AppSettings["CMSPath"].ToString() %>/CKeditor/filemanager/connectors/aspx/connector.aspx',
        filebrowserImageBrowseUrl: '<%=ConfigurationManager.AppSettings["CMSPath"].ToString() %>/CKeditor/filemanager/browser/default/browser.html?Type=Image&Connector=<%=ConfigurationManager.AppSettings["CMSPath"].ToString() %>/CKeditor/filemanager/connectors/aspx/connector.aspx',
        filebrowserFlashBrowseUrl: '<%=ConfigurationManager.AppSettings["CMSPath"].ToString() %>/CKeditor/filemanager/browser/default/browser.html?Type=Flash&Connector=<%=ConfigurationManager.AppSettings["CMSPath"].ToString() %>/CKeditor/filemanager/connectors/aspx/connector.aspx',
                    enterMode: CKEDITOR.ENTER_BR,
                    uiColor: '#cccccc'
                });
</script>