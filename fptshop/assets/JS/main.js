// Code banner-left slide
//Tạo biến imageIndex theo dõi chỉ số của ảnh hiện tại
var imageIndex = 0;

//Mảng chứa đường dẫn ảnh
var images = [
  "./assets/img/banner-left/1.webp",
  "./assets/img/banner-left/2.webp",
  "./assets/img/banner-left/3.webp",
  "./assets/img/banner-left/4.webp",
  "./assets/img/banner-left/5.webp",
];

//Sử dụng hàm setInterval() để thực thi hàm nextImage() 
//sau mỗi khoảng thời gian 3 giây. Kết quả được gán cho biến timer.

var timer = setInterval(nextImage, 3000);

function nextImage() {

  //Tăng imageIndex lên 1
  imageIndex++;

  //Nếu imageIndex vượt qua chiều dài mảng images thì dc đặt thành 0
  if (imageIndex >= images.length) {
    imageIndex = 0;
  }
  //khung image sẽ được lấy nguồn từ mảng images và hiển thị
  document.getElementById("image").src = images[imageIndex];
}

function previousImage() {

  // Giảm imageIndex đi 1
  imageIndex--;
  if (imageIndex < 0) {

    // imageIndex đặt thành images.length - 1 để quay trở lại hình ảnh cuối cùng trong mảng images
    imageIndex = images.length - 1;
  }
  document.getElementById("image").src = images[imageIndex];
}


// // Vô hiệu hóa chuột phải
// //Sự kiện 'contexmenu' được kích hoạt khi người dùng nhấp chuột phải trên trang web
// document.addEventListener('contextmenu', event => {
//   event.preventDefault();
// });

// //Vô hiệu hóa phím F12
// document.addEventListener('keydown', event => {
//   if (event.keyCode === 123) { // 123 là mã phím F12
//     event.preventDefault();
//   }
// });

// // Vô hiệu hóa sự kiện click chuột trái
// document.addEventListener('click', function(e) {
//   if (e.button === 0) { // kiểm tra xem sự kiện click có phải là chuột trái không
//     e.preventDefault(); // ngăn chặn hành động mặc định của sự kiện click
//     e.stopPropagation(); // ngăn chặn sự kiện click lan rộng đến các phần tử cha
//   }
// }, false);


