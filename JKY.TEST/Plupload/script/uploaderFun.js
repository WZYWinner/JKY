function uplaoderFun($obj,isPicMode, updateHiddenValueFun) {
    var mine_types=isPicMode?[{ title: "Image files", extensions: "jpg,gif,png,jpeg" }]:[{ title: "Zip files,Rar files", extensions: "zip,rar" }];
    $($obj).pluploadQueue({
        // General settings
        runtimes: 'html5,flash,html4', // 这里是说用什么技术引擎
        url: '/Plupload/uploader.ashx', // 服务端上传路径
        unique_names: false, // 上传的文件名是否唯一
        dragdrop: true,
        // Resize images on clientside if we can
        //// 是否生成缩略图（仅对图片文件有效）
        //resize: { width: 320, height: 240, quality: 90 },
        rename: false,
        // Specify what files to browse for
        ////  这个数组是选择器，就是上传文件时限制的上传文件类型
        filters: {
            // Maximum file size
            max_file_size: '2mb',
            // Specify what files to browse for
            
            mime_types: mine_types
        },
        isPicMode: isPicMode,
        //updateHiddenValueFun:updateHiddenValueFun,

        //    function (uploader) {
        //    var urlList = "";
        //    $(".uploadered_hidden").each(function (i, value) {
        //        urlList += $(this).val() + ";";
        //    });
        //    //$("#uploader_url").val(urlList);
        //},
        // Flash settings
        // plupload.flash.swf 的所在路径
        flash_swf_url: 'script/Moxie.swf',

        // Silverlight settings
        // silverlight所在路径
        silverlight_xap_url: 'script/Moxie.xap',
        init: {
            FileUploaded: function (up, file, info) {
                if (info.response != null) {
                    var jsonstr = eval("(" + info.response + ")");

                    if (jsonstr.result_state) {
                        //alert(jsonstr.msg);
                        for (var i = 0; i < jsonstr.list.length; i++) {
                            var url = jsonstr.list[i];
                            $($obj+" .plupload_wrapper").append('<input type="hidden" value="' + url + '" name="uploader_' + file.id + '" class="uploadered_hidden"/>');
                        }
                    } else {
                        var file2 = file;
                        file2.status = plupload.FAILED;
                        file = file2;
                        alert(jsonstr.msg);
                    }
                } else {
                    var file2 = file;
                    file2.status = plupload.FAILED;
                    file = file2;
                    alert("上传发生错误，请重新试一试");
                }
            },
            Error: function (up, args) {
                //发生错误
                if (args.file) {
                    if (args.code == plupload.FILE_SIZE_ERROR || args.code == plupload.FILE_EXTENSION_ERROR) {
                        return;
                    }
                    alert('文件错误:' + args.message);
                } else {
                    alert('出错' + args.message);
                }
            },
            UploadComplete: function (uploader, files) {
                updateHiddenValueFun(uploader);
            }
        }
    });
}
/*字符床格式化*/
String.prototype.format = function (array) { var str = this.toString(); for (var i in array) { str = str.replace(eval('/\\{' + i + '\\}/g'), array[i]); } return str; }
String.prototype.fileName = function () {
    var str = this.toString();
    return str.substr(str.lastIndexOf("/") + 1, str.length)
}
