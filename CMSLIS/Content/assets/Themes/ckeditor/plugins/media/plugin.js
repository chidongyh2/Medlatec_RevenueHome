CKEDITOR.plugins.add('media', {
    requires: ['iframedialog'],
    icons: 'media',
    init: function (editor) {
        CKEDITOR.dialog.addIframe('mediaDialog', 'Upload Media',  '../News/AddUploadVideo', 600, 400, function () { /*oniframeload*/ });
        editor.ui.addButton('media', {
            label: 'Insert Video từ máy tính',
            command: 'uploadmedia',
            id: 'btnUpload',
            toolbar: 'document',
        });
        editor.addCommand('uploadmedia', {
            exec: function (e) {
                e.openDialog('mediaDialog');
            }
        });
    }
});
