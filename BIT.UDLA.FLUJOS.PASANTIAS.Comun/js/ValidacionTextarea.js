function ValidateLines(e, max, chrln) {
    var text = e.value; //.replace(/\s+$/g,"");
    var split = e.value.split("\n");

    if (max == 0)
        max = split.length;
    if (chrln == 0)
        chrln = text.length + 1;

    if (split.length <= max && text.length + 1 <= chrln) {
        return true;
    }
    else if (split.length >= max || e.value.length >= chrln) {
        return false;
    }
}  