/// <reference path="../libs/class.js" />
/// <reference path="../libs/jquery-1.9.1.js" />
/// <reference path="../libs/jquery-ui-1.10.3.custom.js" />
/// <reference path="../libs/underscore.js" />


var controls = controls || {};
var StartPageView = Class.create({
    init: function (template) {        
        this.template = template;
    },
    render: function (container,selector) {
        $(container).html(this.template);
        $(selector).tabs();
    }
});

var PostsPageView = Class.create({
    init: function (posts) {
        this.posts = posts;
    },
    render: function (template, postsTemplate, container) {
        var user = {
            username:localStorage.getItem("username")
        }
        $(container).html(template(user));
        //_.sortBy(this.posts.result, function (post) {
        //    return post.CreatedAt;
        //});
        var html = "";
        for (var i = 0; i < this.posts.result.length; i++) {
            var item = this.posts.result[i];
            html += postsTemplate(item);
        }

        $(container).append(html);
       
    }
});

var PostsFormView = Class.create({
    init: function (template) {
        this.template = template;
    },
    render: function (container) {
       
        $(container).prepend(this.template);

    }
});

var SinglePostView = Class.create({
    init: function (post,comments) {
        this.post = post;
        this.comments = comments;
    },
    render: function (container, template, tagTemplate, commentsTemplate, wellcomeTemplate) {
        var user = {
            username:localStorage.getItem("username")
        }

        $(container).html(wellcomeTemplate(user));
        $(container).append(template(this.post.result));
        
        if (this.post.result.Tags) {
            for (var i = 0; i < this.post.result.Tags.length; i++) {
                $("#tagsCont").append(tagTemplate(this.post.result.Tags[i]));
            }
        }    

        for (var j = 0; j < this.comments.result.length; j++) {
            $("#commentsCont").append(commentsTemplate(this.comments.result[j]));
        }

    }
});

var CommentsFormView = Class.create({
    init: function (template) {
        this.template = template;
    },
    render: function (container) {

        $(container).prepend(this.template);

    }
});

controls.startPageView = function (template) {
    return new StartPageView(template);
}
controls.PostsPageView = function (posts) {
    return new PostsPageView(posts);
}
controls.PostsFormView = function (template) {
    return new PostsFormView(template);
}
controls.SinglePostView = function (post,comments) {
    return new SinglePostView(post,comments);
}
controls.CommentsFormView = function (template) {
    return new CommentsFormView(template);
}