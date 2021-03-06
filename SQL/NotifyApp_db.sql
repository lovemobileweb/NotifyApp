USE [NotifyApp_db]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 6/7/2016 7:17:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ClientId] [int] IDENTITY(1,1) NOT NULL,
	[ClientEmail] [nvarchar](max) NULL,
	[ClientLogo] [nvarchar](max) NULL,
	[ClientName] [nvarchar](max) NULL,
	[ClientUserName] [nvarchar](50) NULL,
	[ClientPassword] [nvarchar](50) NULL,
	[RoleId] [int] NULL,
	[AdminId] [int] NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContactListDetails]    Script Date: 6/7/2016 7:17:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactListDetails](
	[ListDetailID] [int] IDENTITY(1,1) NOT NULL,
	[ContactListID] [int] NULL,
	[ContactID] [int] NULL,
	[ClientId] [int] NULL,
 CONSTRAINT [PK_ContactListDetails] PRIMARY KEY CLUSTERED 
(
	[ListDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContactListMaster]    Script Date: 6/7/2016 7:17:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactListMaster](
	[ListId] [int] IDENTITY(1,1) NOT NULL,
	[ContactListname] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ClientId] [int] NULL,
 CONSTRAINT [PK_ContactList] PRIMARY KEY CLUSTERED 
(
	[ListId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 6/7/2016 7:17:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[AnniversaryDate] [nvarchar](max) NULL,
	[CellPhone] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Company] [nvarchar](50) NULL,
	[DateOfBirth] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[IsActive] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[PrimaryPhone] [nvarchar](max) NULL,
	[SecondaryPhone] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[Street] [nvarchar](max) NULL,
	[UserMappingId] [nvarchar](max) NULL,
	[ZipCode] [nvarchar](max) NULL,
	[ClientId] [int] NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NotificationLog]    Script Date: 6/7/2016 7:17:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotificationLog](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[ContactId] [int] NOT NULL,
	[NotificaiontStatus] [int] NOT NULL,
	[NotificationId] [int] NOT NULL,
 CONSTRAINT [PK_NotificationLog] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 6/7/2016 7:17:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[NotificationId] [int] IDENTITY(1,1) NOT NULL,
	[TemplateName] [nvarchar](max) NULL,
	[NotificationMessage] [nvarchar](max) NULL,
	[NotificationType] [nvarchar](max) NULL,
	[TypeId] [int] NULL,
	[Status] [nvarchar](max) NULL,
	[ClientId] [int] NULL,
 CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED 
(
	[NotificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Resources]    Script Date: 6/7/2016 7:17:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resources](
	[ResoureId] [int] IDENTITY(1,1) NOT NULL,
	[AccountNumber] [nvarchar](max) NULL,
	[CellPhoneNumber] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[ClientId] [int] NOT NULL,
	[EmailAddress] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[PrimaryPhoneNumber] [nvarchar](max) NULL,
	[ResoureDescription] [nvarchar](max) NULL,
	[ResoureName] [nvarchar](max) NULL,
	[SecondaryPhoneNumber] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[Street] [nvarchar](max) NULL,
	[URL] [nvarchar](max) NULL,
	[ZipCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_Resources] PRIMARY KEY CLUSTERED 
(
	[ResoureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 6/7/2016 7:17:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_NotificationSchedule]    Script Date: 6/7/2016 7:17:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_NotificationSchedule](
	[NScheduleID] [int] IDENTITY(1,1) NOT NULL,
	[NotificationCampaign] [nvarchar](max) NULL,
	[ContactListId] [int] NULL,
	[ResourceId] [int] NULL,
	[NotificationId] [int] NULL,
	[CampaignDate] [datetime] NULL,
	[ChanelMode] [nvarchar](max) NULL,
	[NotificationMessage] [nvarchar](max) NULL,
	[RequestConfirmMsg] [nvarchar](max) NULL,
	[RepeatNotificationAllow] [nvarchar](max) NULL,
	[MsgNumberOfTime] [int] NULL,
	[ReapeatDate] [date] NULL,
	[Status] [bit] NULL,
	[IsActive] [bit] NULL,
	[ClientId] [int] NULL,
 CONSTRAINT [PK_NotificationSchedule] PRIMARY KEY CLUSTERED 
(
	[NScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 6/7/2016 7:17:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Fullname] [nvarchar](50) NULL,
	[EmailId] [nvarchar](50) NULL,
	[RoleId] [int] NULL,
	[ClientId] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserClientRoleMapping]    Script Date: 6/7/2016 7:17:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClientRoleMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ClientId] [int] NULL,
	[RoleId] [int] NULL,
 CONSTRAINT [PK_UserClientRoleMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([ClientId], [ClientEmail], [ClientLogo], [ClientName], [ClientUserName], [ClientPassword], [RoleId], [AdminId]) VALUES (4094, N'balkrishnap@synoris.com', N'abc.png', N'Balkrishna Patidar', N'Bala', N'bala2112', 2, 10)
INSERT [dbo].[Client] ([ClientId], [ClientEmail], [ClientLogo], [ClientName], [ClientUserName], [ClientPassword], [RoleId], [AdminId]) VALUES (4095, N'priyas@synoris.com', N'ineshcorp_logo_only.png', N'priya', N'test', N'synoris', 2, 10)
INSERT [dbo].[Client] ([ClientId], [ClientEmail], [ClientLogo], [ClientName], [ClientUserName], [ClientPassword], [RoleId], [AdminId]) VALUES (4096, N'priyas@synoris.com', N'ineshcorp_logo_only.png', N'priya saraf', N'priya', N'synoris', 2, 10)
INSERT [dbo].[Client] ([ClientId], [ClientEmail], [ClientLogo], [ClientName], [ClientUserName], [ClientPassword], [RoleId], [AdminId]) VALUES (4097, N'priyas@synoris.com', N'ineshcorp_logo_only.png', N'priya saraf', N'priyasaraf', N'synoris.com', 2, 10)
INSERT [dbo].[Client] ([ClientId], [ClientEmail], [ClientLogo], [ClientName], [ClientUserName], [ClientPassword], [RoleId], [AdminId]) VALUES (4098, N'priyas@synoris.com', N'ineshcorp_logo_only.png', N'priya saraf', N'priyasar', N'synoris', 2, 10)
INSERT [dbo].[Client] ([ClientId], [ClientEmail], [ClientLogo], [ClientName], [ClientUserName], [ClientPassword], [RoleId], [AdminId]) VALUES (4100, N'priyas@synoris.com', N'ineshcorp_logo_only.png', N'priyasaraf', N'sarafpriya', N'synoris', 2, 10)
INSERT [dbo].[Client] ([ClientId], [ClientEmail], [ClientLogo], [ClientName], [ClientUserName], [ClientPassword], [RoleId], [AdminId]) VALUES (4101, N'priyas@synoris.com', N'ineshcorp_logo_only.png', N'sarafpriya', N'sarafpriya', N'synoris123', 2, 10)
INSERT [dbo].[Client] ([ClientId], [ClientEmail], [ClientLogo], [ClientName], [ClientUserName], [ClientPassword], [RoleId], [AdminId]) VALUES (4102, N'priyas@synoris.com', N'ineshcorp_logo_only.png', N'saraf', N'sarafpriya', N'synoris', 2, 10)
INSERT [dbo].[Client] ([ClientId], [ClientEmail], [ClientLogo], [ClientName], [ClientUserName], [ClientPassword], [RoleId], [AdminId]) VALUES (4103, N'nitinv@synoris.com', N'sunny-big.png', N'Nitin vyas', N'Nitin', N'nitin123', 2, 10)
INSERT [dbo].[Client] ([ClientId], [ClientEmail], [ClientLogo], [ClientName], [ClientUserName], [ClientPassword], [RoleId], [AdminId]) VALUES (4104, N'arunp@synoris.com', N'4.png', N'yadav', N'Arun', N'arun123', 2, 10)
INSERT [dbo].[Client] ([ClientId], [ClientEmail], [ClientLogo], [ClientName], [ClientUserName], [ClientPassword], [RoleId], [AdminId]) VALUES (4105, N'rajeshc@synoris.com', N'3.png', N'Rajesh Roy', N'Rajesh', N'1234', 2, 10)
INSERT [dbo].[Client] ([ClientId], [ClientEmail], [ClientLogo], [ClientName], [ClientUserName], [ClientPassword], [RoleId], [AdminId]) VALUES (5100, N'ashab@synoris.com', N'3.png', N'Asha bansal', N'Asha', N'asha1234', 2, 10)
INSERT [dbo].[Client] ([ClientId], [ClientEmail], [ClientLogo], [ClientName], [ClientUserName], [ClientPassword], [RoleId], [AdminId]) VALUES (5101, N'priyas@synoris.com', N'ineshcorp_logo_only.png', N'piya saraf', N'piya', N'oiya', 2, 10)
INSERT [dbo].[Client] ([ClientId], [ClientEmail], [ClientLogo], [ClientName], [ClientUserName], [ClientPassword], [RoleId], [AdminId]) VALUES (5102, N'priyas@synoris.com', N'ineshcorp_logo_only.png', N'piyaa saraf', N'piyaa', N'piyaa', 2, 10)
SET IDENTITY_INSERT [dbo].[Client] OFF
SET IDENTITY_INSERT [dbo].[ContactListDetails] ON 

INSERT [dbo].[ContactListDetails] ([ListDetailID], [ContactListID], [ContactID], [ClientId]) VALUES (2057, 1027, 2062, NULL)
INSERT [dbo].[ContactListDetails] ([ListDetailID], [ContactListID], [ContactID], [ClientId]) VALUES (6347, 5191, 6099, NULL)
INSERT [dbo].[ContactListDetails] ([ListDetailID], [ContactListID], [ContactID], [ClientId]) VALUES (6348, 5191, 6100, NULL)
INSERT [dbo].[ContactListDetails] ([ListDetailID], [ContactListID], [ContactID], [ClientId]) VALUES (6349, 5192, 6099, NULL)
INSERT [dbo].[ContactListDetails] ([ListDetailID], [ContactListID], [ContactID], [ClientId]) VALUES (6350, 5193, 6099, NULL)
INSERT [dbo].[ContactListDetails] ([ListDetailID], [ContactListID], [ContactID], [ClientId]) VALUES (6351, 5194, 6106, NULL)
INSERT [dbo].[ContactListDetails] ([ListDetailID], [ContactListID], [ContactID], [ClientId]) VALUES (6352, 5195, 6108, NULL)
INSERT [dbo].[ContactListDetails] ([ListDetailID], [ContactListID], [ContactID], [ClientId]) VALUES (6353, 5196, 6108, NULL)
INSERT [dbo].[ContactListDetails] ([ListDetailID], [ContactListID], [ContactID], [ClientId]) VALUES (7351, 6194, 7105, NULL)
INSERT [dbo].[ContactListDetails] ([ListDetailID], [ContactListID], [ContactID], [ClientId]) VALUES (7352, 6195, 7106, NULL)
INSERT [dbo].[ContactListDetails] ([ListDetailID], [ContactListID], [ContactID], [ClientId]) VALUES (7353, 6196, 7107, NULL)
INSERT [dbo].[ContactListDetails] ([ListDetailID], [ContactListID], [ContactID], [ClientId]) VALUES (7354, 6197, 7107, NULL)
SET IDENTITY_INSERT [dbo].[ContactListDetails] OFF
SET IDENTITY_INSERT [dbo].[ContactListMaster] ON 

INSERT [dbo].[ContactListMaster] ([ListId], [ContactListname], [Description], [ClientId]) VALUES (19, N'pramod', NULL, NULL)
INSERT [dbo].[ContactListMaster] ([ListId], [ContactListname], [Description], [ClientId]) VALUES (5191, N'School Campgien', NULL, 4094)
INSERT [dbo].[ContactListMaster] ([ListId], [ContactListname], [Description], [ClientId]) VALUES (5192, N'synoris', NULL, 4094)
INSERT [dbo].[ContactListMaster] ([ListId], [ContactListname], [Description], [ClientId]) VALUES (5193, N'sharepoint synoris', NULL, 4094)
INSERT [dbo].[ContactListMaster] ([ListId], [ContactListname], [Description], [ClientId]) VALUES (5194, N'test', NULL, 4094)
INSERT [dbo].[ContactListMaster] ([ListId], [ContactListname], [Description], [ClientId]) VALUES (5195, N'testing', NULL, 4097)
INSERT [dbo].[ContactListMaster] ([ListId], [ContactListname], [Description], [ClientId]) VALUES (5196, N'Demo', NULL, 4097)
INSERT [dbo].[ContactListMaster] ([ListId], [ContactListname], [Description], [ClientId]) VALUES (6194, N'Test Info Group', NULL, 5100)
INSERT [dbo].[ContactListMaster] ([ListId], [ContactListname], [Description], [ClientId]) VALUES (6195, N'synoris12', NULL, 4102)
INSERT [dbo].[ContactListMaster] ([ListId], [ContactListname], [Description], [ClientId]) VALUES (6196, N'testing group', NULL, 4096)
INSERT [dbo].[ContactListMaster] ([ListId], [ContactListname], [Description], [ClientId]) VALUES (6197, N'testing group1', NULL, 4096)
SET IDENTITY_INSERT [dbo].[ContactListMaster] OFF
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([ContactId], [AnniversaryDate], [CellPhone], [City], [Company], [DateOfBirth], [Email], [FirstName], [IsActive], [LastName], [PrimaryPhone], [SecondaryPhone], [State], [Street], [UserMappingId], [ZipCode], [ClientId]) VALUES (6099, NULL, N'+915 558 888 888', N'Indore', NULL, NULL, N'rohant@synoris.com', N'Rahul', NULL, N'Tina', N'+919 424 035 401', N'+999 888 888 888', N'mp', N'vijay nagar', NULL, N'452012', 4094)
INSERT [dbo].[Contacts] ([ContactId], [AnniversaryDate], [CellPhone], [City], [Company], [DateOfBirth], [Email], [FirstName], [IsActive], [LastName], [PrimaryPhone], [SecondaryPhone], [State], [Street], [UserMappingId], [ZipCode], [ClientId]) VALUES (6100, NULL, N'+918 597 789 988', N'Indore', NULL, NULL, N'madhup@synoris.com', N'madhu', NULL, N'Parmar', N'+919 926 850 014', N'+919 926 850 014', N'Mp', N'vijay nagar', NULL, N'452100', 4094)
INSERT [dbo].[Contacts] ([ContactId], [AnniversaryDate], [CellPhone], [City], [Company], [DateOfBirth], [Email], [FirstName], [IsActive], [LastName], [PrimaryPhone], [SecondaryPhone], [State], [Street], [UserMappingId], [ZipCode], [ClientId]) VALUES (6101, NULL, N'+677 656 564 556', NULL, NULL, NULL, N'kumar@gmail.com', N'prashamt', NULL, N'kumar', N'+919 926 850 014', N'+775 675 646 454', NULL, NULL, NULL, NULL, 4094)
INSERT [dbo].[Contacts] ([ContactId], [AnniversaryDate], [CellPhone], [City], [Company], [DateOfBirth], [Email], [FirstName], [IsActive], [LastName], [PrimaryPhone], [SecondaryPhone], [State], [Street], [UserMappingId], [ZipCode], [ClientId]) VALUES (6102, NULL, NULL, N'Indore', NULL, NULL, N'random@gmail.com', N'thisis', NULL, N'rendom', N'+919 424 035 401', N'+786 876 756 756', N'Mp', N'inda', NULL, N'452012', 4094)
INSERT [dbo].[Contacts] ([ContactId], [AnniversaryDate], [CellPhone], [City], [Company], [DateOfBirth], [Email], [FirstName], [IsActive], [LastName], [PrimaryPhone], [SecondaryPhone], [State], [Street], [UserMappingId], [ZipCode], [ClientId]) VALUES (6104, NULL, NULL, NULL, NULL, NULL, N'raj@gmail.com', N'Raj', NULL, N'Tiwari', N'+919 926 850 014', NULL, NULL, NULL, NULL, NULL, 4094)
INSERT [dbo].[Contacts] ([ContactId], [AnniversaryDate], [CellPhone], [City], [Company], [DateOfBirth], [Email], [FirstName], [IsActive], [LastName], [PrimaryPhone], [SecondaryPhone], [State], [Street], [UserMappingId], [ZipCode], [ClientId]) VALUES (6106, NULL, NULL, N'Indore', NULL, NULL, N'priyas@synoris.com', N'priya', NULL, N'saraf', N'+919 993 436 261', NULL, NULL, N'', NULL, NULL, 4094)
INSERT [dbo].[Contacts] ([ContactId], [AnniversaryDate], [CellPhone], [City], [Company], [DateOfBirth], [Email], [FirstName], [IsActive], [LastName], [PrimaryPhone], [SecondaryPhone], [State], [Street], [UserMappingId], [ZipCode], [ClientId]) VALUES (6107, N'11-12-2016', N'9981890338', N'Indore', NULL, N'10-09-1991', N'aniket@gmail.com', N'pushpendra', N'0', N'thakur', NULL, N'7316998080', N'Indore', N'Indore', N'NULL', N'452001', NULL)
INSERT [dbo].[Contacts] ([ContactId], [AnniversaryDate], [CellPhone], [City], [Company], [DateOfBirth], [Email], [FirstName], [IsActive], [LastName], [PrimaryPhone], [SecondaryPhone], [State], [Street], [UserMappingId], [ZipCode], [ClientId]) VALUES (6108, NULL, NULL, NULL, NULL, NULL, N'priyas@synoris.com', N'priya', NULL, N'priya', N'+919 993 436 261', NULL, NULL, NULL, NULL, NULL, 4097)
INSERT [dbo].[Contacts] ([ContactId], [AnniversaryDate], [CellPhone], [City], [Company], [DateOfBirth], [Email], [FirstName], [IsActive], [LastName], [PrimaryPhone], [SecondaryPhone], [State], [Street], [UserMappingId], [ZipCode], [ClientId]) VALUES (6109, NULL, N'+954 216 589 999', N'Indore', NULL, NULL, N'Shilpas@synoris.com', N'Shilpa', NULL, N'Shetty', N'+919 424 035 401', N'+918 554 447 777', N'Mp', N'Vijay Nagar', NULL, N'452101', 4104)
INSERT [dbo].[Contacts] ([ContactId], [AnniversaryDate], [CellPhone], [City], [Company], [DateOfBirth], [Email], [FirstName], [IsActive], [LastName], [PrimaryPhone], [SecondaryPhone], [State], [Street], [UserMappingId], [ZipCode], [ClientId]) VALUES (7105, NULL, N'+914 588 998 888', N'Indore', NULL, NULL, N'rita@gmail.com', N'Rita', NULL, N'Albert', N'+918 956 555 555', N'+988 744 455 555', N'MP', N'Rajendra nagar', NULL, N'452012', 5100)
INSERT [dbo].[Contacts] ([ContactId], [AnniversaryDate], [CellPhone], [City], [Company], [DateOfBirth], [Email], [FirstName], [IsActive], [LastName], [PrimaryPhone], [SecondaryPhone], [State], [Street], [UserMappingId], [ZipCode], [ClientId]) VALUES (7106, NULL, NULL, NULL, NULL, NULL, N'priyas@synoris.com', N'piya', NULL, N'saraf', N'+919 993 436 261', NULL, NULL, NULL, NULL, NULL, 4102)
INSERT [dbo].[Contacts] ([ContactId], [AnniversaryDate], [CellPhone], [City], [Company], [DateOfBirth], [Email], [FirstName], [IsActive], [LastName], [PrimaryPhone], [SecondaryPhone], [State], [Street], [UserMappingId], [ZipCode], [ClientId]) VALUES (7107, NULL, NULL, NULL, NULL, NULL, N'sandeepb@synoris.com', N'sandeep', NULL, N'baley1', N'+919 993 436 261', NULL, NULL, NULL, NULL, NULL, 4096)
SET IDENTITY_INSERT [dbo].[Contacts] OFF
SET IDENTITY_INSERT [dbo].[Notifications] ON 

INSERT [dbo].[Notifications] ([NotificationId], [TemplateName], [NotificationMessage], [NotificationType], [TypeId], [Status], [ClientId]) VALUES (3098, N'Welcome Synoris Template', N'Hello, welcome to synoris.

Thanks for Join our Team.

Regards', N'Email', 1, N'True', 15)
INSERT [dbo].[Notifications] ([NotificationId], [TemplateName], [NotificationMessage], [NotificationType], [TypeId], [Status], [ClientId]) VALUES (4105, N'Synoris Welcome Template', N'Hello,

Welcome To synoris India

Thanks', N'Email', 1, N'True', 4094)
INSERT [dbo].[Notifications] ([NotificationId], [TemplateName], [NotificationMessage], [NotificationType], [TypeId], [Status], [ClientId]) VALUES (4106, N'synoris seo team', N'Hello,
This is a test team.', N'Voice Call', 3, N'True', 4094)
INSERT [dbo].[Notifications] ([NotificationId], [TemplateName], [NotificationMessage], [NotificationType], [TypeId], [Status], [ClientId]) VALUES (4107, N'Welcome Synoris Template', N'Hello,

Good Morning', N'Voice Call', 3, N'True', 4094)
INSERT [dbo].[Notifications] ([NotificationId], [TemplateName], [NotificationMessage], [NotificationType], [TypeId], [Status], [ClientId]) VALUES (4108, N'Test Synoris Group', N'You can Everything', N'SMS', 2, N'True', 4094)
INSERT [dbo].[Notifications] ([NotificationId], [TemplateName], [NotificationMessage], [NotificationType], [TypeId], [Status], [ClientId]) VALUES (4109, N'synoris89', N'This is a demo test', N'SMS', 2, N'True', 4094)
INSERT [dbo].[Notifications] ([NotificationId], [TemplateName], [NotificationMessage], [NotificationType], [TypeId], [Status], [ClientId]) VALUES (4110, N'hello123', N'This is a test demo', N'Email', 1, N'True', 4097)
INSERT [dbo].[Notifications] ([NotificationId], [TemplateName], [NotificationMessage], [NotificationType], [TypeId], [Status], [ClientId]) VALUES (5109, N'hello', N'This is a demo test', N'Voice Call', 3, N'True', 4096)
INSERT [dbo].[Notifications] ([NotificationId], [TemplateName], [NotificationMessage], [NotificationType], [TypeId], [Status], [ClientId]) VALUES (5110, N'hello', N'Hello,
       sandeep', N'Voice Call', 3, N'True', 4096)
INSERT [dbo].[Notifications] ([NotificationId], [TemplateName], [NotificationMessage], [NotificationType], [TypeId], [Status], [ClientId]) VALUES (6109, N'test3', N'ddfgdfgdfgdfg', N'Email', 1, N'True', 0)
SET IDENTITY_INSERT [dbo].[Notifications] OFF
SET IDENTITY_INSERT [dbo].[Resources] ON 

INSERT [dbo].[Resources] ([ResoureId], [AccountNumber], [CellPhoneNumber], [City], [ClientId], [EmailAddress], [FirstName], [LastName], [PrimaryPhoneNumber], [ResoureDescription], [ResoureName], [SecondaryPhoneNumber], [State], [Street], [URL], [ZipCode]) VALUES (3065, N'6666666666', NULL, NULL, 4094, N'balkrishnap@synoris.com', N'kkkjh', NULL, N'+919 926 850 014', N'synoris', N'Web Synoris Group', NULL, NULL, NULL, NULL, N'564454')
INSERT [dbo].[Resources] ([ResoureId], [AccountNumber], [CellPhoneNumber], [City], [ClientId], [EmailAddress], [FirstName], [LastName], [PrimaryPhoneNumber], [ResoureDescription], [ResoureName], [SecondaryPhoneNumber], [State], [Street], [URL], [ZipCode]) VALUES (3066, N'852369741', NULL, N'Indore', 4094, N'priyas@synoris.com', N'priya', N'saraf', N'+919 993 436 261', NULL, N'synorisgroup', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Resources] ([ResoureId], [AccountNumber], [CellPhoneNumber], [City], [ClientId], [EmailAddress], [FirstName], [LastName], [PrimaryPhoneNumber], [ResoureDescription], [ResoureName], [SecondaryPhoneNumber], [State], [Street], [URL], [ZipCode]) VALUES (3067, N'96565841555555555', NULL, NULL, 4097, N'priyas@synoris.com', N'priya', NULL, N'+919 993 436 261', NULL, N'priya', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Resources] ([ResoureId], [AccountNumber], [CellPhoneNumber], [City], [ClientId], [EmailAddress], [FirstName], [LastName], [PrimaryPhoneNumber], [ResoureDescription], [ResoureName], [SecondaryPhoneNumber], [State], [Street], [URL], [ZipCode]) VALUES (4066, N'7412589630', NULL, NULL, 4096, N'sandeepb@synoris.com', N'sandeep', N'baley', N'+919 993 436 261', NULL, N'testinggroup', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Resources] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'ClientAdmin')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (3, N'User')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[Tbl_NotificationSchedule] ON 

INSERT [dbo].[Tbl_NotificationSchedule] ([NScheduleID], [NotificationCampaign], [ContactListId], [ResourceId], [NotificationId], [CampaignDate], [ChanelMode], [NotificationMessage], [RequestConfirmMsg], [RepeatNotificationAllow], [MsgNumberOfTime], [ReapeatDate], [Status], [IsActive], [ClientId]) VALUES (21, N'synoris', 14, 7, NULL, CAST(N'2016-04-12 00:00:00.000' AS DateTime), N'Email', N'ytjttttyuuuu', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Tbl_NotificationSchedule] ([NScheduleID], [NotificationCampaign], [ContactListId], [ResourceId], [NotificationId], [CampaignDate], [ChanelMode], [NotificationMessage], [RequestConfirmMsg], [RepeatNotificationAllow], [MsgNumberOfTime], [ReapeatDate], [Status], [IsActive], [ClientId]) VALUES (4155, N'Welcome Notification', 5191, 3065, 4105, NULL, N'Email', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4094)
INSERT [dbo].[Tbl_NotificationSchedule] ([NScheduleID], [NotificationCampaign], [ContactListId], [ResourceId], [NotificationId], [CampaignDate], [ChanelMode], [NotificationMessage], [RequestConfirmMsg], [RepeatNotificationAllow], [MsgNumberOfTime], [ReapeatDate], [Status], [IsActive], [ClientId]) VALUES (4156, N'Web Synoris Group', 5191, 3065, 3098, NULL, N'Email', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4094)
INSERT [dbo].[Tbl_NotificationSchedule] ([NScheduleID], [NotificationCampaign], [ContactListId], [ResourceId], [NotificationId], [CampaignDate], [ChanelMode], [NotificationMessage], [RequestConfirmMsg], [RepeatNotificationAllow], [MsgNumberOfTime], [ReapeatDate], [Status], [IsActive], [ClientId]) VALUES (4157, N'Test School camp', 5191, 3065, 4105, NULL, N'Email', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4094)
INSERT [dbo].[Tbl_NotificationSchedule] ([NScheduleID], [NotificationCampaign], [ContactListId], [ResourceId], [NotificationId], [CampaignDate], [ChanelMode], [NotificationMessage], [RequestConfirmMsg], [RepeatNotificationAllow], [MsgNumberOfTime], [ReapeatDate], [Status], [IsActive], [ClientId]) VALUES (4158, N'Synoris Blood Camp', 5191, 3065, 4105, CAST(N'2016-05-25 00:00:00.000' AS DateTime), N'Email', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4094)
INSERT [dbo].[Tbl_NotificationSchedule] ([NScheduleID], [NotificationCampaign], [ContactListId], [ResourceId], [NotificationId], [CampaignDate], [ChanelMode], [NotificationMessage], [RequestConfirmMsg], [RepeatNotificationAllow], [MsgNumberOfTime], [ReapeatDate], [Status], [IsActive], [ClientId]) VALUES (4159, N'synoris technologies', 5193, 3065, 4105, NULL, N'Email', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4094)
INSERT [dbo].[Tbl_NotificationSchedule] ([NScheduleID], [NotificationCampaign], [ContactListId], [ResourceId], [NotificationId], [CampaignDate], [ChanelMode], [NotificationMessage], [RequestConfirmMsg], [RepeatNotificationAllow], [MsgNumberOfTime], [ReapeatDate], [Status], [IsActive], [ClientId]) VALUES (4160, N'synoris group', 5191, 3065, 4105, CAST(N'2016-05-31 06:30:00.000' AS DateTime), N'Email', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4094)
INSERT [dbo].[Tbl_NotificationSchedule] ([NScheduleID], [NotificationCampaign], [ContactListId], [ResourceId], [NotificationId], [CampaignDate], [ChanelMode], [NotificationMessage], [RequestConfirmMsg], [RepeatNotificationAllow], [MsgNumberOfTime], [ReapeatDate], [Status], [IsActive], [ClientId]) VALUES (4161, N'synoris technology', 5192, 3065, 4105, NULL, N'Email', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4094)
INSERT [dbo].[Tbl_NotificationSchedule] ([NScheduleID], [NotificationCampaign], [ContactListId], [ResourceId], [NotificationId], [CampaignDate], [ChanelMode], [NotificationMessage], [RequestConfirmMsg], [RepeatNotificationAllow], [MsgNumberOfTime], [ReapeatDate], [Status], [IsActive], [ClientId]) VALUES (4162, N'Roy Group', 5191, 3065, 4107, CAST(N'2016-05-28 11:35:00.000' AS DateTime), N'Voice Call', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4094)
INSERT [dbo].[Tbl_NotificationSchedule] ([NScheduleID], [NotificationCampaign], [ContactListId], [ResourceId], [NotificationId], [CampaignDate], [ChanelMode], [NotificationMessage], [RequestConfirmMsg], [RepeatNotificationAllow], [MsgNumberOfTime], [ReapeatDate], [Status], [IsActive], [ClientId]) VALUES (4163, N'Test synoris camp Group', 5191, 3065, 4108, CAST(N'2016-05-27 19:30:00.000' AS DateTime), N'SMS', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4094)
INSERT [dbo].[Tbl_NotificationSchedule] ([NScheduleID], [NotificationCampaign], [ContactListId], [ResourceId], [NotificationId], [CampaignDate], [ChanelMode], [NotificationMessage], [RequestConfirmMsg], [RepeatNotificationAllow], [MsgNumberOfTime], [ReapeatDate], [Status], [IsActive], [ClientId]) VALUES (4164, N'synoris techno', 5191, 3065, 4107, CAST(N'2016-05-28 02:00:00.000' AS DateTime), N'Voice Call', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4094)
INSERT [dbo].[Tbl_NotificationSchedule] ([NScheduleID], [NotificationCampaign], [ContactListId], [ResourceId], [NotificationId], [CampaignDate], [ChanelMode], [NotificationMessage], [RequestConfirmMsg], [RepeatNotificationAllow], [MsgNumberOfTime], [ReapeatDate], [Status], [IsActive], [ClientId]) VALUES (4165, N'synoris1', 5193, 3065, 4105, CAST(N'2016-05-28 01:00:00.000' AS DateTime), N'Email', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4094)
INSERT [dbo].[Tbl_NotificationSchedule] ([NScheduleID], [NotificationCampaign], [ContactListId], [ResourceId], [NotificationId], [CampaignDate], [ChanelMode], [NotificationMessage], [RequestConfirmMsg], [RepeatNotificationAllow], [MsgNumberOfTime], [ReapeatDate], [Status], [IsActive], [ClientId]) VALUES (4166, N'syno', 5191, 3065, 4106, CAST(N'2016-05-29 23:00:00.000' AS DateTime), N'Voice Call', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4094)
INSERT [dbo].[Tbl_NotificationSchedule] ([NScheduleID], [NotificationCampaign], [ContactListId], [ResourceId], [NotificationId], [CampaignDate], [ChanelMode], [NotificationMessage], [RequestConfirmMsg], [RepeatNotificationAllow], [MsgNumberOfTime], [ReapeatDate], [Status], [IsActive], [ClientId]) VALUES (4167, N'testdemo', 5194, 3066, 4109, CAST(N'2016-06-03 00:00:00.000' AS DateTime), N'SMS', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4094)
INSERT [dbo].[Tbl_NotificationSchedule] ([NScheduleID], [NotificationCampaign], [ContactListId], [ResourceId], [NotificationId], [CampaignDate], [ChanelMode], [NotificationMessage], [RequestConfirmMsg], [RepeatNotificationAllow], [MsgNumberOfTime], [ReapeatDate], [Status], [IsActive], [ClientId]) VALUES (4168, N'synoris', 5195, 3067, 4110, CAST(N'2016-05-28 00:00:00.000' AS DateTime), N'Email', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4097)
INSERT [dbo].[Tbl_NotificationSchedule] ([NScheduleID], [NotificationCampaign], [ContactListId], [ResourceId], [NotificationId], [CampaignDate], [ChanelMode], [NotificationMessage], [RequestConfirmMsg], [RepeatNotificationAllow], [MsgNumberOfTime], [ReapeatDate], [Status], [IsActive], [ClientId]) VALUES (5164, N'hello sandeep', 6197, 4066, 5110, CAST(N'2016-05-30 16:00:00.000' AS DateTime), N'Voice Call', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4096)
INSERT [dbo].[Tbl_NotificationSchedule] ([NScheduleID], [NotificationCampaign], [ContactListId], [ResourceId], [NotificationId], [CampaignDate], [ChanelMode], [NotificationMessage], [RequestConfirmMsg], [RepeatNotificationAllow], [MsgNumberOfTime], [ReapeatDate], [Status], [IsActive], [ClientId]) VALUES (5165, N'sandeep', 6197, 4066, 5111, CAST(N'2016-05-30 16:00:00.000' AS DateTime), N'SMS', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4096)
SET IDENTITY_INSERT [dbo].[Tbl_NotificationSchedule] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [UserName], [Password], [Fullname], [EmailId], [RoleId], [ClientId]) VALUES (10, N'admin', N'admin123', N'admin', N'admin@admin.com', 1, 0)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [Fullname], [EmailId], [RoleId], [ClientId]) VALUES (13, N'Nitin', N'nitin123', N'Nitin Vyas', N'nitinv@synoris.com', 2, 4094)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [Fullname], [EmailId], [RoleId], [ClientId]) VALUES (3023, N'jtoth', N'stingersix', N'Joe Toth', N'jtoth@tierfive.com', NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserClientRoleMapping] ON 

INSERT [dbo].[UserClientRoleMapping] ([Id], [UserId], [ClientId], [RoleId]) VALUES (1, 10, 0, 1)
INSERT [dbo].[UserClientRoleMapping] ([Id], [UserId], [ClientId], [RoleId]) VALUES (3011, 0, 4093, 2)
INSERT [dbo].[UserClientRoleMapping] ([Id], [UserId], [ClientId], [RoleId]) VALUES (3012, 0, 4094, 2)
INSERT [dbo].[UserClientRoleMapping] ([Id], [UserId], [ClientId], [RoleId]) VALUES (3013, 0, 4095, 2)
INSERT [dbo].[UserClientRoleMapping] ([Id], [UserId], [ClientId], [RoleId]) VALUES (3014, 0, 4096, 2)
INSERT [dbo].[UserClientRoleMapping] ([Id], [UserId], [ClientId], [RoleId]) VALUES (3015, 0, 4097, 2)
INSERT [dbo].[UserClientRoleMapping] ([Id], [UserId], [ClientId], [RoleId]) VALUES (3016, 0, 4098, 2)
INSERT [dbo].[UserClientRoleMapping] ([Id], [UserId], [ClientId], [RoleId]) VALUES (3017, 0, 4100, 2)
INSERT [dbo].[UserClientRoleMapping] ([Id], [UserId], [ClientId], [RoleId]) VALUES (3018, 0, 4101, 2)
INSERT [dbo].[UserClientRoleMapping] ([Id], [UserId], [ClientId], [RoleId]) VALUES (3019, 0, 4102, 2)
INSERT [dbo].[UserClientRoleMapping] ([Id], [UserId], [ClientId], [RoleId]) VALUES (3020, 0, 4103, 2)
INSERT [dbo].[UserClientRoleMapping] ([Id], [UserId], [ClientId], [RoleId]) VALUES (3021, 0, 4104, 2)
INSERT [dbo].[UserClientRoleMapping] ([Id], [UserId], [ClientId], [RoleId]) VALUES (3022, 0, 4105, 2)
INSERT [dbo].[UserClientRoleMapping] ([Id], [UserId], [ClientId], [RoleId]) VALUES (4017, 0, 5100, 2)
INSERT [dbo].[UserClientRoleMapping] ([Id], [UserId], [ClientId], [RoleId]) VALUES (4018, 0, 5101, 2)
INSERT [dbo].[UserClientRoleMapping] ([Id], [UserId], [ClientId], [RoleId]) VALUES (4019, 0, 5102, 2)
SET IDENTITY_INSERT [dbo].[UserClientRoleMapping] OFF
/****** Object:  StoredProcedure [dbo].[GetVoiceTemplate]    Script Date: 6/7/2016 7:17:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetVoiceTemplate]
@id int
as
select * from [dbo].[Notifications] where NotificationId = @id
GO
