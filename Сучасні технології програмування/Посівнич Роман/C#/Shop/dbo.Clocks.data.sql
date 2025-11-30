SET IDENTITY_INSERT [dbo].[Clocks] ON
INSERT INTO [dbo].[Clocks] ([Id], [Name], [ShortDesc], [LongDesc], [img], [price], [isFavourite], [available], [categoryID]) VALUES (1, N'Fossil', N'Чоловічий годинник', N'Шанувальники Fossil – стильні молоді люди, які цінують комфорт, функціональність та високі технології в годиннику.', N'/img/Fossil.jpg', 1000, 1, 1, 1)
INSERT INTO [dbo].[Clocks] ([Id], [Name], [ShortDesc], [LongDesc], [img], [price], [isFavourite], [available], [categoryID]) VALUES (2, N'Rolex Submariner', N'Чоловічий механічний годинник', N'Іконічний годинник Rolex Submariner із водонепроникністю та стильним дизайном.', N'/img/Rolex Submariner.jpg', 5000, 0, 1, 1)
INSERT INTO [dbo].[Clocks] ([Id], [Name], [ShortDesc], [LongDesc], [img], [price], [isFavourite], [available], [categoryID]) VALUES (3, N'Garmin Forerunner 945', N'Спортивний годинник з GPS', N'Garmin Forerunner 945 із вимірюванням пульсу, GPS та розширеними функціями для тренувань.', N'/img/Garmin Forerunner 945.jpg', 700, 1, 1, 2)
INSERT INTO [dbo].[Clocks] ([Id], [Name], [ShortDesc], [LongDesc], [img], [price], [isFavourite], [available], [categoryID]) VALUES (4, N'Apple Watch Series 7', N'Смарт-годинник від Apple', N'Новий Apple Watch Series 7 з великим дисплеєм, широким функціоналом та стильним дизайном.', N'/img/Apple Watch Series 7.jpg', 800, 1, 1, 3)
SET IDENTITY_INSERT [dbo].[Clocks] OFF




SET IDENTITY_INSERT [dbo].[Clocks] ON

-- Годинник 1
INSERT INTO [dbo].[Clocks] ([Id],[Name], [ShortDesc], [LongDesc], [img], [price], [isFavourite], [available], [categoryID]) 
VALUES (5, N'Cartier Tank Solo', N'Жіночий годинник', N'Cartier Tank Solo - класичний та елегантний годинник для жінок.', N'/img/Cartier_Tank_Solo.jpg', 3800, 0, 1, 1)

-- Годинник 2
INSERT INTO [dbo].[Clocks] ([Id],[Name], [ShortDesc], [LongDesc], [img], [price], [isFavourite], [available], [categoryID]) 
VALUES (6, N'Suunto 9 Baro', N'Спортивний годинник з альтиметром', N'Suunto 9 Baro - годинник з високоточним альтиметром для альпінізму та гірських тренувань.', N'/img/Suunto_9_Baro.jpg', 6000, 0, 1, 2)

-- Годинник 3
INSERT INTO [dbo].[Clocks] ([Id],[Name], [ShortDesc], [LongDesc], [img], [price], [isFavourite], [available], [categoryID]) 
VALUES (7, N'Adidas Process_SP1', N'Спортивний годинник для бігу', N'Adidas Process_SP1 - годинник із функціями для бігу та підсумками тренувань.', N'/img/Adidas_Process_SP1.jpg', 1200, 0, 1, 2)

-- Годинник 4
INSERT INTO [dbo].[Clocks] ([Id],[Name], [ShortDesc], [LongDesc], [img], [price], [isFavourite], [available], [categoryID]) 
VALUES (8, N'Samsung Galaxy Watch 4', N'Смарт-годинник від Samsung', N'Samsung Galaxy Watch 4 - сучасний смарт-годинник з функціями для здоровя та фітнесу.', N'/img/Samsung_Galaxy_Watch_4.jpg', 2500, 0, 1, 3)

-- Годинник 5
INSERT INTO [dbo].[Clocks] ([Id],[Name], [ShortDesc], [LongDesc], [img], [price], [isFavourite], [available], [categoryID]) 
VALUES (9, N'Fitbit Versa 3', N'Спортивний смарт-годинник', N'Fitbit Versa 3 - годинник із великим дисплеєм та функціями для відстеження активності.', N'/img/Fitbit_Versa_3.jpg', 1800, 0, 1, 3)

INSERT INTO [dbo].[Clocks] ([Id],[Name], [ShortDesc], [LongDesc], [img], [price], [isFavourite], [available], [categoryID]) 
VALUES (10, N'Seiko Presage', N'Чоловічий годинник', N'Seiko Presage - годинник з класичним дизайном та автоматичним механізмом.', N'/img/Seiko_Presage.jpg', 1200, 1, 1, 1)

-- Годинник 7
INSERT INTO [dbo].[Clocks] ([Id],[Name], [ShortDesc], [LongDesc], [img], [price], [isFavourite], [available], [categoryID]) 
VALUES (11, N'Citizen Eco-Drive', N'Жіночий годинник', N'Citizen Eco-Drive - екологічний годинник для жінок із сонячним панеллю.', N'/img/Citizen_Eco-Drive.jpg', 5500, 0, 1, 1)

-- Годинник 8
INSERT INTO [dbo].[Clocks] ([Id],[Name], [ShortDesc], [LongDesc], [img], [price], [isFavourite], [available], [categoryID]) 
VALUES (12, N'Casio G-Shock', N'Спортивний годинник', N'Casio G-Shock - знаменитий спортивний годинник із високою міцністю до ударів.', N'/img/Casio_G-Shock.jpg', 1000, 0, 1, 2)

-- Годинник 9
INSERT INTO [dbo].[Clocks] ([Id],[Name], [ShortDesc], [LongDesc], [img], [price], [isFavourite], [available], [categoryID]) 
VALUES (13, N'Garmin Fenix 6', N'Спортивний годинник для екстремальних умов', N'Garmin Fenix 6 - високотехнологічний годинник для екстремальних тренувань та подорожей.', N'/img/Garmin_Fenix_6.jpg', 8000, 0, 1, 1)

-- Годинник 10
INSERT INTO [dbo].[Clocks] ([Id],[Name], [ShortDesc], [LongDesc], [img], [price], [isFavourite], [available], [categoryID]) 
VALUES (14, N'Huawei Watch GT 3', N'Смарт-годинник від Huawei', N'Huawei Watch GT 3 - стильний смарт-годинник з великим обсягом функцій та тривалим часом роботи від акумулятора.', N'/img/Huawei_Watch_GT_3.jpg', 3000, 1, 1, 3)

-- Годинник 11
INSERT INTO [dbo].[Clocks] ([Id],[Name], [ShortDesc], [LongDesc], [img], [price], [isFavourite], [available], [categoryID]) 
VALUES (15, N'Xiaomi Mi Band 6', N'Фітнес-браслет', N'Xiaomi Mi Band 6 - бюджетний фітнес-браслет із функціями відстеження активності та серцевого ритму.', N'/img/Xiaomi_Mi_Band_6.jpg', 4000, 0, 1, 3)



SET IDENTITY_INSERT [dbo].[Clocks] OFF
