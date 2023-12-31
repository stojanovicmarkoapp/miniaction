USE [Miniaction]
GO
SET IDENTITY_INSERT [dbo].[Avatars] ON 

INSERT [dbo].[Avatars] ([ID], [UserID], [Name]) VALUES (2, 3, N'e284b203-7842-4c0f-b192-b94413fe7190Annie.jpeg')
SET IDENTITY_INSERT [dbo].[Avatars] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([ID], [Name]) VALUES (1, N'Administrator')
INSERT [dbo].[Roles] ([ID], [Name]) VALUES (3, N'Customer')
INSERT [dbo].[Roles] ([ID], [Name]) VALUES (2, N'Employee')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Username], [FirstName], [LastName], [Sex], [EmailAddress], [HomeAddress], [Password], [RoleID], [AvatarID]) VALUES (2, N'johnny', N'John', N'Doe', N'M', N'johndoe@gmail.com', N'Rich Street 1, Richmond, Virginia, USA', N'$2a$10$5uN0JdsvO9GMfyoBUoXIdO2KQMNH1N9sGaVFUT4sLhQKCNlvVHPxG', 1, NULL)
INSERT [dbo].[Users] ([ID], [Username], [FirstName], [LastName], [Sex], [EmailAddress], [HomeAddress], [Password], [RoleID], [AvatarID]) VALUES (3, N'annie', N'Ann', N'Blyth', N'F', N'blythe@outlook.com', N'Ron''s Drive 1, Miami, Florida, USA', N'$2a$10$1ly7arL6939wd0DfgJO9KuD3boJ5z/ja6mrXNzdt/iNfJs7sdCKfe', 2, 2)
INSERT [dbo].[Users] ([ID], [Username], [FirstName], [LastName], [Sex], [EmailAddress], [HomeAddress], [Password], [RoleID], [AvatarID]) VALUES (4, N'katie', N'Catherine', N'Deneuve', N'F', N'katie@hotmail.com', N'Stone Road 1, Nort Fork, Pennsylvania, USA', N'$2a$10$nK8OkuKAND9CrDC4A73W7eD2TFiVH.Y3fuZdRRUzPtJAj1sx1Vj.m', 3, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Formats] ON 

INSERT [dbo].[Formats] ([ID], [Name]) VALUES (2, N'Blu-ray')
INSERT [dbo].[Formats] ([ID], [Name]) VALUES (1, N'CD')
INSERT [dbo].[Formats] ([ID], [Name]) VALUES (3, N'DVD')
INSERT [dbo].[Formats] ([ID], [Name]) VALUES (4, N'VHS')
SET IDENTITY_INSERT [dbo].[Formats] OFF
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([ID], [Name]) VALUES (3, N'Cartoon')
INSERT [dbo].[Genres] ([ID], [Name]) VALUES (1, N'Comedy')
INSERT [dbo].[Genres] ([ID], [Name]) VALUES (2, N'Drama')
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
SET IDENTITY_INSERT [dbo].[Networks] ON 

INSERT [dbo].[Networks] ([ID], [Name]) VALUES (3, N'ABC')
INSERT [dbo].[Networks] ([ID], [Name]) VALUES (2, N'CBS')
INSERT [dbo].[Networks] ([ID], [Name]) VALUES (4, N'FOX')
INSERT [dbo].[Networks] ([ID], [Name]) VALUES (1, N'NBC')
SET IDENTITY_INSERT [dbo].[Networks] OFF
GO
SET IDENTITY_INSERT [dbo].[PGs] ON 

INSERT [dbo].[PGs] ([ID], [Name], [Description]) VALUES (1, N'TV-Y', N'This program is designed to be appropriate for all children.')
INSERT [dbo].[PGs] ([ID], [Name], [Description]) VALUES (2, N'TV-Y7', N'This program is designed for children age 7 and above. It may be more appropriate for children who have acquired the developmental skills needed to distinguish between make-believe and reality.')
INSERT [dbo].[PGs] ([ID], [Name], [Description]) VALUES (3, N'TV-Y7-FV', N'This program is designed for children age 7 and above. It may contain fantasy violence that is more intense or combative than other programs in this rating category.')
INSERT [dbo].[PGs] ([ID], [Name], [Description]) VALUES (4, N'TV-G', N'This program is suitable for all ages. It contains little or no violence, no strong language, and little or no sexual dialogue or situations.')
INSERT [dbo].[PGs] ([ID], [Name], [Description]) VALUES (5, N'TV-PG', N'This program contains material that parents may find unsuitable for younger children. Parental guidance is advised, as it may contain some material that parents might not find suitable for children under 10.')
INSERT [dbo].[PGs] ([ID], [Name], [Description]) VALUES (6, N'TV-14', N'This program contains some material that many parents would find unsuitable for children under 14 years of age. Parents are urged to learn more about the program before letting their children watch it.')
INSERT [dbo].[PGs] ([ID], [Name], [Description]) VALUES (7, N'TV-MA', N'This program is specifically designed to be viewed by adults and therefore may be unsuitable for children under 17. It may contain intense violence, strong sexual content, and/or crude language.')
SET IDENTITY_INSERT [dbo].[PGs] OFF
GO
SET IDENTITY_INSERT [dbo].[Serials] ON 

INSERT [dbo].[Serials] ([ID], [Title], [Features], [Released], [PGID], [TrailerID], [GenreID], [NetworkID]) VALUES (1, N'Simpsons Season 1', N'The most beloved cartoon series ever.', 1989, 1, 1, 3, 4)
INSERT [dbo].[Serials] ([ID], [Title], [Features], [Released], [PGID], [TrailerID], [GenreID], [NetworkID]) VALUES (2, N'The Tonight Show with Conan O''Brien Season 1', N'The most beloved talk show host.', 2009, 7, 2, 1, 1)
SET IDENTITY_INSERT [dbo].[Serials] OFF
GO
SET IDENTITY_INSERT [dbo].[Options] ON 

INSERT [dbo].[Options] ([ID], [Available], [Price], [SerialID], [FormatID]) VALUES (1, 0, CAST(10.00 AS Decimal(18, 2)), 1, 4)
INSERT [dbo].[Options] ([ID], [Available], [Price], [SerialID], [FormatID]) VALUES (2, 1, CAST(10.00 AS Decimal(18, 2)), 1, 3)
INSERT [dbo].[Options] ([ID], [Available], [Price], [SerialID], [FormatID]) VALUES (3, 1, CAST(10.00 AS Decimal(18, 2)), 2, 3)
INSERT [dbo].[Options] ([ID], [Available], [Price], [SerialID], [FormatID]) VALUES (4, 0, CAST(10.00 AS Decimal(18, 2)), 2, 4)
INSERT [dbo].[Options] ([ID], [Available], [Price], [SerialID], [FormatID]) VALUES (5, 1, CAST(10.00 AS Decimal(18, 2)), 2, 1)
INSERT [dbo].[Options] ([ID], [Available], [Price], [SerialID], [FormatID]) VALUES (6, 1, CAST(10.00 AS Decimal(18, 2)), 2, 2)
SET IDENTITY_INSERT [dbo].[Options] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([ID], [OrderedAt], [PaidAt], [Paid], [Quantity], [Price], [OptionID], [UserID]) VALUES (1, CAST(N'2023-08-28T09:18:38.4279396' AS DateTime2), CAST(N'2023-07-28T09:21:37.7850000' AS DateTime2), 1, 3, CAST(10.00 AS Decimal(18, 2)), 1, 2)
INSERT [dbo].[Orders] ([ID], [OrderedAt], [PaidAt], [Paid], [Quantity], [Price], [OptionID], [UserID]) VALUES (2, CAST(N'2023-08-28T09:18:59.5378879' AS DateTime2), CAST(N'2023-06-28T09:21:37.7850000' AS DateTime2), 1, 2, CAST(10.00 AS Decimal(18, 2)), 4, 2)
INSERT [dbo].[Orders] ([ID], [OrderedAt], [PaidAt], [Paid], [Quantity], [Price], [OptionID], [UserID]) VALUES (3, CAST(N'2023-08-28T09:19:04.7979641' AS DateTime2), CAST(N'2023-05-28T09:21:37.7850000' AS DateTime2), 1, 1, CAST(10.00 AS Decimal(18, 2)), 3, 2)
INSERT [dbo].[Orders] ([ID], [OrderedAt], [PaidAt], [Paid], [Quantity], [Price], [OptionID], [UserID]) VALUES (4, CAST(N'2023-08-28T09:24:43.8231788' AS DateTime2), NULL, 0, 1, CAST(10.00 AS Decimal(18, 2)), 6, 2)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Stars] ON 

INSERT [dbo].[Stars] ([ID], [Score], [Description]) VALUES (1, 1, N'Regrettable')
INSERT [dbo].[Stars] ([ID], [Score], [Description]) VALUES (2, 2, N'Forgettable')
INSERT [dbo].[Stars] ([ID], [Score], [Description]) VALUES (3, 3, N'Disappointing')
INSERT [dbo].[Stars] ([ID], [Score], [Description]) VALUES (4, 4, N'Satisfying')
INSERT [dbo].[Stars] ([ID], [Score], [Description]) VALUES (5, 5, N'Unforgettable')
INSERT [dbo].[Stars] ([ID], [Score], [Description]) VALUES (6, 6, N'Masterpiece')
SET IDENTITY_INSERT [dbo].[Stars] OFF
GO
SET IDENTITY_INSERT [dbo].[Reviews] ON 

INSERT [dbo].[Reviews] ([ID], [ModifiedAt], [Comment], [OptionID], [UserID], [StarID]) VALUES (1, CAST(N'2023-08-28T09:27:13.9546308' AS DateTime2), N'I love Simpsons!', 1, 2, 6)
SET IDENTITY_INSERT [dbo].[Reviews] OFF
GO
SET IDENTITY_INSERT [dbo].[Grants] ON 

INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (1, 1, 1)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (24, 1, 2)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (25, 1, 3)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (26, 1, 4)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (27, 1, 5)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (28, 1, 6)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (29, 1, 7)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (30, 1, 8)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (31, 1, 9)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (32, 1, 10)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (33, 1, 11)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (34, 1, 12)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (35, 1, 13)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (36, 1, 14)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (37, 1, 15)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (38, 1, 16)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (39, 1, 17)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (40, 1, 18)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (41, 1, 19)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (42, 1, 20)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (23, 1, 21)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (22, 1, 22)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (21, 1, 23)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (10, 1, 24)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (2, 1, 25)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (3, 1, 26)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (4, 1, 27)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (5, 1, 28)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (6, 1, 29)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (7, 1, 30)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (8, 1, 31)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (9, 1, 32)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (11, 1, 33)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (20, 1, 34)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (12, 1, 35)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (13, 1, 36)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (14, 1, 37)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (15, 1, 38)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (16, 1, 39)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (17, 1, 40)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (18, 1, 41)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (19, 1, 42)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (43, 1, 43)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (44, 1, 44)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (45, 2, 1)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (66, 2, 2)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (67, 2, 3)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (68, 2, 4)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (69, 2, 5)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (70, 2, 6)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (71, 2, 7)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (72, 2, 8)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (74, 2, 9)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (82, 2, 10)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (75, 2, 11)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (76, 2, 12)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (77, 2, 13)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (78, 2, 15)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (79, 2, 16)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (80, 2, 17)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (81, 2, 18)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (65, 2, 19)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (73, 2, 20)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (64, 2, 21)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (53, 2, 22)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (46, 2, 23)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (47, 2, 24)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (48, 2, 25)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (49, 2, 26)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (50, 2, 27)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (51, 2, 30)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (52, 2, 31)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (54, 2, 32)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (62, 2, 33)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (55, 2, 34)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (56, 2, 35)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (57, 2, 36)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (58, 2, 37)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (59, 2, 38)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (60, 2, 39)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (61, 2, 40)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (63, 2, 41)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (83, 2, 42)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (84, 3, 6)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (111, 3, 10)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (110, 3, 11)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (109, 3, 13)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (108, 3, 15)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (107, 3, 16)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (106, 3, 17)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (105, 3, 18)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (104, 3, 19)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (103, 3, 20)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (102, 3, 21)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (101, 3, 22)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (100, 3, 23)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (99, 3, 24)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (98, 3, 25)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (97, 3, 26)
GO
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (96, 3, 27)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (95, 3, 30)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (94, 3, 31)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (93, 3, 32)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (92, 3, 33)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (91, 3, 34)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (90, 3, 35)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (89, 3, 36)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (88, 3, 37)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (87, 3, 38)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (86, 3, 39)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (85, 3, 40)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (112, 3, 41)
INSERT [dbo].[Grants] ([ID], [RoleID], [UseCaseID]) VALUES (113, 3, 42)
SET IDENTITY_INSERT [dbo].[Grants] OFF
GO
SET IDENTITY_INSERT [dbo].[Trailers] ON 

INSERT [dbo].[Trailers] ([ID], [SerialID], [Name]) VALUES (1, 1, N'49d14bfd-d1a9-4316-89f8-fbdd47b4d2besimpsons.mp4')
INSERT [dbo].[Trailers] ([ID], [SerialID], [Name]) VALUES (2, 2, N'2672d7fa-443b-45c2-b1e1-ab4acceb13a3conan.mp4')
SET IDENTITY_INSERT [dbo].[Trailers] OFF
GO
SET IDENTITY_INSERT [dbo].[TrackEntries] ON 

INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (1, 2, N'johnny', N'Genres search', N'{"Name":null}', CAST(N'2023-08-24T12:21:11.9490988' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (2, 2, N'johnny', N'Genres search', N'{"Name":null}', CAST(N'2023-08-24T12:22:40.7607908' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (3, 2, N'johnny', N'Formats search', N'{"Name":null}', CAST(N'2023-08-24T12:25:41.4851215' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (4, 2, N'johnny', N'Formats search', N'{"Name":null}', CAST(N'2023-08-24T12:26:21.7300313' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (5, 2, N'johnny', N'Formats search', N'{"Name":null}', CAST(N'2023-08-24T12:26:39.8411222' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (6, 2, N'johnny', N'Trackings search', N'{"ActorID":null,"ActorUsername":null,"UseCaseName":null,"CreatedBefore":null,"CreatedAfter":null}', CAST(N'2023-08-24T12:27:27.5798753' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (7, 2, N'johnny', N'Networks search', N'{"Name":null}', CAST(N'2023-08-24T12:31:47.6571002' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (8, 2, N'johnny', N'Grants search', N'{"RoleID":null,"RoleName":null,"UseCaseID":null}', CAST(N'2023-08-24T12:32:01.3563289' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (9, 2, N'johnny', N'Parental guidelines search', N'{"Name":null}', CAST(N'2023-08-24T12:36:47.0327538' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (10, 2, N'johnny', N'Stars search', N'{"Score":null}', CAST(N'2023-08-24T13:00:23.4341285' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (11, 2, N'johnny', N'Avatars search', N'{"Name":null,"Username":null,"UserID":null}', CAST(N'2023-08-28T08:56:29.3211793' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (12, 2, N'johnny', N'Formats search', N'{"Name":null}', CAST(N'2023-08-28T08:57:37.6932941' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (13, 2, N'johnny', N'Genres search', N'{"Name":null}', CAST(N'2023-08-28T08:57:42.2527098' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (14, 2, N'johnny', N'Grants search', N'{"RoleID":null,"RoleName":null,"UseCaseID":null}', CAST(N'2023-08-28T08:57:46.5225986' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (15, 2, N'johnny', N'Networks search', N'{"Name":null}', CAST(N'2023-08-28T08:57:56.1685573' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (16, 2, N'johnny', N'Options search', N'{"Available":null,"SmallerPrice":null,"BiggerPrice":null,"SerialID":null,"SerialTitle":null,"FormatID":null,"FormatName":null}', CAST(N'2023-08-28T08:58:02.1711003' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (17, 2, N'johnny', N'Parental guidelines search', N'{"Name":null}', CAST(N'2023-08-28T08:58:06.3815427' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (18, 2, N'johnny', N'Reviews search', N'{"ModifiedBefore":null,"ModifiedAfter":null,"OptionID":null,"SerialTitle":null,"FormatName":null,"UserID":null,"Username":null,"StarScore":null}', CAST(N'2023-08-28T08:58:10.9308057' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (19, 2, N'johnny', N'Roles search', N'{"Name":null}', CAST(N'2023-08-28T08:58:15.5053241' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (20, 2, N'johnny', N'Serials search', N'{"Title":null,"Released":null,"PGID":null,"PGName":null,"GenreID":null,"GenreName":null,"NetworkID":null,"NetworkName":null}', CAST(N'2023-08-28T08:58:23.3270221' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (21, 2, N'johnny', N'Trailers search', N'{"Name":null,"SerialTitle":null,"SerialID":null}', CAST(N'2023-08-28T08:58:27.0432607' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (22, 2, N'johnny', N'Users search', N'{"Username":null,"FirstName":null,"LastName":null,"Sex":null,"EmailAddress":null,"HomeAddress":null,"RoleID":null,"RoleName":null}', CAST(N'2023-08-28T08:58:42.7153987' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (23, 2, N'johnny', N'Options search', N'{"Available":null,"SmallerPrice":null,"BiggerPrice":null,"SerialID":null,"SerialTitle":null,"FormatID":null,"FormatName":null}', CAST(N'2023-08-28T09:19:50.4109221' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (24, 2, N'johnny', N'Orders search', N'{"OrderedBefore":null,"OrderedAfter":null,"Paid":null,"LessQuantity":null,"MoreQuantity":null,"SmallerPrice":null,"BiggerPrice":null,"SmallerValue":null,"BiggerValue":null,"OptionID":null,"SerialTitle":null,"FormatName":null,"UserID":null,"Username":null}', CAST(N'2023-08-28T09:20:06.3835841' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (25, 2, N'johnny', N'Options search', N'{"Available":null,"SmallerPrice":null,"BiggerPrice":null,"SerialID":null,"SerialTitle":null,"FormatID":null,"FormatName":null}', CAST(N'2023-08-28T09:20:58.2971693' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (26, 2, N'johnny', N'Orders search', N'{"OrderedBefore":null,"OrderedAfter":null,"Paid":null,"LessQuantity":null,"MoreQuantity":null,"SmallerPrice":null,"BiggerPrice":null,"SmallerValue":null,"BiggerValue":null,"OptionID":null,"SerialTitle":null,"FormatName":null,"UserID":null,"Username":null}', CAST(N'2023-08-28T09:23:24.4260096' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (27, 2, N'johnny', N'Options search', N'{"Available":null,"SmallerPrice":null,"BiggerPrice":null,"SerialID":null,"SerialTitle":null,"FormatID":null,"FormatName":null}', CAST(N'2023-08-28T09:24:08.3253077' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (28, 2, N'johnny', N'Orders search', N'{"OrderedBefore":null,"OrderedAfter":null,"Paid":null,"LessQuantity":null,"MoreQuantity":null,"SmallerPrice":null,"BiggerPrice":null,"SmallerValue":null,"BiggerValue":null,"OptionID":null,"SerialTitle":null,"FormatName":null,"UserID":null,"Username":null}', CAST(N'2023-08-28T09:24:48.7673822' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (29, 2, N'johnny', N'Reviews search', N'{"ModifiedBefore":null,"ModifiedAfter":null,"OptionID":null,"SerialTitle":null,"FormatName":null,"UserID":null,"Username":null,"StarScore":null}', CAST(N'2023-08-28T09:27:17.2478062' AS DateTime2))
INSERT [dbo].[TrackEntries] ([ID], [ActorID], [ActorUsername], [UseCaseName], [UseCaseData], [CreatedAt]) VALUES (30, 2, N'johnny', N'Users search', N'{"Username":null,"FirstName":null,"LastName":null,"Sex":null,"EmailAddress":null,"HomeAddress":null,"RoleID":null,"RoleName":null}', CAST(N'2023-08-28T15:43:03.0894662' AS DateTime2))
SET IDENTITY_INSERT [dbo].[TrackEntries] OFF
GO
