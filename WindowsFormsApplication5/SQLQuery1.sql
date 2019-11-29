Create database QuanLySanBong
go


use QuanLySanBong
GO



CREATE TABLE Account
(
	DisplayName NVARCHAR(100) NOT NULL DEFAULT N'GUESS',
	UserName NVARCHAR(100) NOT NULL PRIMARY KEY,
	PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
	Type INT NOT NULL DEFAULT 0,
);
GO

CREATE TABLE Thongtinsan
(
	id INT IDENTITY PRIMARY KEY,
	name nvarchar(100) not null default N'chưa có tên'
)
go


CREATE TABLE San
(
	id	INT IDENTITY PRIMARY KEY,
	name nvarchar(100) NOT NULL,
	idCategory INT not null,
	price FLOAT NOT NULL default 0

	FOREIGN KEY (idCategory) REFERENCES dbo.Thongtinsan(id)
)
GO


CREATE TABLE Sanbong
(
	id INT IDENTITY PRIMARY KEY,
	name nvarchar(100) NOT NULL DEFAULT N'CHƯA CÓ TÊN ',
	status nvarchar(100) NOT NULL DEFAULT N'TRỐNG' --trống
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL,
	DateCheckOut DATE,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0 --1 THANH TOAN 0 CHUA TRA

	FOREIGN KEY (idTable) REFERENCES dbo.Sanbong(id)
)	
GO

CREATE TABLE Billinfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill		INT NOT NULL,
	idSan	INT NOT NULL,
	count INT NOT NULL DEFAULT 0

	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idSan) REFERENCES dbo.San(id)
)
GO



-- lấy thông tin account

CREATE PROC USP_GetAccountByUserName
@userName nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName
END
GO

EXEC dbo.USP_GetAccountByUserName @userName = N'admin' --nvarchar(100)

INSERT INTO dbo.Account
	(
	UserName ,
	DisplayName ,
	PassWord ,
	Type) 

VALUES ( N'admin' , -- UserName - nvarchar(100)
		N'ADMINISTRATOR' , -- DisplayName - nvarchar(100)
		N'1' , -- PassWord - nvarchar(1000)
		1 -- Type - int
		)
INSERT INTO dbo.Account
	(
	UserName ,
	DisplayName ,
	PassWord ,
	Type) 

VALUES ( N'staff' , -- UserName - nvarchar(100)
		N'Quan ly' , -- DisplayName - nvarchar(100)
		N'1' , -- PassWord - nvarchar(1000)
		0 -- Type - int
		)
SELECT * FROM dbo.Account WHERE UserName = N'admin' AND PassWord = N'1'

go

DECLARE @i int = 0

while @i <= 9 -- 9 sân
begin

	insert dbo.sanbong ( name)VALUES (N'Sân ' + CAST (@i AS nvarchar(100)))
	set @i = @i + 1
end
go
SELECT * FROM dbo.sanbong


-- lấy bảng sân // table

CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.Sanbong
go


insert dbo.Thongtinsan
	(name)
values (N'Mượn bóng' )

insert dbo.Thongtinsan
	(name)
values (N'Thức ăn' )

insert dbo.Thongtinsan
	(name)
values (N'Thức uống' )
insert dbo.Thongtinsan
	(name)
values (N'Đồng phục mượn' )
insert dbo.Thongtinsan
	(name)
values (N'Dụng cụ y tế / hỗ trợ' )



-- loại 1 bóng


insert dbo.San
	(name, idCategory,price)
values (N'Banh nhựa',1,5000)
insert dbo.San
	(name, idCategory,price)
values (N'Bóng nhẹ Size 3',1,10000)
insert dbo.San
	(name, idCategory,price)
values (N'Bóng vừa Size 4',1,12000)
insert dbo.San
	(name, idCategory,price)
values (N'Bóng chuyên nghiệp',1,20000)
insert dbo.San
	(name, idCategory,price)
values (N'Dụng cụ hỗ trợ',1,10000)

-- loại 2

insert dbo.San
	(name, idCategory,price)
values (N'Bánh Chocopie',2,7000)
insert dbo.San
	(name, idCategory,price)
values (N'Bánh Orion',2,15000)
insert dbo.San
	(name, idCategory,price)
values (N'Bánh KinhDo',2,8000)
insert dbo.San
	(name, idCategory,price)
values (N'Snack khoai tây',2,10000)
insert dbo.San
	(name, idCategory,price)
values (N'Mỳ sống',2,3000)

--loại 3 thức uống

insert dbo.San
	(name, idCategory,price)
values (N'Number 1',3,10000)
insert dbo.San
	(name, idCategory,price)
values (N'Coca',3,10000)
insert dbo.San
	(name, idCategory,price)
values (N'Pepsi',3,10000)
insert dbo.San
	(name, idCategory,price)
values (N'7Up',3,10000)
insert dbo.San
	(name, idCategory,price)
values (N'Revive',3,12000)
insert dbo.San
	(name, idCategory,price)
values (N'Aquafina',3,7000)

--loại 4 đồng phục
insert dbo.San
	(name, idCategory,price)
values (N'Áo quần Realmadrid',4,40000)
insert dbo.San
	(name, idCategory,price)
values (N'Áo quần Juventus',4,40000)
insert dbo.San
	(name, idCategory,price)
values (N'Áo quần Manchester United',4,40000)
insert dbo.San
	(name, idCategory,price)
values (N'Áo quần tập (dạ quang)',4,50000)
insert dbo.San
	(name, idCategory,price)
values (N'Áo phông thể thao co dãn',4,20000)
insert dbo.San
	(name, idCategory,price)
values (N'Quần thể thao co dãn',4,20000)

--loại 5 dụng cụ
insert dbo.San
	(name, idCategory,price)
values (N'Băng gạc',5,10000)
insert dbo.San
	(name, idCategory,price)
values (N'Thuốc đỏ',5,8000)
insert dbo.San
	(name, idCategory,price)
values (N'Băng keo',5,3000)
insert dbo.San
	(name, idCategory,price)
values (N'Bảo vệ chân (đầu gối)',5,60000)
insert dbo.San
	(name, idCategory,price)
values (N'Bảo vệ chân (mắt cá)',5,60000)
insert dbo.San
	(name, idCategory,price)
values (N'Găng tay thủ môn',5,320000)
insert dbo.San
	(name, idCategory,price)
values (N'Giày tự chọn',5,600000)

insert dbo.Bill
	(DateCheckIn,DateCheckOut,idTable,status)
values (GETDATE(),
		null,
		3,
		0
		)

insert dbo.Bill
	(DateCheckIn,DateCheckOut,idTable,status)
values (GETDATE(),
		null,
		4,
		1
		)
	
insert dbo.Billinfo
	(idBill,idSan,count)
values (1,1,3)

insert dbo.Billinfo
	(idBill,idSan,count)
values (2,2,4)

insert dbo.Billinfo
	(idBill,idSan,count)
values (3,3,1)

EXEC dbo.USP_GetTableList



SELECT * FROM dbo.Bill
SELECT * FROM dbo.Billinfo
Select * From dbo.San
SELECT * FROM dbo.Thongtinsan


-- thêm vào bảng table // bảng sân
select s.name,bi.count,s.price,s.price*bi.count as total from dbo.BillInfo as bi, dbo.Bill as b, dbo.San as s
where bi.idBill = b.id and bi.idSan = s.id and b.status=0 and b.idTable = 1

select * from Thongtinsan

create proc USP_InsertBill
@idTable INT
as
begin
	insert dbo.Bill
		(
			
			DateCheckIn ,
			DateCheckOut ,
			idTable ,
			status )
	values (GETDATE(),null,@idTable,0)
END
go
		

-- nhấn nút thanh toán 
create PROC USP_InsertBillInfo
@idBill INT, @idSan INT , @count int
as
begin

	declare @isExitsBillInfo INT;
	declare @sanCount INT = 1

	select @isExitsBillInfo = id, @sanCount =b.count 
	FROM dbo.BillInfo as b 
	where idBill = @idBill and idSan = @idSan

	if (@isExitsBillInfo>0)
	begin
		declare @newCount Int = @sanCount + @count
		if (@newCount > 0)
			update dbo.Billinfo set count = @sanCount + @count
		else
			delete dbo.Billinfo where idBill = @idBill and idSan = @idSan
	end
	else
	begin
			insert dbo.Billinfo
			(idBill,idSan,count)
				values (@idBill ,
				@idSan  , 
				@count )
		end
	end
go



Select max(id) from dbo.bill
go
-- cập nhật bàn trống >> có người
UPDATE dbo.Bill SET status = 1 where id = 1

DELETE dbo.BillInfo
DELETE dbo.Bill


-- check bảng on off
create TRIGGER UTG_UpdateBillInfo
on dbo.Billinfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT

	SELECT @idBill = idBill FROM Inserted

	DECLARE @idTable INT

	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill AND status = 0

	UPDATE dbo.Sanbong SET status = N'Đã có người' where id = @idTable
END
GO


-- kiểm tra nếu bàn trống hoặc không có đơn
create TRIGGER UTG_UpdateBill
ON dbo.Bill FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT

	SELECT @idBill = id FROM Inserted

	DECLARE @idTable INT

	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill 

	DECLARE @count int = 0

	SELECT @count = COUNT(*) FROM dbo.Bill WHERE idTable = @idTable and status = 0

	IF (@count = 0)
		UPDATE dbo.Sanbong SET status = N'TRỐNG' where id = @idTable
END
GO


-- chuyển sân //
CREATE PROC USP_Switch
@idTable1 int, @idTable2 int
as
begin
	DECLARE @idFirstBill int
	DECLARE @idSeconrdBill int

	SELECT @idSeconrdBill = id FROM dbo.Bill WHERE idTable = @idTable2 and status = 0
	SELECT @idFirstBill = id FROM dbo.Bill WHERE idTable = @idTable1 and status = 0

	-- nếu 1 trong 2 sân swap mà null thì 
	IF (@idFirstBill = null)
	begin
		INSERT dbo.Bill(DateCheckIn,DateCheckOut,idTable,status)
		values (GETDATE(),null,@idTable1,0)
		SELECT @idFirstBill = MAX(id)FROM dbo.Bill WHERE idTable = @idTable1 and status = 0
	end

	IF (@idSeconrdBill = null)
	begin
		INSERT dbo.Bill(DateCheckIn,DateCheckOut,idTable,status)
		values (GETDATE(),null,@idTable2,0)
		SELECT @idSeconrdBill = MAX(id)FROM dbo.Bill WHERE idTable = @idTable2 and status = 0
	end

	select id INTO IDBillInfoTable FROM dbo.BillInfo Where idBill = @idSeconrdBill

	UPDATE dbo.Billinfo SET idBill = @idSeconrdBill where idBill = @idFirstBill

	UPDATE dbo.BillInfo SET idBill = @idFirstBill where id IN (select * FROM IDBillInfoTable)

	DROP TABLE IDBillInfoTable

END
GO


-- thêm 1 cột tổng tiền
create table dbo.Bill add totalPrice float
-- hóa đơn cho vào doanh thu
create proc USP_GetListBillByDate
@checkIn date, @checkOut date
as
begin

	SELECT t.name as [Tên sân],b.totalPrice as [Tổng tiền], DateCheckIn as [Ngày đăng ký] , DateCheckOut as [Ngày trả sân] 
	FROM dbo.Bill as b ,dbo.Sanbong as t
	Where DateCheckIn >= @checkIn and DateCheckOut <= @checkOut and b.status = 1
	and t.id = b.idTable

end
go



-- cập nhật tài khoản

create PROC USP_UpdateAccount
@userName NVARCHAR(100), @displayName NVARCHAR(100), @password NVARCHAR(100), @newPassword NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	
	SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE USERName = @userName AND PassWord = @password
	
	IF (@isRightPass = 1)
	BEGIN
		IF (@newPassword = NULL OR @newPassword = '')
		BEGIN
			UPDATE dbo.Account SET DisplayName = @displayName WHERE UserName = @userName
		END		
		ELSE
			UPDATE dbo.Account SET DisplayName = @displayName, PassWord = @newPassword WHERE UserName = @userName
	end
END
GO
select * from dbo.San

