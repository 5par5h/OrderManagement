USE [OrderManagement]
GO
/****** Object:  Table [dbo].[CartDetails]    Script Date: 4/20/2020 3:28:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartDetails](
	[user_id] [varchar](50) NOT NULL,
	[product_id] [varchar](50) NOT NULL,
	[quantity] [int] NOT NULL,
	[amount] [decimal](18, 0) NOT NULL,
	[total_amount] [decimal](18, 0) NOT NULL,
	[is_ordered] [nchar](10) NOT NULL,
	[item_added_on] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 4/20/2020 3:28:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[order_id] [varchar](50) NOT NULL,
	[user_id] [varchar](50) NOT NULL,
	[order_status] [nchar](10) NOT NULL,
	[shipping_address] [varchar](max) NOT NULL,
	[phone_number] [varchar](max) NOT NULL,
	[payment_type] [varchar](20) NULL,
	[Is_payment_completed] [varchar](10) NULL,
	[PinCode] [varchar](max) NOT NULL,
	[date_created] [datetime] NOT NULL,
	[total_amount] [float] NOT NULL,
	[order_num] [int] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductDetails]    Script Date: 4/20/2020 3:28:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDetails](
	[product_id] [varchar](50) NOT NULL,
	[product_name] [varchar](50) NOT NULL,
	[product_description] [varchar](max) NULL,
	[weight] [float] NULL,
	[height] [float] NULL,
	[image] [varchar](max) NULL,
	[SKU] [int] NOT NULL,
	[bar_code] [varchar](50) NULL,
	[available_qty] [int] NOT NULL,
	[price] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_ProductDetails] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 4/20/2020 3:28:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[User_Id] [varchar](50) NOT NULL,
	[First_Name] [varchar](50) NOT NULL,
	[Last_Name] [varchar](50) NULL,
	[Email_Address] [varchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Alternate_Email_Address] [varchar](max) NULL,
	[Phone_Number] [nchar](15) NOT NULL,
	[Created_Date] [datetime] NULL,
	[IsAdmin] [nchar](10) NOT NULL,
	[IsDeactive] [nchar](2) NOT NULL,
	[Deactive_On] [datetime] NULL,
	[Last_Activity_On] [datetime] NULL,
 CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
