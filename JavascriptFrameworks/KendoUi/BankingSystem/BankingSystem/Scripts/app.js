/// <reference path="libs/_references.js" />


(function () {
	var appLayout =
		new kendo.Layout('<div id="main-content"></div>');
	var data = persisters.get("http://localhost:60675/api/");
	vmFactory.setPersister(data);

	var router = new kendo.Router();

	router.route("/", function () {
	   
	    var user = localStorage.getItem("username");
	    if (user) {
	        router.navigate("/about");
	    }
	    else {
	        router.navigate("/reg-log");
	    }
	    
	});

	router.route("/reg-log", function () {
		
	    var user = localStorage.getItem("username");
	    if (user) {
	        router.navigate("/about");
	    }
	    else {
	      


	        viewsFactory.getLoginView()
				.then(function (loginViewHtml) {
				    var loginVm = vmFactory.getLoginVM(
						function () {
						    router.navigate("/about");
						});
				    var view = new kendo.View(loginViewHtml,
						{ model: loginVm });
				    appLayout.showIn("#main-content", view);
				});
	    }
	});
	
	router.route("/about", function () {
	    
	    var user = localStorage.getItem("username");
	    if (!user) {
	        router.navigate("/reg-log");
	    }
	    else {

	        viewsFactory.getAboutView()
                .then(function (aboutViewHtml) {
                    var aboutVm = vmFactory.getAboutVM(
                        function (url) {
                            router.navigate(url);
                        });
                    var view = new kendo.View(aboutViewHtml,
                        { model: aboutVm });
                    appLayout.showIn("#main-content", view);
                });
	    }
	});

	router.route("/TransferMoney", function () {

	    var user = localStorage.getItem("username");
	    if (!user) {
	        router.navigate("/reg-log");
	    }
	    else {
	        viewsFactory.getMoneyTransferView()
                .then(function (moneyTransferViewHtml) {
                    vmFactory.getTransactionViewModel()
                        .then(function (data) {
                            var transferVm = data;

                            var view = new kendo.View(moneyTransferViewHtml,
                        { model: transferVm });
                            appLayout.showIn("#main-content", view);
                        })

                });
	    }
	});

	router.route("/VeiwLog",function () {
        
	    viewsFactory.getGridView()
            .then(function (gridHtml) {
                 vmFactory.getLogViewModel()
                    .then(function (result) {
                        console.log( JSON.stringify(result));
                        var logVM = result;
                        var view = new kendo.View(gridHtml);
                        appLayout.showIn("#main-content", view);

                        $('#grid').kendoGrid({
                            dataSource: result.log,
                            editable: true,                          
                            pageable: {
                                input: true,
                                numeric: false
                            },
                            scrollable: false,
                            sortable: true,
                            filterable: false,
                            groupable: true,
                            columns: [
                                { field: "NewSum", title: "NewSum", width: 130 },
                                { field: "OldSum", title: "OldSum", width: 100 },
                                { field: "TransDate", title: "TransDate", width: 80 }
                              
                            ]
                        });
                    })

               
            });
        
	});

	$(function () {
		appLayout.render("#app");
		router.start();
		$("body").on('click', "#logout", function () {
		    localStorage.clear();
		});
	});
}());