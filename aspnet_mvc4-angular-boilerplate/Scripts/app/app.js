(function (angular) {
    var app = angular.module('exampleApp', [ 'pascalprecht.translate' ]);
    app.config(function ($translateProvider) {
        $translateProvider.translations('en', {
            user: {
                username: 'Username',
                password: 'Password'
            },
            submit: 'Submit'
        }).translations('es', {
            user: {
                username: 'Usuario',
                password: 'Contraseña'
            },
            submit: 'Enviar'
        });

        $translateProvider.preferredLanguage('en');
    }).controller('SessionsController', function ($scope) {

    }).controller('LanguageController', function ($translate) {

        this.current = 'en';

        this.changeLanguage = function (lang) {
            this.current = lang;
            
            $translate.use(lang).then(function(){}, function(){ console.log(arguments)});
        };

    });
})(angular);