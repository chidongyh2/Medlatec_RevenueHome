(function () {
    CKEDITOR.plugins.add('customize', {
        requires: ['iframedialog'],
        init: function (a) {
            CKEDITOR.dialog.addIframe('customizeDialog', 'Upload IMGS', 'http://localhost/cmsmoison/Upload/MultilUpload.aspx', 600, 400, function () { /*oniframeload*/ });
            a.addCommand('customize', {
                exec: function (e) {
                    e.openDialog('customizeDialog');
                }
            });
            a.ui.addButton('customize', {
                label: 'Insert IMG here',
                command: 'customize',
                icon: this.path + 'icons/customize.png'
            });
        }
    });
})();