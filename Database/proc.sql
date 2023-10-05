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

--Hàm thủ tục Insert data quản trị
CREATE PROCEDURE [dbo].[sp_Insert_QuanTri](
	@hoten nvarchar(150),
	@diachi nvarchar(250),
	@gioitinh nvarchar(30),
	@email nvarchar(100),
	@taikhoan nvarchar(100),
	@matkhau nvarchar(100)
)
AS
    BEGIN
       insert into QuanTri(hoten, diachi, gioitinh, email, taikhoan, matkhau)
	   values(@hoten, @diachi, @gioitinh, @email, @taikhoan, @matkhau);
    END;
GO



SELECT * FROM sys.procedures;
