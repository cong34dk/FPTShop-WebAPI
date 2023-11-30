var app = angular.module('AppBanDienThoai', []);

    app.controller('ProductController', function ($scope, $http) {
        //Khai báo biến
        $scope.products = []; // Dữ liệu sản phẩm được lấy từ API

        $scope.newProduct = {
            "maSanPham": 0,
            "maChuyenMuc": 31,
            "tenSanPham": "",
            "anhDaiDien": "",
            "gia": null,
            "giaGiam": null,
            "soLuong": null,
            "trangThai": true,
            "luotXem": 0,
            "dacBiet": false
        };

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

        //Hàm thêm sản phẩm
        // $scope.addProduct = function() {

        //     $http.post('https://localhost:44388/api/SanPham/create-SanPham', $scope.newProduct)
        //         .then(function(response) {
        //             // Xử lý kết quả sau khi thêm sản phẩm thành công
        //             console.log('Sản phẩm đã được thêm:', response.data.filePath);

        //             // Cập nhật đường dẫn ảnh từ API response vào cơ sở dữ liệu
        //             $scope.newProduct.anhDaiDien = response.data.filePath;

        //             // Đặt logic xử lý khi thêm sản phẩm thành công
        //             alert('Sản phẩm đã được thêm thành công');
        //             $scope.LoadSanPham();
        //             $scope.newProduct = {};
        //         })
        //         .catch(function(error) {
        //             // Xử lý khi có lỗi trong quá trình thêm sản phẩm
        //             console.error('Lỗi khi thêm sản phẩm:', error);
        //             // Đặt logic xử lý khi có lỗi
        //             alert('Lỗi khi thêm sản phẩm');
        //         });
        // };


        //Hàm sửa sản phẩm
        $scope.openEditModal = function (product) {
            $scope.isEditModalOpen = true;
            $scope.editedProduct = angular.copy(product); // Copy thông tin sản phẩm cần sửa vào biến editedProduct
        };

        $scope.closeEditModal = function () {
            $scope.isEditModalOpen = false;
        };

        $scope.saveEditedProduct = function () {
            // Sử dụng $scope.editedProduct để lấy thông tin sản phẩm đã chỉnh sửa
            // Sau khi gọi API xong, đóng modal sửa sản phẩm
            $http.put('https://localhost:44388/api/SanPham/update-SanPham', $scope.editedProduct)
                .then(function (response) {
                    // Xử lý kết quả từ API (response)
                    console.log(response.data.message); // Log message từ server
                    alert('Sửa sản phẩm thành công')
                    $scope.LoadSanPham()
                    $scope.isEditModalOpen = false; // Đóng modal sau khi cập nhật thành công
                })
                .catch(function (error) {
                    // Xử lý lỗi (nếu có)
                    console.error('Lỗi khi đang sửa sản phẩm:', error);
                });
        };
        
        $scope.capNhatAnhSanPham = function(files, imgId) {
            var reader = new FileReader();
            reader.onload = function(e) {
                document.getElementById(imgId + 'Preview').src = e.target.result;
            };
            reader.readAsDataURL(files[0]);
            // Gán đường dẫn ảnh đã chọn vào $scope.newProduct.anhDaiDien
            $scope.newProduct.anhDaiDien = files[0].name;
        };
        
        $scope.uploadFile = function (file, event) {
            event.preventDefault();
            var formData = new FormData();
            formData.append('file', file);
    
            $http({
                method: 'POST',
                url: 'https://localhost:44388/api/SanPham/upload',
                headers: {
                    'Content-Type': undefined 
                },
                data: formData
            }).then(function (response) {
                console.log('File uploaded:', response.data.filePath);

                // Hiển thị ảnh được chọn trong modal thêm sản phẩm
                 document.getElementById('anhDaiDienSanPhamThemPreview').src = response.data.filePath;

                 // Cập nhật đường dẫn ảnh trong $scope.newProduct.anhDaiDien sau khi upload thành công
                $scope.newProduct.anhDaiDien = response.data.filePath; 
            }).catch(function (error) {
                console.error('Error uploading file:', error);
            });
        };


        $scope.addProduct = function() {
            var formData = new FormData();
            formData.append('file', document.getElementById('imageInput').files[0]);
            formData.append('tenSanPham', $scope.newProduct.tenSanPham);
            formData.append('maChuyenMuc', $scope.newProduct.maChuyenMuc);
            formData.append('gia', $scope.newProduct.gia);
            formData.append('giaGiam', $scope.newProduct.giaGiam);
            formData.append('soLuong', $scope.newProduct.soLuong);
        
            $http.post('https://localhost:44388/api/SanPham/upload', formData, {
                headers: { 'Content-Type': undefined } // Đảm bảo định dạng form data
            }).then(function(response) {
                // Lấy đường dẫn tệp ảnh từ response
                var imagePath = response.data.filePath;
                
                // Tiến hành thêm sản phẩm với đường dẫn ảnh vào cơ sở dữ liệu
                $scope.newProduct.anhDaiDien = "/assets/img/hot-promotion/" + imagePath;
        
                $http.post('https://localhost:44388/api/SanPham/create-SanPham', $scope.newProduct)
                    .then(function(response) {
                        console.log('Sản phẩm đã được thêm:', response.data);
                        alert('Sản phẩm đã được thêm thành công');
                        $scope.LoadSanPham();
                        $scope.newProduct = {};
                        document.getElementById('previewImage').src = '';
                        document.getElementById('previewImage').style.display = 'none';
                    })
                    .catch(function(error) {
                        console.error('Lỗi khi thêm sản phẩm:', error);
                        alert('Lỗi khi thêm sản phẩm');
                    });
            }).catch(function(error) {
                console.error('Lỗi khi upload ảnh:', error);
                alert('Lỗi khi upload ảnh');
            });
        };
        
        
          // Gọi API khi trang được tải
          $scope.LoadSanPham()

    });