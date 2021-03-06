USE [Chicken_Shop]
GO
/****** Object:  Table [dbo].[TbBill_Items]    Script Date: 24-Nov-20 11:55:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbBill_Items](
	[ItemIDPK] [bigint] IDENTITY(1,1) NOT NULL,
	[Price] [decimal](18, 3) NOT NULL,
	[ItemID_FK] [int] NOT NULL,
	[Quantity] [decimal](15, 3) NOT NULL,
	[TodayItem] [datetime] NOT NULL,
 CONSTRAINT [PK_Bill_Items] PRIMARY KEY CLUSTERED 
(
	[ItemIDPK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbBills]    Script Date: 24-Nov-20 11:55:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbBills](
	[BilI_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TotalPrice] [decimal](15, 4) NOT NULL,
	[CustomerID] [bigint] NULL,
	[TreaderID] [bigint] NULL,
	[WorkerID] [int] NOT NULL,
 CONSTRAINT [PK_Bills] PRIMARY KEY CLUSTERED 
(
	[BilI_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbBillsItemsBridge]    Script Date: 24-Nov-20 11:55:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbBillsItemsBridge](
	[ItemsInBillID] [bigint] NOT NULL,
	[BillFkID] [bigint] NULL,
	[ItemsFkID] [bigint] NULL,
 CONSTRAINT [PK_TbBillsItemsBridge] PRIMARY KEY CLUSTERED 
(
	[ItemsInBillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbCustomer]    Script Date: 24-Nov-20 11:55:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbCustomer](
	[Customer_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](100) NULL,
	[CustomerAddress] [nvarchar](50) NULL,
	[CustomerMobileNumber] [nvarchar](20) NULL,
	[CustomerPoints] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Customer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbItemTypes]    Script Date: 24-Nov-20 11:55:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbItemTypes](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbPasswords]    Script Date: 24-Nov-20 11:55:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbPasswords](
	[int] [int] IDENTITY(1,1) NOT NULL,
	[Password] [nvarchar](16) NOT NULL,
 CONSTRAINT [PK_TbPasswords] PRIMARY KEY CLUSTERED 
(
	[int] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbStock]    Script Date: 24-Nov-20 11:55:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbStock](
	[Stock] [int] NOT NULL,
	[QuantityInStock] [int] NULL,
	[Date] [datetime] NULL,
	[State] [bit] NOT NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[Stock] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbTreaders]    Script Date: 24-Nov-20 11:55:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbTreaders](
	[TreaderID] [bigint] IDENTITY(1,1) NOT NULL,
	[TreaderName] [nvarchar](100) NOT NULL,
	[Money] [decimal](15, 4) NOT NULL,
	[TreaderMobileNumber] [nvarchar](15) NULL,
	[TreaderAddress] [nvarchar](100) NULL,
 CONSTRAINT [PK_TbTeaders] PRIMARY KEY CLUSTERED 
(
	[TreaderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbTreaderTransactions]    Script Date: 24-Nov-20 11:55:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbTreaderTransactions](
	[TransactionData] [datetime] NOT NULL,
	[IncomeMoney] [decimal](15, 4) NOT NULL,
	[OutcomeMoney] [decimal](15, 4) NOT NULL,
	[Total] [decimal](15, 4) NOT NULL,
	[TransactionBillID] [bigint] NULL,
	[TreaderID] [bigint] NOT NULL,
 CONSTRAINT [PK_TbTeaderTransactions] PRIMARY KEY CLUSTERED 
(
	[TransactionData] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbWorkers]    Script Date: 24-Nov-20 11:55:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbWorkers](
	[WorkerID] [int] IDENTITY(1,1) NOT NULL,
	[WorkerName] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_TbWorkers] PRIMARY KEY CLUSTERED 
(
	[WorkerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TbPasswords] ADD  CONSTRAINT [DF_TbPasswords_Password]  DEFAULT ((0)) FOR [Password]
GO
ALTER TABLE [dbo].[TbBill_Items]  WITH CHECK ADD  CONSTRAINT [FK_TbBill_Items_TbItemTypes] FOREIGN KEY([ItemID_FK])
REFERENCES [dbo].[TbItemTypes] ([ItemID])
GO
ALTER TABLE [dbo].[TbBill_Items] CHECK CONSTRAINT [FK_TbBill_Items_TbItemTypes]
GO
ALTER TABLE [dbo].[TbBills]  WITH CHECK ADD  CONSTRAINT [FK_TbBills_TbCustomer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[TbCustomer] ([Customer_ID])
GO
ALTER TABLE [dbo].[TbBills] CHECK CONSTRAINT [FK_TbBills_TbCustomer]
GO
ALTER TABLE [dbo].[TbBills]  WITH CHECK ADD  CONSTRAINT [FK_TbBills_TbTeaders] FOREIGN KEY([TreaderID])
REFERENCES [dbo].[TbTreaders] ([TreaderID])
GO
ALTER TABLE [dbo].[TbBills] CHECK CONSTRAINT [FK_TbBills_TbTeaders]
GO
ALTER TABLE [dbo].[TbBills]  WITH CHECK ADD  CONSTRAINT [FK_TbBills_TbWorkers] FOREIGN KEY([WorkerID])
REFERENCES [dbo].[TbWorkers] ([WorkerID])
GO
ALTER TABLE [dbo].[TbBills] CHECK CONSTRAINT [FK_TbBills_TbWorkers]
GO
ALTER TABLE [dbo].[TbBillsItemsBridge]  WITH CHECK ADD  CONSTRAINT [FK_TbBillsItemsBridge_TbBill_Items] FOREIGN KEY([ItemsFkID])
REFERENCES [dbo].[TbBill_Items] ([ItemIDPK])
GO
ALTER TABLE [dbo].[TbBillsItemsBridge] CHECK CONSTRAINT [FK_TbBillsItemsBridge_TbBill_Items]
GO
ALTER TABLE [dbo].[TbBillsItemsBridge]  WITH CHECK ADD  CONSTRAINT [FK_TbBillsItemsBridge_TbBills] FOREIGN KEY([BillFkID])
REFERENCES [dbo].[TbBills] ([BilI_ID])
GO
ALTER TABLE [dbo].[TbBillsItemsBridge] CHECK CONSTRAINT [FK_TbBillsItemsBridge_TbBills]
GO
ALTER TABLE [dbo].[TbTreaderTransactions]  WITH CHECK ADD  CONSTRAINT [FK_TbTeaderTransactions_TbTeaders] FOREIGN KEY([TreaderID])
REFERENCES [dbo].[TbTreaders] ([TreaderID])
GO
ALTER TABLE [dbo].[TbTreaderTransactions] CHECK CONSTRAINT [FK_TbTeaderTransactions_TbTeaders]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'hold noraml clients data' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TbCustomer'
GO
