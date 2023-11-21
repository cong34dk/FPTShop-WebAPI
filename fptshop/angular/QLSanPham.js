var app = angular.module('AppBanDienThoai', []);

    app.controller('ProductController', function ($scope, $http) {
        $scope.products = []; // Dữ liệu sản phẩm được lấy từ API

        // Hàm lấy danh sách sản phẩm
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

        // Hàm xóa sản phẩm
        $scope.deleteProduct = function(productId) {
            if (confirm('Bạn có chắc chắn muốn xóa sản phẩm này không?')) {
                $http({
                    method: "DELETE",
                    url: `https://localhost:44388/api/SanPham/delete/${productId}`
                }).then(function (response) {
                    alert(response.data.message);
                    // Sau khi xóa thành công, cập nhật lại danh sách sản phẩm
                    $scope.LoadSanPham();
                }).catch(function (error) {
                    alert('Có lỗi khi xóa sản phẩm');
                    console.log('Lỗi khi xóa sản phẩm', error);
                });
            }
        };

          // Gọi API khi trang được tải
          $scope.LoadSanPham()

    });