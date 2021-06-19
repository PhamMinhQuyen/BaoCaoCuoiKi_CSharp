create database PhamMinhQuyenDB
use PhamMinhQuyenDB
drop table UserAccount 
create table UserAccount 
(
	ID int identity(1,1) primary key,
	Username varchar(50),
	Password varchar(50),
	Status nvarchar(50)
)

insert into UserAccount(Username,Password,Status)
values
('admin','admin','Blocked ')

create table Category
(
		ID int identity(1,1) primary key,
		Name nvarchar(100),
		Description nvarchar(100)
)

insert into Category(Name,Description)
values
('Sneaker',N'Gi�y Sneaker'),
('Nike',N'Gi�y Nike');

DROP table Product
create table Product
(
	ID int identity(1,1) primary key,
	Name nvarchar(100),
	UnitCost int,
	Quantity int,
	Image nvarchar(50),
	Description nvarchar(200),
	Status nvarchar(50),
	ID_Category int foreign key references Category(ID)
)

insert into Product(Name,UnitCost,Quantity,Image,Description,Status,ID_Category)
values
(N'Falcon Crystal White Navy','982.000 ?',10,NULL,N'Adidas kh�ng khi?n fans c?a h�ng gi�y 3 s?c n�y th?t v?ng khi li�n ti?p cho release nh?ng m?u gi�y ??c ?�o ??m t�nh th?i trang v� lu�n ch�y h�ng tr�n m?i m?t tr?n',NULL,1)