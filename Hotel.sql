CREATE DATABASE [Hotel]
USE [Hotel]

CREATE TABLE [users] 
(
  [user_id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [username] nvarchar(255) UNIQUE NOT NULL,
  [password] nvarchar(255) NOT NULL,
  [type] nvarchar(255) NOT NULL CHECK ([type] IN ('client', 'worker', 'admin'))
)
GO

CREATE TABLE [reservations] 
(
  [reservation_id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [user_id] int NOT NULL,
  [start_date] datetime NOT NULL,
  [end_date] datetime NOT NULL,
  [status] nvarchar(255) NOT NULL CHECK ([status] IN ('active', 'cancelled', 'paid'))
)
GO

CREATE TABLE [services] 
(
  [service_id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [name] nvarchar(255) NOT NULL,
  [price] int NOT NULL,
  [is_deleted] bit NOT NULL DEFAULT (0)
)
GO

CREATE TABLE [reservation_service] 
(
  [reservation_id] int NOT NULL,
  [service_id] int NOT NULL
)
GO

CREATE TABLE [rooms] 
(
  [room_id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [reservation_id] int,
  [type] nvarchar(255) NOT NULL CHECK ([type] IN ('type_A', 'type_B', 'type_C', 'type_D')),
  [price] int NOT NULL,
  [is_deleted] bit NOT NULL DEFAULT (0)
)
GO

CREATE TABLE [images] 
(
  [image_id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [room_id] int,
  [path] nvarchar(255) NOT NULL,
  [is_deleted] bit NOT NULL DEFAULT (0)
)
GO

ALTER TABLE [reservations] ADD FOREIGN KEY ([user_id]) REFERENCES [users] ([user_id])
GO

ALTER TABLE [reservation_service] ADD FOREIGN KEY ([reservation_id]) REFERENCES [reservations] ([reservation_id])
GO

ALTER TABLE [reservation_service] ADD FOREIGN KEY ([service_id]) REFERENCES [services] ([service_id])
GO

ALTER TABLE [rooms] ADD FOREIGN KEY ([reservation_id]) REFERENCES [reservations] ([reservation_id])
GO

ALTER TABLE [images] ADD FOREIGN KEY ([room_id]) REFERENCES [rooms] ([room_id])
GO


-- STORED PROCEDURES --------------------------------
USE [Hotel]
GO
/****** Object:  StoredProcedure [dbo].[AddImage]    Script Date: 25.05.2022 09:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddImage] @image_id int, @room_id int, @path nvarchar(255)
AS
SET IDENTITY_INSERT images ON;
INSERT INTO images(image_id, room_id, "path") VALUES (@image_id, @room_id, @path);
SET IDENTITY_INSERT images OFF;
GO
/****** Object:  StoredProcedure [dbo].[AddRoom]    Script Date: 25.05.2022 09:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddRoom] @room_id int, @type nvarchar(30), @price int
AS
SET IDENTITY_INSERT rooms ON;
INSERT INTO rooms (room_id, "type", price) VALUES (@room_id, @type, @price);
SET IDENTITY_INSERT rooms OFF;
GO
/****** Object:  StoredProcedure [dbo].[AddService]    Script Date: 25.05.2022 09:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddService] @service_id int, @name nvarchar(255), @price int 
AS
SET IDENTITY_INSERT "services" ON;
INSERT INTO "services" (service_id, "name", price)
VALUES (@service_id, @name, @price);
SET IDENTITY_INSERT "services" OFF;
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 25.05.2022 09:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser] @Username nvarchar(30), @Password nvarchar(30)
AS
INSERT INTO users
VALUES (@Username, @Password, 'client');
GO
/****** Object:  StoredProcedure [dbo].[DeleteImage]    Script Date: 25.05.2022 09:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteImage] @image_id int
AS
UPDATE images
SET is_deleted = 1
WHERE image_id = @image_id;
GO
/****** Object:  StoredProcedure [dbo].[DeleteRoom]    Script Date: 25.05.2022 09:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteRoom] @room_id int 
AS
UPDATE rooms
SET is_deleted = 1
WHERE room_id = @room_id;
UPDATE images
SET is_deleted = 1
WHERE room_id = @room_id;
GO
/****** Object:  StoredProcedure [dbo].[DeleteService]    Script Date: 25.05.2022 09:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteService] @service_id int 
AS
UPDATE "services"
SET is_deleted = 1
WHERE service_id = @service_id;
GO
/****** Object:  StoredProcedure [dbo].[FindUser]    Script Date: 25.05.2022 09:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FindUser] @Username nvarchar(30), @Password nvarchar(30)
AS
SELECT count(*)
FROM users
WHERE users.username = @Username AND users.password = @Password;
GO
/****** Object:  StoredProcedure [dbo].[GetAllImages]    Script Date: 25.05.2022 09:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllImages]
AS
SELECT * FROM "images" WHERE is_deleted = 0;
GO
/****** Object:  StoredProcedure [dbo].[GetAllReservations]    Script Date: 25.05.2022 09:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllReservations]
AS
SELECT * FROM reservations;
GO
/****** Object:  StoredProcedure [dbo].[GetAllRooms]    Script Date: 25.05.2022 09:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllRooms]
AS
SELECT * FROM rooms WHERE is_deleted = 0;
GO
/****** Object:  StoredProcedure [dbo].[GetAllServices]    Script Date: 25.05.2022 09:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllServices]
AS
SELECT * FROM "services" WHERE is_deleted = 0;
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 25.05.2022 09:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsers]
AS
SELECT * FROM users
GO;
GO
/****** Object:  StoredProcedure [dbo].[GetMaxImageID]    Script Date: 25.05.2022 09:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMaxImageID]
AS
SELECT MAX(image_id)
FROM images;
GO
/****** Object:  StoredProcedure [dbo].[GetMaxRoomID]    Script Date: 25.05.2022 09:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMaxRoomID]
AS
SELECT MAX(room_id)
FROM rooms;
GO
/****** Object:  StoredProcedure [dbo].[GetMaxServiceID]    Script Date: 25.05.2022 09:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMaxServiceID]
AS
SELECT MAX(service_id)
FROM services;
GO
/****** Object:  StoredProcedure [dbo].[GetUserFromUsername]    Script Date: 25.05.2022 09:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserFromUsername] @Username nvarchar(30)
AS
SELECT * FROM users WHERE username = @Username;
GO
/****** Object:  StoredProcedure [dbo].[GetUsernameFromUserID]    Script Date: 25.05.2022 09:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUsernameFromUserID] @user_id int 
AS
SELECT username
FROM users
WHERE user_id = @user_id;
GO
/****** Object:  StoredProcedure [dbo].[ModifyImage]    Script Date: 25.05.2022 09:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModifyImage] @image_id int, @room_id int, @path nvarchar(255)
AS
UPDATE images
SET "path" = @path, room_id = @room_id
WHERE image_id = @image_id;
GO
/****** Object:  StoredProcedure [dbo].[ModifyReservation]    Script Date: 25.05.2022 09:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModifyReservation] @reservation_id int, @status nvarchar(30)
AS
UPDATE reservations
SET "status" = @status
WHERE reservation_id = @reservation_id;
GO
/****** Object:  StoredProcedure [dbo].[ModifyRoom]    Script Date: 25.05.2022 09:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModifyRoom] @room_id int, @type nvarchar(255), @price int
AS
UPDATE rooms
SET "type" = @type, price = @price
WHERE room_id = @room_id
GO
/****** Object:  StoredProcedure [dbo].[ModifyService]    Script Date: 25.05.2022 09:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModifyService] @service_id int, @name nvarchar(255), @price int 
AS
UPDATE "services"
SET "name" = @name, price = @price
WHERE service_id = @service_id;
GO