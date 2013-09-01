/// <reference path="../libs/_references.js" />

window.vmFactory = (function () {

    var data = null;

    function getLoginViewModel(successCallback) {
        var viewModel = {
            username: "",
            password: "",
            firstName: "",
            lastName: "",
            login: function () {
                var validator = $('#tabstrip-1').kendoValidator().data('kendoValidator');
                if (validator.validate()) {
                    data.users.login(this.get("username"), this.get("password"))
                        .then(function () {
                            if (successCallback) {
                                successCallback();
                            }
                        }, function (error) {
                            alert(JSON.stringify(error.responseText));
                        });

                    
                }
                else {
                    alert("invalidData");
                }
                
            },
            register: function () {
                var user =
                    {
                        username: this.get("username"),
                        password: this.get("password"),
                        firstName: this.get("firstName"),
                        lastName: this.get("lastName"),
                        avelableMoney:0
                    }
                var validator = $('#tabstrip-2').kendoValidator().data('kendoValidator');
                if (validator.validate()) {
                    data.users.register(user)
                        .then(function () {

                            if (successCallback) {
                                successCallback();
                            }
                        }

                        );
                }
            }
        };
        return kendo.observable(viewModel);
    };

    function getAboutVM(successCallback) {
        var viewModel =
            {
                url: "",
                getOperation: function () {
                    if (successCallback) {
                        if (this.get("url")) {
                            successCallback("/" + this.get("url"));
                        }

                    }
                }
            }

        return kendo.observable(viewModel);

    };

    function getTransactionViewModel(successCallback) {
        
      return  data.users.get().then(function (result) {
           
            var viewModel = {
                money: result.avelableMoney,
                moneyToOperate: 0,
                withdraw: function () {
                    var validator2 = $('#monitor').kendoValidator().data('kendoValidator');
                    if (validator2.validate()) {
                        
                        var money = parseInt(this.get("money"));
                        var moneyToDrow = parseInt(this.get("moneyToOperate"));
                        var self = this;
                        if (money >= moneyToDrow) {
                            data.users.updateMoney(money - moneyToDrow)
                                .then(function (user) {
                                    
                                    self.set("money", user.avelableMoney);
                                    self.set("moneyToOperate", 0);
                                });
                        }
                        else {
                            alert("Not enough money in your account");
                        }
                    }
                   
                },
                deposit: function () {
                   
                    var validator = $('#monitor').kendoValidator().data('kendoValidator');
                    if (validator.validate()) {
                        
                        var money = parseInt(this.get("money"));
                        var moneyToDrow = parseInt(this.get("moneyToOperate"));
                        var self = this;
                        
                            data.users.updateMoney(money + moneyToDrow)
                                .then(function (user) {
                                    
                                    self.set("money", user.avelableMoney);
                                    self.set("moneyToOperate", 0);
                                }, function (error) {
                                    alert(JSON.stringify(error));
                                });
                        }
                }
            }
            return kendo.observable(viewModel);
        })      
    };

    function getLogViewModel(successCallback) {
       
      return data.log.getLog().then(
            function (log) {                
               
                var viewModel = {
                    log:  log
                }

                return kendo.observable(viewModel);
            });  
    }
              
    return {
        getLoginVM: getLoginViewModel,
        getAboutVM: getAboutVM,
        getTransactionViewModel: getTransactionViewModel,
        getLogViewModel:getLogViewModel,
        setPersister: function (persister) {
            data = persister
        }
    };
}());