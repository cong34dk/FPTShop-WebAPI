// Khai báo ứng dụng AngularJS
var app = angular.module("AppBanDienThoai", []);

// Tạo controller để quản lý logic
app.controller("HomeController", function ($scope, $http, $window, $interval) {
  // Khai báo biến
  $scope.pageNumber = 1;
  $scope.pageSize = 8;
  $scope.totalPages = 0;

  $scope.categories;
  $scope.currentImage;
  $scope.imageIndex = 0;
  $scope.advertisement;
  $scope.products;


  $scope.LoadChuyenMuc = function () {
    $http({
      method: "GET",
      url: "https://localhost:7102/user-gateway/Home/GetAllChuyenMuc",
    }).then(function (response) {
      // Gán dữ liệu từ API vào $scope để hiển thị trong trang HTML
      //   $scope.categories = response.data;
      // Chia dữ liệu thành các hàng (mỗi hàng có 6 phần tử)
      $scope.categories = chunkArray(response.data, 6);
      //   console.log($scope.categories);
    });
  };



  $scope.LoadSlide = function (){
    $http({
        method: "GET",
        url: "https://localhost:7102/user-gateway/Home/GetAllSlide",
    }).then(function (response){
        $scope.images = response.data;
        $scope.currentImage = $scope.images[0].linkAnh;

        // Sử dụng $interval để tự động chuyển ảnh sau 3 giây
        $interval($scope.nextImage, 3000);      
    })
  }

  $scope.LoadQuangCao = function (){
    $http({
      method: "GET",
      url: "https://localhost:7102/user-gateway/Home/GetAllQuangCaos",
    }).then(function (response){
          $scope.advertisements = response.data;
          $scope.advertisement = $scope.advertisements[0];

    })
  }
  // Load chạy Danh Sach sản phẩm
  $scope.listSanPham = [];
  $scope.LoadSanPham = function () {
      $http({
          method: 'GET',
          url: 'https://localhost:44388/api/SanPham/phan-trang',
          params: { pageNumber: $scope.pageNumber, pageSize: $scope.pageSize }
      }).then(function (response) {
          $scope.listSanPham = response.data.products;
          $scope.totalPages = response.data.totalPages;
      });
  };

  // $scope.LoadSanPham();

  // Hàm thay đổi trang
  $scope.changePage = function (pageNumber) {
      $scope.pageNumber = pageNumber;
      $scope.LoadSanPham();
  };

  // Hàm tạo mảng trang để hiển thị
  $scope.getPages = function (totalPages) {
      return new Array(totalPages);
  };


  // $scope.LoadSanPham = function (){
  //   $http({
  //     method: "GET",
  //     url: "https://localhost:7102/user-gateway/Home/GetAllSanPhams",
  //   }).then(function (response){
  //     $scope.products = response.data;
  //   })
  //   .catch(function(error){
  //     console.log('Có lỗi khi lấy dữ liệu từ API', error)
  //   })
  // }

  // Hàm chia mảng thành các mảng con với kích thước được chỉ định
  function chunkArray(array, size) {
    var result = [];
    for (var i = 0; i < array.length; i += size) {
      result.push(array.slice(i, i + size));
    }
    return result;
  }


  $scope.nextImage = function () {
    $scope.imageIndex++;
    if ($scope.imageIndex >= $scope.images.length) {
      $scope.imageIndex = 0;
    }
    $scope.currentImage = $scope.images[$scope.imageIndex].linkAnh;
  };

  $scope.previousImage = function () {
    $scope.imageIndex--;
    if ($scope.imageIndex < 0) {
      $scope.imageIndex = $scope.images.length - 1;
    }
    $scope.currentImage = $scope.images[$scope.imageIndex].linkAnh;
  };



  // Gọi API khi trang được tải
  $scope.LoadChuyenMuc();
  $scope.LoadSlide();
  $scope.LoadQuangCao();
  $scope.LoadSanPham();
});

app.filter('currencyDisplayFormat', function() {
  return function(input) {
      if (!isNaN(input)) {
          //Nếu input là số hợp lệ(không phải là NaN)
          // Chuyển đổi số thành chuỗi và loại bỏ dấu phân cách hàng nghìn
          return parseFloat(input).toFixed(0).replace(/\B(?=(\d{3})+(?!\d))/g, ",");
      } else {
          return input;
      }
  };
});
