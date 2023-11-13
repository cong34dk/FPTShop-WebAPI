// Khai báo ứng dụng AngularJS
var app = angular.module("AppBanDienThoai", []);

// Tạo controller để quản lý logic
app.controller("HomeController", function ($scope, $http, $window) {
  $scope.categories;

  $scope.LoadChuyenMuc = function () {
    $http({
      method: "GET",
      url: "https://localhost:44321/api/Home/GetAllChuyenMuc",
    }).then(function (response) {
      // Gán dữ liệu từ API vào $scope để hiển thị trong trang HTML
      //   $scope.categories = response.data;
      // Chia dữ liệu thành các hàng (mỗi hàng có 6 phần tử)
      $scope.categories = chunkArray(response.data, 6);
      //   console.log($scope.categories);
    });
  };

  // Hàm chia mảng thành các mảng con với kích thước được chỉ định
  function chunkArray(array, size) {
    var result = [];
    for (var i = 0; i < array.length; i += size) {
      result.push(array.slice(i, i + size));
    }
    return result;
  }

  // Gọi API GetAllChuyenMuc khi trang được tải
  $scope.LoadChuyenMuc();
});
