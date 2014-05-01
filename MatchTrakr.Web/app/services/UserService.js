'use strict';

app.service('UserService', ['$http', function UserService($http) {
      var userData = {
          isAuthenticated: false,
          username: '',
          bearerToken: '',
          expirationDate: null,
      };

      function setHttpAuthHeader() {
          $http.defaults.headers.common.Authorization = 'Bearer ' + userData.bearerToken;
      }

      function clearUserData() {
          userData.isAuthenticated = false;
          userData.username = '';
          userData.bearerToken = '';
          userData.expirationDate = null;
      };

      this.getUserData = function () {
          return userData;
      };

      this.authenticate = function (username, password, successCallback, errorCallback) {
          var config = {
              method: 'POST',
              url: '/token',
              headers: {
                  'Content-Type': 'application/x-www-form-urlencoded',
              },
              data: 'grant_type=password&username=' + username + '&password=' + password,
          };

          $http(config)
            .success(function (data) {
                userData.isAuthenticated = true;
                userData.username = data.userName;
                userData.bearerToken = data.access_token;
                userData.expirationDate = new Date(data['.expires']);
                setHttpAuthHeader();
                if (typeof successCallback === 'function') {
                    successCallback();
                }
            })
            .error(function (data) {
                if (typeof errorCallback === 'function') {
                    if (data.error_description) {
                        errorCallback(data.error_description);
                    } else {
                        errorCallback('Unable to contact server; please, try again later.');
                    }
                }
            });
      };

      this.removeAuthentication = function () {
          clearUserData();
          $http.defaults.headers.common.Authorization = null;
      };
  }]);