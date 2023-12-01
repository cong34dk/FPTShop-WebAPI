USE [BanDienThoai_NguyenDinhCong]
GO

--Hàm thủ tục Procuduce-
SELECT * FROM KhachHangs
GO

--Hàm thủ tục Insert data khách hàng


CREATE PROCEDURE sp_InsertKhachHang
(
    @TenKH nvarchar(50),
    @GioiTinh bit,
    @DiaChi nvarchar(250),
    @SDT nvarchar(50),
    @Email nvarchar(250)
)
AS
BEGIN
    INSERT INTO KhachHangs (TenKH, GioiTinh, DiaChi, SDT, Email)
    VALUES (@TenKH, @GioiTinh, @DiaChi, @SDT, @Email)
END;
GO

--Hàm thủ tục tìm kiếm khách hàng theo mã ID
CREATE PROCEDURE sp_khachhang_get_by_id
(
	@Id int
)
AS
BEGIN 
	SELECT* FROM KhachHangs WHERE Id=@Id;
END;
GO

--Hàm update khách hàng
CREATE PROCEDURE sp_khachhang_update
(
	@Id int,
	@TenKH nvarchar(50),
	@GioiTinh BIT,
	@DiaChi nvarchar(250),
	@SDT nvarchar(50),
	@Email nvarchar(250)
)
AS
BEGIN
	UPDATE KhachHangs
		SET TenKH=@TenKH,
		GioiTinh=@GioiTinh,
		DiaChi=@DiaChi,
		SDT=@SDT,
		Email=@Email
	WHERE id=@Id;
END;
GO

--Hàm thủ tục xóa khách hàng
CREATE PROCEDURE sp_khachhang_delete
(
	@Id int
)
AS
BEGIN
	DELETE FROM KhachHangs
	WHERE Id=@Id;
END;
GO

--Tìm kiếm trang khách hàng
CREATE PROCEDURE sp_khach_search (@page_index  INT, 
                                       @page_size   INT,
									   @ten_khach Nvarchar(50),
									   @dia_chi Nvarchar(250)
									   )
AS
    BEGIN
        DECLARE @RecordCount BIGINT;
        IF(@page_size <> 0)
            BEGIN
						SET NOCOUNT ON;
                        SELECT(ROW_NUMBER() OVER(
                              ORDER BY TenKH ASC)) AS RowNumber, 
                              k.Id,
							  k.TenKH,
							  k.DiaChi
                        INTO #Results1
                        FROM KhachHangs AS k
					    WHERE  (@ten_khach = '' Or k.TenKH like N'%'+@ten_khach+'%') and						
						(@dia_chi = '' Or k.DiaChi like N'%'+@dia_chi+'%');                   
                        SELECT @RecordCount = COUNT(*)
                        FROM #Results1;
                        SELECT *, 
                               @RecordCount AS RecordCount
                        FROM #Results1
                        WHERE ROWNUMBER BETWEEN(@page_index - 1) * @page_size + 1 AND(((@page_index - 1) * @page_size + 1) + @page_size) - 1
                              OR @page_index = -1;
                        DROP TABLE #Results1; 
            END;
            ELSE
            BEGIN
						SET NOCOUNT ON;
                        SELECT(ROW_NUMBER() OVER(
                              ORDER BY TenKH ASC)) AS RowNumber, 
                              k.Id,
							  k.TenKH,
							  k.DiaChi
                        INTO #Results2
                        FROM KhachHangs AS k
					    WHERE  (@ten_khach = '' Or k.TenKH like N'%'+@ten_khach+'%') and						
						(@dia_chi = '' Or k.DiaChi like N'%'+@dia_chi+'%');                   
                        SELECT @RecordCount = COUNT(*)
                        FROM #Results2;
                        SELECT *, 
                               @RecordCount AS RecordCount
                        FROM #Results2;                        
                        DROP TABLE #Results1; 
        END;
    END;
GO

--Hàm procudre tài khoản
CREATE PROCEDURE sp_login (@taikhoan nvarchar(50), @matkhau nvarchar(50))
AS
    BEGIN
      SELECT  *
      FROM TaiKhoans
      where TenTaiKhoan= @taikhoan and MatKhau = @matkhau;
    END;
GO


--Tìm kiếm id hóa đơn
CREATE PROCEDURE sp_hoadon_get_by_id(@MaHoaDon int)
AS
    BEGIN
        SELECT h.*, 
        (
            SELECT c.*
            FROM ChiTietHoaDons AS c
            WHERE h.MaHoaDon = c.MaHoaDon FOR JSON PATH --trả về dưới dạng JSON bằng FOR JSON PATH. Điều này tạo ra một chuỗi JSON chứa thông tin về chi tiết hóa đơn.
        ) AS list_json_chitiethoadon
        FROM HoaDons AS h
        WHERE  h.MaHoaDon = @MaHoaDon;
    END;
GO


DECLARE @MaHoaDon int
SET @MaHoaDon = 1 

EXEC sp_hoadon_get_by_id @MaHoaDon

----Stored lấy về tất cả tài khoản từ bảng TaiKhoans
CREATE PROCEDURE sp_get_all_users
AS
BEGIN
    SELECT * FROM TaiKhoans;
END

--Hàm thủ tục lấy về tài khoản theo mã ID
CREATE PROCEDURE sp_get_by_id_user
(
	@Id int
)
AS
BEGIN 
	SELECT * FROM TaiKhoans WHERE MaTaiKhoan=@Id;
END;
GO

EXEC sp_get_by_id_user 1

-- Tạo stored procedure để chèn dữ liệu vào bảng TaiKhoans mà không cần nhập MaTaiKhoan
CREATE PROCEDURE sp_create_user
    @LoaiTaiKhoan int,
    @TenTaiKhoan nvarchar(50),
    @MatKhau nvarchar(50),
    @Email nvarchar(150)
AS
BEGIN
    SET NOCOUNT ON;

    -- Thêm tài khoản mới vào bảng TaiKhoans
    INSERT INTO [dbo].[TaiKhoans] ([LoaiTaiKhoan], [TenTaiKhoan], [MatKhau], [Email])
    VALUES (@LoaiTaiKhoan, @TenTaiKhoan, @MatKhau, @Email);

    -- Lấy mã tài khoản mới đã được tạo tự động (nếu sử dụng cột Identity)
    DECLARE @NewMaTaiKhoan int;
    SET @NewMaTaiKhoan = SCOPE_IDENTITY();

    -- Trả về mã tài khoản của tài khoản mới được thêm vào
    SELECT @NewMaTaiKhoan AS MaTaiKhoan;
END


-----Tạo procedure thực hiện sửa tài khoản
CREATE PROCEDURE sp_update_user
    @MaTaiKhoan int,
    @LoaiTaiKhoan int,
    @TenTaiKhoan nvarchar(50),
    @MatKhau nvarchar(50),
    @Email nvarchar(150)
AS
BEGIN
    SET NOCOUNT ON;

    -- Thực hiện cập nhật thông tin tài khoản trong bảng TaiKhoans
    UPDATE [dbo].[TaiKhoans]
    SET [LoaiTaiKhoan] = @LoaiTaiKhoan,
        [TenTaiKhoan] = @TenTaiKhoan,
        [MatKhau] = @MatKhau,
        [Email] = @Email
    WHERE [MaTaiKhoan] = @MaTaiKhoan;

    -- Trả về số hàng bị ảnh hưởng
    SELECT @@ROWCOUNT AS 'RowsAffected';
END

-----PROC xóa tài khoản
CREATE PROCEDURE sp_delete_user
    @MaTaiKhoan int
AS
BEGIN
    SET NOCOUNT ON;

    -- Thực hiện xóa tài khoản từ bảng TaiKhoans
    DELETE FROM [dbo].[TaiKhoans]
    WHERE [MaTaiKhoan] = @MaTaiKhoan;
END


-----Tạo procedure thực hiện thêm sản phẩm
CREATE PROCEDURE sp_AddSanPham
    @MaChuyenMuc int,
    @TenSanPham nvarchar(150),
    @AnhDaiDien nvarchar(350),
    @Gia decimal(18, 0),
    @GiaGiam decimal(18, 0),
    @SoLuong int,
    @TrangThai bit,
    @LuotXem int,
    @DacBiet bit
AS
BEGIN
    INSERT INTO dbo.SanPhams (MaChuyenMuc, TenSanPham, AnhDaiDien, Gia, GiaGiam, SoLuong, TrangThai, LuotXem, DacBiet)
    VALUES (@MaChuyenMuc, @TenSanPham, @AnhDaiDien, @Gia, @GiaGiam, @SoLuong, @TrangThai, @LuotXem, @DacBiet)
    
    SELECT CAST(scope_identity() AS int) -- Trả về ID của sản phẩm mới được thêm
END
GO


SELECT * FROM sys.procedures;

exec sp_get_all_users

EXEC sp_create_user
    @LoaiTaiKhoan = 1,
    @TenTaiKhoan = 'hiep',
    @MatKhau = '123',
    @Email = 'hiep@gmail.com';


-- Xóa stored procedure có tên "usp_InsertTaiKhoan"
DROP PROCEDURE sp_create_user;


-- Xóa tài khoản dựa trên mã tài khoản
DELETE FROM [dbo].[TaiKhoans]
WHERE [MaTaiKhoan] = N'4';


-- Chạy stored procedure sp_update_user để cập nhật tài khoản người dùng
DECLARE @MaTaiKhoan int = 11; 
DECLARE @LoaiTaiKhoan int = 2; 
DECLARE @TenTaiKhoan nvarchar(50) = N'okroi'; 
DECLARE @MatKhau nvarchar(50) = N'000';
DECLARE @Email nvarchar(150) = N'newemail@example.com'; 

EXEC sp_update_user
    @MaTaiKhoan,
    @LoaiTaiKhoan,
    @TenTaiKhoan,
    @MatKhau,
    @Email;

exec sp_delete_user 9



EXEC sp_AddSanPham
    @MaChuyenMuc = 1, -- Giả sử mã chuyên mục là 1
    @TenSanPham = N'Điện thoại iPhone 13',
    @AnhDaiDien = N'iphone_13.png',
    @Gia = 20000000,
    @GiaGiam = 19000000,
    @SoLuong = 100,
    @TrangThai = 1, -- 1 cho sản phẩm đang hoạt động, 0 cho ngừng kinh doanh
    @LuotXem = 0, -- Số lượt xem ban đầu thường là 0
    @DacBiet = 0 -- 0 cho sản phẩm không đặc biệt, 1 cho sản phẩm đặc biệt


-----Stored Procedure để thêm một sản phẩm mới
CREATE PROCEDURE sp_InsertSanPham
    @MaChuyenMuc int,
    @TenSanPham nvarchar(150),
    @AnhDaiDien nvarchar(350),
    @Gia decimal(18, 0),
    @GiaGiam decimal(18, 0),
    @SoLuong int,
    @TrangThai bit,
    @LuotXem int,
    @DacBiet bit
AS
BEGIN
    INSERT INTO SanPhams (MaChuyenMuc, TenSanPham, AnhDaiDien, Gia, GiaGiam, SoLuong, TrangThai, LuotXem, DacBiet)
    VALUES (@MaChuyenMuc, @TenSanPham, @AnhDaiDien, @Gia, @GiaGiam, @SoLuong, @TrangThai, @LuotXem, @DacBiet)
    
    SELECT SCOPE_IDENTITY() -- Trả về ID của sản phẩm vừa được thêm vào
END
GO

-----Stored Procedure để cập nhật thông tin sản phẩm:
CREATE PROCEDURE sp_UpdateSanPham
    @MaSanPham int,
    @MaChuyenMuc int,
    @TenSanPham nvarchar(150),
    @AnhDaiDien nvarchar(350),
    @Gia decimal(18, 0),
    @GiaGiam decimal(18, 0),
    @SoLuong int,
    @TrangThai bit,
    @LuotXem int,
    @DacBiet bit
AS
BEGIN
    UPDATE SanPhams
    SET
        MaChuyenMuc = @MaChuyenMuc,
        TenSanPham = @TenSanPham,
        AnhDaiDien = @AnhDaiDien,
        Gia = @Gia,
        GiaGiam = @GiaGiam,
        SoLuong = @SoLuong,
        TrangThai = @TrangThai,
        LuotXem = @LuotXem,
        DacBiet = @DacBiet
    WHERE MaSanPham = @MaSanPham
END
GO

----Stored Procedure để xóa sản phẩm:
CREATE PROCEDURE sp_DeleteSanPham
    @MaSanPham int
AS
BEGIN
    DELETE FROM SanPhams
    WHERE MaSanPham = @MaSanPham
END
GO


----Stored Procedure để tìm kiếm sản phẩm:
CREATE PROCEDURE sp_SearchSanPhams
    @Keyword nvarchar(150),
    @PageIndex int,
    @PageSize int,
    @Total int OUTPUT
AS
BEGIN
    -- Tính số lượng bản ghi tìm kiếm được
    SELECT @Total = COUNT(*)
    FROM SanPhams
    WHERE (@Keyword IS NULL OR TenSanPham LIKE '%' + @Keyword + '%')

    -- Thực hiện truy vấn tìm kiếm và phân trang
    SELECT *
    FROM
    (
        SELECT ROW_NUMBER() OVER (ORDER BY MaSanPham) as RowNum, *
        FROM SanPhams
        WHERE (@Keyword IS NULL OR TenSanPham LIKE '%' + @Keyword + '%')
    ) AS SanPhamsWithRowNumbers
    WHERE RowNum BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize

    -- Trả về tổng số lượng bản ghi tìm kiếm được
    SELECT @Total AS TotalRecords
END
GO

----- Stored lấy về tất cả các sản phẩm từ bảng SanPhams:
CREATE PROCEDURE sp_GetAllSanPhams
AS
BEGIN
    SELECT * FROM SanPhams;
END
GO

------stored procedure để lấy về thông tin sản phẩm dựa trên ID từ bảng SanPhams
CREATE PROCEDURE sp_GetSanPhamByID
    @MaSanPham INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM SanPhams WHERE MaSanPham = @MaSanPham;
END
GO


--------Chạy stored của SanPhams
--------
DECLARE @NewProductId INT;

EXEC sp_InsertSanPham
    @MaChuyenMuc = 1, -- Hoặc NULL nếu không có chuyên mục
    @TenSanPham = N'Iphone 6',
    @AnhDaiDien = N'iphone6.png',
    @Gia = 1000000,
    @GiaGiam = 900000,
    @SoLuong = 100,
    @TrangThai = 1, -- Hoặc 0
    @LuotXem = 0,
    @DacBiet = 0; -- Hoặc 1

SELECT @NewProductId AS NewProductId;

----------
EXEC sp_UpdateSanPham
    @MaSanPham = 6,
    @MaChuyenMuc = 1, -- Hoặc NULL nếu không có chuyên mục
    @TenSanPham = N'Iphone 4',
    @AnhDaiDien = N'iphone4.png',
    @Gia = 1100000,
    @GiaGiam = 950000,
    @SoLuong = 150,
    @TrangThai = 1, -- Hoặc 0
    @LuotXem = 10,
    @DacBiet = 0; -- Hoặc 1
	 
--------
EXEC sp_DeleteSanPham @MaSanPham = 6;

------ Search
DECLARE @TotalRecords INT;

EXEC sp_SearchSanPhams
    @Keyword = N'iPhone',
    @PageIndex = 1,
    @PageSize = 10,
    @Total = @TotalRecords OUTPUT;

SELECT @TotalRecords AS TotalNumberOfProducts;

----
EXEC sp_GetAllSanPhams;

EXEC sp_GetSanPhamByID 3

GO
----Stored lấy về tổng doanh thu
CREATE PROCEDURE sp_GetTotalRevenue
AS
BEGIN
    SELECT SUM(TongGia) AS TotalRevenue
    FROM HoaDons
    WHERE TrangThai = 1; -- Giả sử TrangThai = 1 đại diện cho hóa đơn đã được thanh toán
END
GO

EXEC sp_GetTotalRevenue;

GO
-------Stored lấy về tổng doanh thu theo khoảng thời gian
CREATE PROCEDURE sp_GetTotalRevenueByDateRange
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT SUM(TongGia) AS TotalRevenue
    FROM HoaDons
    WHERE TrangThai = 1 AND NgayTao BETWEEN @StartDate AND @EndDate;
END
GO

EXEC sp_GetTotalRevenueByDateRange @StartDate = '2023-01-01', @EndDate = '2023-12-31';


GO
-----stored getALLDanhMuc
CREATE PROCEDURE GetAllChuyenMuc
AS
BEGIN
    SELECT * FROM ChuyenMucs;
END;

GO

EXEC GetAllChuyenMuc

GO
------stored procedure 
CREATE PROCEDURE sp_GetChuyenMucByID
    @MaChuyenMuc INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM ChuyenMucs WHERE MaChuyenMuc = @MaChuyenMuc;
END
GO

EXEC sp_GetChuyenMucByID 37

GO
-----stored GetAllSlide
CREATE PROCEDURE GetAllSlide
AS
BEGIN
    SELECT * FROM Slide;
END;

GO

EXEC GetAllSlide

GO
------stored procedure 
CREATE PROCEDURE sp_GetSlideByID
    @MaAnh INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM Slide WHERE MaAnh = @MaAnh;
END
GO

EXEC sp_GetSlideByID 11

GO

-------Stored Procedure cho Đổi Mật Khẩu
GO
CREATE PROCEDURE ChangePassword
    @TenTaiKhoan NVARCHAR(50),
    @MatKhauCu NVARCHAR(50),
    @MatKhauMoi NVARCHAR(50)
AS
BEGIN
    UPDATE TaiKhoans
    SET MatKhau = @MatKhauMoi
    WHERE TenTaiKhoan = @TenTaiKhoan AND MatKhau = @MatKhauCu
END

GO
EXEC ChangePassword 'dung', '123', '789'

GO
-----stored
GO
CREATE PROCEDURE ForgotPassword
    @Email NVARCHAR(100)
AS
BEGIN
    DECLARE @Password NVARCHAR(50);

    -- Tìm mật khẩu cho email tương ứng
    SELECT @Password = MatKhau
    FROM TaiKhoans
    WHERE Email = @Email;

    -- Nếu tìm thấy mật khẩu, trả về mật khẩu đó
    IF (@Password IS NOT NULL)
    BEGIN
        SELECT @Password AS 'MatKhau'; -- Trả về mật khẩu
    END
    ELSE
    BEGIN
        -- Nếu không tìm thấy mật khẩu cho email đã nhập
        -- Có thể thêm thông báo hoặc xử lý khác tùy theo yêu cầu
        SELECT N'Email không tồn tại trong hệ thống.' AS 'Message'; 
    END
END

EXEC ForgotPassword 'dung@gmail.com'

GO
----stored
CREATE PROCEDURE sp_GetAllQuangCaos
AS
BEGIN
    SELECT * FROM QuangCaos;
END
GO

EXEC sp_GetAllQuangCaos

---------------------------Phân Trang Sản Phẩm---------------------
CREATE PROCEDURE GetPagedProducts
    @PageNumber INT,
    @PageSize INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Offset INT;

    -- Tính toán Offset
	--trang đầu tiên có vị trí bắt đầu từ 0
    SET @Offset = (@PageNumber - 1) * @PageSize;

    -- Sử dụng câu truy vấn phân trang với OFFSET và FETCH
    SELECT *
    FROM SanPhams
    ORDER BY MaSanPham
    OFFSET @Offset ROWS
    FETCH NEXT @PageSize ROWS ONLY;
    
    -- Tính tổng số trang
    DECLARE @TotalPages INT;
    SELECT @TotalPages = CEILING(COUNT(*) * 1.0 / @PageSize) FROM SanPhams;

    SELECT @TotalPages AS TotalPages;
END;
GO
EXEC GetPagedProducts @PageNumber = 1, @PageSize = 10;
GO