var app = angular.module('AppBanDienThoai', []);

    app.controller('ProductController', function ($scope, $http) {
        $scope.products = [];

        $scope.LoadSanPham = function (){
            $http({
                method: "GET",
                url: "https://localhost:44388/api/SanPham/get-all"
            }).then(function (response) {
                $scope.products = response.data;
            }).catch(function (error) {
                console.log('Có lỗi khi lấy dữ liệu từ API', error);
            });
        }

          // Gọi API khi trang được tải
          $scope.LoadSanPham()

    });