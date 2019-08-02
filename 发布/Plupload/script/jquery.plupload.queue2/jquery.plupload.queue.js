; (function ($, o) {
    function _(str) {
        return plupload.translate(str) || str;
    }
    function renderUI(id, target) {
        target.contents().each(function (i, node) {
            node = $(node);

            if (!node.is('.plupload')) {
                node.remove();
            }
        });

        target.prepend(
            '<div class="plupload_queue_container">' +
                '<a class="btn_up" href="javascript:void(0)" id="' + id + '_browse"></a>' +
            '</div>'
            +
            '<div class="plupload_queue_preview">' +
                '<ul>' +
                '</ul>' +
            '</div>'
            );
    }

    $.fn.pluploadQueue = function (settings) {
        if (settings) {
            var uploader, target, id, contents_bak;
            target = $(this);
            id = target.attr('id');

            if (!id) {
                id = plupload.guid();
                target.attr('id', id);
            }
            contents_bak = target.html();
            renderUI(id, target);
            settings = $.extend({
                multi_selection: true,
                dragdrop: false,
                unique_names: false,
                browse_button: id + '_browse',
                container: id
            }, settings);
            uploader = new plupload.Uploader(settings);

            function destroy() {
                if (uploader != null) {
                    uploader.destroy();
                    target.html(contents_bak);
                    uploader = target = contents_bak = null;
                }
            }
            function updateHtml() {

            }

            uploader.bind("FilesAdded", function (up, files) {
                up.start();
            });

            uploader.init();

            uploader.bind("Error", function (up, err) {
                var file = err.file, message;
                if (file) {
                    message = err.message;
                    if (err.code == plupload.FILE_EXTENSION_ERROR) {
                        alert(_("File extension error.") + " 扩展名必须为" + uploader.settings.filters.mime_types[0].extensions);
                    } else {
                        alert(file.name + "的错误: " + message);
                    }
                    
                }
                if (err.code === plupload.INIT_ERROR) {
                    setTimeout(function () {
                        destroy();
                    }, 1);
                }
            });
            return this;
        }
    };
})(jQuery, mOxie);