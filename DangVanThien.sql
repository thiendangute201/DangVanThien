create database DangVanThienDB02
go
use DangVanThienDB02
go
set dateformat dmy

--
-- CREATE TABLE
--
create table tblUserAccount
(
	idUser		char(7) primary key,
	userName	varchar(50) unique,
	password	varchar(max),
	status		char(1) default '1'
		check(status in ('1', '2'))
)

create table tblDanhMuc (
	idDM	char(7) primary key,
	tenDM	nvarchar(100),
	moTa	nvarchar(500),
)


create table tblSanPham(
	idSP		char(7) primary key,
	tenSP		nvarchar(100),
	soLuong		int default 0
		check (soLuong >= 0),
	giaBan		money default 0
		check (giaBan >= 0),
	hinhAnh		varchar(max),
	mota		varchar(500),
	trangThai	char(1) default 'e'
		check (trangThai in('e', 'd')),
	DMNo		char(7) constraint FK_DMNo foreign key references tblDanhMuc(idDM)
)

--
--	INSERT
--

insert into tblUserAccount values
	('A000001', 'thiendang123', 'aaa', '1'),
	('A000002', 'vanthien123', 'bbb', '1'),
	('U000003', 'thienvan123', 'ccc', '2'),
	('U000004', 'dangthien123', 'ddd', '2'),
	('U000005', 'vandang123', 'eee', '1 '),
	('A000006', 'test111', 'aaa', '1'),
	('A000007', 'test112', 'bbb', '1'),
	('U000008', 'test113', 'ccc', '2'),
	('U000009', 'test114', 'ddd', '2'),
	('U000010', 'test115', 'eee', '1 ')

insert into tblDanhMuc values
	('DM00001', N'Bánh ngọt', N'Mấy cái bánh này ngon lắm, mua điiii'),
	('DM00002', N'Thức uống', N'Mấy chai nước này ngon lắm, mua điiiiii')

insert into tblSanPham values
	('SP00001', N'Black Forest', 20, 30000, null, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, sit amet commodo magna eros quis urna.', default, 'DM00001'),
	('SP00002', N'Bánh su kem', 10, 40000, null, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, sit amet commodo magna eros quis urna.', default, 'DM00001'),
	('SP00003', 'Cupcake', 43, 15000, null,'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, sit amet commodo magna eros quis urna.', default, 'DM00001'),
	('SP00004', 'Muffin', 35, 20000, null , 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, sit amet commodo magna eros quis urna.', default, 'DM00001'),
	('SP00005', 'Pancake ', 5, 30000, null , 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, sit amet commodo magna eros quis urna.', default, 'DM00001'),
	('SP00006', 'Coca Cola', 5, 10000, null, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, sit amet commodo magna eros quis urna.', default, 'DM00002'),
	('SP00007', '7 UP ', 5, 30000, null, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, sit amet commodo magna eros quis urna.', default, 'DM00002')

