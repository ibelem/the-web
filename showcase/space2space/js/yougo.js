// JScript File

function ow(obj) {
    URL=obj.href;
    width=420;
    height=800;
    var left = ( screen.width - width ) / 2;
    var top = ( screen.height - height ) / 2;
    window.open(URL,'','width=420,height=560,top='+top+',left='+left+',scrollbars=1,resizable=0');
    return false;
}
