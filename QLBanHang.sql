CREATE TABLE [dbo].[tblMathang]
(
	[masp] NCHAR(5) NOT NULL PRIMARY KEY, 
    [tensp] NVARCHAR(30) NULL, 
    [ngaysx] DATE NULL, 
    [ngayhh] DATE NULL, 
    [donvi] NVARCHAR(10) NULL, 
    [dongia] FLOAT NULL, 
    [ghichu] NVARCHAR(200) NULL
)
