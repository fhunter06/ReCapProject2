--Önce Db olustur
Create Database CarDatabase;

--Cars Table olustur
CREATE TABLE Cars (

    CarId int IDENTITY(1,1) PRIMARY KEY,
    BrandId int,
    ColorId int,
    ModelYear int,
    DailyPrice money,
    Description varchar(255),
);

--Colors Table Olustur
CREATE TABLE Colors (
    ColorId int not null,
    ColorName varchar(40),
);

--Brands Table olustur
CREATE TABLE Brands (
    BrandId int Not Null,
    BrandName varchar(40),
);

--Sonradan Primary key yaptım
ALTER TABLE Colors
ADD PRIMARY KEY (ColorId);

--Sonradan Primary Key yaptım
ALTER TABLE Brands
ADD PRIMARY KEY (BrandId);

--Ekleme yaptım
INSERT INTO Cars (BrandId,ColorId,DailyPrice,ModelYear,Description)
VALUES (1,1,50000,1980,'arac');

Insert Into Colors(ColorId,ColorName)
values (1,'Kırmızı')

Insert Into Brands(BrandId,BrandName)
values (1,'Mercedes')

--Cars'a BrandId ve ColorId referans eklemeye çalıştım. Dogru mu bilmiyorum :)
ALTER TABLE Cars
ADD FOREIGN KEY (BrandId) REFERENCES Brands(BrandId);

ALTER TABLE Cars
ADD FOREIGN KEY (ColorId) REFERENCES Colors(ColorId);