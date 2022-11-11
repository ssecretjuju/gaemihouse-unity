mergeInto(LibraryManager.library, {

    init: function() {
        var val = sessionStorage.getItem('memberCode');
        window.alert(val);
    }
});