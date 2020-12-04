


CKEDITOR.dialog.add('uploadimgDialog', function (editor) {
    return {
        title: 'Upload Image',
        minWidth: 600,
        minHeight: 400,
        contents: [
           {
               id: 'upload-tab',
               label: 'Upload',
               elements: [
                    {
                        type: 'fileButton',
                        id: 'upload',
                        label: 'Upload Images'
                    }
               ]

           }
        ]
        //,
        //buttons: [
        //    CKEDITOR.dialog.okButton,

        //    CKEDITOR.dialog.cancelButton,

        //    {
        //        id: 'unique name',
        //        label: 'Custom Button',
        //        title: 'Button description',
        //        accessKey: 'C',
        //        disabled: false,
        //        onClick: function () {
        //            // code on click
        //        },
        //    }

        //]

    };
});


