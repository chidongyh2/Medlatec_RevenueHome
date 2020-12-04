<%@ page language="C#" autoeventwireup="true" inherits="V2_Upload_MultilUpload, App_Web_multilupload.aspx.69e8a45a" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<title>Upload nhiều ảnh</title>
		<meta http-equiv="Content-Language" content="en-us">
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<link rel="stylesheet" type="text/css" href="../images/style.css">
		<link href="../images/default.css" rel="stylesheet" type="text/css" />
		<script language="javascript" src="../common/jquery-1.2.6.min.js" type="text/javascript"></script>
		<script type="text/javascript" src="../swfupload/swfupload.js"></script>
	    <script type="text/javascript" src="../common/handlers.js"></script>	
        <script type="text/javascript">
            var dialog = window.parent ;
            var oEditor = dialog.InnerDialogLoaded() ;
            var FCK = oEditor.FCK;
            var FCKTools	= oEditor.FCKTools ;
            var FCKConfig	= oEditor.FCKConfig ;
            var FCKBrowserInfo = oEditor.FCKBrowserInfo ;
            function closedialog()
            {
                dialog.close();
                //FCKDialog.OnDialogClose(dialog);
            }
            window.onload = function ()
            {
	            // First of all, translate the dialog box texts
	            dialog.SetOkButton( true ) ;           
            } 
            function Ok()
            {
	            // Before doing anything, save undo snapshot.
	            oEditor.FCKUndo.SaveUndoStep() ;
	            var sHtml = $('#list').html();//oEditor.FCKTools.HTMLEncode($('#list').html());
	            
//	            sHtml = sHtml.replace('<img','<p style = "text-align: center;"><img');
//	            sHtml = sHtml.replace('style="opacity: 1;">','style="opacity: 1;"></p>');
	            
	            
	            
	            //sHtml = FCKTools.ProcessLineBreaks( oEditor, FCKConfig, sHtml ) ;
	            var oDoc = oEditor.FCK.EditorDocument ; 
	            var e = oDoc.createElement( 'p' ) ;
	            e.innerHTML = sHtml;
	            var oRange = new oEditor.FCKDomRange( oEditor.FCK.EditorWindow ) ;
	            oRange.MoveToSelection();
	            //oRange.InsertNode(e);
	            //console.dir(oRange);
	            //console.dir(oRange.StartBlock);
	            var parentElement = oRange.StartBlock;
	            
	            if(parentElement.tagName == 'P' || parentElement.tagName == 'p')
	            {
	                insertAfter(e, parentElement);
	                // xoa the p di
	                var parentOfP = parentElement.parentNode;
	                parentOfP.removeChild(parentElement);
	            }else{
	                oRange.StartBlock.appendChild(e);
	            }
	            
	            return true ;
            }
            //create function, it expects 2 values.
            function insertAfter(newElement,targetElement) {
	            //target is what you want it to go after. Look for this elements parent.
	            var parent = targetElement.parentNode;
            	
	            //if the parents lastchild is the targetElement...
	            if(parent.lastchild == targetElement) {
		            //add the newElement after the target element.
		            parent.appendChild(newElement);
	            } else {
	                // else the target has siblings, insert the new element between the target and it's next sibling.
	                parent.insertBefore(newElement, targetElement.nextSibling);
	            }
            }
            function onOk()
            {
                return true;
            }

            // This function will be called from the PasteFromWord dialog (fck_paste.html)
            // Input: oNode a DOM node that contains the raw paste from the clipboard
            // bIgnoreFont, bRemoveStyles booleans according to the values set in the dialog
            // Output: the cleaned string
            function CleanWord( oNode, bIgnoreFont, bRemoveStyles )
            {
	            var html = oNode.innerHTML ;
	            return html ;
            }
        </script>
        <script type="text/javascript">
               
		    var swfu;
		    window.onload = function () {		    		   
			    swfu = new SWFUpload({
				    // Backend Settings
				    upload_url: "../Upload/upload.aspx",
				    //upload_url: "../upload.aspx",
                    post_params : {
                        "ASPSESSID" : "<%=Session.SessionID %>"
                    },
                   
				    // File Upload Settings
				    file_size_limit : "3 MB",
				    file_types : "*.jpg;*.gif;*.png",
				    file_types_description : "Image Files",
				    file_upload_limit : "0",    // Zero means unlimited

				    // Event Handler Settings - these functions as defined in Handlers.js
				    //  The handlers are not part of SWFUpload but are part of my website and control how
				    //  my website reacts to the SWFUpload events.
				    file_queue_error_handler : fileQueueError,
				    file_dialog_complete_handler : fileDialogComplete,
				    upload_progress_handler : uploadProgress,
				    upload_error_handler : uploadError,
				    upload_success_handler : uploadSuccess,
				    upload_complete_handler : uploadComplete,

				    // Button settings
				    button_image_url : "../images/XPButtonNoText_160x22.png",
				    button_placeholder_id : "spanButtonPlaceholder",
				    button_width: 160,
				    button_height: 22,
				    button_text : '<span class="button">Chọn nhiều ảnh</span>',
				    button_text_style : '.button { font-family: Helvetica, Arial, sans-serif; font-size: 14pt; width:300px;text-align:center;}',
				    button_text_top_padding: 1,
				    button_text_left_padding: 5,

				    // Flash Settings
				    flash_url : "../swfupload/swfupload.swf",	// Relative to this file

				    custom_settings : {
					    upload_target : "divFileProgressContainer"
				    },

				    // Debug Settings
				    debug: false
				    // 
			    });
			    dialog.SetOkButton( true ) ;        
		    }
	    </script>
	 
	    <style type="text/css">
            img{
                margin-bottom:10px;
            }
	    </style>   
	</HEAD>
	<body bgColor="#FFFFFF" leftMargin="2" topMargin="2">
			<form id="frmMain" runat="server">
				<div>
				    <div id="swfu_container" style="margin: 0px 10px;">
		            <div>
				        <span id="spanButtonPlaceholder"></span>
		            </div>
		            <div id="divFileProgressContainer" style="height: 75px;"></div>
		            <div id="list">
		          
		            
		            </div>
		        </div>
		        </div>
			</form>
	</body>
</HTML>
