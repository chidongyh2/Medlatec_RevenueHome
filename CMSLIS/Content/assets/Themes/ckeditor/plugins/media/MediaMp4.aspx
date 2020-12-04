<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MediaMp4.aspx.cs" Inherits="fckeditor_editor_plugins_media_MediaMp4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Media Manager</title>
</head>
<body>
    <script type="text/javascript">

        function MediaPlayer() {
          
           var output = Script();             
            return output;
        }

        function Script() {

            var output = "";
            output = '<%= OutPut %>';

            return output;


        }

        var CKEDITOR = window.parent.CKEDITOR;
        var oEditor = CKEDITOR.instances.txtContent;



        var okListener = function (ev) {
            // remove the listeners to avoid any JS exceptions
            var output = "";
            output += MediaPlayer();
            output += "";
            oEditor.insertHtml(output);


            CKEDITOR.dialog.getCurrent().removeListener("ok", okListener);
            CKEDITOR.dialog.getCurrent().removeListener("cancel", cancelListener);
        };

        var cancelListener = function (ev) {

            CKEDITOR.dialog.getCurrent().removeListener("ok", okListener);
            CKEDITOR.dialog.getCurrent().removeListener("cancel", cancelListener);
        };

        CKEDITOR.event.implementOn(CKEDITOR.dialog.getCurrent());
        CKEDITOR.dialog.getCurrent().on("ok", okListener);
        CKEDITOR.dialog.getCurrent().on("cancel", cancelListener);
    </script>
    <form id="form1" runat="server" method="post">
       <!-- Cho Phép người dùng Upload hoặc đưa URL của File Mp3, FLV, Mp4 hoặc Link Youtube -->
        <table width="100%" cellpadding="5" cellspacing="0" border="0">
            <tr>
                <td colspan="2" align="center">
                Hiện Website chỉ hỗ trợ các tập tin Media có đuôi  .mp4
                </td>        
            </tr>
            <tr>
                <td style="height: 34px">
                    Link video :
                </td>
                <td style="height: 100px">
                   <textarea  id="txtURL" name="txtURL" style="width: 462px; height: 93px;"   ></textarea> 
                                                
                 
                   <%-- <input id="txtURL" name="txtURL"  type="text" style="width: 453px" />--%>
                </td>
            </tr>
            <tr>
                <td>
                    Upload video (MP4) :
                </td>
                <td>
                   <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            
        <%--  <tr>
                <td>
                    Upload video (3gp) :
                </td>
                <td>
                   <asp:FileUpload ID="FileUpload3" runat="server" />
                </td>
            </tr>--%>
            
            <tr>
                <td>
                    Upload Anh  :
                </td>
                <td>
                   <asp:FileUpload ID="FileUpload2" runat="server" />
                   <asp:Button ID="btnUploadImage" runat="server"
                    Text="Upload" OnClick="btnUploadImage_Click" />
                </td>
            </tr>
            
          <%-- <tr>
                <td style="height: 34px">
                    Link :
                </td>
                <td style="height: 34px">
                    <input id="txtURL" name="txtURL" type="text" style="width: 453px"  />
                </td>
            </tr>--%>
                     
        </table>
    </form>

</body>
</html>
