CKEDITOR.dialog.add('uploadimgDialog', function (editor) {
    return {
        title: 'Abbreviation Properties',
        minWidth: 400,
        minHeight: 200,
        contents: [
            {
                id: 'tab-basic',
                label: 'Upload IMG',
                elements: [
                    {
                        type: 'button',
                        id: 'btnUpload',
                        label: 'Upload Image',
                        onClick: function () {
                            window.showModalDialog( "http://localhost/cmsmoison/Upload/MultilUpload.aspx?T=Insert Image", null, "dialogWidth:750px;dialogHeight:500px;center:yes; resizable: yes; help: no");
                          //  myWindow.opener.document.write("<p>This is the source window!</p>");
                            // window.open("http://localhost/cmsmoison/Upload/MultilUpload.aspx", "myWindow", "width=200, height=100");

                           // exec: function (editor) {
                                //            var media = window.showModalDialog(editor.config.syrinx_siteBase + "/popups/InsertImagePopup.aspx?T=Insert Image", null, "dialogWidth:750px;dialogHeight:500px;center:yes; resizable: yes; help: no");
                                //            if (media != false && media != null) {
                                //                if (media.mediaUrl.substr(media.mediaUrl.length - 4) == ".wmv") {
                                //                    var x = '<div title="click to play video" onclick="showMediaClip(this,' + media.mediaUrl + ',' + media.width + ',' + media.height + ')" style="cursor: pointer"><img alt="" src="' + media.mediaImage + '" /></div>';
                                //                    editor.insertHtml(x);
                                //                }
                                //                else
                                //                    editor.insertHtml("<img src='" + media.mediaUrl + "' />");
                                //            }
                                //        }
                        }
                    }
                    
                ]
            }
        ],
        onOk: function () {
            var dialog = this;
            var abbr = editor.document.createElement('abbr');
            abbr.setAttribute('title', dialog.getValueOf('tab-basic', 'title'));
            abbr.setText(dialog.getValueOf('tab-basic', 'abbr'));

            var id = dialog.getValueOf('tab-adv', 'id');
            if (id)
                abbr.setAttribute('id', id);

            editor.insertElement(abbr);
        }
    };
});