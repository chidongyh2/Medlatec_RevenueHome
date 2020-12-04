
CKEDITOR.plugins.add('uploadimg', {
    requires: ['iframedialog'],
        icons: 'uploadimg',
        init: function (editor) {
            CKEDITOR.dialog.addIframe('uploadimgDialog', 'Upload IMGS', '../News/AddUploadimg', 600, 400, function () { /*oniframeload*/ });
            editor.ui.addButton('uploadimg', {
                label: 'Upload IMG',
                command: 'uploadimg',
                id: 'btnUpload',
                toolbar: 'document',
            });
            editor.addCommand('uploadimg', {
                exec: function (e) {
                    e.openDialog('uploadimgDialog');
                }
            });
        }
   });
