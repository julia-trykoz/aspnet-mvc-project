function fileUploadInitialize(target, url, doneFunc){
    $(target).fileupload({
        dataType: 'json',
        add: function (e, data) {
            var uploadErrors = [];
            var acceptFileTypes = /^image\/(gif|jpe?g|png)$/i;
            if (data.originalFiles[0]['type'].length && !acceptFileTypes.test(data.originalFiles[0]['type'])) {
                uploadErrors.push('Not an accepted file type');
            }
            if (data.originalFiles[0]['size'] && data.originalFiles[0]['size'] > 4000000) {
                uploadErrors.push('Filesize is too big');
            }
            if (uploadErrors.length > 0) {
                alert(uploadErrors.join("\n"));
            } else {
                data.url = url;
                data.submit();
            }
        },
        done: function (event, data) {
            doneFunc(data);
        },
        fail: function (event, data) {
            if (data.files[0].error) {
                alert(data.files[0].error);
            }
        }
    });
}
