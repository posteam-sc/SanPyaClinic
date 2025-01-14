USE [Tamine_ClearDB]
GO
/****** Object:  Table [dbo].[AttachGiftForTransaction]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AttachGiftForTransaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AttachGiftId] [int] NOT NULL,
	[TransactionId] [varchar](20) NOT NULL,
 CONSTRAINT [PK_AttachGiftForTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Authorize]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Authorize](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[licenseKey] [varchar](max) NULL,
	[macAddress] [varchar](max) NULL,
 CONSTRAINT [PK_Authorize] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[City]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [varchar](100) NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ConsignmentCounter]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsignmentCounter](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[CounterLocation] [nvarchar](200) NULL,
	[PhoneNo] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_ConsignmentCounter] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Counter]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Counter](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Counter] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Currency]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Currency](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Country] [nvarchar](50) NULL,
	[Symbol] [varchar](5) NULL,
	[CurrencyCode] [varchar](20) NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](5) NULL,
	[Name] [nvarchar](200) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[NRC] [varchar](20) NULL,
	[Email] [varchar](100) NULL,
	[CityId] [int] NULL,
	[TownShipId] [int] NULL,
	[Gender] [varchar](10) NULL,
	[Birthday] [date] NULL,
	[CustomerCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DailyDutyPhysio]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DailyDutyPhysio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StaffID] [varchar](100) NOT NULL,
	[DutyDate] [datetime] NOT NULL,
	[Shift] [nvarchar](100) NOT NULL,
	[GroupID] [int] NULL,
 CONSTRAINT [PK_DailyDutyPhysio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DailyRecord]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DailyRecord](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CounterId] [int] NULL,
	[StartDateTime] [datetime] NULL,
	[EndDateTime] [datetime] NULL,
	[OpeningBalance] [bigint] NULL,
	[ClosingBalance] [bigint] NULL,
	[AccuralAmount] [bigint] NULL,
	[DifferenceAmount] [bigint] NULL,
	[Comment] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_DailyRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DeleteLog]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DeleteLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[CounterId] [int] NULL,
	[TransactionId] [varchar](20) NULL,
	[TransactionDetailId] [bigint] NULL,
	[IsParent] [bit] NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK_DeleteLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DoctorPhysio]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DoctorPhysio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDoctor] [bit] NULL,
	[ChargesPerPatient] [int] NULL,
	[PhysicoCharges] [int] NULL,
	[IsInhouse] [bit] NULL,
	[ForPhysioTrain] [decimal](18, 0) NULL,
	[Name] [nvarchar](200) NULL,
	[Degree] [nvarchar](500) NULL,
	[Specialisation] [nvarchar](500) NULL,
	[Gender] [nvarchar](6) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[Address] [nvarchar](200) NULL,
	[IsPercent] [bit] NULL,
 CONSTRAINT [PK_DoctorPhysio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Expense]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expense](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExpenseNo] [nvarchar](100) NOT NULL,
	[ExpenseDate] [datetime] NULL,
	[IsApproved] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedUser] [int] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedUser] [int] NULL,
	[TotalExpenseAmount] [decimal](18, 2) NULL,
	[Comment] [nvarchar](max) NULL,
	[ExpenseCategoryId] [int] NULL,
	[Count] [int] NULL,
 CONSTRAINT [PK_Expense] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExpenseCategory]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpenseCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ExpenseCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExpenseDetail]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpenseDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExpenseId] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Qty] [decimal](18, 2) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_ExpenseDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GiftCard]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GiftCard](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CardNumber] [varchar](200) NULL,
	[Amount] [bigint] NULL,
 CONSTRAINT [PK_GiftCard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GiftCardInCustomer]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiftCardInCustomer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[GiftCardId] [int] NOT NULL,
 CONSTRAINT [PK_GiftCardInCustomer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GiftSystem]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GiftSystem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsGWP] [bit] NOT NULL,
	[Name] [varchar](200) NULL,
	[MustBuyCostFrom] [bigint] NULL,
	[MustBuyCostTo] [bigint] NULL,
	[MustIncludeProductId] [bigint] NULL,
	[FilterBrandId] [int] NULL,
	[FilterCategoryId] [int] NULL,
	[FilterSubCategoryId] [int] NULL,
	[ValidFrom] [datetime] NOT NULL,
	[ValidTo] [datetime] NOT NULL,
	[GiftProductId] [bigint] NULL,
	[GiftDiscountAmountForGiftProduct] [bigint] NOT NULL,
	[GiftCashAmount] [bigint] NOT NULL,
	[GiftDiscountAmount] [bigint] NOT NULL,
	[GiftDiscountPercent] [int] NOT NULL,
 CONSTRAINT [PK_GiftSystem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Group]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](100) NULL,
	[IsUse] [bit] NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupByPhysio]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupByPhysio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupID] [int] NULL,
	[PhysioID] [int] NULL,
 CONSTRAINT [PK_GroupByPhysio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupByTransaction]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GroupByTransaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionId] [varchar](20) NULL,
	[GroupMemberID] [int] NULL,
	[PaymentPercent] [int] NULL,
 CONSTRAINT [PK_GroupByTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Loc_CustomerPoint]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loc_CustomerPoint](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[OldPoint] [int] NULL,
	[TotalRedeemPoint] [int] NULL,
 CONSTRAINT [PK_Loc_CustomerPoint] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Loc_PointRedeemHistory]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loc_PointRedeemHistory](
	[Id] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[RedeemPoint] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[CounterId] [int] NOT NULL,
	[CasherId] [int] NOT NULL,
 CONSTRAINT [PK_Loc_PointRedeemHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MainPurchase]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MainPurchase](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SupplierId] [int] NULL,
	[Date] [datetime] NULL,
	[VoucherNo] [nvarchar](50) NULL,
	[TotalAmount] [bigint] NULL,
	[Cash] [bigint] NULL,
	[OldCreditAmount] [bigint] NULL,
	[SettlementAmount] [bigint] NULL,
	[IsActive] [bit] NULL,
	[DiscountAmount] [int] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[IsCompletedInvoice] [bit] NULL,
	[IsCompletedPaid] [bit] NULL,
	[IsPurchase] [bit] NULL,
 CONSTRAINT [PK_MainPurchase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PaymentType]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_PaymentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[ProductCode] [varchar](50) NOT NULL,
	[Barcode] [varchar](50) NOT NULL,
	[Price] [bigint] NOT NULL,
	[Qty] [int] NULL,
	[BrandId] [int] NULL,
	[ProductLocation] [nvarchar](200) NULL,
	[ProductCategoryId] [int] NULL,
	[ProductSubCategoryId] [int] NULL,
	[UnitId] [int] NULL,
	[TaxId] [int] NULL,
	[MinStockQty] [int] NULL,
	[DiscountRate] [decimal](5, 2) NOT NULL,
	[IsWrapper] [bit] NULL,
	[IsConsignment] [bit] NULL,
	[IsDiscontinue] [bit] NULL,
	[ConsignmentPrice] [bigint] NULL,
	[ConsignmentCounterId] [int] NULL,
	[Size] [nvarchar](50) NULL,
	[PurchasePrice] [bigint] NULL,
	[IsNotifyMinStock] [bit] NULL,
	[ChargesforDoctor] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Charges] [int] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductInfo]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NULL,
	[Supplier] [nvarchar](200) NULL,
	[ManufacturedCode] [bigint] NULL,
	[LocationInWareHose] [varchar](200) NULL,
	[Length] [int] NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
	[Weight] [int] NULL,
	[Unit] [varchar](10) NULL,
 CONSTRAINT [PK_ProductInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductPriceChange]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductPriceChange](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Price] [bigint] NULL,
	[UpdateDate] [datetime] NULL,
	[UserID] [int] NULL,
	[ProductId] [bigint] NULL,
	[OldPrice] [bigint] NULL,
 CONSTRAINT [PK_ProductPriceChange] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductSubCategory]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSubCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[ProductCategoryId] [int] NULL,
	[Prefix] [nvarchar](20) NULL,
 CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseDeleteLog]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseDeleteLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[CounterId] [int] NULL,
	[MainPurchaseId] [int] NULL,
	[PurchaseDetailId] [int] NULL,
	[IsParent] [bit] NULL,
	[DeletedDate] [datetime] NULL,
	[VoucherNo] [nvarchar](50) NULL,
 CONSTRAINT [PK_PurchaseDeleteLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseDetail]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MainPurchaseId] [int] NULL,
	[ProductId] [bigint] NULL,
	[Qty] [int] NULL,
	[UnitPrice] [int] NULL,
	[CurrentQy] [int] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedDate] [datetime] NULL,
	[DeletedUser] [int] NULL,
	[Date] [datetime] NULL,
	[ConvertQty] [numeric](18, 2) NULL,
 CONSTRAINT [PK_PurchaseDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseDetailInTransaction]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseDetailInTransaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NULL,
	[TransactionDetailId] [bigint] NULL,
	[PurchaseDetailId] [int] NULL,
	[Qty] [int] NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_PurchaseDetailInTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleManagement]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoleManagement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RuleFeature] [varchar](100) NOT NULL,
	[UserRoleId] [int] NOT NULL,
	[IsAllowed] [bit] NOT NULL,
 CONSTRAINT [PK_RoleManagement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Setting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Key] [varchar](max) NULL,
	[Value] [varchar](max) NULL,
 CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SPDetail]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SPDetail](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TransactionDetailID] [bigint] NULL,
	[ParentProductID] [bigint] NULL,
	[ChildProductID] [bigint] NULL,
	[Price] [bigint] NULL,
	[DiscountRate] [decimal](5, 2) NULL,
	[SPDetailID] [nvarchar](50) NULL,
 CONSTRAINT [PK_SPDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[Email] [varchar](100) NULL,
	[ContactPerson] [nvarchar](200) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tax]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tax](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[TaxPercent] [decimal](5, 2) NULL,
 CONSTRAINT [PK_Tax] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Townshipdb]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Townshipdb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TownshipName] [varchar](100) NULL,
 CONSTRAINT [PK_Townshipdb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Transaction](
	[Id] [varchar](20) NOT NULL,
	[DateTime] [datetime] NULL,
	[UserId] [int] NULL,
	[CounterId] [int] NULL,
	[Type] [varchar](20) NULL,
	[IsPaid] [bit] NULL,
	[IsComplete] [bit] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[PaymentTypeId] [int] NULL,
	[TaxAmount] [int] NULL,
	[DiscountAmount] [int] NULL,
	[TotalAmount] [bigint] NULL,
	[RecieveAmount] [bigint] NULL,
	[ParentId] [varchar](20) NULL,
	[GiftCardId] [int] NULL,
	[CustomerId] [int] NULL,
	[DoctorID] [int] NULL,
	[ServiceChages] [int] NULL,
	[GroupID] [int] NULL,
	[Consultantfees] [int] NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TransactionDetail]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TransactionDetail](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TransactionId] [varchar](20) NULL,
	[ProductId] [bigint] NULL,
	[Qty] [int] NULL,
	[UnitPrice] [bigint] NULL,
	[DiscountRate] [decimal](5, 2) NOT NULL,
	[TaxRate] [decimal](5, 2) NOT NULL,
	[TotalAmount] [bigint] NULL,
	[IsDeleted] [bit] NULL,
	[InjectionRate] [decimal](18, 0) NULL,
	[PTRate] [decimal](18, 0) NULL,
	[XRayRate] [decimal](18, 0) NULL,
 CONSTRAINT [PK_TransactionDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UnitName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsePrePaidDebt]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UsePrePaidDebt](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreditTransactionId] [varchar](20) NULL,
	[PrePaidDebtTransactionId] [varchar](20) NULL,
	[UseAmount] [int] NULL,
	[CashierId] [int] NULL,
	[CounterId] [int] NULL,
 CONSTRAINT [PK_UsePrePaidDebt] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[UserRoleId] [int] NULL,
	[Password] [varchar](max) NULL,
	[DateTime] [datetime] NULL CONSTRAINT [DF_User_DateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WrapperItem]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WrapperItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentProductId] [bigint] NULL,
	[ChildProductId] [bigint] NULL,
 CONSTRAINT [PK_WrapperItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Counter] ON 

INSERT [dbo].[Counter] ([Id], [Name]) VALUES (1, N'One')
SET IDENTITY_INSERT [dbo].[Counter] OFF
SET IDENTITY_INSERT [dbo].[Currency] ON 

INSERT [dbo].[Currency] ([Id], [Country], [Symbol], [CurrencyCode]) VALUES (1, N'United State of America', N'$', N'USD')
INSERT [dbo].[Currency] ([Id], [Country], [Symbol], [CurrencyCode]) VALUES (2, N'Myanmar', N'Ks', N'MMK')
SET IDENTITY_INSERT [dbo].[Currency] OFF
SET IDENTITY_INSERT [dbo].[ExpenseCategory] ON 

INSERT [dbo].[ExpenseCategory] ([Id], [Name]) VALUES (1, N'Appliance')
INSERT [dbo].[ExpenseCategory] ([Id], [Name]) VALUES (2, N'Commodities')
INSERT [dbo].[ExpenseCategory] ([Id], [Name]) VALUES (3, N'Salary')
SET IDENTITY_INSERT [dbo].[ExpenseCategory] OFF
SET IDENTITY_INSERT [dbo].[PaymentType] ON 

INSERT [dbo].[PaymentType] ([Id], [Name]) VALUES (1, N'Cash')
INSERT [dbo].[PaymentType] ([Id], [Name]) VALUES (2, N'Credit')
INSERT [dbo].[PaymentType] ([Id], [Name]) VALUES (3, N'GiftCard')
INSERT [dbo].[PaymentType] ([Id], [Name]) VALUES (4, N'FOC')
INSERT [dbo].[PaymentType] ([Id], [Name]) VALUES (5, N'MPU')
INSERT [dbo].[PaymentType] ([Id], [Name]) VALUES (6, N'Tester')
SET IDENTITY_INSERT [dbo].[PaymentType] OFF
SET IDENTITY_INSERT [dbo].[Setting] ON 

INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (1, N'barcode_printer', N'Adobe PDF')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (2, N'a4_printer', N'Send To OneNote 2010')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (3, N'allow_salep_counter', N'True')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (4, N'allow_salep_brand', N'False')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (5, N'allow_salep_product_category', N'False')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (6, N'allow_salep_giftcard', N'False')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (7, N'allow_salep_products', N'True')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (8, N'slip_printer', N'Foxit Reader PDF Printer')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (9, N'shop_name', N'San Pya')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (10, N'branch_name', N'20/256, Insein Road,Hlaing Township,Yangon')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (11, N'phone_number', N'01522778')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (12, N'opening_hours', N'8:00 am to 8:00 pm')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (13, N'default_tax_rate', N'5')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (14, N'default_top_sale_row', N'1')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (15, N'default_city_id', N'1')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (16, N'slip_printer_counter1', N'XP-80C (copy 1)')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (17, N'slip_printer_counter2', N'Send To OneNote 2013')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (18, N'slip_printer_counter1006', N'Foxit Reader PDF Printer')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (19, N'slip_printer_counter1007', N'Send To OneNote 2010')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (20, N'slip_printer_counter1008', N'Birch BP-003 (Copy 2)')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (21, N'slip_printer_counter2011', N'Star TSP043')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (22, N'slip_printer_counter2010', N'Star TSP043')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (23, N'slip_printer_counter2012', N'Star TSP043')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (24, N'slip_printer_counter1009', N'Birch BP-003 (Copy 2)')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (25, N'default_service_charges', N'1000')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (26, N'default_book_fees', N'200')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (27, N'default_Physio_Percent', N'20')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (28, N'shift_assign', N'Afternoon Assign')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (29, N'amshift_assign', N'10:00 AM-4:00 PM')
INSERT [dbo].[Setting] ([Id], [Key], [Value]) VALUES (30, N'pmshift_assign', N'4:00 PM-8:00 PM')
SET IDENTITY_INSERT [dbo].[Setting] OFF
SET IDENTITY_INSERT [dbo].[Tax] ON 

INSERT [dbo].[Tax] ([Id], [Name], [TaxPercent]) VALUES (5, N'None', CAST(0.00 AS Decimal(5, 2)))
INSERT [dbo].[Tax] ([Id], [Name], [TaxPercent]) VALUES (1005, N'GOV Tax', CAST(5.00 AS Decimal(5, 2)))
SET IDENTITY_INSERT [dbo].[Tax] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [UserRoleId], [Password], [DateTime]) VALUES (1, N'sourcecodeadmin', 1, N'2BMH+NlLeYZl8t03W04flA==', CAST(N'2016-06-23 13:06:07.460' AS DateTime))
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[UserRole] ([Id], [RoleName]) VALUES (2, N'Super Cashier')
INSERT [dbo].[UserRole] ([Id], [RoleName]) VALUES (3, N'Cashier')
SET IDENTITY_INSERT [dbo].[UserRole] OFF
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_City] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_City]
GO
ALTER TABLE [dbo].[DailyRecord]  WITH CHECK ADD  CONSTRAINT [FK_DailyRecord_Counter] FOREIGN KEY([CounterId])
REFERENCES [dbo].[Counter] ([Id])
GO
ALTER TABLE [dbo].[DailyRecord] CHECK CONSTRAINT [FK_DailyRecord_Counter]
GO
ALTER TABLE [dbo].[DeleteLog]  WITH CHECK ADD  CONSTRAINT [FK_DeleteLog_Counter] FOREIGN KEY([CounterId])
REFERENCES [dbo].[Counter] ([Id])
GO
ALTER TABLE [dbo].[DeleteLog] CHECK CONSTRAINT [FK_DeleteLog_Counter]
GO
ALTER TABLE [dbo].[DeleteLog]  WITH CHECK ADD  CONSTRAINT [FK_DeleteLog_Transaction] FOREIGN KEY([TransactionId])
REFERENCES [dbo].[Transaction] ([Id])
GO
ALTER TABLE [dbo].[DeleteLog] CHECK CONSTRAINT [FK_DeleteLog_Transaction]
GO
ALTER TABLE [dbo].[DeleteLog]  WITH CHECK ADD  CONSTRAINT [FK_DeleteLog_TransactionDetail] FOREIGN KEY([TransactionDetailId])
REFERENCES [dbo].[TransactionDetail] ([Id])
GO
ALTER TABLE [dbo].[DeleteLog] CHECK CONSTRAINT [FK_DeleteLog_TransactionDetail]
GO
ALTER TABLE [dbo].[DeleteLog]  WITH CHECK ADD  CONSTRAINT [FK_DeleteLog_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[DeleteLog] CHECK CONSTRAINT [FK_DeleteLog_User]
GO
ALTER TABLE [dbo].[Expense]  WITH CHECK ADD  CONSTRAINT [FK_Expense_ExpenseCategory] FOREIGN KEY([ExpenseCategoryId])
REFERENCES [dbo].[ExpenseCategory] ([Id])
GO
ALTER TABLE [dbo].[Expense] CHECK CONSTRAINT [FK_Expense_ExpenseCategory]
GO
ALTER TABLE [dbo].[Expense]  WITH CHECK ADD  CONSTRAINT [FK_Expense_User] FOREIGN KEY([CreatedUser])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Expense] CHECK CONSTRAINT [FK_Expense_User]
GO
ALTER TABLE [dbo].[ExpenseDetail]  WITH CHECK ADD  CONSTRAINT [FK_ExpenseDetail_Expense] FOREIGN KEY([ExpenseId])
REFERENCES [dbo].[Expense] ([Id])
GO
ALTER TABLE [dbo].[ExpenseDetail] CHECK CONSTRAINT [FK_ExpenseDetail_Expense]
GO
ALTER TABLE [dbo].[GroupByPhysio]  WITH CHECK ADD  CONSTRAINT [FK_GroupByPhysio_DoctorPhysio] FOREIGN KEY([PhysioID])
REFERENCES [dbo].[DoctorPhysio] ([Id])
GO
ALTER TABLE [dbo].[GroupByPhysio] CHECK CONSTRAINT [FK_GroupByPhysio_DoctorPhysio]
GO
ALTER TABLE [dbo].[GroupByPhysio]  WITH CHECK ADD  CONSTRAINT [FK_GroupByPhysio_Group] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[GroupByPhysio] CHECK CONSTRAINT [FK_GroupByPhysio_Group]
GO
ALTER TABLE [dbo].[GroupByTransaction]  WITH CHECK ADD  CONSTRAINT [FK_GroupByTransaction_DoctorPhysio] FOREIGN KEY([GroupMemberID])
REFERENCES [dbo].[DoctorPhysio] ([Id])
GO
ALTER TABLE [dbo].[GroupByTransaction] CHECK CONSTRAINT [FK_GroupByTransaction_DoctorPhysio]
GO
ALTER TABLE [dbo].[GroupByTransaction]  WITH CHECK ADD  CONSTRAINT [FK_GroupByTransaction_GroupByTransaction] FOREIGN KEY([TransactionId])
REFERENCES [dbo].[Transaction] ([Id])
GO
ALTER TABLE [dbo].[GroupByTransaction] CHECK CONSTRAINT [FK_GroupByTransaction_GroupByTransaction]
GO
ALTER TABLE [dbo].[MainPurchase]  WITH CHECK ADD  CONSTRAINT [FK_MainPurchase_Supplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([Id])
GO
ALTER TABLE [dbo].[MainPurchase] CHECK CONSTRAINT [FK_MainPurchase_Supplier]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Brand]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ConsignmentCounter] FOREIGN KEY([ConsignmentCounterId])
REFERENCES [dbo].[ConsignmentCounter] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ConsignmentCounter]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductCategory] FOREIGN KEY([ProductCategoryId])
REFERENCES [dbo].[ProductCategory] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductCategory]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductType] FOREIGN KEY([ProductSubCategoryId])
REFERENCES [dbo].[ProductSubCategory] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductType]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Tax] FOREIGN KEY([TaxId])
REFERENCES [dbo].[Tax] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Tax]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Unit] FOREIGN KEY([UnitId])
REFERENCES [dbo].[Unit] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Unit]
GO
ALTER TABLE [dbo].[ProductPriceChange]  WITH CHECK ADD  CONSTRAINT [FK_ProductPriceChange_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductPriceChange] CHECK CONSTRAINT [FK_ProductPriceChange_Product]
GO
ALTER TABLE [dbo].[ProductPriceChange]  WITH CHECK ADD  CONSTRAINT [FK_ProductPriceChange_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[ProductPriceChange] CHECK CONSTRAINT [FK_ProductPriceChange_User]
GO
ALTER TABLE [dbo].[ProductSubCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductSubCategory_ProductCategory] FOREIGN KEY([ProductCategoryId])
REFERENCES [dbo].[ProductCategory] ([Id])
GO
ALTER TABLE [dbo].[ProductSubCategory] CHECK CONSTRAINT [FK_ProductSubCategory_ProductCategory]
GO
ALTER TABLE [dbo].[PurchaseDeleteLog]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseDeleteLog_Counter] FOREIGN KEY([CounterId])
REFERENCES [dbo].[Counter] ([Id])
GO
ALTER TABLE [dbo].[PurchaseDeleteLog] CHECK CONSTRAINT [FK_PurchaseDeleteLog_Counter]
GO
ALTER TABLE [dbo].[PurchaseDeleteLog]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseDeleteLog_MainPurchase] FOREIGN KEY([MainPurchaseId])
REFERENCES [dbo].[MainPurchase] ([Id])
GO
ALTER TABLE [dbo].[PurchaseDeleteLog] CHECK CONSTRAINT [FK_PurchaseDeleteLog_MainPurchase]
GO
ALTER TABLE [dbo].[PurchaseDeleteLog]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseDeleteLog_PurchaseDetail] FOREIGN KEY([PurchaseDetailId])
REFERENCES [dbo].[PurchaseDetail] ([Id])
GO
ALTER TABLE [dbo].[PurchaseDeleteLog] CHECK CONSTRAINT [FK_PurchaseDeleteLog_PurchaseDetail]
GO
ALTER TABLE [dbo].[PurchaseDeleteLog]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseDeleteLog_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PurchaseDeleteLog] CHECK CONSTRAINT [FK_PurchaseDeleteLog_User]
GO
ALTER TABLE [dbo].[PurchaseDetail]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseDetail_MainPurchase] FOREIGN KEY([MainPurchaseId])
REFERENCES [dbo].[MainPurchase] ([Id])
GO
ALTER TABLE [dbo].[PurchaseDetail] CHECK CONSTRAINT [FK_PurchaseDetail_MainPurchase]
GO
ALTER TABLE [dbo].[PurchaseDetail]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseDetail_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[PurchaseDetail] CHECK CONSTRAINT [FK_PurchaseDetail_Product]
GO
ALTER TABLE [dbo].[PurchaseDetailInTransaction]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseDetailInTransaction_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[PurchaseDetailInTransaction] CHECK CONSTRAINT [FK_PurchaseDetailInTransaction_Product]
GO
ALTER TABLE [dbo].[PurchaseDetailInTransaction]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseDetailInTransaction_PurchaseDetail] FOREIGN KEY([PurchaseDetailId])
REFERENCES [dbo].[PurchaseDetail] ([Id])
GO
ALTER TABLE [dbo].[PurchaseDetailInTransaction] CHECK CONSTRAINT [FK_PurchaseDetailInTransaction_PurchaseDetail]
GO
ALTER TABLE [dbo].[PurchaseDetailInTransaction]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseDetailInTransaction_TransactionDetail] FOREIGN KEY([TransactionDetailId])
REFERENCES [dbo].[TransactionDetail] ([Id])
GO
ALTER TABLE [dbo].[PurchaseDetailInTransaction] CHECK CONSTRAINT [FK_PurchaseDetailInTransaction_TransactionDetail]
GO
ALTER TABLE [dbo].[RoleManagement]  WITH CHECK ADD  CONSTRAINT [FK_RoleManagement_UserRole] FOREIGN KEY([UserRoleId])
REFERENCES [dbo].[UserRole] ([Id])
GO
ALTER TABLE [dbo].[RoleManagement] CHECK CONSTRAINT [FK_RoleManagement_UserRole]
GO
ALTER TABLE [dbo].[SPDetail]  WITH CHECK ADD  CONSTRAINT [FK_SPDetail_Product] FOREIGN KEY([ParentProductID])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[SPDetail] CHECK CONSTRAINT [FK_SPDetail_Product]
GO
ALTER TABLE [dbo].[SPDetail]  WITH CHECK ADD  CONSTRAINT [FK_SPDetail_Product1] FOREIGN KEY([ChildProductID])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[SPDetail] CHECK CONSTRAINT [FK_SPDetail_Product1]
GO
ALTER TABLE [dbo].[SPDetail]  WITH CHECK ADD  CONSTRAINT [FK_SPDetail_TransactionDetail] FOREIGN KEY([TransactionDetailID])
REFERENCES [dbo].[TransactionDetail] ([Id])
GO
ALTER TABLE [dbo].[SPDetail] CHECK CONSTRAINT [FK_SPDetail_TransactionDetail]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Counter] FOREIGN KEY([CounterId])
REFERENCES [dbo].[Counter] ([Id])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_Counter]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_Customer]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_DoctorPhysio] FOREIGN KEY([DoctorID])
REFERENCES [dbo].[DoctorPhysio] ([Id])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_DoctorPhysio]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_GiftCard] FOREIGN KEY([GiftCardId])
REFERENCES [dbo].[GiftCard] ([Id])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_GiftCard]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_PaymentType] FOREIGN KEY([PaymentTypeId])
REFERENCES [dbo].[PaymentType] ([Id])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_PaymentType]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Transaction] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Transaction] ([Id])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_Transaction]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_User]
GO
ALTER TABLE [dbo].[TransactionDetail]  WITH CHECK ADD  CONSTRAINT [FK_TransactionDetail_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[TransactionDetail] CHECK CONSTRAINT [FK_TransactionDetail_Product]
GO
ALTER TABLE [dbo].[TransactionDetail]  WITH CHECK ADD  CONSTRAINT [FK_TransactionDetail_Transaction] FOREIGN KEY([TransactionId])
REFERENCES [dbo].[Transaction] ([Id])
GO
ALTER TABLE [dbo].[TransactionDetail] CHECK CONSTRAINT [FK_TransactionDetail_Transaction]
GO
ALTER TABLE [dbo].[UsePrePaidDebt]  WITH CHECK ADD  CONSTRAINT [FK_UsePrePaidDebt_Counter] FOREIGN KEY([CounterId])
REFERENCES [dbo].[Counter] ([Id])
GO
ALTER TABLE [dbo].[UsePrePaidDebt] CHECK CONSTRAINT [FK_UsePrePaidDebt_Counter]
GO
ALTER TABLE [dbo].[UsePrePaidDebt]  WITH CHECK ADD  CONSTRAINT [FK_UsePrePaidDebt_Transaction] FOREIGN KEY([CreditTransactionId])
REFERENCES [dbo].[Transaction] ([Id])
GO
ALTER TABLE [dbo].[UsePrePaidDebt] CHECK CONSTRAINT [FK_UsePrePaidDebt_Transaction]
GO
ALTER TABLE [dbo].[UsePrePaidDebt]  WITH CHECK ADD  CONSTRAINT [FK_UsePrePaidDebt_Transaction1] FOREIGN KEY([PrePaidDebtTransactionId])
REFERENCES [dbo].[Transaction] ([Id])
GO
ALTER TABLE [dbo].[UsePrePaidDebt] CHECK CONSTRAINT [FK_UsePrePaidDebt_Transaction1]
GO
ALTER TABLE [dbo].[UsePrePaidDebt]  WITH CHECK ADD  CONSTRAINT [FK_UsePrePaidDebt_User] FOREIGN KEY([CashierId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UsePrePaidDebt] CHECK CONSTRAINT [FK_UsePrePaidDebt_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserRole] FOREIGN KEY([UserRoleId])
REFERENCES [dbo].[UserRole] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserRole]
GO
ALTER TABLE [dbo].[WrapperItem]  WITH CHECK ADD  CONSTRAINT [FK_WrapperItem_Product] FOREIGN KEY([ParentProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[WrapperItem] CHECK CONSTRAINT [FK_WrapperItem_Product]
GO
ALTER TABLE [dbo].[WrapperItem]  WITH CHECK ADD  CONSTRAINT [FK_WrapperItem_Product1] FOREIGN KEY([ChildProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[WrapperItem] CHECK CONSTRAINT [FK_WrapperItem_Product1]
GO
/****** Object:  StoredProcedure [dbo].[ClearDBConnections]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ClearDBConnections]
AS
BEGIN
	
ALTER DATABASE POSDoctor
SET OFFLINE WITH ROLLBACK IMMEDIATE
ALTER DATABASE POSDoctor
SET ONLINE

END




GO
/****** Object:  StoredProcedure [dbo].[ExportDatabase]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ExportDatabase]
	@Path varchar(Max),
	@BackUpName varchar(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    BACKUP DATABASE POS TO  DISK = @Path WITH NOFORMAT, NOINIT,  NAME = @BackUpName, SKIP, NOREWIND, NOUNLOAD,  STATS = 10

END




GO
/****** Object:  StoredProcedure [dbo].[GetConsignmentProduct]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetConsignmentProduct]
@fromdate datetime,
@todate	datetime,
@cId int


as
BEGIN

if(@cId=0)
begin

select pd.Name,td.Qty,td.UnitPrice,td.TotalAmount,con.Name as [Counter Name],td.IsDeleted,td.DiscountRate,td.TaxRate  from TransactionDetail as td inner join Product as pd on td.ProductId=pd.Id  inner join
 [Transaction] as t on td.TransactionId= t.Id inner join ConsignmentCounter as con on pd.ConsignmentCounterId=con.Id
 where pd.IsConsignment=1 and  CAST(t.DateTime as Date) >=CAST(@fromdate as Date) and CAST(t.DateTime as Date)<=CAST(@todate as Date) 


end

else
begin
 select pd.Name,td.Qty,td.UnitPrice,td.TotalAmount,td.IsDeleted,con.Name as [Counter Name],td.DiscountRate,td.TaxRate from TransactionDetail as td inner join Product as pd on td.ProductId=pd.Id  inner join
 [Transaction] as t on td.TransactionId= t.Id inner join ConsignmentCounter as con on pd.ConsignmentCounterId=con.Id
 where pd.IsConsignment=1 and pd.ConsignmentCounterId=@cId 
 and  CAST(t.DateTime as Date) >=CAST(@fromdate as Date) and CAST(t.DateTime as Date)<=CAST(@todate as Date)  
 end
END




GO
/****** Object:  StoredProcedure [dbo].[GetConsultantfeesDoctorFeesByDateRate]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetConsultantfeesDoctorFeesByDateRate]
	@DID int,
	@fromDate datetime,
	@toDate datetime
AS
BEGIN


SELECT                   SUM([Transaction].Consultantfees) AS Consultantfees,DoctorPhysio.Name,[Transaction].DoctorID,Count([Transaction].Id) AS NoofPatient
FROM                     [Transaction] INNER JOIN
                         DoctorPhysio ON [Transaction].DoctorID = DoctorPhysio.Id
                         
						 WHERE  CAST([Transaction].DateTime as Date) >=CAST(@fromDate as Date) and CAST([Transaction].DateTime as Date)<=CAST(@toDate as Date) 
						 AND ([Transaction].DoctorID=@DID) AND [Transaction].IsDeleted=0
						  AND [Transaction].IsComplete=1 AND [Transaction].IsActive=1 AND [Transaction].PaymentTypeId <> 4 
						  --AND [Transaction].GroupID IS NULL 
						  And [Transaction].Consultantfees >0
						 Group By DoctorPhysio.Name,[Transaction].DoctorID ,[Transaction].CustomerId

END




GO
/****** Object:  StoredProcedure [dbo].[GetCustomerCode]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetCustomerCode]
@prefix  varchar(20),
@TotalNumberlength int,
@PrefixLength int
as
begin
	DECLARE @NEWID VARCHAR(10);		
	SELECT @NEWID = (@prefix + replicate('0',@TotalNumberlength - len(CONVERT(VARCHAR,N.OID + 1))) +
CONVERT(VARCHAR,N.OID + 1)) FROM (
SELECT CASE WHEN MAX(T.TID) IS null then 0 else MAX(T.TID) end as OID FROM (
SELECT SUBSTRING(CustomerCode,@PrefixLength, LEN(CustomerCode)) as TID FROM Customer Where SUBSTRING(CustomerCode,0,@PrefixLength) = @prefix
) AS T 
) AS N
Select @NEWID

End




GO
/****** Object:  StoredProcedure [dbo].[GetCustomerSaleByCuId]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetCustomerSaleByCuId]
@Id int
as
begin

select cu.Name as [Customer Name],p.Name as [Product Name],p.Qty,p.Price,(p.Qty*p.Price) as [Total Amount] from  Customer as cu left join [Transaction] as t on t.CustomerId = cu.Id


left join TransactionDetail as td on td.TransactionId=t.Id 


left join Product as p on p.Id=td.ProductId  where cu.Id=@Id and t.IsDeleted=0 and td.IsDeleted=0
end




GO
/****** Object:  StoredProcedure [dbo].[GetCustomerSaleById]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetCustomerSaleById]
@CustomerId int,
@ProductId int,
@fromdate datetime,
@todate datetime
as
begin

if(@CustomerId=0 and @ProductId=0)

begin
select t.Id as TransactionId,t.DateTime as SaleDate,cu.Name as [Customer Name],p.Name as [Product Name],td.Qty,td.UnitPrice,(td.Qty*td.UnitPrice) as [Total Amount] from  Customer   as cu inner join [Transaction] as t on t.CustomerId = cu.Id 
inner join TransactionDetail as td on td.TransactionId=t.Id 
inner join Product as p on p.Id=td.ProductId where  CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date)  and t.IsDeleted=0 and td.IsDeleted=0 order by cu.Name asc 
end

else if(@CustomerId=0 and @ProductId>0)

begin
select t.Id as TransactionId,t.DateTime as SaleDate, cu.Name as [Customer Name],p.Name as [Product Name],td.Qty,td.UnitPrice,(td.Qty*td.UnitPrice) as [Total Amount] from  Customer as cu inner join [Transaction] as t on t.CustomerId = cu.Id
inner join TransactionDetail as td on td.TransactionId=t.Id 
inner join Product as p on p.Id=td.ProductId  where  p.id=@ProductId and  CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and t.IsDeleted=0 and td.IsDeleted=0 order by cu.Name asc
end


else if(@CustomerId >0 and @ProductId=0)

begin
select t.Id as TransactionId,t.DateTime as SaleDate, cu.Name as [Customer Name],p.Name as [Product Name],td.Qty,td.UnitPrice,(td.UnitPrice*td.Qty) as [Total Amount] from  Customer as cu inner join [Transaction] as t on t.CustomerId = cu.Id
inner join TransactionDetail as td on td.TransactionId=t.Id 
inner join Product as p on p.Id=td.ProductId  where cu.id=@CustomerId and  CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and t.IsDeleted=0 and td.IsDeleted=0 order by cu.Name asc
end

else if(@CustomerId>0 and @ProductId>0)

begin
select t.Id as TransactionId,t.DateTime as SaleDate, cu.Name as [Customer Name],p.Name as [Product Name],td.Qty,td.UnitPrice,(td.Qty*td.UnitPrice) as [Total Amount] from  Customer as cu inner join [Transaction] as t on t.CustomerId = cu.Id
inner join TransactionDetail as td on td.TransactionId=t.Id 
inner join Product as p on p.Id=td.ProductId  where cu.id=@CustomerId and p.Id=@ProductId and  CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and t.IsDeleted=0 and td.IsDeleted=0 order by cu.Name asc
end

end




GO
/****** Object:  StoredProcedure [dbo].[GetDailyDoctorFees]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetDailyDoctorFees]
	@DID int,
	@Date datetime
AS
BEGIN
DECLARE @Consultantfees int,@Injection decimal(18,0);


set @Consultantfees=(SELECT SUM([Transaction].Consultantfees) AS Consultantfees
FROM                     [Transaction] INNER JOIN
                         DoctorPhysio ON [Transaction].DoctorID = DoctorPhysio.Id
						 WHERE ([Transaction].DoctorID=@DID) AND (CAST([Transaction].DateTime AS date) = CAST(@Date AS date)) AND ([Transaction].IsDeleted=0) AND ([Transaction].PaymentTypeId <> 4) AND ([Transaction].IsComplete=1) AND ([Transaction].IsActive=1)
						 )




set @Injection=(SELECT SUM(TransactionDetail.InjectionRate) AS Injection
FROM                     [Transaction] INNER JOIN
                         dbo.TransactionDetail ON dbo.[Transaction].Id = dbo.TransactionDetail.TransactionId INNER JOIN
                         dbo.DoctorPhysio ON dbo.[Transaction].DoctorID = dbo.DoctorPhysio.Id 
						 WHERE [Transaction].DoctorID=@DID AND (CAST([Transaction].DateTime AS date) = CAST(@Date AS date)) AND ([TransactionDetail].IsDeleted=0) AND ([Transaction].IsDeleted=0) AND ([Transaction].PaymentTypeId <> 4)  AND ([Transaction].IsComplete=1) AND ([Transaction].IsActive=1)
)



select @Consultantfees AS Consultantfees,@Injection AS Injection

END




GO
/****** Object:  StoredProcedure [dbo].[GetDoctorFeesByDateRate]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetDoctorFeesByDateRate]
	@DID int,
	@fromDate datetime,
	@toDate datetime,
	@Type nvarchar(10)
AS
BEGIN

if(@Type='ALL')

SELECT					 SUM(TransactionDetail.InjectionRate) AS Injection,SUM(TransactionDetail.PTRate) As Physio,Sum(TransactionDetail.XRayRate) AS XRay,DoctorPhysio.Name,
						[Transaction].DoctorID,[Transaction].Consultantfees
FROM                     [Transaction] INNER JOIN
                         TransactionDetail ON [Transaction].Id = TransactionDetail.TransactionId INNER JOIN
                         DoctorPhysio ON [Transaction].DoctorID = DoctorPhysio.Id 
						 WHERE  CAST([Transaction].DateTime as Date) >=CAST(@fromDate as Date) and CAST([Transaction].DateTime as Date)<=CAST(@toDate as Date) 
						 AND (TransactionDetail.IsDeleted=0) AND ([Transaction].IsDeleted=0) AND ([Transaction].PaymentTypeId <> 4)  AND ([Transaction].IsComplete=1)
						  AND ([Transaction].IsActive=1) AND [Transaction].Consultantfees !=0
						 Group By DoctorPhysio.Name,[Transaction].DoctorID,[Transaction].Consultantfees
Else
						 SELECT	SUM(TransactionDetail.InjectionRate) AS Injection,SUM(TransactionDetail.PTRate) As Physio,Sum(TransactionDetail.XRayRate) AS XRay,DoctorPhysio.Name,
							[Transaction].DoctorID,[Transaction].Consultantfees
FROM                     [Transaction] INNER JOIN
                         TransactionDetail ON [Transaction].Id = TransactionDetail.TransactionId INNER JOIN
                         DoctorPhysio ON [Transaction].DoctorID = DoctorPhysio.Id 
						 WHERE  CAST([Transaction].DateTime as Date) >=CAST(@fromDate as Date) and CAST([Transaction].DateTime as Date)<=CAST(@toDate as Date) 
						 AND ([Transaction].DoctorID=@DID) AND  (TransactionDetail.IsDeleted=0) AND ([Transaction].IsDeleted=0) AND ([Transaction].PaymentTypeId <> 4) 
						  AND ([Transaction].IsComplete=1) AND ([Transaction].IsActive=1) AND [Transaction].Consultantfees !=0
						 Group By DoctorPhysio.Name,[Transaction].DoctorID,[Transaction].Consultantfees

END




GO
/****** Object:  StoredProcedure [dbo].[GetDoctorFeesConsultantFeeByDateRate]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetDoctorFeesConsultantFeeByDateRate]
	@DID int,
	@fromDate datetime,
	@toDate datetime,
	@Type nvarchar(10)
AS
BEGIN

if(@Type='ALL')
SELECT                   SUM([Transaction].Consultantfees) AS Consultantfees,DoctorPhysio.Name
FROM                     [Transaction] INNER JOIN
                         DoctorPhysio ON [Transaction].DoctorID = DoctorPhysio.Id
						 WHERE  CAST([Transaction].DateTime as Date) >=CAST(@fromDate as Date) and CAST([Transaction].DateTime as Date)<=CAST(@toDate as Date) AND ([Transaction].IsDeleted=0) AND ([Transaction].PaymentTypeId <> 4)  AND ([Transaction].IsComplete=1) AND ([Transaction].IsActive=1)
						 Group By DoctorPhysio.Name
Else
SELECT					 SUM([Transaction].Consultantfees) AS Consultantfees,DoctorPhysio.Name
FROM                     [Transaction] INNER JOIN
                         DoctorPhysio ON [Transaction].DoctorID = DoctorPhysio.Id
						 WHERE  CAST([Transaction].DateTime as Date) >=CAST(@fromDate as Date) and CAST([Transaction].DateTime as Date)<=CAST(@toDate as Date) AND ([Transaction].DoctorID=@DID) AND ([Transaction].PaymentTypeId <> 4)  AND ([Transaction].IsDeleted=0)  AND ([Transaction].IsComplete=1) AND ([Transaction].IsActive=1)
						 Group By DoctorPhysio.Name

END




GO
/****** Object:  StoredProcedure [dbo].[GetProductCode]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetProductCode]
@prefix  varchar(20),
@TotalNumberlength int,
@PrefixLength int
as
begin
	DECLARE @NEWID VARCHAR(10);		
	SELECT @NEWID = (@prefix + replicate('0',@TotalNumberlength - len(CONVERT(VARCHAR,N.OID + 1))) +
CONVERT(VARCHAR,N.OID + 1)) FROM (
SELECT CASE WHEN MAX(T.TID) IS null then 0 else MAX(T.TID) end as OID FROM (
SELECT SUBSTRING(ProductCode,@PrefixLength, LEN(ProductCode)) as TID FROM Product Where SUBSTRING(ProductCode,0,@PrefixLength) = @prefix
) AS T 
) AS N
Select @NEWID

End




GO
/****** Object:  StoredProcedure [dbo].[GetProductReport]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[GetProductReport]
as
begin
select p.ProductCode,p.Name,b.Name as[Brand Name],p.Qty,pC.Name as [Segment Name],pSubC.Name as [SubSegment Name],p.IsDiscontinue from Product as p
 left join Brand  as b  on p.BrandId=b.Id
 left join ProductCategory as pC on p.ProductCategoryId=pC.Id
 left join ProductSubCategory as pSubC on p.ProductSubCategoryId=pSubC.Id
end




GO
/****** Object:  StoredProcedure [dbo].[GetProfitandLoss]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetProfitandLoss]

@fromDate datetime,
@toDate datetime


as
	begin

		Declare  @ProfitAndLossTempTable Table (SaleDate datetime, TotalSaleQty int,TotalSaleAmount bigint,TotalPurchaseAmount bigint,DiscountAmount bigint,TaxAmount bigint,
		ProfitAndLoss bigint)
			insert Into @ProfitAndLossTempTable

			select CAST(t.DateTime as date) as SaleDate, SUM(pInt.Qty) as TotalSaleQty,SUM(pInt.Qty * td.UnitPrice) as TotalSaleAmount ,

			SUM ((pInt.Qty) * purd.UnitPrice) as TotalPurchase,SUM((td.UnitPrice/100)*td.DiscountRate*pInt.Qty) as DiscountAmount ,

			SUM((td.UnitPrice/100)*td.TaxRate*pInt.Qty) as TaxAmount,SUM (t.TotalAmount-((pInt.Qty) * purd.UnitPrice)) as ProfitAndLoss  from [Transaction] as t

			inner join TransactionDetail as td on t.Id=td.TransactionId

			inner join PurchaseDetailInTransaction as pInt on pInt.TransactionDetailId=td.Id

			inner join PurchaseDetail as purd on purd.Id=pInt.PurchaseDetailId

		

			where t.IsDeleted=0 and  CAST(t.DateTime as Date) >=CAST(@fromDate as Date) and CAST(t.DateTime as Date)<=CAST(@toDate as Date)

			Group by td.Id, CAST(t.DateTime as date)	

			select CAST(SaleDate as date) as [SaleDate],SUM(TotalSaleQty) as [TotalSaleQty],SUM(TotalSaleAmount -DiscountAmount) as [TotalSaleAmount],SUM(TotalPurchaseAmount) as [TotalPurchaseAmount],SUM(DiscountAmount) as TotalDiscountAmount,SUM(TaxAmount) as TotalTaxAmount,SUM((TotalSaleAmount-DiscountAmount) -TotalPurchaseAmount) as [Total ProfitAndLoss] from @ProfitAndLossTempTable
			group by CAST(SaleDate as date)

		end




GO
/****** Object:  StoredProcedure [dbo].[GetProfitAndLossByBrandId]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetProfitAndLossByBrandId]

@fromDate datetime,
@toDate datetime,
@BrandId int

as
	begin

		Declare  @ProfitAndLossTempTable Table (SaleDate datetime, TotalSaleQty int,TotalSaleAmount bigint,TotalPurchaseAmount bigint,DiscountAmount bigint,TaxAmount bigint,
		ProfitAndLoss bigint)
			insert Into @ProfitAndLossTempTable

			select CAST(t.DateTime as date) as SaleDate, SUM(pInt.Qty) as TotalSaleQty,SUM(pInt.Qty * td.UnitPrice) as TotalSaleAmount ,

			SUM ((pInt.Qty) * purd.UnitPrice) as TotalPurchase,SUM((td.UnitPrice/100)*td.DiscountRate*pInt.Qty) as DiscountAmount ,

			SUM((td.UnitPrice/100)*tx.TaxPercent*pInt.Qty) as TaxAmount,SUM ((pInt.Qty*td.UnitPrice)-((pInt.Qty) * purd.UnitPrice)) as ProfitAndLoss  from [Transaction] as t

			inner join TransactionDetail as td on t.Id=td.TransactionId

			inner join PurchaseDetailInTransaction as pInt on pInt.TransactionDetailId=td.Id

			inner join PurchaseDetail as purd on purd.Id=pInt.PurchaseDetailId

			inner join Product as p on p.id=td.ProductId

			inner join Brand as b on b.Id=p.BrandId

			inner join Tax as tx on p.TaxId=tx.Id

			where t.IsDeleted=0 and p.BrandId=@BrandId and CAST(t.DateTime as Date) >=CAST(@fromDate as Date) and CAST(t.DateTime as Date)<=CAST(@toDate as Date)

			Group by  CAST(t.DateTime as date)	

			select CAST(SaleDate as date) as [SaleDate],SUM(TotalSaleQty) as [TotalSaleQty],SUM(TotalSaleAmount-DiscountAmount) as [TotalSaleAmount],SUM(TotalPurchaseAmount) as [TotalPurchaseAmount],SUM(DiscountAmount) as TotalDiscountAmount,SUM(TaxAmount) as TotalTaxAmount,SUM((TotalSaleAmount-DiscountAmount) -TotalPurchaseAmount) as [Total ProfitAndLoss] from @ProfitAndLossTempTable
			group by CAST(SaleDate as date)

		end




GO
/****** Object:  StoredProcedure [dbo].[GetProfitAndLossByCouterId]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[GetProfitAndLossByCouterId]

@fromDate datetime,
@toDate datetime,
@counterID bigint

as
	begin

		Declare  @ProfitAndLossTempTable Table (SaleDate datetime, TotalSaleQty int,TotalSaleAmount bigint,TotalPurchaseAmount bigint,DiscountAmount bigint,TaxAmount bigint,
		ProfitAndLoss bigint)
			insert Into @ProfitAndLossTempTable

			select CAST(t.DateTime as date) as SaleDate, SUM(pInt.Qty) as TotalSaleQty,SUM(pInt.Qty * td.UnitPrice) as TotalSaleAmount ,

			SUM ((pInt.Qty) * purd.UnitPrice) as TotalPurchase,SUM((td.UnitPrice/100)*td.DiscountRate*pInt.Qty) as DiscountAmount ,

			SUM((td.UnitPrice/100)*td.TaxRate*pInt.Qty) as TaxAmount,SUM ((pInt.Qty*td.UnitPrice)-((pInt.Qty) * purd.UnitPrice)) as ProfitAndLoss  from [Transaction] as t

			inner join TransactionDetail as td on t.Id=td.TransactionId

			inner join PurchaseDetailInTransaction as pInt on pInt.TransactionDetailId=td.Id

			inner join PurchaseDetail as purd on purd.Id=pInt.PurchaseDetailId	


			where t.IsDeleted=0 and t.CounterId=@counterID and CAST(t.DateTime as Date) >=CAST(@fromDate as Date) and CAST(t.DateTime as Date)<=CAST(@toDate as Date)

			Group by td.Id, CAST(t.DateTime as date)	

			select CAST(SaleDate as date) as [SaleDate],SUM(TotalSaleQty) as [TotalSaleQty],SUM(TotalSaleAmount-DiscountAmount) as [TotalSaleAmount],SUM(TotalPurchaseAmount) as [TotalPurchaseAmount],SUM(DiscountAmount) as TotalDiscountAmount,SUM(TaxAmount) as TotalTaxAmount,SUM((TotalSaleAmount-DiscountAmount) -TotalPurchaseAmount) as [Total ProfitAndLoss] from @ProfitAndLossTempTable
			group by CAST(SaleDate as date)

		end




GO
/****** Object:  StoredProcedure [dbo].[GetProfitAndLossByProductId]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetProfitAndLossByProductId]

@fromDate datetime,
@toDate datetime,
@productID bigint

as
	begin

		Declare  @ProfitAndLossTempTable Table (SaleDate datetime, TotalSaleQty int,TotalSaleAmount bigint,TotalPurchaseAmount bigint,DiscountAmount bigint,TaxAmount bigint,
		ProfitAndLoss bigint)
			insert Into @ProfitAndLossTempTable

			select CAST(t.DateTime as date) as SaleDate, SUM(pInt.Qty) as TotalSaleQty,SUM(pInt.Qty * td.UnitPrice) as TotalSaleAmount ,

			SUM ((pInt.Qty) * purd.UnitPrice) as TotalPurchase,SUM((td.UnitPrice/100)*td.DiscountRate*pInt.Qty) as DiscountAmount ,

			SUM((td.UnitPrice/100)*td.TaxRate*pInt.Qty) as TaxAmount,SUM ((pInt.Qty*td.UnitPrice)-((pInt.Qty) * purd.UnitPrice)) as ProfitAndLoss  from [Transaction] as t

			inner join TransactionDetail as td on t.Id=td.TransactionId

			inner join PurchaseDetailInTransaction as pInt on pInt.TransactionDetailId=td.Id

			inner join PurchaseDetail as purd on purd.Id=pInt.PurchaseDetailId

			inner join Product as p on p.Id=td.ProductId 

			where t.IsDeleted=0 and p.Id=@productID and CAST(t.DateTime as Date) >=CAST(@fromDate as Date) and CAST(t.DateTime as Date)<=CAST(@toDate as Date) 

			Group by td.Id, CAST(t.DateTime as date)	

			select CAST(SaleDate as date) as [SaleDate],SUM(TotalSaleQty) as [TotalSaleQty],SUM(TotalSaleAmount-DiscountAmount) as [TotalSaleAmount],SUM(TotalPurchaseAmount) as [TotalPurchaseAmount],SUM(DiscountAmount) as TotalDiscountAmount,SUM(TaxAmount) as TotalTaxAmount,SUM((TotalSaleAmount-DiscountAmount) -TotalPurchaseAmount) as [Total ProfitAndLoss] from @ProfitAndLossTempTable
			group by CAST(SaleDate as date)

		end




GO
/****** Object:  StoredProcedure [dbo].[GetSaleSpecialPromotionByCustomerId]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSaleSpecialPromotionByCustomerId] 
	@fromDate datetime,
	@toDate datetime,
	@bId int,
	@IsSaleTruePrice bit
AS
BEGIN
	Declare  @SaleSP Table (Id int, Total bigint, Qty int)
	Declare  @RefundSP Table (Id int, Total bigint,Qty int)
	if @IsSaleTruePrice = 1
	
	
		Begin
			insert @SaleSP
			select  Br.Id, Sum(Pr.Price - (Pr.Price* (P.DiscountRate/100))) as Total, Sum(TD.Qty) as Qty
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.productId = P.Id
			inner join Brand as B on B.Id = P.BrandId inner join WrapperItem as W on W.ParentProductId = P.Id inner join Product as Pr on Pr.Id = W.ChildProductId inner join Brand as Br on Br.Id = Pr.BrandId inner join Customer as C on C.Id = T.CustomerId
			where B.Name = 'Special Promotion' and (T.Type = 'Sale' or T.Type = 'Credit') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and (T.IsDeleted IS NULL OR T.IsDeleted = 0)  and Br.Id = @bId and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0)
			Group By Br.Id

			insert @RefundSP
			select  Br.Id, Sum(Pr.Price - (Pr.Price* (P.DiscountRate/100))) as Total, Sum(TD.Qty) as Qty
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.productId = P.Id
			inner join Brand as B on B.Id = P.BrandId inner join WrapperItem as W on W.ParentProductId = P.Id inner join Product as Pr on Pr.Id = W.ChildProductId inner join Brand as Br on Br.Id = Pr.BrandId inner join Customer as C on C.Id = T.CustomerId
			where B.Name = 'Special Promotion' and (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and (T.IsDeleted IS NULL OR T.IsDeleted = 0) and Br.Id = @bId and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0)
			Group By Br.Id

			select Br.Id as Id,Br.Name as Name, A.Total as TotalSale, A.Qty as SaleQty,B.Total as TotalRefund, B.Qty as RefundQty
			From Brand as Br  Full outer join @SaleSp as A on A.Id = Br.Id
			Full Outer join @RefundSP B on B.Id = Br.Id
			where Br.Id = @bId

		End
		
	

	Else
	
		
		Begin
			insert @SaleSP
			select  Br.Id, Sum(Pr.Price) as Total, Sum(TD.Qty) as Qty
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.productId = P.Id
			inner join Brand as B on B.Id = P.BrandId inner join WrapperItem as W on W.ParentProductId = P.Id inner join Product as Pr on Pr.Id = W.ChildProductId inner join Brand as Br on Br.Id = Pr.BrandId inner join Customer as C on C.Id = T.CustomerId
			where B.Name = 'Special Promotion' and (T.Type = 'Sale' or T.Type = 'Credit') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and (T.IsDeleted IS NULL OR T.IsDeleted = 0) and Br.Id = @bId and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0)
			Group By Br.Id

			insert @RefundSP
			select  Br.Id, Sum(Pr.Price) as Total, Sum(TD.Qty) as Qty
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.productId = P.Id
			inner join Brand as B on B.Id = P.BrandId inner join WrapperItem as W on W.ParentProductId = P.Id inner join Product as Pr on Pr.Id = W.ChildProductId inner join Brand as Br on Br.Id = Pr.BrandId inner join Customer as C on C.Id = T.CustomerId
			where B.Name = 'Special Promotion' and (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and (T.IsDeleted IS NULL OR T.IsDeleted = 0)  and Br.Id = @bId and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0)
			Group By Br.Id

			select Br.Id as Id,Br.Name as Name, A.Total as TotalSale, A.Qty as SaleQty,B.Total as TotalRefund, B.Qty as RefundQty
			From Brand as Br  Full outer join @SaleSp as A on A.Id = Br.Id
			Full Outer join @RefundSP B on B.Id = Br.Id
			where Br.Id = @bId

		End
	
		

END




GO
/****** Object:  StoredProcedure [dbo].[GetSaleSpecialPromotionSegmentByCustomerId]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSaleSpecialPromotionSegmentByCustomerId] 
	@fromDate datetime,
	@toDate datetime,
	@bId int,
	@IsSaleTruePrice bit
AS
BEGIN
	Declare  @SaleSP Table (Id int, Total bigint, Qty int)
	Declare  @RefundSP Table (Id int, Total bigint,Qty int)
	if @IsSaleTruePrice = 1
		
	Begin
			insert @SaleSP
			select  PC.Id, Sum(Pr.Price - (Pr.Price* (P.DiscountRate/100))) as Total, Sum(TD.Qty) as Qty
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.productId = P.Id
			inner join Brand as B on B.Id = P.BrandId inner join WrapperItem as W on W.ParentProductId = P.Id inner join Product as Pr on Pr.Id = W.ChildProductId inner join Brand as Br on Br.Id = Pr.BrandId inner join Customer as C on C.Id = T.CustomerId inner join ProductCategory as PC on Pr.ProductCategoryId = PC.Id
			where B.Name = 'Special Promotion' and (T.Type = 'Sale' or T.Type = 'Credit') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and(T.IsDeleted IS NULL OR T.IsDeleted = 0)   and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0)
			Group By PC.Id

			insert @RefundSP
			select  PC.Id, Sum(Pr.Price - (Pr.Price* (P.DiscountRate/100))) as Total, Sum(TD.Qty) as Qty
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.productId = P.Id
			inner join Brand as B on B.Id = P.BrandId inner join WrapperItem as W on W.ParentProductId = P.Id inner join Product as Pr on Pr.Id = W.ChildProductId inner join Brand as Br on Br.Id = Pr.BrandId inner join Customer as C on C.Id = T.CustomerId inner join ProductCategory as PC on Pr.ProductCategoryId = PC.Id
			where B.Name = 'Special Promotion' and (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and (T.IsDeleted IS NULL OR T.IsDeleted = 0) and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0)
			Group By PC.Id

			select Br.Id as Id,Br.Name as Name, A.Total as TotalSale, A.Qty as SaleQty,B.Total as TotalRefund, B.Qty as RefundQty
			From ProductCategory as Br  Full outer join @SaleSp as A on A.Id = Br.Id
			Full Outer join @RefundSP B on B.Id = Br.Id
			where Br.Id = @bId

		End
		
	
	Else
	Begin
		
			insert @SaleSP
			select  PC.Id, Sum(Pr.Price) as Total, Sum(TD.Qty) as Qty
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.productId = P.Id
			inner join Brand as B on B.Id = P.BrandId inner join WrapperItem as W on W.ParentProductId = P.Id inner join Product as Pr on Pr.Id = W.ChildProductId inner join Brand as Br on Br.Id = Pr.BrandId inner join Customer as C on C.Id = T.CustomerId inner join ProductCategory as PC on Pr.ProductCategoryId = PC.Id
			where B.Name = 'Special Promotion' and (T.Type = 'Sale' or T.Type = 'Credit') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and (T.IsDeleted IS NULL OR T.IsDeleted = 0) and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0)
			Group By PC.Id

			insert @RefundSP
			select  PC.Id, Sum(Pr.Price) as Total, Sum(TD.Qty) as Qty
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.productId = P.Id
			inner join Brand as B on B.Id = P.BrandId inner join WrapperItem as W on W.ParentProductId = P.Id inner join Product as Pr on Pr.Id = W.ChildProductId inner join Brand as Br on Br.Id = Pr.BrandId inner join Customer as C on C.Id = T.CustomerId inner join ProductCategory as PC on Pr.ProductCategoryId = PC.Id
			where B.Name = 'Special Promotion' and (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and (T.IsDeleted IS NULL OR T.IsDeleted = 0) and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0)
			Group By PC.Id

			select Br.Id as Id,Br.Name as Name, A.Total as TotalSale, A.Qty as SaleQty,B.Total as TotalRefund, B.Qty as RefundQty
			From ProductCategory as Br  Full outer join @SaleSp as A on A.Id = Br.Id
			Full Outer join @RefundSP B on B.Id = Br.Id
			where Br.Id = @bId

		End
		
END


select *
from ProductCategory




GO
/****** Object:  StoredProcedure [dbo].[GetTotalAmountForCash]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[GetTotalAmountForCash]
@Datetime datetime,
@PaymentTypeID int,
@CounterId int
as 

begin

if(@CounterId>0)

	begin

	select  COUNT(distinct(t.Id))as TotalTransaction ,SUM(td.Qty) as TotalQty ,
	SUM(td.TotalAmount) as TotalAmount



	from [Transaction] as t inner join TransactionDetail as td on t.id=td.TransactionId

	where t.IsDeleted=0 and CAST(t.DateTime as Date)=CAST(@Datetime as Date) and t.PaymentTypeId=@PaymentTypeID and CounterId=@CounterId and ParentId is Null and t.Type='Sale' or t.Type='Credit'




	

	end

else
begin 


					if @PaymentTypeID=1

					begin

					select  COUNT(distinct(t.Id)) as TotalTransaction ,SUM(td.Qty) as TotalQty ,
					SUM(td.TotalAmount)  as TotalAmount



					from [Transaction] as t inner join TransactionDetail as td on t.id=td.TransactionId

					where t.IsDeleted=0 and CAST(t.DateTime as Date)=CAST(@Datetime as Date) and t.PaymentTypeId=@PaymentTypeID and ParentId is Null and  t.Type='Sale'


					end

					if @PaymentTypeID=2

					begin

					select  COUNT(distinct(t.Id)) as TotalTransaction ,SUM(td.Qty) as TotalQty ,
					SUM(td.TotalAmount)  as TotalAmount



					from [Transaction] as t inner join TransactionDetail as td on t.id=td.TransactionId

					where t.IsDeleted=0 and CAST(t.DateTime as Date)=CAST(@Datetime as Date) and t.PaymentTypeId=@PaymentTypeID and ParentId is Null and  t.Type='Credit'


					end



					if @PaymentTypeID=3

					begin

					select  COUNT(distinct(t.Id)) as TotalTransaction ,SUM(td.Qty) as TotalQty ,
					SUM(td.TotalAmount)  as TotalAmount



					from [Transaction] as t inner join TransactionDetail as td on t.id=td.TransactionId

					where t.IsDeleted=0 and CAST(t.DateTime as Date)=CAST(@Datetime as Date) and t.PaymentTypeId=@PaymentTypeID and ParentId is Null and  t.Type='Sale'


					end


					if @PaymentTypeID=4

					begin

					select  COUNT(distinct(t.Id)) as TotalTransaction ,SUM(td.Qty) as TotalQty ,
					SUM(td.TotalAmount)  as TotalAmount



					from [Transaction] as t inner join TransactionDetail as td on t.id=td.TransactionId

					where t.IsDeleted=0 and CAST(t.DateTime as Date)=CAST(@Datetime as Date) and t.PaymentTypeId=@PaymentTypeID and ParentId is Null and  t.Type='Sale'


					end

					if @PaymentTypeID=5

					begin

					select  COUNT(distinct(t.Id)) as TotalTransaction ,SUM(td.Qty) as TotalQty ,
					SUM(td.TotalAmount)  as TotalAmount



					from [Transaction] as t inner join TransactionDetail as td on t.id=td.TransactionId

					where t.IsDeleted=0 and CAST(t.DateTime as Date)=CAST(@Datetime as Date) and t.PaymentTypeId=@PaymentTypeID and ParentId is Null and  t.Type='Sale'


					end

end


end




GO
/****** Object:  StoredProcedure [dbo].[GetTotalAmountForPrepaid]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[GetTotalAmountForPrepaid]
@Datetime datetime,
@PaymentTypeID int,
@CounterId int
as 

if(@CounterId>0)
begin
select COUNT(distinct(t.Id)) as TotalTransaction ,SUM(td.Qty) as TotalQty ,

SUM(td.TotalAmount)  as TotalAmount

from [Transaction] as t inner join TransactionDetail as td on t.id=td.TransactionId

where t.IsDeleted=0 and CAST(t.DateTime as Date)=CAST(@Datetime as Date) and t.PaymentTypeId=@PaymentTypeID and CounterId=@CounterId and ParentId is Null and t.Type='Prepaid'
end


else

begin

select  COUNT(distinct(t.Id)) as TotalTransaction ,SUM(td.Qty) as TotalQty ,

SUM(td.TotalAmount)  as TotalAmount from [Transaction] as t inner join TransactionDetail as td on t.id=td.TransactionId

where t.IsDeleted=0 and CAST(t.DateTime as Date)=CAST(@Datetime as Date) and t.PaymentTypeId=@PaymentTypeID and  ParentId is Null and t.Type='Prepaid'


end




GO
/****** Object:  StoredProcedure [dbo].[GetTotalAmountForRefund]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetTotalAmountForRefund]
@Datetime datetime,
@CounterId int
as 

if(@CounterId >0)
begin

select CAST(t .DateTime as Date) as SaleDate , COUNT(distinct(t.Id)) as TotalTransaction ,SUM(td.Qty) as TotalQty ,
SUM(td.TotalAmount)  as TotalAmount



from [Transaction] as t inner join TransactionDetail as td on t.id=td.TransactionId

where t.IsDeleted=0 and CAST(t.DateTime as Date)=CAST(@Datetime as Date) and  t.ParentId is not Null and CounterId=@CounterId

group by CAST(t.DateTime as Date)




end
else
begin

select CAST(t .DateTime as Date) as SaleDate , COUNT(distinct(t.Id)) as TotalTransaction ,SUM(td.Qty) as TotalQty ,
SUM(td.TotalAmount)  as TotalAmount



from [Transaction] as t inner join TransactionDetail as td on t.id=td.TransactionId

where t.IsDeleted=0 and CAST(t.DateTime as Date)=CAST(@Datetime as Date) and  t.ParentId is not Null 

group by CAST(t.DateTime as Date)




end




GO
/****** Object:  StoredProcedure [dbo].[GetTotalTransactionQtyAndQty]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetTotalTransactionQtyAndQty]
@Datetime datetime,
@CounterId int
as 

if(@CounterId>0)

begin

select COUNT(distinct(t.Id)) as TotalTransaction ,SUM(td.Qty) as TotalQty ,SUM(td.TotalAmount) as TotalAmount

from [Transaction] as t inner join TransactionDetail as td on t.id=td.TransactionId

where t.IsDeleted=0 and  CAST(t.DateTime as Date)= CAST(@Datetime as Date) and t.Type='Sale' or t.Type='Credit' and CounterId=@CounterId and t.ParentId is null 

end

else
begin

select COUNT(distinct(t.Id)) as TotalTransaction ,SUM(td.Qty) as TotalQty ,SUM(td.TotalAmount) as TotalAmount

from [Transaction] as t inner join TransactionDetail as td on t.id=td.TransactionId

where t.IsDeleted=0 and CAST(t.DateTime as Date)=CAST(@Datetime as Date) and t.Type='Sale' or t.Type='Credit' and t.ParentId is null 

end




GO
/****** Object:  StoredProcedure [dbo].[GetTransactionByGroup]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTransactionByGroup]
	
	@fromDate datetime,
	@toDate datetime
	
AS
BEGIN

SELECT					 *
FROM                     [Transaction]
						 WHERE  CAST([Transaction].DateTime as Date) >=CAST(@fromDate as Date) 
						 and CAST([Transaction].DateTime as Date)<=CAST(@toDate as Date) AND ([Transaction].IsDeleted=0) 
						 AND ([Transaction].IsComplete=1) AND ([Transaction].IsActive=1) 
						  AND ([Transaction].PaymentTypeId <> 4)
			
END




GO
/****** Object:  StoredProcedure [dbo].[InsertDraft]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertDraft]
			@DateTime datetime
           ,@UserId int
           ,@CounterId int
           ,@Type varchar(20)
           ,@IsPaid bit
           ,@IsActive bit
           ,@PaymentTypeId int
           ,@TaxAmount int
           ,@DiscountAmount int
           ,@TotalAmount bigint
           ,@RecieveAmount bigint           
           ,@GiftCardId int
           ,@CustomerId int
           ,@DoctorId int
		   ,@ServiceCharges int
		   ,@GroupID int
		   ,@Consultantfees int


AS
BEGIN
	DECLARE @NEWID VARCHAR(10);		
	SELECT @NEWID = ('DF' + replicate('0', 6 - len(CONVERT(VARCHAR,N.OID + 1))) +
CONVERT(VARCHAR,N.OID + 1)) FROM (
SELECT CASE WHEN MAX(T.TID) IS null then 0 else MAX(T.TID) end as OID FROM (
SELECT SUBSTRING(Id, 4, LEN(Id)) as TID FROM [Transaction] Where SUBSTRING(Id,0,3) = 'DF'
) AS T 
) AS N

INSERT INTO [dbo].[Transaction]
           ([Id]
           ,[DateTime]
           ,[UserId]
           ,[CounterId]
           ,[Type]
           ,[IsPaid]
		   ,[IsComplete]
           ,[IsActive]
           ,[PaymentTypeId]
           ,[TaxAmount]
           ,[DiscountAmount]
           ,[TotalAmount]
           ,[RecieveAmount]
         
           ,[GiftCardId]
           ,[CustomerId]
		   ,[DoctorID]
            ,[ServiceChages]
		   ,[GroupID],
		   [Consultantfees])
		   
     VALUES
           (@NEWID
           ,@DateTime
           ,@UserId
           ,@CounterId
           ,@Type
           ,@IsPaid
		   ,0
           ,@IsActive
           ,@PaymentTypeId
           ,@TaxAmount
           ,@DiscountAmount
           ,@TotalAmount
           ,@RecieveAmount
           
           ,@GiftCardId
           ,@CustomerId
           ,@DoctorId
		   ,@ServiceCharges
		   ,@GroupID
		   ,@Consultantfees)

Select @NEWID

END




GO
/****** Object:  StoredProcedure [dbo].[InsertRefundTransaction]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertRefundTransaction]
			@DateTime datetime
           ,@UserId int
           ,@CounterId int
		   ,@Type varchar(20)
           ,@IsPaid bit
           ,@IsActive bit
           ,@PaymentTypeId int
           ,@TaxAmount int
           ,@DiscountAmount int
           ,@TotalAmount bigint
           ,@RecieveAmount bigint
           
		   ,@ParentId varchar(20)
           ,@GiftCardId int
           ,@CustomerId int


AS
BEGIN
	DECLARE @NEWID VARCHAR(10);		
	SELECT @NEWID = ('RF' + replicate('0', 6 - len(CONVERT(VARCHAR,N.OID + 1))) +
CONVERT(VARCHAR,N.OID + 1)) FROM (
SELECT CASE WHEN MAX(T.TID) IS null then 0 else MAX(T.TID) end as OID FROM (
SELECT SUBSTRING(Id, 4, LEN(Id)) as TID FROM [Transaction] Where SUBSTRING(Id,0,3) = 'RF'
) AS T  
) AS N

INSERT INTO [dbo].[Transaction]
           ([Id]
           ,[DateTime]
           ,[UserId]
           ,[CounterId]
           ,[Type]
           ,[IsPaid]
		   ,[IsComplete]
           ,[IsActive]
           ,[PaymentTypeId]
           ,[TaxAmount]
           ,[DiscountAmount]
           ,[TotalAmount]
           ,[RecieveAmount]
           
		   ,[ParentId]
           ,[GiftCardId]
           ,[CustomerId])
     VALUES
           (@NEWID
           ,@DateTime
           ,@UserId
           ,@CounterId
           ,@Type
           ,@IsPaid
		   ,1
           ,@IsActive
           ,@PaymentTypeId
           ,@TaxAmount
           ,@DiscountAmount
           ,@TotalAmount
           ,@RecieveAmount
           
		   ,@ParentId
           ,@GiftCardId
           ,@CustomerId)

Select @NEWID

END




GO
/****** Object:  StoredProcedure [dbo].[insertSPDetail]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[insertSPDetail]
	@TransactionDetailID bigint,
	@ParentProductID bigint,
	@ChildProductID bigint,
	@Price bigint,
	@DiscountRate decimal(15,2),
	@ShopCode varchar(20)
	
	
AS
BEGIN
	DECLARE @NEWID VARCHAR(10);		
	SELECT @NEWID = ('SP' + @ShopCode + replicate('0', 6 - len(CONVERT(VARCHAR,N.OID + 1))) +
	CONVERT(VARCHAR,N.OID + 1)) FROM (
	SELECT CASE WHEN MAX(T.TID) IS null then 0 else MAX(T.TID) end as OID FROM (
	SELECT SUBSTRING(SPDetailID, 5, LEN(SPDetailID)) as TID FROM SPDetail Where SUBSTRING(SPDetailID,0,3) = 'SP' And SUBSTRING(SPDetailID,3,2) = @ShopCode
	) AS T 
	) AS N

   INSERT INTO [dbo].[SPDetail]
           ([TransactionDetailID]
		   ,[ParentProductID]
		   ,[ChildProductID]
		   ,[Price]
		   ,[DiscountRate]
		   ,[SPDetailID])
     VALUES
           (@TransactionDetailID
		   ,@ParentProductID
		   ,@ChildProductID
		   ,@Price
		   ,@DiscountRate
		   ,@NEWID)

END




GO
/****** Object:  StoredProcedure [dbo].[InsertTransaction]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertTransaction]
			@DateTime datetime
           ,@UserId int
           ,@CounterId int
           ,@Type varchar(20)
           ,@IsPaid bit
           ,@IsActive bit
           ,@PaymentTypeId int
           ,@TaxAmount int
           ,@DiscountAmount int
           ,@TotalAmount bigint
           ,@RecieveAmount bigint
           ,@GiftCardId int
           ,@CustomerId int
           ,@DId int
           ,@ServiceCharges int
		   ,@GroupID int
		   ,@Consultantfees int
		  
           


AS
BEGIN
	DECLARE @NEWID VARCHAR(10);		
	SELECT @NEWID = ('TS' + replicate('0', 6 - len(CONVERT(VARCHAR,N.OID + 1))) +
CONVERT(VARCHAR,N.OID + 1)) FROM (
SELECT CASE WHEN MAX(T.TID) IS null then 0 else MAX(T.TID) end as OID FROM (
SELECT SUBSTRING(Id, 4, LEN(Id)) as TID FROM [Transaction] Where SUBSTRING(Id,0,3) = 'TS'
) AS T 
) AS N

INSERT INTO [dbo].[Transaction]
           ([Id]
           ,[DateTime]
           ,[UserId]
           ,[CounterId]
           ,[Type]
           ,[IsPaid]
		   ,[IsComplete]
           ,[IsActive]
           ,[PaymentTypeId]
           ,[TaxAmount]
           ,[DiscountAmount]
           ,[TotalAmount]
           ,[RecieveAmount]
           ,[GiftCardId]
           ,[CustomerId]
           ,[DoctorID]
           ,[ServiceChages]
		   ,[GroupID]
		   ,[Consultantfees])
     VALUES
           (@NEWID
           ,@DateTime
           ,@UserId
           ,@CounterId
           ,@Type
           ,@IsPaid
		   ,1
           ,@IsActive
           ,@PaymentTypeId
           ,@TaxAmount
           ,@DiscountAmount
           ,@TotalAmount
           ,@RecieveAmount
           ,@GiftCardId
           ,@CustomerId
           ,@DId
           ,@ServiceCharges
		   ,@GroupID
		   ,@Consultantfees)

Select @NEWID

END




GO
/****** Object:  StoredProcedure [dbo].[InsertTransactionDetail]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertTransactionDetail]
	@TransactionId varchar(20),
	@ProductId int,
	@Qty int,
	@UnitPrice int,
	@DiscountRate decimal,
	@TaxRate decimal,
	@TotalAmount int,
	@IsDeleted bit,
	@InjectionRate decimal,
	@PTRate decimal,
	@XRayRate decimal
AS
BEGIN
	INSERT INTo[TransactionDetail]
(
	[TransactionDetail].[TransactionId],
	[TransactionDetail].[ProductId],
	[TransactionDetail].[Qty],
	[TransactionDetail].[UnitPrice],
	[TransactionDetail].[DiscountRate],
	[TransactionDetail].[TaxRate],
	[TransactionDetail].[TotalAmount],
	[TransactionDetail].[IsDeleted],
	[TransactionDetail].[InjectionRate],
	[TransactionDetail].[PTRate],
	[TransactionDetail].[XRayRate]
)	
VALUES
(
	@TransactionId,
	@ProductId,
	@Qty,
	@UnitPrice,
	@DiscountRate,
	@TaxRate,
	@TotalAmount,
	@IsDeleted,
	@InjectionRate,
	@PTRate,
	@XRayRate
	
	

);
SELECT SCOPE_IDENTITY();
END




GO
/****** Object:  StoredProcedure [dbo].[Paid]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Paid]
	@paid bit,
	@Id varchar(50)
AS
	UPDATE [Transaction] Set IsPaid = @paid where Id = @Id
RETURN 0




GO
/****** Object:  StoredProcedure [dbo].[ProductReportByBId]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[ProductReportByBId]
@BrandId int
AS
begin	

select pd.ProductCode,pd.Name,PC.Name as [Segment Name],PdSC.Name as [SubSegment Name],bd.Name as [Brand Name],pd.Qty,pd.IsDiscontinue from Product as pd 
left join  ProductCategory as PC on pd.ProductCategoryId=PC.Id 
left join  ProductSubCategory as PdSC on pd.ProductSubCategoryId=PdSC.Id
left join Brand as bd on pd.BrandId=bd.Id Where pd.BrandId=@BrandId

end




GO
/****** Object:  StoredProcedure [dbo].[ProductReportByCId]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[ProductReportByCId]
@MainCategoryId int	
AS
begin	
select pd.ProductCode,pd.Name,PC.Name as [Segment Name],PdSC.Name as [SubSegment Name],bd.Name as [Brand Name],pd.Qty,pd.IsDiscontinue from Product as pd 
left join  ProductCategory as PC on pd.ProductCategoryId=PC.Id 
left join  ProductSubCategory as PdSC on pd.ProductSubCategoryId=PdSC.Id
left join Brand as bd on pd.BrandId=bd.Id Where pd.ProductCategoryId=@MainCategoryId
end




GO
/****** Object:  StoredProcedure [dbo].[ProductReportByCIdAndBId]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[ProductReportByCIdAndBId]
@BrandId int,
@MainCategoryId int
AS
begin

select pd.ProductCode,pd.Name,PC.Name as [Segment Name],PdSC.Name as [SubSegment Name],bd.Name as [Brand Name],pd.Qty,pd.IsDiscontinue from Product as pd 
left join  ProductCategory as PC on pd.ProductCategoryId=PC.Id 
left join  ProductSubCategory as PdSC on pd.ProductSubCategoryId=PdSC.Id
left join Brand as bd on pd.BrandId=bd.Id Where pd.ProductCategoryId=@MainCategoryId and pd.BrandId=@BrandId

end




GO
/****** Object:  StoredProcedure [dbo].[ProductReportBySCIdAndCId]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[ProductReportBySCIdAndCId]
@MainCategoryId int,
@SubCategoryId int
AS
begin	
BEGIN

if(@SubCategoryId=1)

select pd.ProductCode,pd.Name,PC.Name as [Segment Name],PdSC.Name as [SubSegment Name],bd.Name as [Brand Name],pd.Qty ,pd.IsDiscontinue from Product as pd 
inner join  ProductCategory as PC on pd.ProductCategoryId=PC.Id 
inner join  ProductSubCategory as PdSC on pd.ProductSubCategoryId=PdSC.Id
inner join Brand as bd on pd.BrandId=bd.Id Where pd.ProductCategoryId=@MainCategoryId and pd.ProductSubCategoryId is Null

else
select pd.ProductCode,pd.Name,PC.Name as [Segment Name],PdSC.Name as [SubSegment Name],bd.Name as [Brand Name],pd.Qty,pd.IsDiscontinue from Product as pd 
inner join  ProductCategory as PC on pd.ProductCategoryId=PC.Id 
inner join  ProductSubCategory as PdSC on pd.ProductSubCategoryId=PdSC.Id
inner join Brand as bd on pd.BrandId=bd.Id Where pd.ProductCategoryId=@MainCategoryId and pd.ProductSubCategoryId=@SubCategoryId
End
end




GO
/****** Object:  StoredProcedure [dbo].[ProductReportBySCIdAndCIdAndBId]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[ProductReportBySCIdAndCIdAndBId]
@MainCategoryId int,
@SubCategoryId int,
@BrandId int
AS
begin	
BEGIN

if(@SubCategoryId=0)

select pd.ProductCode,pd.Name,PC.Name as [Segment Name],PdSC.Name as [SubSegment Name],bd.Name as [Brand Name],pd.Qty ,pd.IsDiscontinue from Product as pd 
left join  ProductCategory as PC on pd.ProductCategoryId=PC.Id 
left join  ProductSubCategory as PdSC on pd.ProductSubCategoryId=PdSC.Id
left join Brand as bd on pd.BrandId=bd.Id Where pd.ProductCategoryId=@MainCategoryId and pd.ProductSubCategoryId is Null and pd.BrandId=@BrandId

else
select pd.ProductCode,pd.Name,PC.Name as [Segment Name],PdSC.Name as [SubSegment Name],bd.Name as [Brand Name],pd.Qty,pd.IsDiscontinue from Product as pd 
left join  ProductCategory as PC on pd.ProductCategoryId=PC.Id 
left join  ProductSubCategory as PdSC on pd.ProductSubCategoryId=PdSC.Id
left join Brand as bd on pd.BrandId=bd.Id Where pd.ProductCategoryId=@MainCategoryId and pd.ProductSubCategoryId=@SubCategoryId and pd.BrandId=@BrandId
END
End




GO
/****** Object:  StoredProcedure [dbo].[PurchaseDiscountReport]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[PurchaseDiscountReport]
@fromDate datetime,
@toDate datetime,
@supplierId int
as
begin

if @supplierId=0
	begin

		select Date as [Purchase Date] , VoucherNo,sp.Name as SupplierName,TotalAmount,DiscountAmount   from MainPurchase as mp 

		inner join Supplier as sp on sp.Id =mp.SupplierId  

		where mp.DiscountAmount >0 and mp.IsDeleted=0 and CAST(@fromDate as Date) <=CAST(mp.Date as Date) and CAST(@toDate as date) >=CAST(mp.Date as Date) and mp.IsDeleted=0
	end


else
	begin	

		select Date as [Purchase Date] , VoucherNo,sp.Name as SupplierName,TotalAmount,DiscountAmount   from MainPurchase as mp 

		inner join Supplier as sp on sp.Id =mp.SupplierId  

		where mp.DiscountAmount >0 and mp.IsDeleted=0 and CAST(@fromDate as Date) <=CAST(mp.Date as Date) and CAST(@toDate as date) >=CAST(mp.Date as Date) and mp.SupplierId=@supplierId and mp.IsDeleted=0
	end
end




GO
/****** Object:  StoredProcedure [dbo].[PurchaseReport]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[PurchaseReport]

@fromDate datetime,
@toDate datetime,
@SupplierId int,
@BrandId int,
@ProductId int,
@SearchType varchar(20)

as

if(@SearchType='SupplierName')

	begin 
		select mp.Date,p.Name as ProductName,sp.Name as SupplierName,pd.UnitPrice,pd.Qty,mp.TotalAmount,mp.VoucherNo from MainPurchase as mp 
		inner join PurchaseDetail as pd  on mp.Id=pd.MainPurchaseId
		inner join Product as p on p.Id=pd.ProductId
		inner join Brand as b on b.Id=p.BrandId
		inner join Supplier as  sp on sp.Id=mp.SupplierId 

		where CAST(mp.Date as date) >= CAST(@fromDate as date) and CAST(mp.Date as date) <= CAST(@toDate as date) and mp.SupplierId=@SupplierId and mp.IsDeleted=0
		and pd.IsDeleted=0
	end

else if(@SearchType='BrandName')

	begin 
		select mp.Date,p.Name as ProductName,sp.Name as SupplierName,pd.UnitPrice,pd.Qty,mp.TotalAmount,mp.VoucherNo from MainPurchase as mp 
		inner join PurchaseDetail as pd  on mp.Id=pd.MainPurchaseId
		inner join Product as p on p.Id=pd.ProductId
		inner join Brand as b on b.Id=p.BrandId
		inner join Supplier as  sp on sp.Id=mp.SupplierId

		where CAST(mp.Date as date) >= CAST(@fromDate as date) and CAST(mp.Date as date) <= CAST(@toDate as date) and b.Id=@BrandId and mp.IsDeleted=0
		and pd.IsDeleted=0

	end



else if(@SearchType='ProductName')

	begin 
		select mp.Date,p.Name as ProductName,sp.Name as SupplierName,pd.UnitPrice,pd.Qty,mp.TotalAmount,mp.VoucherNo from MainPurchase as mp 
		inner join PurchaseDetail as pd  on mp.Id=pd.MainPurchaseId
		inner join Product as p on p.Id=pd.ProductId
		inner join Brand as b on b.Id=p.BrandId
		inner join Supplier as  sp on sp.Id=mp.SupplierId

		where CAST(mp.Date as date) >= CAST(@fromDate as date) and CAST(mp.Date as date) <= CAST(@toDate as date) and pd.ProductId =@ProductId and mp.IsDeleted=0
		and pd.IsDeleted=0

	end

	else

	begin 
		select mp.Date,p.Name as ProductName,sp.Name as SupplierName,pd.UnitPrice,pd.Qty,mp.TotalAmount,mp.VoucherNo from MainPurchase as mp 
		inner join PurchaseDetail as pd  on mp.Id=pd.MainPurchaseId
		inner join Product as p on p.Id=pd.ProductId
		inner join Brand as b on b.Id=p.BrandId
		inner join Supplier as  sp on sp.Id=mp.SupplierId

		where CAST(mp.Date as date) >= CAST(@fromDate as date) and CAST(mp.Date as date) <= CAST(@toDate as date) and mp.IsDeleted=0
		and pd.IsDeleted=0
	end




GO
/****** Object:  StoredProcedure [dbo].[RefundItemList]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RefundItemList]
	 @fromDate datetime,
	@toDate datetime
AS
	Select TD.ProductId as ItemId, P.Name as ItemName, SUM(TD.Qty) as ItemQty, SUM(TD.TotalAmount) as ItemTotalAmount
	from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id
	where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date)
	Group By TD.ProductId, P.Name;
RETURN 0




GO
/****** Object:  StoredProcedure [dbo].[SaleBreakDownByRangeWithSaleTrueValue]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SaleBreakDownByRangeWithSaleTrueValue]
	@fromDate datetime,
	@toDate datetime,
	@isSp bit
AS
	Declare  @SaleByFromToDate Table (Id int, Total bigint, Qty int)
	Declare  @RefundByFromToDate Table (Id int, Total bigint,Qty int)
	if @isSp != 1
		
	Begin
	
		insert into @SaleByFromToDate
		select P.BrandId as BId, Sum(TD.TotalAmount) as DSTP, Sum(TD.Qty) as Qty
		from [Transaction] as T inner join TransactionDetail as TD on TD.TransactionId = T.Id
		inner join Product as P on P.Id = TD.ProductId	
		right join Brand as B on B.Id = P.BrandId
		where (T.Type = 'Sale' or T.Type = 'Credit') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and (T.IsDeleted IS NULL OR T.IsDeleted = 0) and B.Name !=  'Special Promotion' and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0) and T.IsComplete = 1
		Group By P.BrandId

	
		insert into @RefundByFromToDate
		select P.BrandId as BId, Sum(TD.TotalAmount) as DSTP, Sum(TD.Qty) as Qty
		from [Transaction] as T inner join TransactionDetail as TD on TD.TransactionId = T.Id
		inner join Product as P on P.Id = TD.ProductId	
		right join Brand as B on B.Id = P.BrandId
		where (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and (T.IsDeleted IS NULL OR T.IsDeleted = 0) and B.Name != 'Special Promotion' and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0) and T.IsComplete = 1
		Group By P.BrandId

		select Br.Id as Id,Br.Name as Name, A.Total as TotalSale, A.Qty as SaleQty,B.Total as TotalRefund, B.Qty as RefundQty
		From Brand as Br Full outer join @SaleByFromToDate as A on Br.Id = A.Id	
		Full outer join @RefundByFromToDate as B on Br.Id = B.Id
		--where  Br.Name != 'Special Promotion'

		end	
	
	else		
	
	Begin
	
		insert into @SaleByFromToDate
		select P.BrandId as BId, Sum(TD.TotalAmount) as DSTP, Sum(TD.Qty) as Qty
		from [Transaction] as T inner join TransactionDetail as TD on TD.TransactionId = T.Id
		inner join Product as P on P.Id = TD.ProductId	
		right join Brand as B on B.Id = P.BrandId
		where (T.Type = 'Sale' or T.Type = 'Credit') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and (T.IsDeleted IS NULL OR T.IsDeleted = 0)and B.Name =  'Special Promotion' and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0) and T.IsComplete = 1
		Group By P.BrandId

	
		insert into @RefundByFromToDate
		select P.BrandId as BId, Sum(TD.TotalAmount) as DSTP, Sum(TD.Qty) as Qty
		from [Transaction] as T inner join TransactionDetail as TD on TD.TransactionId = T.Id
		inner join Product as P on P.Id = TD.ProductId	
		right join Brand as B on B.Id = P.BrandId
		where (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and (T.IsDeleted IS NULL OR T.IsDeleted = 0) and B.Name = 'Special Promotion' and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0) and T.IsComplete = 1
		Group By P.BrandId

		select Br.Id as Id,Br.Name as Name, Sum(A.Total) as TotalSale, Sum(A.Qty) as SaleQty,Sum(B.Total) as TotalRefund, Sum(B.Qty) as RefundQty
		From Brand as Br left join @SaleByFromToDate as A on Br.Id = A.Id	
		left join @RefundByFromToDate as B on Br.Id = B.Id
		where  Br.Name = 'Special Promotion'
		Group By Br.Id, Br.Name

		end




GO
/****** Object:  StoredProcedure [dbo].[SaleBreakDownByRangeWithUnitValue]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SaleBreakDownByRangeWithUnitValue]
	@fromDate datetime,
	@toDate datetime,
	@isSp bit
AS
	Declare  @SaleByFromToDate Table (Id int, Total bigint, Qty int)
	Declare  @RefundByFromToDate Table (Id int, Total bigint,Qty int)
	if @isSp != 1
	
	Begin

		insert into @SaleByFromToDate
		select P.BrandId as BId, Sum(TD.UnitPrice *TD.Qty) as DSTP, Sum(TD.Qty) as Qty
		from [Transaction] as T inner join TransactionDetail as TD on TD.TransactionId = T.Id
		inner join Product as P on P.Id = TD.ProductId	
		right join Brand as B on B.Id = P.BrandId
		where (T.Type = 'Sale' or T.Type = 'Credit') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and (T.IsDeleted IS NULL OR T.IsDeleted = 0) and B.Name != 'Special Promotion' and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0) and T.IsComplete = 1
		Group By P.BrandId

	
		insert into @RefundByFromToDate
		select P.BrandId as BId, Sum(TD.UnitPrice *TD.Qty) as DSTP, Sum(TD.Qty) as Qty
		from [Transaction] as T inner join TransactionDetail as TD on TD.TransactionId = T.Id
		inner join Product as P on P.Id = TD.ProductId	
		right join Brand as B on B.Id = P.BrandId
		where (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and (T.IsDeleted IS NULL OR T.IsDeleted = 0) and B.Name != 'Special Promotion' and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0) and T.IsComplete = 1
		Group By P.BrandId

		select Br.Id as Id,Br.Name as Name, A.Total as TotalSale, A.Qty as SaleQty,B.Total as TotalRefund, B.Qty as RefundQty
		From Brand as Br Full outer join @SaleByFromToDate as A on Br.Id = A.Id	
		Full outer join @RefundByFromToDate as B on Br.Id = B.Id
		--where Br.Name != 'Special Promotion'

		end
		

	Else
	Begin
	

		insert into @SaleByFromToDate
		select P.BrandId as BId, Sum(P.Price * TD.Qty) as DSTP, Sum(TD.Qty) as Qty
		from [Transaction] as T inner join TransactionDetail as TD on TD.TransactionId = T.Id
		inner join Product as P on P.Id = TD.ProductId	
		right join Brand as B on B.Id = P.BrandId
		where (T.Type = 'Sale' or T.Type = 'Credit') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and (T.IsDeleted IS NULL OR T.IsDeleted = 0) and B.Name =  'Special Promotion' and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0) and T.IsComplete = 1
		Group By P.BrandId

	
		insert into @RefundByFromToDate
		select P.BrandId as BId, Sum(P.Price *TD.Qty) as DSTP, Sum(TD.Qty) as Qty
		from [Transaction] as T inner join TransactionDetail as TD on TD.TransactionId = T.Id
		inner join Product as P on P.Id = TD.ProductId	
		right join Brand as B on B.Id = P.BrandId
		where (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and T.IsDeleted = 0 and B.Name =  'Special Promotion' and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0) and T.IsComplete = 1
		Group By P.BrandId

		select Br.Id as Id,Br.Name as Name, A.Total as TotalSale, A.Qty as SaleQty,B.Total as TotalRefund, B.Qty as RefundQty
		From Brand as Br Full outer join @SaleByFromToDate as A on Br.Id = A.Id	
		Full outer join @RefundByFromToDate as B on Br.Id = B.Id
		where Br.Name = 'Special Promotion'

		end




GO
/****** Object:  StoredProcedure [dbo].[SaleBreakDownBySegmentWithSaleTrueValue]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SaleBreakDownBySegmentWithSaleTrueValue]
	@fromDate datetime,
	@toDate datetime,
	@isSp bit
AS
	Declare  @SaleByFromToDate Table (Id int, Total bigint, Qty int)
	Declare  @RefundByFromToDate Table (Id int, Total bigint,Qty int)
	if @isSP != 1
	Begin
		

			insert into @SaleByFromToDate
			select P.ProductCategoryId as CId, Sum(TD.TotalAmount) as DSTP, Sum(TD.Qty) as Qty
			from [Transaction] as T inner join TransactionDetail as TD on TD.TransactionId = T.Id
			inner join Product as P on P.Id = TD.ProductId	inner join Brand as B on B.Id = P.BrandId
			right join ProductCategory as C on C.Id = P.ProductCategoryId
			where (T.Type = 'Sale' or T.Type = 'Credit') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and  (T.IsDeleted IS NULL OR T.IsDeleted = 0) and B.Name != 'Special Promotion' and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0) and T.IsComplete = 1
			Group By P.ProductCategoryId
	
			insert into @RefundByFromToDate
			select P.ProductCategoryId as CId, Sum(TD.TotalAmount) as DSTP, Sum(TD.Qty) as Qty
			from [Transaction] as T inner join TransactionDetail as TD on TD.TransactionId = T.Id
			inner join Product as P on P.Id = TD.ProductId	inner join Brand as B on B.Id = P.BrandId
			right join ProductCategory as C on C.Id = P.ProductCategoryId
			where (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and (T.IsDeleted IS NULL OR T.IsDeleted = 0) and B.Name != 'Special Promotion' and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0) and T.IsComplete = 1
			Group BY P.ProductCategoryId

			select C.Id as Id,C.Name as Name, A.Total as TotalSale, A.Qty as SaleQty,B.Total as TotalRefund, B.Qty as RefundQty
			From ProductCategory as C Full outer join @SaleByFromToDate as A on C.Id = A.Id	
			Full outer join @RefundByFromToDate as B on C.Id = B.Id 
			--where C.Name != 'Special Promotion'
		
			
	End
	Else
	Begin
		

			insert into @SaleByFromToDate
			select P.ProductCategoryId as CId, Sum(TD.TotalAmount) as DSTP, Sum(TD.Qty) as Qty
			from [Transaction] as T inner join TransactionDetail as TD on TD.TransactionId = T.Id
			inner join Product as P on P.Id = TD.ProductId	inner join Brand as B on B.Id = P.BrandId
			right join ProductCategory as C on C.Id = P.ProductCategoryId
			where (T.Type = 'Sale' or T.Type = 'Credit') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and (T.IsDeleted IS NULL OR T.IsDeleted = 0) and B.Name = 'Special Promotion' and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0) and T.IsComplete = 1
			Group By P.ProductCategoryId

	
			insert into @RefundByFromToDate
			select P.ProductCategoryId as CId, Sum(TD.TotalAmount) as DSTP, Sum(TD.Qty) as Qty
			from [Transaction] as T inner join TransactionDetail as TD on TD.TransactionId = T.Id
			inner join Product as P on P.Id = TD.ProductId	inner join Brand as B on B.Id = P.BrandId
			right join ProductCategory as C on C.Id = P.ProductCategoryId
			where (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and (T.IsDeleted IS NULL OR T.IsDeleted = 0) and B.Name = 'Special Promotion' and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0) and T.IsComplete = 1
			Group BY P.ProductCategoryId

			select C.Id as Id,C.Name as Name, A.Total as TotalSale, A.Qty as SaleQty,B.Total as TotalRefund, B.Qty as RefundQty
			From ProductCategory as C Full outer join @SaleByFromToDate as A on C.Id = A.Id	
			Full outer join @RefundByFromToDate as B on C.Id = B.Id  
			where C.Name = 'Special Promotion'

			end




GO
/****** Object:  StoredProcedure [dbo].[SaleBreakDownBySegmentWithUnitValue]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SaleBreakDownBySegmentWithUnitValue]
	@fromDate datetime,
	@toDate datetime,	
	@isSp bit
AS
	Declare  @SaleByFromToDate Table (Id int, Total bigint, Qty int)
	Declare  @RefundByFromToDate Table (Id int, Total bigint,Qty int)

	if @isSp != 1
	Begin 
		
		

		insert into @SaleByFromToDate
		select P.ProductCategoryId as CId, Sum(TD.UnitPrice *TD.Qty) as DSTP, Sum(TD.Qty) as Qty
		from [Transaction] as T inner join TransactionDetail as TD on TD.TransactionId = T.Id
		inner join Product as P on P.Id = TD.ProductId inner join Brand as B on B.Id = P.BrandId	
		right join ProductCategory as C on C.Id = P.ProductCategoryId
		where (T.Type = 'Sale' or T.Type = 'Credit') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and (T.IsDeleted IS NULL OR T.IsDeleted = 0) and B.Name != 'Special Promotion' and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0) and T.IsComplete = 1
		Group By P.ProductCategoryId

	
		insert into @RefundByFromToDate
		select P.ProductCategoryId as CId, Sum(TD.UnitPrice *TD.Qty) as DSTP, Sum(TD.Qty) as Qty
		from [Transaction] as T inner join TransactionDetail as TD on TD.TransactionId = T.Id
		inner join Product as P on P.Id = TD.ProductId	inner join Brand as B on B.Id = P.BrandId
		right join ProductCategory as C on C.Id = P.ProductCategoryId
		where (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and (T.IsDeleted IS NULL OR T.IsDeleted = 0) and B.Name != 'Special Promotion' and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0) and T.IsComplete = 1
		Group BY P.ProductCategoryId

		select Br.Id as Id,Br.Name as Name, A.Total as TotalSale, A.Qty as SaleQty,B.Total as TotalRefund, B.Qty as RefundQty
		From ProductCategory as Br Full outer join @SaleByFromToDate as A on Br.Id = A.Id	
		Full outer join @RefundByFromToDate as B on Br.Id = B.Id
		--where Br.Name != 'Special Promotion'

		
		
		
	End

	else

	Begin		

		insert into @SaleByFromToDate
		select P.ProductCategoryId as CId, Sum(TD.UnitPrice *TD.Qty) as DSTP, Sum(TD.Qty) as Qty
		from [Transaction] as T inner join TransactionDetail as TD on TD.TransactionId = T.Id
		inner join Product as P on P.Id = TD.ProductId inner join Brand as B on B.Id = P.BrandId	
		right join ProductCategory as C on C.Id = P.ProductCategoryId
		where (T.Type = 'Sale' or T.Type = 'Credit') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and (T.IsDeleted IS NULL OR T.IsDeleted = 0) and B.Name = 'Special Promotion' and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0) and T.IsComplete = 1
		Group By P.ProductCategoryId

	
		insert into @RefundByFromToDate
		select P.ProductCategoryId as CId, Sum(TD.UnitPrice *TD.Qty) as DSTP, Sum(TD.Qty) as Qty
		from [Transaction] as T inner join TransactionDetail as TD on TD.TransactionId = T.Id
		inner join Product as P on P.Id = TD.ProductId inner join Brand as B on B.Id = P.BrandId	 
		right join ProductCategory as C on C.Id = P.ProductCategoryId
		where (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and (T.IsDeleted IS NULL OR T.IsDeleted = 0) and B.Name = 'Special Promotion' and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0) and T.IsComplete = 1
		Group BY P.ProductCategoryId

		select Br.Id as Id,Br.Name as Name, A.Total as TotalSale, A.Qty as SaleQty,B.Total as TotalRefund, B.Qty as RefundQty
		From ProductCategory as Br Full outer join @SaleByFromToDate as A on Br.Id = A.Id	
		Full outer join @RefundByFromToDate as B on Br.Id = B.Id
		where Br.Name = 'Special Promotion'
		
		
	End




GO
/****** Object:  StoredProcedure [dbo].[SaleItemListByDate]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SaleItemListByDate]
 @fromDate datetime,
 @toDate datetime
AS

	Select TD.ProductId as ItemId, P.Name as ItemName, SUM(TD.Qty) as ItemQty, SUM(TD.TotalAmount) as ItemTotalAmount
	from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id
	where (T.IsDeleted IS NULL or T.IsDeleted = 0) and T.Type = 'Sale' or T.Type = 'Credit' and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date)
	Group By TD.ProductId, P.Name;
	
RETURN 0




GO
/****** Object:  StoredProcedure [dbo].[SelectItemListByDate]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectItemListByDate]
	@fromDate datetime,
	@toDate datetime,
	@IsSale bit
AS
	  Begin If (@IsSale = 1)
	Select P.ProductCode as ItemId, P.Name as ItemName, SUM(TD.Qty) as ItemQty, (TD.UnitPrice - (TD.UnitPrice * (TD.DiscountRate/100))) as UnitPrice, SUM(TD.TotalAmount) as ItemTotalAmount, T.PaymentTypeId as PaymentTypeId, P.Size as Size
	from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id
	where T.IsDeleted = 0 and T.IsComplete = 1 and (T.Type = 'Sale' or T.Type = 'Credit' or T.Type = 'GiftCard') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0)
	Group By P.ProductCode, P.Name, TD.UnitPrice, T.PaymentTypeId, P.Size,TD.DiscountRate;
   Else
   Select P.ProductCode as ItemId, P.Name as ItemName, SUM(TD.Qty) as ItemQty, (TD.UnitPrice - (TD.UnitPrice * (TD.DiscountRate/100))) as UnitPrice, SUM(TD.TotalAmount) as ItemTotalAmount, T.PaymentTypeId as PaymentTypeId, P.Size as Size
	from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id
	where  T.IsDeleted = 0 and (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and (TD.IsDeleted IS NULL OR TD.IsDeleted = 0)
	Group By P.ProductCode, P.Name, TD.UnitPrice, T.PaymentTypeId, P.Size,TD.DiscountRate;
   End
RETURN 0




GO
/****** Object:  StoredProcedure [dbo].[SelectTaxesListByDate]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectTaxesListByDate]
	@fromDate datetime,
	@toDate datetime,
	@IsSale bit
AS
   Begin If (@IsSale = 1)
	SELECT CAST(T.DateTime as date) as TDate, SUM(T.TaxAmount) as Amount
	FROM [Transaction] AS T
	WHERE (T.IsDeleted IS NULL or T.IsDeleted = 0) and (T.Type = 'Sale' or T.Type = 'Credit') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date)
	GROUP BY CAST(T.DateTime as date)
   Else
    SELECT CAST(T.DateTime as date) as TDate, SUM(T.TaxAmount) as Amount
	FROM [Transaction] AS T
	WHERE (T.IsDeleted IS NULL or T.IsDeleted = 0) and T.Type = 'Refund' and CAST(T.DateTime as date) >= CAST(@fromDate  as date) and CAST(T.DateTime as date) <= CAST(@toDate as date)
	GROUP BY CAST(T.DateTime as date)
   End




GO
/****** Object:  StoredProcedure [dbo].[Top100SaleItemList]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Top100SaleItemList]
 @fromDate datetime,
 @toDate datetime,
 @IsAmount bit,
 @num int
AS

 if(@IsAmount = 1) 
	Begin
		Select Top (@num) P.ProductCode as ItemId, P.Name as ItemName, TD.DiscountRate as DisCount, TD.UnitPrice as UnitPrice, SUM(TD.Qty) as ItemQty, SUM(TD.TotalAmount) as ItemTotalAmount
		from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id
		where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (T.Type = 'Sale' or T.Type = 'Credit') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and T.IsComplete = 1
		Group By P.ProductCode, P.Name, TD.DiscountRate, TD.UnitPrice
		Order By SUM(TD.TotalAmount) Desc;
	End
 Else
	Begin
		Select Top (@num) P.ProductCode as ItemId, P.Name as ItemName, TD.DiscountRate as DisCount, TD.UnitPrice as UnitPrice, SUM(TD.Qty) as ItemQty, SUM(TD.TotalAmount) as ItemTotalAmount
		from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id
		where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (T.Type = 'Sale' or T.Type = 'Credit') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and T.IsComplete = 1
		Group By P.ProductCode, P.Name, TD.DiscountRate, TD.UnitPrice
		Order By SUM(TD.Qty) Desc;
	End	
RETURN 0




GO
/****** Object:  StoredProcedure [dbo].[TransactionDetailByItem]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TransactionDetailByItem]
	@fromDate datetime,
	@toDate datetime,
	@IsSale bit,
	@MainCategoryId int,
	@SubCategoryId int,
	@BrandId int
AS
	
	Begin If(@SubCategoryId = 1)
		set @SubCategoryId = null
	End
	Begin If(@BrandId = 1)
		set @BrandId = null
	End
	
	Begin If (@IsSale = 1)	
		Begin If(@MainCategoryId = 0 and @BrandId = 0)

			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType, T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and T.IsComplete = 1 and (T.Type = 'Sale' or T.Type = 'Credit') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) 
		
		Else If(@MainCategoryId =0 and @BrandId != 0)

			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType, T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and T.IsComplete = 1 and  (T.Type = 'Sale' or T.Type = 'Credit') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.BrandId = @BrandId
		
		Else If(@MainCategoryId != 0 and @SubCategoryId =0 and @BrandId = 0 )
			
			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType, T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and T.IsComplete = 1  and  (T.Type = 'Sale' or T.Type = 'Credit') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.ProductCategoryId = @MainCategoryId

		Else If(@MainCategoryId != 0 and @SubCategoryId != 0 and @BrandId = 0)
			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType, T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and T.IsComplete = 1 and  (T.Type = 'Sale' or T.Type = 'Credit') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.ProductCategoryId = @MainCategoryId and P.ProductSubCategoryId = @SubCategoryId

		Else If(@MainCategoryId !=0 and @SubCategoryId = 0 and @BrandId !=0)
			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType, T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and T.IsComplete = 1 and  (T.Type = 'Sale' or T.Type = 'Credit') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.ProductCategoryId = @MainCategoryId and P.BrandId = @BrandId

		Else If(@MainCategoryId != 0 and @SubCategoryId != 0 and @BrandId != 0 )
			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType, T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and T.IsComplete = 1 and  (T.Type = 'Sale' or T.Type = 'Credit') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.ProductCategoryId = @MainCategoryId and P.ProductSubCategoryId = @SubCategoryId and P.BrandId = @BrandId
		End	
	--Refund	
	Else
		Begin If(@MainCategoryId = 0 and @BrandId = 0)

			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType, T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and  T.Type = 'Refund' and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date)
		
		Else If(@MainCategoryId =0 and @BrandId != 0)

			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType, T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and  T.Type = 'Refund' and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.BrandId = @BrandId
		
		Else If(@MainCategoryId != 0 and @SubCategoryId =0 and @BrandId = 0 )
			
			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType, T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and  T.Type = 'Refund' and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.ProductCategoryId = @MainCategoryId

		Else If(@MainCategoryId != 0 and @SubCategoryId != 0 and @BrandId = 0)
			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType, T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and  T.Type = 'Refund' and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.ProductCategoryId = @MainCategoryId and P.ProductSubCategoryId = @SubCategoryId

		Else If(@MainCategoryId !=0 and @SubCategoryId = 0 and @BrandId !=0)
			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType, T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and  T.Type = 'Refund' and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.ProductCategoryId = @MainCategoryId and P.BrandId = @BrandId

		Else If(@MainCategoryId != 0 and @SubCategoryId != 0 and @BrandId != 0 )
			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType, T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and  T.Type = 'Refund' and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.ProductCategoryId = @MainCategoryId and P.ProductSubCategoryId = @SubCategoryId and P.BrandId = @BrandId
		End	
				
	End




GO
/****** Object:  StoredProcedure [dbo].[TransactionDetailReport]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TransactionDetailReport]
	@fromDate datetime,
	@toDate datetime,
	@IsSale bit
	
AS
	If(@IsSale = 1)
	Begin 
		Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType,CT.Name as [Counter Name], T.DateTime as TransactionDate
		from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
		where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and T.IsComplete = 1 and  (T.Type = 'Sale' or T.Type = 'Credit' or T.Type = 'GiftCard') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date)
	End
	Else
	Begin
		Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType,CT.Name as [Counter Name], T.DateTime as TransactionDate
		from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
		where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted=0) and  (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date)
	End 
RETURN 0




GO
/****** Object:  StoredProcedure [dbo].[TransactionDetailReportByBId]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TransactionDetailReportByBId]
	@fromDate datetime,
	@toDate datetime,
	@IsSale bit,
	@BrandId int
	
AS
   
	If(@IsSale = 1)
	Begin 
		Begin If(@BrandId = 1)
			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType,CT.Name as [Counter Name]	, T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and T.IsComplete = 1 and (T.Type = 'Sale' or T.Type = 'Credit' or T.Type = 'GiftCard') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.BrandId Is Null
		Else
			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType,CT.Name as [Counter Name], T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and T.IsComplete = 1 and  (T.Type = 'Sale' or T.Type = 'Credit' or T.Type = 'GiftCard') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.BrandId = @BrandId
		End
	End
	Else
	Begin
		Begin If(@BrandId = 1)
			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType
,CT.Name as [Counter Name], T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and  (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.BrandId Is Null
		Else
			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType 
,CT.Name as [Counter Name], T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and  (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.BrandId = @BrandId
		End
	End 
RETURN 0




GO
/****** Object:  StoredProcedure [dbo].[TransactionDetailReportByBIdAndCId]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TransactionDetailReportByBIdAndCId]
	@fromDate datetime,
	@toDate datetime,
	@IsSale bit,
	@BrandId int,
	@MainCategoryId int
	
AS
   
	If(@IsSale = 1)
	Begin 
		Begin If(@BrandId = 1)
			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType ,CT.Name as [Counter Name], T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and T.IsComplete = 1 and  (T.Type = 'Sale' or T.Type = 'Credit' or T.Type = 'GiftCard') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.BrandId Is Null and P.ProductCategoryId = @MainCategoryId
		Else
			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType,CT.Name as [Counter Name], T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and T.IsComplete = 1  and (T.Type = 'Sale' or T.Type = 'Credit' or T.Type = 'GiftCard') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.BrandId = @BrandId and P.ProductCategoryId = @MainCategoryId
		End
	End
	Else
	Begin
		Begin If(@BrandId = 1)
			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType ,CT.Name as [Counter Name], T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and  (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.BrandId Is Null and P.ProductCategoryId = @MainCategoryId
		Else
			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType ,CT.Name as [Counter Name], T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and  (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.BrandId = @BrandId and P.ProductCategoryId = @MainCategoryId
		End
	End 
RETURN 0




GO
/****** Object:  StoredProcedure [dbo].[TransactionDetailReportByBIdAndCIdAndSCId]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TransactionDetailReportByBIdAndCIdAndSCId]
	@fromDate datetime,
	@toDate datetime,
	@IsSale bit,
	@BrandId int,
	@MainCategoryId int,
	@SubCategoryId int
	
AS
   
	If(@IsSale = 1)
	Begin 
		Begin If(@BrandId = 1)
		    Begin If (@SubCategoryId = 1)
				Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType ,CT.Name as [Counter Name], T.DateTime as TransactionDate
				from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
				where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and T.IsComplete = 1 and (T.Type = 'Sale' or T.Type = 'Credit' or T.Type = 'GiftCard') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.BrandId Is Null and P.ProductCategoryId = @MainCategoryId and P.ProductSubCategoryId Is Null

			Else
				Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType ,CT.Name as [Counter Name], T.DateTime as TransactionDate
				from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
				where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and T.IsComplete = 1 and (T.Type = 'Sale' or T.Type = 'Credit' or T.Type = 'GiftCard') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.BrandId Is Null and P.ProductCategoryId = @MainCategoryId and P.ProductSubCategoryId = @SubCategoryId
			End
			
		Else
			Begin If (@SubCategoryId = 1)
				Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType ,CT.Name as [Counter Name], T.DateTime as TransactionDate
				from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
				where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and T.IsComplete = 1 and (T.Type = 'Sale' or T.Type = 'Credit' or T.Type = 'GiftCard') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.BrandId = @BrandId and P.ProductCategoryId = @MainCategoryId and P.ProductSubCategoryId Is Null

			Else
				Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType ,CT.Name as [Counter Name], T.DateTime as TransactionDate
				from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
				where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and T.IsComplete = 1 and (T.Type = 'Sale' or T.Type = 'Credit' or T.Type = 'GiftCard') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.BrandId = @BrandId and P.ProductCategoryId = @MainCategoryId and P.ProductSubCategoryId = @SubCategoryId
			End
			
		End
	End
	Else
	Begin
		Begin If(@BrandId = 1)
		    Begin If (@SubCategoryId = 1)
				Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType,CT.Name as [Counter Name], T.DateTime as TransactionDate
				from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
				where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and  (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.BrandId Is Null and P.ProductCategoryId = @MainCategoryId and P.ProductSubCategoryId Is Null

			Else
				Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType,CT.Name as [Counter Name], T.DateTime as TransactionDate
				from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
				where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and  (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.BrandId Is Null and P.ProductCategoryId = @MainCategoryId and P.ProductSubCategoryId = @SubCategoryId
			End
			
		Else
			Begin If (@SubCategoryId = 1)
				Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType ,CT.Name as [Counter Name], T.DateTime as TransactionDate
				from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
				where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and  (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.BrandId = @BrandId and P.ProductCategoryId = @MainCategoryId and P.ProductSubCategoryId Is Null

			Else
				Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType ,CT.Name as [Counter Name], T.DateTime as TransactionDate
				from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
				where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and  (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.BrandId = @BrandId and P.ProductCategoryId = @MainCategoryId and P.ProductSubCategoryId = @SubCategoryId
			End
			
		End
		
	End 
RETURN 0




GO
/****** Object:  StoredProcedure [dbo].[TransactionDetailReportByCId]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TransactionDetailReportByCId]
	@fromDate datetime,
	@toDate datetime,
	@IsSale bit,
	@MainCategoryId int
	
AS
	If(@IsSale = 1)
	Begin 
		Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType,CT.Name as [Counter Name], T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and T.IsComplete = 1 and (T.Type = 'Slae' or T.Type = 'Credit' or T.Type = 'GiftCard') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.ProductCategoryId = @MainCategoryId
	End
	Else
	Begin
		Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType ,CT.Name as [Counter Name], T.DateTime as TransactionDate
		from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
		where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.ProductCategoryId = @MainCategoryId
	End 
RETURN 0




GO
/****** Object:  StoredProcedure [dbo].[TransactionDetailReportBySCIdAndCId]    Script Date: 12/15/2016 5:17:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TransactionDetailReportBySCIdAndCId]
	@fromDate datetime,
	@toDate datetime,
	@IsSale bit,
	@SubCategoryId int,
	@MainCategoryId int
	
AS
   
	If(@IsSale = 1)
	Begin 
		Begin If(@SubCategoryId = 1)
			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType ,CT.Name as [Counter Name], T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and T.IsComplete = 1 and (T.Type = 'Sale' or T.Type = 'Credit' or T.Type = 'GiftCard') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.ProductSubCategoryId Is Null and P.ProductCategoryId = @MainCategoryId
		Else
			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType ,CT.Name as [Counter Name], T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and T.IsComplete = 1 and (T.Type = 'Sale' or T.Type = 'Credit' or T.Type = 'GiftCard') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.ProductSubCategoryId = @SubCategoryId and P.ProductCategoryId = @MainCategoryId
		End
	End
	Else
	Begin
		Begin If(@SubCategoryId = 1)
			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType ,CT.Name as [Counter Name], T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.ProductSubCategoryId Is Null and P.ProductCategoryId = @MainCategoryId
		Else
			Select P.ProductCode as ItemNo, P.Name as ItemName, TD.TransactionId as TransactionId, TD.Qty as Qty, TD.TotalAmount, T.Type as TransactionType ,CT.Name as [Counter Name] , T.DateTime as TransactionDate
			from [Transaction] as T inner join TransactionDetail as TD on T.Id = TD.TransactionId inner join Product as P on TD.ProductId = P.Id inner join Counter as CT on T.CounterId=CT.Id
			where (T.IsDeleted IS NULL or T.IsDeleted = 0) and (TD.IsDeleted IS NULL or TD.IsDeleted = 0) and (T.Type = 'Refund' or T.Type = 'CreditRefund') and CAST(T.DateTime as date) >= CAST(@fromDate as date) and CAST(T.DateTime as date) <= CAST(@toDate as date) and P.ProductSubCategoryId = @SubCategoryId and P.ProductCategoryId = @MainCategoryId
		End
	End 
RETURN 0




GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction, Refund,Draft, Debt,GiftCard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transaction', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'just for Credit Transaction' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transaction', @level2type=N'COLUMN',@level2name=N'IsPaid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'If false, store as draft' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transaction', @level2type=N'COLUMN',@level2name=N'IsComplete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Use only for Refund Transaction' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transaction', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
