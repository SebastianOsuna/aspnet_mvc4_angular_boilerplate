(function (angular) {
    var app = angular.module('exampleApp', [ 'pascalprecht.translate' ]);
    app.config(function ($translateProvider) {
        $translateProvider.translations('en', {
            user: {
                username: 'Username',
                password: 'Password'
            },
            submit: 'Submit',
            welcome: 'Welcome',
            logout: 'Log out'
        }).translations('es', {
            user: {
                username: 'Usuario',
                password: 'Contraseña'
            },
            submit: 'Enviar',
            welcome: 'Bienvenido',
            logout: 'Salir'
        });

        $translateProvider.preferredLanguage('en');
    }).controller('SessionsController', function ($scope, $http) {
        var self = this;
        self._current_user = null;

        self.login = function () {
            
            if (self.user.username && self.user.password) {
                $http.post('api/sessions', self.user).then(function (session) {
                    self._current_user = {
                        username: self.user.username,
                        token: session.data.token
                    };
                }, function (err) {
                    console.log(err);
                });
            }

        };

        self.getSession = function () {
            var req = {
                method: 'GET',
                url: 'api/sessions?username=' + self._current_user.username,
                headers: {
                    'Authentication': self._current_user.token
                }
            };
            var proxy = self.proxy = {};
            $http(req)
                .then(function (session) {
                    proxy.data = session.data;
                })
            return proxy;
        };

        self.logout = function () {
            self._current_user = null;
        };

        self.authenticated = function () {
            return !!self._current_user;
        };

    }).controller('LanguageController', function ($translate) {

        this.current = $translate.use();

        this.changeLanguage = function (lang) {
            this.current = lang;
            $translate.use(lang);
        };

    });
})(angular);