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