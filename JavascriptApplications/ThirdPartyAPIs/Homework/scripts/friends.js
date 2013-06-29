window.fbAsyncInit = function () {
    FB.init({
        appId: '144171392446133', // App ID
        channelUrl: '//http://localhost:20511/friends.html', // Channel File
        status: true, // check login status
        cookie: true, // enable cookies to allow the server to access the session
        xfbml: true  // parse XFBML
    });
};

// Load the SDK asynchronously
(function (d) {
    var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement('script'); js.id = id; js.async = true;
    js.src = "//connect.facebook.net/en_US/all.js";
    ref.parentNode.insertBefore(js, ref);
}(document));

$("#show-friends").click(function () { getFriends() });
function getFriends() {
    FB.api('/me/friends', function (response) {
        var friendsHolder = $('#firends-holder');
        for (i = 0; i < response.data.length; i++) {
            var friendPictureUrl = 'https://graph.facebook.com/' + response.data[i].id + '/picture';
            var friendName = response.data[i].name;
            friendsHolder.append("<img src =" + friendPictureUrl + " title=" + friendName + "/>"+"<span>"+friendName+"</span>");
        }
    });
}
