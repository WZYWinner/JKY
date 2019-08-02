$(function () {
    var editor = $("#txtContent").xheditor({
        tools: "Cut,Copy,Paste,|,Blocktag,Fontface,FontSize,Bold,Italic,Underline,Strikethrough,FontColor,BackColor,Removeformat,Link,Unlink,|,Align,List,Outdent,Indent,|,Source,Preview,Fullscreen",
        skin: "nostyle",
        beforeSetSource: ubb2html,
        beforeGetSource: html2ubb
    });
    $("#fm").submit(function () {
        $("#content").html(showCode(ubb2html(editor.getSource())));
        return false;
    });
    var editor = $("#txtContent2").xheditor({
        tools: "Cut,Copy,Paste,|,Blocktag,Fontface,FontSize,Bold,Italic,Underline,Strikethrough,FontColor,BackColor,Removeformat,Link,Unlink,|,Align,List,Outdent,Indent,|,Source,Preview,Fullscreen",
        skin: "nostyle",
        beforeSetSource: ubb2html,
        beforeGetSource: html2ubb
    });
    $("#fm").submit(function () {
        $("#content2").html(showCode(ubb2html(editor.getSource())));
        return false;
    });
});


function showCode(sHtml) {
    sHtml = sHtml.replace(/\[code\s*(?:=\s*((?:(?!")[\s\S])+?)(?:"[\s\S]*?)?)?\]([\s\S]*?)\[\/code\]/ig, function (all, t, c) {//code特殊处理
        t = t.toLowerCase();
        if (!t) t = 'plain';
        c = c.replace(/[<>]/g, function (c) { return { '<': '&lt;', '>': '&gt;'}[c]; });
        return '<pre class="prettyprint lang-' + t + '">' + c + '</pre>';
    });
    return sHtml;
}