SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[itemtype]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[itemtype](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[typename] [nvarchar](50) NULL,
	[shortcut] [nvarchar](50) NULL,
	[Metercount] [nchar](10) NULL,
	[hsnCode] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [uk_typename] UNIQUE NONCLUSTERED 
(
	[typename] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[upper_itemtype]'))
EXEC dbo.sp_executesql @statement = N'create trigger [dbo].[upper_itemtype] on [dbo].[itemtype]
after insert
as update itemtype set typename = upper(typename) , shortcut = upper(shortcut) where id in(select id from inserted)
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[indvardate]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'create function [dbo].[indvardate](@date nvarchar(10))
returns datetime
as
begin
	return convert(datetime,@date,103)
end' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[inddatevar]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE function [dbo].[inddatevar](@date datetime)
returns varchar(10)
as
begin
	return convert(varchar(10),@date,103)
end' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[get_company]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[get_company]
AS
SELECT     c.name AS [Company Name], a.city, a.state, a.pincode, a.phno_1, a.phno_2
FROM         dbo.company AS c LEFT OUTER JOIN
                      dbo.address AS a ON a.id = c.address_id
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'get_company', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[54] 4[7] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "c"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "a"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 245
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 3
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'get_company'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'get_company', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'get_company'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[manual_or_original_receiptno]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE function [dbo].[manual_or_original_receiptno](@original int , @manual nvarchar(20))
returns nvarchar(20)
as
begin
	if(rtrim(ltrim(@manual)) <> '''' and @manual <> ''0'' and @manual is not null)
	begin
		return ''M'' + @manual
	end
	return convert(varchar,@original)
end' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ledgerdetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ledgerdetail](
	[name] [varchar](100) NULL,
	[city] [varchar](100) NULL,
	[datefrom] [varchar](20) NULL,
	[dateto] [varchar](20) NULL,
	[calculationdays] [int] NULL,
	[intrestper] [float] NULL,
	[calculationdate] [varchar](20) NULL,
	[openbalance] [numeric](12, 2) NULL,
	[openintrest] [numeric](12, 2) NULL,
	[payment] [numeric](12, 2) NULL,
	[recepit] [numeric](12, 2) NULL,
	[intrest] [numeric](12, 2) NULL,
	[closingbal] [numeric](12, 2) NULL,
	[closingint] [numeric](12, 2) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groupbalance]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[groupbalance](
	[name] [varchar](100) NULL,
	[balance] [numeric](12, 2) NULL,
	[place] [varchar](100) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[blank_on_cd]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'create function [dbo].[blank_on_cd](@iscd bit , @amount float)
returns varchar(20)
as
begin
	if(@iscd = 1)
	begin
		return ''''
	end
	return convert(varchar , @amount)
end' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[get_current_financial_year]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[get_current_financial_year]
as
begin
	if(month(getdate())<=3)
	begin
		select ''1/4/'' + convert(varchar,(year(getdate()))-1),''31/3/'' + convert(varchar,(year(getdate())))
	end
	else
	begin
		select ''1/4/'' + convert(varchar,(year(getdate()))),''31/3/'' + convert(varchar,(year(getdate()))+1)
	end
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[line]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[line](
	[city] [varchar](100) NULL,
	[group] [varchar](100) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[deletion_history]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[deletion_history](
	[type] [varchar](20) NULL,
	[number] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[printledger]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[printledger](
	[date] [varchar](20) NULL,
	[detail] [varchar](500) NULL,
	[exp] [numeric](12, 2) NULL,
	[payment] [numeric](12, 2) NULL,
	[recepit] [numeric](12, 2) NULL,
	[days] [int] NULL,
	[intrest] [numeric](12, 2) NULL,
	[name] [varchar](200) NULL,
	[transtype] [varchar](100) NULL,
	[detail1] [varchar](100) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[temp]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[temp](
	[name] [varchar](30) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[transport]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[transport](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[note] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[return_if_non_zero_non_null]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'create function [dbo].[return_if_non_zero_non_null](@bool numeric(10,2), @value numeric(10,2))
returns numeric(10,2)
as
begin
	declare @x numeric(10,2)
	set @x = NULL
	if ( @bool = 1 )
	begin
		set @x = @value
	end
	return @x
end' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[return_if_zero_or_null]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'create function [dbo].[return_if_zero_or_null](@bool numeric(10,2), @value numeric(10,2))
returns numeric(10,2)
as
begin
	declare @x numeric(10,2)
	set @x = NULL
	if ( @bool = 0 or @bool is NULL )
	begin
		set @x = @value
	end
	return @x
end' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[temp_bill_master]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[temp_bill_master](
	[billid] [int] NULL,
	[billno] [int] NULL,
	[customer] [nvarchar](100) NULL,
	[city] [nvarchar](100) NULL,
	[date] [nvarchar](30) NULL,
	[total] [numeric](10, 2) NULL,
	[expenseper] [float] NULL,
	[expenses] [numeric](10, 2) NULL,
	[transport] [nvarchar](100) NULL,
	[transportcharge] [numeric](10, 2) NULL,
	[transportnumber] [nvarchar](30) NULL,
	[grandtotal] [numeric](12, 0) NULL,
	[through] [nvarchar](100) NULL,
	[paymenttype] [nvarchar](30) NULL,
	[note] [nvarchar](200) NULL,
	[RG Total] [numeric](12, 2) NULL,
	[iscd] [bit] NULL,
	[cdexp] [varchar](10) NULL,
	[vatper] [float] NULL,
	[vat] [numeric](10, 2) NULL,
	[tax_str] [nvarchar](10) NULL,
	[sgst] [numeric](10, 2) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[utility]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[utility](
	[vat_start_date] [datetime] NULL,
	[vat_end_date] [datetime] NULL,
	[gst_start_date] [datetime] NULL,
	[gst_end_date] [datetime] NULL,
	[id] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[log_backup]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[log_backup]
@locationwidname ntext
as
begin
	BACKUP LOG vardhman 
	TO DISK = @locationwidname
	WITH INIT
end

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[place]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[place](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[city] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [uk_city] UNIQUE NONCLUSTERED 
(
	[city] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[upper_place]'))
EXEC dbo.sp_executesql @statement = N'create trigger [dbo].[upper_place] on [dbo].[place]
after insert
as update place set city = upper(city) , state = upper(state) where id in(select id from inserted)
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[differential_backup]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
create procedure [dbo].[differential_backup]
@locationname as ntext
as
begin
	BACKUP DATABASE vardhman
	TO DISK = @locationname
	WITH INIT, DIFFERENTIAL
end

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[differential_restore]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE procedure [dbo].[differential_restore]
@locationname ntext
as
begin
	RESTORE DATABASE vardhman
	FROM DISK = @locationname
	WITH RECOVERY
end
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[log_recovery]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
create procedure [dbo].[log_recovery]
@locationname as ntext
as
begin
	RESTORE LOG vardhman
	FROM DISK = @locationname
	WITH RECOVERY
end

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[customer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[note] [nvarchar](500) NULL,
	[address] [nvarchar](200) NULL,
	[city] [nvarchar](100) NULL,
	[pincode] [nvarchar](6) NULL,
	[phno_1] [nvarchar](50) NULL,
	[phno_2] [nvarchar](50) NULL,
	[openbalance] [numeric](10, 2) NULL,
	[debcredit] [nvarchar](50) NULL,
	[date] [datetime] NULL,
	[type] [nvarchar](30) NULL,
	[accountnumber] [nvarchar](30) NULL,
	[accounttype] [nvarchar](30) NULL,
 CONSTRAINT [PK__costumer__2E1BDC42] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [uk_unoque_customer_city] UNIQUE NONCLUSTERED 
(
	[name] ASC,
	[city] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bill_master]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bill_master](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[billno] [int] NOT NULL,
	[customer] [int] NULL,
	[date] [datetime] NULL,
	[total] [numeric](10, 2) NULL,
	[expensesper] [float] NULL,
	[expenses] [numeric](10, 2) NULL,
	[transport] [nvarchar](100) NULL,
	[transportcherge] [numeric](10, 2) NULL,
	[transportnumber] [nvarchar](30) NULL,
	[grandtotal] [numeric](10, 2) NULL,
	[through] [nvarchar](100) NULL,
	[paymenttype] [nvarchar](30) NULL,
	[note] [nvarchar](200) NULL,
	[rgtotal] [numeric](12, 2) NULL,
	[iscd] [bit] NULL,
	[vatper] [float] NULL,
	[vat] [numeric](10, 2) NULL,
	[sgst] [numeric](10, 2) NULL,
 CONSTRAINT [PK__bill_master__1FCDBCEB] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__bill_master__20C1E124] UNIQUE NONCLUSTERED 
(
	[billno] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[get_price]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[get_price]
@company nvarchar(100),
@group nvarchar(100),
@name nvarchar(100)
as
begin
	if(exists(select * from item_detail where [Item Name] = @name and company like(@company + ''%'') and ([Type name] like(@group +''%'') or shortcut like(@group + ''%''))))
	begin
		select min(price) from item_detail where [Item Name] = @name and company like(@company + ''%'') and ([Type name] like(@group +''%'') or shortcut like(@group + ''%''))		
	end	
	else select ''-1''
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[billorcash]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE function [dbo].[billorcash](@type nvarchar(100))
returns nvarchar(100)
as
begin
	declare @x nvarchar(100)
	set @x = ''''
	if(@type = ''NET AMOUNT TO PAY'')
	begin
		set @x = ''Bill No.''
	end
	else if(@type = ''PAID BY CASH'')
	begin
		set @x = ''Cash B.No.''
	end
	return @x
end' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[maxbillno]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[maxbillno]
as
begin
	if(exists(select * from bill_master))
	begin
		select max(billno) + 1 as billno from bill_master
	end
	else
	begin
		select ''1'' as billno
	end
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rgcal]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE function [dbo].[rgcal](@rg bit)
returns nvarchar(50)
as
begin
	declare @x nvarchar(50)
	if(@rg = 0)
	begin
		set @x = ''''
	end
	else
	begin
		set @x = ''''
	end
	return @x
	
end' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[get_duplicate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[get_duplicate]
@customer nvarchar(30)
as
begin
	if(exists(select * from customer where name =@customer having count(*)>=2))
	begin
		select name , city  from customer_detail where name =@customer
	end
	else
	begin
		select ''0'' , ''0''
	end
end

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[temp_bill_detail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[temp_bill_detail](
	[billid] [int] NULL,
	[company] [nvarchar](100) NULL,
	[group] [nvarchar](50) NULL,
	[item] [nvarchar](500) NULL,
	[meterdetail] [nvarchar](100) NULL,
	[qty] [int] NULL,
	[meter] [nvarchar](500) NULL,
	[rate] [numeric](10, 2) NULL,
	[amt] [numeric](10, 2) NULL,
	[isrg] [bit] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[grpitem]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE function [dbo].[grpitem](@rg nvarchar(50) , @group nvarchar(100),@company nvarchar(100) , @item nvarchar(100) , @meterdetail nvarchar(100))
returns nvarchar(400)
as
begin
	declare @x nvarchar(500)
	
	if(@group = ''RG'')
	begin
		set @group = ''''
	end

	if(@company = ''RG'')
	begin
		set @company = ''''
	end

	if(@rg!='''')
	begin
		set @rg = @rg + '' ''
	end
	else if(@rg is null)
	begin
		set @rg = ''''
	end


	if(@company!='''')
	begin
		set @company = @company + '' ''
	end
	else if(@company is null)
	begin
		set @company = ''''
	end


	if(@group!='''')
	begin
		set @group = @group + ''  ''
	end
	else if(@group is null)
	begin
		set @group = ''''
	end


	if(@item != '''')
	begin
		set @item = @item + '' ''
	end
	else if(@item is null)
	begin
		set @item = ''''
	end


	if(@meterdetail != '''')
	begin
		set @meterdetail = @meterdetail + '' ''
	end
	else if(@meterdetail is null)
	begin
		set @meterdetail = ''''
	end

	set @x = @rg + @company + @group + @item + @meterdetail
	return @x
end



' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[autobackuppath]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[autobackuppath](
	[path] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[full_backup]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[full_backup]
@locationname as nvarchar(700)
as
begin
	BACKUP DATABASE vardhman
	TO DISK = @locationname
end





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[full_restore]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[full_restore]
@locationname nvarchar(700)
as
begin
	RESTORE DATABASE vardhman
	FROM DISK = @locationname
end



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[company]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[company](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[note] [nvarchar](500) NULL,
	[address] [nvarchar](200) NULL,
	[pincode] [nvarchar](6) NULL,
	[phno_1] [nvarchar](10) NULL,
	[phno_2] [nvarchar](50) NULL,
	[city] [nvarchar](100) NULL,
 CONSTRAINT [PK__company__7C8480AE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [uk_unique_name] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[uppercompany]'))
EXEC dbo.sp_executesql @statement = N'create trigger [dbo].[uppercompany] on [dbo].[company]
after insert
as update company set [name] = upper([name]) , note = upper(note) where id in(select id from inserted)
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[intcal]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE function [dbo].[intcal](@datediff int, @payment float ,@intrest float )
returns float
as
begin
	if(@datediff<=0)
	begin
		return 0
	end
	declare @x float
	set @x = @datediff*isnull(@payment , 0)*isnull(@intrest , 0)/3000
	return @x
end' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[temp_recepit]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[temp_recepit](
	[recepitno] [int] NULL,
	[date] [nvarchar](10) NULL,
	[customername] [nvarchar](100) NULL,
	[city] [nvarchar](100) NULL,
	[amount] [numeric](10, 2) NULL,
	[cd] [numeric](10, 2) NULL,
	[total] [numeric](10, 2) NULL,
	[bankname] [nvarchar](100) NULL,
	[checknumber] [nvarchar](20) NULL,
	[rupeeword] [nvarchar](200) NULL,
	[billno] [nvarchar](50) NULL,
	[through] [nvarchar](100) NULL,
	[manualrecepit] [nvarchar](50) NULL,
	[Note] [nvarchar](200) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[password_]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[password_](
	[passwd] [nvarchar](100) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PRICE_LIST_PRINT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PRICE_LIST_PRINT](
	[ID] [int] NULL,
	[COMPANY] [varchar](100) NULL,
	[TYPE] [varchar](100) NULL,
	[NAME] [varchar](100) NULL,
	[RATE] [varchar](100) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[getTransportCharge]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[getTransportCharge]
@name nvarchar(100),
@city nvarchar(100)
as
begin
	if(exists(select charge from transport_detail where name = @name and city = @city))
	begin
		select charge from transport_detail where name = @name and city = @city
	end
	else
	begin
		select 0
	end
end
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[item_type_merge]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[item_type_merge](
	[id] [int] NULL,
	[itemtype] [varchar](100) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[item]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[item](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[companyid] [int] NULL,
	[price] [numeric](10, 2) NULL,
	[note] [nvarchar](500) NULL,
	[date] [datetime] NULL,
	[hits] [int] NULL,
	[itemtype_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[upper_item]'))
EXEC dbo.sp_executesql @statement = N'create trigger [dbo].[upper_item] on [dbo].[item]
after insert
as update item set [name] = upper([name]) , note = upper(note) where id in(select id from inserted)
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[transport_charge]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[transport_charge](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[transportid] [int] NOT NULL,
	[city] [nvarchar](100) NULL,
	[charge] [numeric](10, 2) NULL,
 CONSTRAINT [PK__trancport_charge__35BCFE0A] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[manual_recepit]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[manual_recepit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[recepitno] [int] NULL,
	[date] [datetime] NULL,
	[customerid] [int] NULL,
	[amount] [numeric](10, 2) NULL,
	[cd] [numeric](10, 2) NULL,
	[total] [numeric](10, 2) NULL,
	[bankid] [int] NULL,
	[checknumber] [nvarchar](20) NULL,
	[billno] [nvarchar](50) NULL,
	[through] [nvarchar](100) NULL,
	[note] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [uk_rno_date] UNIQUE NONCLUSTERED 
(
	[recepitno] ASC,
	[date] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[check_bounse_entry]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[check_bounse_entry](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customerid] [int] NULL,
	[bankid] [int] NULL,
	[amount] [numeric](10, 2) NULL,
	[checkno] [nvarchar](30) NULL,
	[date] [datetime] NULL,
	[bounce_charge] [numeric](10, 2) NULL,
	[recepitno] [int] NULL,
 CONSTRAINT [PK_check_bounse_entry] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[manual_bill_master]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[manual_bill_master](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[billno] [int] NULL,
	[customer] [int] NULL,
	[date] [datetime] NULL,
	[total] [numeric](10, 2) NULL,
	[expensesper] [float] NULL,
	[expenses] [numeric](10, 2) NULL,
	[transport] [nvarchar](100) NULL,
	[transportcherge] [numeric](10, 2) NULL,
	[transportnumber] [nvarchar](30) NULL,
	[grandtotal] [numeric](10, 2) NULL,
	[through] [nvarchar](100) NULL,
	[paymenttype] [nvarchar](30) NULL,
	[note] [nvarchar](200) NULL,
	[rgtotal] [numeric](12, 2) NULL,
	[iscd] [bit] NULL,
	[vatper] [float] NULL,
	[vat] [numeric](10, 2) NULL,
	[sgst] [numeric](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [uk_billno_date] UNIQUE NONCLUSTERED 
(
	[billno] ASC,
	[date] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[recepit]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[recepit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[recepitno] [int] NULL,
	[date] [datetime] NULL,
	[customerid] [int] NULL,
	[amount] [numeric](10, 2) NULL,
	[cd] [numeric](10, 2) NULL,
	[total] [numeric](10, 2) NULL,
	[manualrecepit] [nvarchar](50) NULL,
	[bankid] [int] NULL,
	[checknumber] [nvarchar](20) NULL,
	[billno] [nvarchar](50) NULL,
	[through] [nvarchar](100) NULL,
	[note] [nvarchar](200) NULL,
 CONSTRAINT [PK__recepit__3A4CA8FD] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__recepit__3B40CD36] UNIQUE NONCLUSTERED 
(
	[recepitno] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bill_detail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bill_detail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[billid] [int] NOT NULL,
	[company] [nvarchar](100) NULL,
	[Group] [nvarchar](50) NULL,
	[item] [nvarchar](150) NULL,
	[Meterdetail] [nvarchar](100) NULL,
	[qty] [int] NOT NULL,
	[meter] [nvarchar](500) NULL,
	[rate] [numeric](10, 2) NOT NULL,
	[amount] [numeric](10, 2) NULL,
	[isrg] [bit] NULL,
 CONSTRAINT [PK__bill_datail__24927208] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[manual_bill_detail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[manual_bill_detail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[billid] [int] NULL,
	[company] [nvarchar](100) NULL,
	[Group] [nvarchar](50) NULL,
	[item] [nvarchar](150) NULL,
	[meterdetail] [nvarchar](100) NULL,
	[qty] [int] NULL,
	[meter] [nvarchar](500) NULL,
	[rate] [numeric](10, 2) NULL,
	[amount] [numeric](10, 2) NULL,
	[isrg] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[add_manual_item]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[add_manual_item]
@billno int,
@company nvarchar(100),
@group nvarchar(50),
@item nvarchar(150),
@meterdetail nvarchar(100),
@qty int,
@meter nvarchar(500),
@rate numeric(10,2),
@amount numeric(10,2),
@metercount nchar(10),
@update nvarchar(10),
@isrg bit
as
begin
	if(@isrg = 0)
	begin
		declare @billid int , @itemtypeid int , @companyid int
	----company insertion and updation starts
		if(not exists(select * from company where name = @company))
		begin
			insert into company(name) values(@company)
		end
		select @companyid = id from company where name = @company
	----cumpany insertion and updation ends
	----itemtype insertion and updation starts
		if(not exists(select * from itemtype where typename = @group or shortcut = @group))
		begin
			insert into itemtype(typename , metercount) values(@group , @metercount)
		end
		else if(@metercount = ''YES'')
		begin
			update itemtype set metercount = @metercount where typename = @group or shortcut = @group
		end
		select @itemtypeid = id from itemtype where typename = @group or shortcut = @group
	----itemtype insertion and updation ends
	----item insertion and updation starts
		if(not exists(select * from item where name = @item and companyid = @companyid and itemtype_id = @itemtypeid))
		begin
			insert into item(name , companyid , price , date , itemtype_id) values(@item , @companyid , @rate , getdate() , @itemtypeid)
		end
		else if(@update = ''true'')
		begin
			update item set price = @rate where name = @item and companyid = @companyid and itemtype_id = @itemtypeid
		end
	----item insertion and updation complete
		select @billid = id from manual_bill_master where billno = @billno
		insert into manual_bill_detail(billid , company , [group] , item , meterdetail , qty , meter , rate , amount , isrg)
		values(@billid , @company ,@group, @item , @meterdetail , @qty , @meter , @rate ,@amount , @isrg)
	end
	else
	begin
		declare @bill int
		select @bill = id from manual_bill_master where billno = @billno
		insert into manual_bill_detail([group] , company , billid , item , qty , rate , amount , isrg)
		values(''RG'' , ''RG'' ,@bill , @item , @qty , @rate , @amount , @isrg)
	end
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[delete_type]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[delete_type]
@typename nvarchar(50)
as
begin
	declare @itemtypeid int
	select @itemtypeid = id from itemtype where typename = @typename
	if(not exists(select * from item where itemtype_id = @itemtypeid))
	begin
		delete from itemtype where typename = @typename
		select ''1''
	end
	else
	begin
		select ''0''
	end
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[item_detail]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[item_detail]
AS
SELECT     dbo.item.name AS [Item Name], dbo.company.name AS Company, dbo.item.price, dbo.item.note, dbo.item.date, dbo.itemtype.typename AS [Type Name], dbo.item.id, dbo.itemtype.shortcut, 
                      dbo.itemtype.Metercount, dbo.itemtype.hsnCode
FROM         dbo.item LEFT OUTER JOIN
                      dbo.itemtype ON dbo.item.itemtype_id = dbo.itemtype.id INNER JOIN
                      dbo.company ON dbo.item.companyid = dbo.company.id
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'item_detail', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[47] 4[14] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "item"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "itemtype"
            Begin Extent = 
               Top = 124
               Left = 227
               Bottom = 228
               Right = 387
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "company"
            Begin Extent = 
               Top = 1
               Left = 228
               Bottom = 120
               Right = 388
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'item_detail'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'item_detail', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'item_detail'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[update_item]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[update_item]
@itemid int,
@itemname nvarchar(50),
@company nvarchar(50),
@price numeric (10,2),
@note nvarchar(500),
@typename nvarchar(50)
as
begin
	if(exists(select * from company where name = @company) and @company<>'''' and @company != null)
	begin
		if(exists(select * from itemtype where typename = @typename))
		begin
			declare @itemtype_id  int , @company_id int
			select @company_id = id from company where [name] = @company
			if(@typename<>'''' or @typename<>null)
			begin
				select @itemtype_id = id from itemtype where typename = @typename
			end
			else
			begin
				set @itemtype_id = null
			end
			
			update item set [name] = @itemname , price = @price , note = @note ,  itemtype_id = @itemtype_id , companyid = @company_id where id = @itemid
			select ''1''
		end
		else
		begin
			select ''-1''
		end
	end
	else
	begin
		select ''-2''
	end
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROC_ITEM_TYPE_MERGE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [dbo].[PROC_ITEM_TYPE_MERGE]
@TYPE1 VARCHAR(100),
@TYPE2 VARCHAR(100)
AS
BEGIN
	--CHANGE TYPE1 TO TYPE2
	IF(EXISTS(SELECT * FROM ITEMTYPE WHERE TYPENAME = @TYPE1))
	BEGIN
		IF(NOT EXISTS(SELECT * FROM ITEMTYPE WHERE TYPENAME = @TYPE2))
		BEGIN
			INSERT INTO ITEMTYPE(TYPENAME) VALUES(@TYPE2)
		END
		DECLARE @TYPE1ID INT,@TYPE2ID INT
		SELECT @TYPE1ID = ID FROM ITEMTYPE WHERE TYPENAME = @TYPE1
		SELECT @TYPE2ID = ID FROM ITEMTYPE WHERE TYPENAME = @TYPE2

		UPDATE ITEM SET ITEMTYPE_ID = @TYPE2ID WHERE ITEMTYPE_ID = @TYPE1ID
		DELETE FROM ITEMTYPE WHERE TYPENAME = @TYPE1
	END
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[merge_type]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[merge_type]
@old_type_id varchar(50),
@new_type varchar(50)
as
begin
	if(not exists(select * from itemtype where typename = @new_type))
	begin
		insert into itemtype(typename) values(@new_type)
	end
	declare @new_type_id int
	select @new_type_id = id from itemtype where typename = @new_type
	update item set itemtype_id = @new_type_id where itemtype_id = @old_type_id
	delete from itemtype where id = @old_type_id
end
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[update_item_from_id]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[update_item_from_id]
@company varchar(50),
@type varchar(50),
@name varchar(100),
@price numeric(12,2),
@id int
as
begin
	declare @company_id int , @type_id int
	---------setting value of company_id 
	if(@company is null)
	begin
		set @company_id = null
	end
	else
	begin
		if(not exists(select * from company where [name] = @company))
		begin
			insert into company([name]) values(@company)
		end
		select @company_id = id from company where name = @company
	end
	----------setting value of type_id
	if(@type = null)
	begin
		set @type_id = null
	end
	else
	begin
		if(not exists(select * from [itemtype] where [typename] = @type))
		begin
			insert into [itemtype]([typename]) values(@type)
		end
		select @type_id = id from itemtype where typename = @type
	end
	----------Update Item
	if(not exists(select * from item where companyid = @company_id and itemtype_id = @type_id and name = @name))
	begin
		select 0
		return 0
	end
	else
	begin
		update item set [name] = @name , companyid = @company_id , itemtype_id = @type_id , price = @price ,date = getdate() where id = @id
		select 1
		return 1
	end
end
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[insert_item]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[insert_item]
@company varchar(50),
@type varchar(50),
@name varchar(100),
@price numeric(12,2)
as
begin
	declare @company_id int , @type_id int
	---------setting value of company_id 
	if(@company is null)
	begin
		set @company_id = null
	end
	else
	begin
		if(not exists(select * from company where [name] = @company))
		begin
			insert into company([name]) values(@company)
		end
		select @company_id = id from company where name = @company
	end
	----------setting value of type_id
	if(@type = null)
	begin
		set @type_id = null
	end
	else
	begin
		if(not exists(select * from [itemtype] where [typename] = @type))
		begin
			insert into [itemtype]([typename]) values(@type)
		end
		select @type_id = id from itemtype where typename = @type
	end
	----------Insert / Update Item
	if(not exists(select * from item where companyid = @company_id and itemtype_id = @type_id and name = @name))
	begin
		insert into item([name] , companyid , price , date , hits , itemtype_id)
		values(@name , @company_id , @price , getdate() , 0 , @type_id)
	end
	else
	begin
		update item set price = @price ,date = getdate() where [name] = @name and companyid = @company_id and itemtype_id = @type_id
	end
end
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[del_manual_billdetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[del_manual_billdetail]
@billno int,
@date nvarchar(20)
as
begin
	declare @billid int
	select @billid = id from manual_bill_master where billno = @billno and date = dbo.indvardate(@date)
	delete from manual_bill_detail where billid = @billid
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[manual_bill_del]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[manual_bill_del]
@billno int,
@date varchar(20)
as
begin
	declare @billid int
	select @billid = id from manual_bill_master where billno = @billno and date = dbo.indvardate(@date)
	delete from manual_bill_detail where id = @billid
	delete from manual_bill_master where id = @billid
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_manual_bill_detail]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[view_manual_bill_detail]
AS
SELECT     dbo.manual_bill_master.billno, dbo.manual_bill_detail.company, dbo.manual_bill_detail.[Group], dbo.manual_bill_detail.item, dbo.manual_bill_detail.Meterdetail, dbo.manual_bill_detail.qty, 
                      dbo.manual_bill_detail.meter, dbo.manual_bill_detail.rate, dbo.manual_bill_detail.amount, dbo.manual_bill_detail.isrg
FROM         dbo.manual_bill_detail INNER JOIN
                      dbo.manual_bill_master ON dbo.manual_bill_detail.billid = dbo.manual_bill_master.id
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[add_manual_recepit]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[add_manual_recepit]
@recepitno int,
@date nvarchar(10),
@customername nvarchar(100),
@city nvarchar(100),
@amount numeric(10,2),
@cd numeric(10,2),
@total numeric(10,2),
--manual recepitno not required
@bankname nvarchar(100),
@checknumber nvarchar(20),
@billno nvarchar(50),
@through nvarchar(100),
@note nvarchar(200)
as
begin
	--check for customer
	if(not exists(select * from customer where name = @customername and city = @city and type = ''CUSTOMER''))
	begin
		select ''0''
		return 0
	end
	--check for bank if its in input parameter
	if(@bankname <> '''' and not exists(select * from customer where name = @bankname and type = ''BANK''))
	begin
		select ''1''
		return 1
	end
	--initialize customer , bank id
	declare @customerid int , @bankid int
	select @customerid = id from customer where name = @customername and city = @city and type = ''CUSTOMER''
	if(@bankname <> '''')
	begin
		select @bankid = id from customer where name = @bankname and type = ''BANK''
	end
	else 
	begin
		set @bankid = null
	end
	--check for recepit no existance
	if(not exists(select * from manual_recepit where recepitno = @recepitno and date = dbo.indvardate(@date)))
	begin
		insert into manual_recepit(recepitno , date , customerid , amount , cd , total , bankid , checknumber , billno , through , note)
		values(@recepitno , dbo.indvardate(@date) , @customerid , @amount , @cd , @total ,@bankid , @checknumber , @billno , @through , @note)
	end
	else
	begin
		raiserror(''Receipt number date combination already exists'' , 16 , 1)
	end
	select ''2''
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[upd_manual_recepit]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[upd_manual_recepit]
@recepitno int,
@date nvarchar(10),
@customername nvarchar(100),
@city nvarchar(100),
@amount numeric(10,2),
@cd numeric(10,2),
@total numeric(10,2),
--manual recepitno not required
@bankname nvarchar(100),
@checknumber nvarchar(20),
@billno nvarchar(50),
@through nvarchar(100),
@note nvarchar(200),
@id int
as
begin
	--check for customer
	if(not exists(select * from customer where name = @customername and city = @city and type = ''CUSTOMER''))
	begin
		select ''0''
		return 0
	end
	--check for bank if its in input parameter
	if(@bankname <> '''' and not exists(select * from customer where name = @bankname and type = ''BANK''))
	begin
		select ''1''
		return 1
	end
	--initialize customer , bank id
	declare @customerid int , @bankid int
	select @customerid = id from customer where name = @customername and city = @city and type = ''CUSTOMER''
	if(@bankname <> '''')
	begin
		select @bankid = id from customer where name = @bankname and type = ''BANK''
	end
	else 
	begin
		set @bankid = null
	end
	--check for recepit no existance
	if(exists(select * from manual_recepit where id = @id))
	begin
		update manual_recepit set date = dbo.indvardate(@date) , customerid = @customerid , amount = @amount , cd = @cd , total = @total , billno = @billno , through = @through , 
		bankid = @bankid , checknumber = @checknumber , note = @note where id = @id
	end
	else
	begin
		raiserror(''Recepit cannot be updated'' , 16 , 1)
	end
	select ''2''
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_manual_Recepit]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_manual_Recepit]
AS
SELECT     dbo.manual_recepit.id, dbo.manual_recepit.recepitno, dbo.manual_recepit.date, dbo.customer.name, dbo.customer.city, dbo.manual_recepit.amount, dbo.manual_recepit.cd, dbo.manual_recepit.total, 
                      customer_1.name AS bank, customer_1.city AS bank_city, dbo.manual_recepit.checknumber, dbo.manual_recepit.billno, dbo.manual_recepit.through, 
                      dbo.manual_recepit.note
FROM         dbo.manual_recepit LEFT OUTER JOIN
                      dbo.customer ON dbo.manual_recepit.customerid = dbo.customer.id LEFT OUTER JOIN
                      dbo.customer AS customer_1 ON dbo.manual_recepit.bankid = customer_1.id
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[chk_manual_recepitno]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[chk_manual_recepitno]
@recepitno int,
@date nvarchar(20)
as
begin	
	if(exists(select * from manual_recepit where recepitno = @recepitno and date = dbo.indvardate(@date)))
	begin
		select 0
		return 0
	end
	if(exists(select * from recepit where manualrecepit is not null and manualrecepit <> ''''and (manualrecepit like(convert(varchar , @recepitno)) or convert(varchar , @recepitno) like(manualrecepit) and date = dbo.indvardate(@date))))
	begin
		select 0
		return 0
	end
	select 1
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ledger]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[ledger]
AS
SELECT		name + '' '' + isnull(city,'''') as name ,date,''Opening balance'' as detail,NULL as exp,openbalance as payment,NULL as recepit 
from		customer
where		name is not null
union
SELECT     c.name + '' '' + ISNULL(c.city, '''') AS name, bm.date, ''Bill No. '' + CONVERT(nvarchar, bm.billno) AS detail, dbo.blank_on_cd(iscd , bm.expenses) AS exp, bm.grandtotal AS payment, NULL 
                      AS recepit
FROM         dbo.bill_master AS bm LEFT OUTER JOIN
                      dbo.customer AS c ON bm.customer = c.id
WHERE     (bm.paymenttype = ''NET AMOUNT TO PAY'') AND (c.name IS NOT NULL)
UNION
SELECT     c.name + '' '' + ISNULL(c.city, '''') AS name, r.date, ''R.No. '' + dbo.manual_or_original_receiptno(r.recepitno , manualrecepit) AS detail, NULL AS exp, NULL AS payment, r.total AS recepit
FROM         dbo.recepit AS r LEFT OUTER JOIN
                      dbo.customer AS c ON r.customerid = c.id
WHERE     (r.bankid IS NULL OR
                      r.bankid = '''') AND (c.name IS NOT NULL)
UNION
SELECT     c.name + '' '' + ISNULL(c.city, '''') AS name, r.date, ''R.No. '' + dbo.manual_or_original_receiptno(r.recepitno , manualrecepit) + '' Chk No. '' + r.checknumber AS detail, NULL AS exp, NULL AS payment, 
                      r.total AS recepit
FROM         dbo.recepit AS r LEFT OUTER JOIN
                      dbo.customer AS c ON r.customerid = c.id
WHERE     (r.bankid IS NOT NULL OR
                      r.bankid <> '''') AND (c.name IS NOT NULL)
UNION
SELECT     c.name, r.date, ''CHK No. '' + r.checknumber AS detail, NULL AS exp, r.total AS payment, NULL AS recepit
FROM         dbo.recepit AS r LEFT OUTER JOIN
                      dbo.customer AS c ON r.bankid = c.id
WHERE     (r.bankid IS NOT NULL OR
                      r.bankid <> '''') AND (c.name IS NOT NULL)
UNION
SELECT     c.name + '' '' + c.city AS name, cbe.date, ''Chk Bounse '' + cbe.checkno AS detail, NULL AS exp, cbe.amount AS payment, NULL AS recepit
FROM         dbo.check_bounse_entry AS cbe LEFT OUTER JOIN
                      dbo.customer AS c ON cbe.customerid = c.id
UNION
SELECT     c.name + '' '' + c.city AS name, cbe.date, ''Chk Bounse Panelty '' + cbe.checkno AS detail, NULL AS exp, cbe.bounce_charge AS payment, NULL AS recepit
FROM         dbo.check_bounse_entry AS cbe LEFT OUTER JOIN
                      dbo.customer AS c ON cbe.customerid = c.id
UNION
SELECT     c.name, cbe.date, ''Chk Bounse '' + cbe.checkno AS detail, NULL AS exp, NULL AS payment, cbe.amount AS recepit
FROM         dbo.check_bounse_entry AS cbe LEFT OUTER JOIN
                      dbo.customer AS c ON cbe.bankid = c.id
UNION
-------------------------------------------------------------------------------------
SELECT     c.name + '' '' + ISNULL(c.city, '''') AS name, bm.date, ''Bill No. '' + ''M''+CONVERT(nvarchar, bm.billno) AS detail, dbo.blank_on_cd(iscd , bm.expenses) AS exp, bm.grandtotal AS payment, NULL 
                      AS recepit
FROM         dbo.manual_bill_master AS bm LEFT OUTER JOIN
                      dbo.customer AS c ON bm.customer = c.id
WHERE     (bm.paymenttype = ''NET AMOUNT TO PAY'') AND (c.name IS NOT NULL)
UNION
SELECT     c.name + '' '' + ISNULL(c.city, '''') AS name, r.date, ''R.No. '' + ''M''+CONVERT(nvarchar, r.recepitno) AS detail, NULL AS exp, NULL AS payment, r.total AS recepit
FROM         dbo.manual_recepit AS r LEFT OUTER JOIN
                      dbo.customer AS c ON r.customerid = c.id
WHERE     (r.bankid IS NULL OR
                      r.bankid = '''') AND (c.name IS NOT NULL)
UNION
SELECT     c.name + '' '' + ISNULL(c.city, '''') AS name, r.date, ''R.No. '' + ''M''+CONVERT(nvarchar, r.recepitno) + '' Chk No. '' + r.checknumber AS detail, NULL AS exp, NULL AS payment, 
                      r.total AS recepit
FROM         dbo.manual_recepit AS r LEFT OUTER JOIN
                      dbo.customer AS c ON r.customerid = c.id
WHERE     (r.bankid IS NOT NULL OR
                      r.bankid <> '''') AND (c.name IS NOT NULL)
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'ledger', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4[30] 2[40] 3) )"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 3
   End
   Begin DiagramPane = 
      PaneHidden = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 5
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ledger'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'ledger', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ledger'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[intrest]'))
EXEC dbo.sp_executesql @statement = N'CREATE view [dbo].[intrest]
as
SELECT     c.name + '' '' + ISNULL(c.city, '''') AS name, bm.date, ''Bill No. '' + CONVERT(nvarchar, bm.billno) AS detail, bm.expenses AS exp, bm.grandtotal AS payment, NULL 
                      AS recepit, DATEDIFF(day, bm.date, GETDATE()) - 60 AS datedifference
FROM         dbo.bill_master AS bm LEFT OUTER JOIN
                      dbo.customer AS c ON bm.customer = c.id
WHERE     (bm.paymenttype = ''NET AMOUNT TO PAY'')
UNION
SELECT     c.name + '' '' + ISNULL(c.city, '''') AS name, r.date, ''R.No. '' + dbo.manual_or_original_receiptno(r.recepitno , manualrecepit) AS detail, NULL AS exp, NULL AS payment, r.total AS recepit, 
                      DATEDIFF(day, r.date, GETDATE()) AS datedifference
FROM         dbo.recepit AS r LEFT OUTER JOIN
                      dbo.customer AS c ON r.customerid = c.id
WHERE     (r.bankid IS NULL) OR
                      (r.bankid = '''')
UNION
SELECT     c.name + '' '' + ISNULL(c.city, '''') AS name, r.date, ''R.No. '' + dbo.manual_or_original_receiptno(r.recepitno , manualrecepit) + '' Chk No. '' + r.checknumber AS detail, NULL AS exp, NULL AS payment, 
                      r.total AS recepit, DATEDIFF(day, r.date, GETDATE()) AS datedifference
FROM         dbo.recepit AS r LEFT OUTER JOIN
                      dbo.customer AS c ON r.customerid = c.id
WHERE     (r.bankid IS NOT NULL OR
                      r.bankid <> '''') AND (r.checknumber NOT IN
                          (SELECT     checkno AS checknumber
                            FROM          dbo.check_bounse_entry))
UNION
SELECT     c.name + '' '' + c.city AS name, r1.date, ''Chk Bounse Panelty '' + cbe.checkno AS detail, NULL AS exp, cbe.bounce_charge AS payment, NULL AS recepit, DATEDIFF(day, 
                      r1.date, GETDATE()) AS datedifference
FROM         dbo.check_bounse_entry AS cbe LEFT OUTER JOIN
                      dbo.customer AS c ON cbe.customerid = c.id LEFT OUTER JOIN
                      dbo.recepit AS r1 ON r1.checknumber = cbe.checkno
WHERE     (r1.checknumber IS NOT NULL)
UNION
-----------------------------------------------------------------------------------------------------------
SELECT     c.name + '' '' + ISNULL(c.city, '''') AS name, bm.date, ''Bill No. M'' + CONVERT(nvarchar, bm.billno) AS detail, bm.expenses AS exp, bm.grandtotal AS payment, NULL 
                      AS recepit, DATEDIFF(day, bm.date, GETDATE()) - 60 AS datedifference
FROM         dbo.manual_bill_master AS bm LEFT OUTER JOIN
                      dbo.customer AS c ON bm.customer = c.id
WHERE     (bm.paymenttype = ''NET AMOUNT TO PAY'')
UNION
SELECT     c.name + '' '' + ISNULL(c.city, '''') AS name, r.date, ''R.No. M'' + CONVERT(nvarchar, r.recepitno) AS detail, NULL AS exp, NULL AS payment, r.total AS recepit, 
                      DATEDIFF(day, r.date, GETDATE()) AS datedifference
FROM         dbo.manual_recepit AS r LEFT OUTER JOIN
                      dbo.customer AS c ON r.customerid = c.id
WHERE     (r.bankid IS NULL) OR
                      (r.bankid = '''')
UNION
SELECT     c.name + '' '' + ISNULL(c.city, '''') AS name, r.date, ''R.No. M'' + CONVERT(nvarchar, r.recepitno) + '' Chk No. '' + r.checknumber AS detail, NULL AS exp, NULL AS payment, 
                      r.total AS recepit, DATEDIFF(day, r.date, GETDATE()) AS datedifference
FROM         dbo.manual_recepit AS r LEFT OUTER JOIN
                      dbo.customer AS c ON r.customerid = c.id
WHERE     (r.bankid IS NOT NULL OR
                      r.bankid <> '''') AND (r.checknumber NOT IN
                          (SELECT     checkno AS checknumber
                            FROM          dbo.check_bounse_entry))
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ledger_showall]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[ledger_showall]
AS
SELECT     name AS n, city AS c, id, name + '' '' + ISNULL(city, '''') AS name, date, ''Opening balance'' AS transtype, '''' AS detail, NULL AS exp, openbalance AS payment, NULL AS recepit
FROM         dbo.customer
WHERE     (name IS NOT NULL) AND (openbalance <> 0)
UNION
SELECT     c.name AS n, c.city AS c, bm.id, c.name + '' '' + ISNULL(c.city, '''') AS name, bm.date, ''Bill'' AS transtype, CONVERT(nvarchar, bm.billno) AS detail, dbo.blank_on_cd(bm.iscd, bm.expenses) AS exp, 
                      bm.grandtotal AS payment, NULL AS recepit
FROM         dbo.bill_master AS bm LEFT OUTER JOIN
                      dbo.customer AS c ON bm.customer = c.id
WHERE     (c.name IS NOT NULL) AND (bm.paymenttype = ''NET AMOUNT TO PAY'')
UNION
SELECT     c.name AS n, c.city AS c, r.id, c.name + '' '' + ISNULL(c.city, '''') AS Expr1, r.date, ''Recepit'' AS transtype, dbo.manual_or_original_receiptno(r.recepitno, r.manualrecepit) AS detail, NULL AS exp, NULL 
                      AS payment, r.total AS recepit
FROM         dbo.recepit AS r LEFT OUTER JOIN
                      dbo.customer AS c ON r.customerid = c.id
WHERE     (c.name IS NOT NULL) AND (r.bankid IS NULL OR
                      r.bankid = '''')
UNION
SELECT     c.name AS n, c.city AS c, r.id, c.name + '' '' + ISNULL(c.city, '''') AS name, r.date, ''RecepitBank'' AS transtype, dbo.manual_or_original_receiptno(r.recepitno, r.manualrecepit) 
                      + '' Chk No. '' + r.checknumber AS detail, NULL AS exp, NULL AS payment, r.total AS recepit
FROM         dbo.recepit AS r LEFT OUTER JOIN
                      dbo.customer AS c ON r.customerid = c.id
WHERE     (c.name IS NOT NULL) AND (r.bankid IS NOT NULL OR
                      r.bankid <> '''')
UNION
SELECT     c.name AS n, c.city AS c, r.id, c.name, r.date, ''RecepitBank'' AS transtype, r.checknumber AS detail, NULL AS exp, r.total AS payment, NULL AS recepit
FROM         dbo.recepit AS r LEFT OUTER JOIN
                      dbo.customer AS c ON r.bankid = c.id
WHERE     (c.name IS NOT NULL) AND (r.bankid IS NOT NULL OR
                      r.bankid <> '''')
UNION
SELECT     c.name AS n, c.city AS c, cbe.id, c.name + '' '' + c.city AS Expr1, cbe.date, ''Chk Bounse '' AS transtype, cbe.checkno AS detail, NULL AS exp, cbe.amount AS payment, NULL AS recepit
FROM         dbo.check_bounse_entry AS cbe LEFT OUTER JOIN
                      dbo.customer AS c ON cbe.customerid = c.id
UNION
SELECT     c.name AS n, c.city AS c, cbe.id, c.name + '' '' + c.city AS Expr1, cbe.date, ''Chk Bounse Panelty '' AS transtype, cbe.checkno AS detail, NULL AS exp, cbe.bounce_charge AS payment, NULL 
                      AS recepit
FROM         dbo.check_bounse_entry AS cbe LEFT OUTER JOIN
                      dbo.customer AS c ON cbe.customerid = c.id
UNION
SELECT     c.name AS n, c.city AS c, cbe.id, c.name, cbe.date, ''Chk Bounse '' AS transtype, cbe.checkno AS detail, NULL AS exp, NULL AS payment, cbe.amount AS recepit
FROM         dbo.check_bounse_entry AS cbe LEFT OUTER JOIN
                      dbo.customer AS c ON cbe.bankid = c.id
UNION
SELECT     ''CASH'' AS n, '''' AS city, bm.id, ''CASH'' AS Expr1, bm.date, c.name + '' '' + ISNULL(c.city, '''') AS transtype, CONVERT(nvarchar, bm.billno) AS detail, CONVERT(nvarchar, bm.expenses) AS exp, 
                      bm.grandtotal AS payment, bm.grandtotal AS recepit
FROM         dbo.bill_master AS bm LEFT OUTER JOIN
                      dbo.customer AS c ON bm.customer = c.id
WHERE     (c.name IS NOT NULL) AND (bm.paymenttype = ''PAID BY CASH'')
UNION
SELECT     c.name AS n, c.city AS c, bm.id, c.name + '' '' + ISNULL(c.city, '''') AS Expr1, bm.date, ''Bill'' AS transtype, ''M'' + CONVERT(nvarchar, bm.billno) AS detail, dbo.blank_on_cd(bm.iscd, bm.expenses) AS exp, 
                      bm.grandtotal AS payment, NULL AS recepit
FROM         dbo.manual_bill_master AS bm LEFT OUTER JOIN
                      dbo.customer AS c ON bm.customer = c.id
WHERE     (c.name IS NOT NULL) AND (bm.paymenttype = ''NET AMOUNT TO PAY'')
UNION
SELECT     c.name AS n, c.city AS c, r.id, c.name + '' '' + ISNULL(c.city, '''') AS Expr1, r.date, ''Recepit'' AS transtype, ''M'' + CONVERT(nvarchar, r.recepitno) AS detail, NULL AS exp, NULL AS payment, 
                      r.total AS recepit
FROM         dbo.manual_recepit AS r LEFT OUTER JOIN
                      dbo.customer AS c ON r.customerid = c.id
WHERE     (c.name IS NOT NULL) AND (r.bankid IS NULL OR
                      r.bankid = '''')
UNION
SELECT     c.name AS n, c.city AS c, r.id, c.name + '' '' + ISNULL(c.city, '''') AS name, r.date, ''RecepitBank'' AS transtype, ''M'' + CONVERT(nvarchar, r.recepitno) + '' Chk No. '' + r.checknumber AS detail, NULL 
                      AS exp, NULL AS payment, r.total AS recepit
FROM         dbo.manual_recepit AS r LEFT OUTER JOIN
                      dbo.customer AS c ON r.customerid = c.id
WHERE     (c.name IS NOT NULL) AND (r.bankid IS NOT NULL OR
                      r.bankid <> '''')
UNION
SELECT     ''CASH'' AS n, '''' AS city, bm.id, ''CASH'' AS name, bm.date, c.name + '' '' + ISNULL(c.city, '''') AS transtype, ''M'' + CONVERT(nvarchar, bm.billno) AS detail, CONVERT(varchar, bm.expenses) AS exp, 
                      bm.grandtotal AS payment, bm.grandtotal AS recepit
FROM         dbo.manual_bill_master AS bm LEFT OUTER JOIN
                      dbo.customer AS c ON bm.customer = c.id
WHERE     (c.name IS NOT NULL) AND (bm.paymenttype = ''PAID BY CASH'')
UNION
SELECT     ''VAT'' AS n, '''' AS city, bm.id, ''VAT'' AS name, bm.date, c.name + '' '' + ISNULL(c.city, '''') AS transtype, CONVERT(nvarchar, bm.billno) AS detail, ''0'' AS exp, bm.vat AS payment, 0 AS recepit
FROM         dbo.bill_master AS bm LEFT OUTER JOIN
                      dbo.customer AS c ON bm.customer = c.id
WHERE     (c.name IS NOT NULL) AND (bm.vatper <> 0) AND (bm.date < ''2017-07-01'')
UNION
SELECT     ''CGST'' AS n, '''' AS city, bm.id, ''CGST'' AS name, bm.date, c.name + '' '' + ISNULL(c.city, '''') AS transtype, CONVERT(nvarchar, bm.billno) AS detail, ''0'' AS exp, bm.vat AS payment, 0 AS recepit
FROM         dbo.bill_master AS bm LEFT OUTER JOIN
                      dbo.customer AS c ON bm.customer = c.id
WHERE     (c.name IS NOT NULL) AND (bm.vatper <> 0) AND (bm.date >= ''2017-07-01'')
UNION
SELECT     ''SGST'' AS n, '''' AS city, bm.id, ''SGST'' AS name, bm.date, c.name + '' '' + ISNULL(c.city, '''') AS transtype, CONVERT(nvarchar, bm.billno) AS detail, ''0'' AS exp, bm.sgst AS payment, 0 AS recepit
FROM         dbo.bill_master AS bm LEFT OUTER JOIN
                      dbo.customer AS c ON bm.customer = c.id
WHERE     (c.name IS NOT NULL) AND (bm.vatper <> 0) AND (bm.date >= ''2017-07-01'')
UNION
SELECT     ''VAT'' AS n, '''' AS city, bm.id, ''VAT'' AS name, bm.date, c.name + '' '' + ISNULL(c.city, '''') AS transtype, CONVERT(nvarchar, bm.billno) AS detail, ''0'' AS exp, bm.vat AS payment, 0 AS recepit
FROM         dbo.manual_bill_master AS bm LEFT OUTER JOIN
                      dbo.customer AS c ON bm.customer = c.id
WHERE     (c.name IS NOT NULL) AND (bm.vatper <> 0) AND (bm.date < ''2017-07-01'')
UNION
SELECT     ''CGST'' AS n, '''' AS city, bm.id, ''CGST'' AS name, bm.date, c.name + '' '' + ISNULL(c.city, '''') AS transtype, CONVERT(nvarchar, bm.billno) AS detail, ''0'' AS exp, bm.vat AS payment, 0 AS recepit
FROM         dbo.manual_bill_master AS bm LEFT OUTER JOIN
                      dbo.customer AS c ON bm.customer = c.id
WHERE     (c.name IS NOT NULL) AND (bm.vatper <> 0) AND (bm.date >= ''2017-07-01'')
UNION
SELECT     ''SGST'' AS n, '''' AS city, bm.id, ''SGST'' AS name, bm.date, c.name + '' '' + ISNULL(c.city, '''') AS transtype, CONVERT(nvarchar, bm.billno) AS detail, ''0'' AS exp, bm.sgst AS payment, 0 AS recepit
FROM         dbo.manual_bill_master AS bm LEFT OUTER JOIN
                      dbo.customer AS c ON bm.customer = c.id
WHERE     (c.name IS NOT NULL) AND (bm.vatper <> 0) AND (bm.date >= ''2017-07-01'')
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'ledger_showall', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4[30] 2[40] 3) )"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 3
   End
   Begin DiagramPane = 
      PaneHidden = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 5
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ledger_showall'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'ledger_showall', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ledger_showall'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[summary]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[summary]
AS
SELECT     bm.billno AS id, c.name + '' '' + ISNULL(c.city, '''') AS name, bm.date, dbo.billorcash(bm.paymenttype) + CONVERT(nvarchar, bm.billno) AS detail, bm.expenses AS exp, bm.grandtotal AS payment, NULL
                       AS recepit, dbo.return_if_zero_or_null(bm.iscd, bm.expenses) AS expense, dbo.return_if_non_zero_non_null(bm.iscd, bm.expenses) AS cd, bm.vat, bm.transportcherge AS transport, 
                      bm.total AS bill_total, NULL AS recepit_total, bm.sgst
FROM         dbo.bill_master AS bm LEFT OUTER JOIN
                      dbo.customer AS c ON bm.customer = c.id
WHERE     (c.name IS NOT NULL)
UNION
SELECT     r.recepitno AS id, c.name + '' '' + ISNULL(c.city, '''') AS name, r.date, ''R.No. '' + dbo.manual_or_original_receiptno(r.recepitno, r.manualrecepit) AS detail, NULL AS exp, NULL AS payment, 
                      r.amount AS recepit, NULL AS expense, r.cd, NULL AS vat, NULL AS transport, NULL AS bill_total, r.total AS recepit_total, NULL AS sgst
FROM         dbo.recepit AS r LEFT OUTER JOIN
                      dbo.customer AS c ON r.customerid = c.id
WHERE     (r.bankid IS NULL OR
                      r.bankid = '''') AND (c.name IS NOT NULL)
UNION
SELECT     r.recepitno AS id, c.name + '' '' + ISNULL(c.city, '''') AS name, r.date, ''R.No. '' + dbo.manual_or_original_receiptno(r.recepitno, r.manualrecepit) + '' Chk No. '' + r.checknumber AS detail, NULL 
                      AS exp, NULL AS payment, r.amount AS recepit, NULL AS expense, r.cd, NULL AS vat, NULL AS transport, NULL AS bill_total, r.total AS recepit_total, NULL AS sgst
FROM         dbo.recepit AS r LEFT OUTER JOIN
                      dbo.customer AS c ON r.customerid = c.id
WHERE     (r.bankid IS NOT NULL OR
                      r.bankid <> '''') AND (c.name IS NOT NULL)
UNION
SELECT     r.recepitno AS id, c.name, r.date, ''CHK No. '' + r.checknumber AS detail, NULL AS exp, r.amount AS payment, NULL AS recepit, NULL AS expense, r.cd, NULL AS vat, NULL AS transport, NULL 
                      AS bill_total, r.total AS recepit_total, NULL AS sgst
FROM         dbo.recepit AS r LEFT OUTER JOIN
                      dbo.customer AS c ON r.bankid = c.id
WHERE     (r.bankid IS NOT NULL OR
                      r.bankid <> '''') AND (c.name IS NOT NULL)
UNION
SELECT     cbe.recepitno AS id, c.name + '' '' + c.city AS name, cbe.date, ''Chk Bounse '' + cbe.checkno AS detail, NULL AS exp, cbe.amount AS payment, NULL AS recepit, NULL AS expense, NULL AS cd, NULL 
                      AS vat, NULL AS transport, NULL AS bill_total, NULL AS recepit_total, NULL AS sgst
FROM         dbo.check_bounse_entry AS cbe LEFT OUTER JOIN
                      dbo.customer AS c ON cbe.customerid = c.id
UNION
SELECT     cbe.recepitno AS id, c.name + '' '' + c.city AS name, cbe.date, ''Chk Bounse Panelty '' + cbe.checkno AS detail, NULL AS exp, cbe.bounce_charge AS payment, NULL AS recepit, NULL AS expense, NULL 
                      AS cd, NULL AS vat, NULL AS transport, NULL AS bill_total, NULL AS recepit_total, NULL AS sgst
FROM         dbo.check_bounse_entry AS cbe LEFT OUTER JOIN
                      dbo.customer AS c ON cbe.customerid = c.id
UNION
SELECT     cbe.recepitno AS id, c.name, cbe.date, ''Chk Bounse '' + cbe.checkno AS detail, NULL AS exp, NULL AS payment, cbe.amount AS recepit, NULL AS expense, NULL AS cd, NULL AS vat, NULL 
                      AS transport, NULL AS bill_total, NULL AS recepit_total, NULL AS sgst
FROM         dbo.check_bounse_entry AS cbe LEFT OUTER JOIN
                      dbo.customer AS c ON cbe.bankid = c.id
UNION
SELECT     bm.billno AS id, c.name + '' '' + ISNULL(c.city, '''') AS name, bm.date, dbo.billorcash(bm.paymenttype) + ''M'' + CONVERT(nvarchar, bm.billno) AS detail, bm.expenses AS exp, 
                      bm.grandtotal AS payment, NULL AS recepit, dbo.return_if_zero_or_null(bm.iscd, bm.expenses) AS expense, dbo.return_if_non_zero_non_null(bm.iscd, bm.expenses) AS cd, bm.vat, 
                      bm.transportcherge AS transport, bm.total AS bill_total, NULL AS recepit_total, bm.sgst
FROM         dbo.manual_bill_master AS bm LEFT OUTER JOIN
                      dbo.customer AS c ON bm.customer = c.id
WHERE     (c.name IS NOT NULL)
UNION
SELECT     r.recepitno AS id, c.name + '' '' + ISNULL(c.city, '''') AS name, r.date, ''R.No. M'' + CONVERT(nvarchar, r.recepitno) AS detail, NULL AS exp, NULL AS payment, r.amount AS recepit, NULL AS expense, 
                      r.cd, NULL AS vat, NULL AS transport, NULL AS bill_total, r.total AS recepit_total, NULL AS sgst
FROM         dbo.manual_recepit AS r LEFT OUTER JOIN
                      dbo.customer AS c ON r.customerid = c.id
WHERE     (r.bankid IS NULL OR
                      r.bankid = '''') AND (c.name IS NOT NULL)
UNION
SELECT     r.recepitno AS id, c.name + '' '' + ISNULL(c.city, '''') AS name, r.date, ''R.No. M'' + CONVERT(nvarchar, r.recepitno) + '' Chk No. '' + r.checknumber AS detail, NULL AS exp, NULL AS payment, 
                      r.amount AS recepit, NULL AS expense, r.cd, NULL AS vat, NULL AS transport, NULL AS bill_total, r.total AS recepit_total, NULL AS sgst
FROM         dbo.manual_recepit AS r LEFT OUTER JOIN
                      dbo.customer AS c ON r.customerid = c.id
WHERE     (r.bankid IS NOT NULL OR
                      r.bankid <> '''') AND (c.name IS NOT NULL)
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'summary', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4[30] 2[40] 3) )"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 3
   End
   Begin DiagramPane = 
      PaneHidden = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 5
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'summary'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'summary', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'summary'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[getMeterCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[getMeterCount]
@company nvarchar(100),
@group nvarchar(100),
@item nvarchar(100)
as
begin
	if(exists(select * from itemtype where typename = @group))
	begin
		select isnull(metercount , '''') from itemtype where (typename = @group)
	end
	else
	begin
		select ''''
	end
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[check_manual_billno]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[check_manual_billno]
@billno int,
@date varchar(20)
as
begin
	if(exists(select * from manual_bill_master where billno = @billno and date = dbo.indvardate(@date)))
	begin
		select 1 --bill number already exists
	end
	else
	begin
		select 0-- Bill Number dosenot exists
	end
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[add_customer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[add_customer]
@name nvarchar(100),
@note nvarchar(500),
@address nvarchar(200),
@city nvarchar(100),
@pincode nvarchar(6),
@phno_1 nvarchar(50),
@phno_2 nvarchar(50),
@openbalance numeric(10,2),
@date nvarchar(10),
@type nvarchar(30),
@accountnumber nvarchar(30),
@accounttype nvarchar(30),
@select int
as
begin
	declare @num as int
	if(not exists(select * from customer where name = @name and city = @city))
	begin
		insert into customer(name , note , address , city , pincode , phno_1 , phno_2 , openbalance , date , type , accountnumber , accounttype) 
				values(@name , @note , @address , @city , @pincode , @phno_1 , @phno_2 , @openbalance , dbo.indvardate(@date) , @type , @accountnumber , @accounttype)
	end
	select @num = id from customer where name = @name and city = @city
	if(@select = 1)
	begin
		select @num
	end
	return @num
end
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[get_manual_billdetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[get_manual_billdetail]
@billno nvarchar(50),
@date nvarchar(15)
as
begin
	if(exists(select * from manual_bill_master where convert(varchar,billno) = @billno and date = dbo.indvardate(@date)))
	begin
		select billno , name , city ,dbo.inddatevar(date) , total , expenses , transport , transportcharge , grandtotal ,datediff(day , date , dbo.indvardate(@date)) as [datediff] from view_manual_bill_master where billno = @billno and date = dbo.indvardate(@date)
	end
	else
	begin
		select 0
	end
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[create_city_closebalance]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[create_city_closebalance]
@date varchar(20),
@city varchar(100),
@like varchar(120)
as
begin
	declare @balancedate datetime
	set @balancedate = dbo.indvardate(@date)
	select 
		l.n as Name,
		l.c as City,
		isnull(sum(isnull(payment,0)),0)-isnull(sum(isnull(recepit,0)),0) as ClosingBalance
	from 
		ledger_showall l
	where 
		c in(select city from line where [group] = @city) and 
		l.date<=@balancedate and
		l.n like(@like)
	group by 
		l.n,
		l.c
	union
	select name,city,openbalance from customer where name + city not in (select distinct(n+c) from ledger_showall l where l.date<=@balancedate) and city = @city and name like(@like)
end
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[create_group_closebalance]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[create_group_closebalance]
@date varchar(20),
@like varchar(120)
as
begin
	declare @balancedate datetime
	set @balancedate = dbo.indvardate(@date)
	select 
		l1.[group], 
		--sum(isnull(payment,0)) as payment,sum(isnull(recepit,0)) as recepit,
		--balance as openbalance,
		isnull(sum(isnull(payment,0)),0) - isnull(sum(isnull(recepit,0)),0) as [closing balance]
	from ledger_showall l full outer join line l1 on l1.city = l.c
	where 
		(l.date <= @balancedate or date is null )and
		l1.[group] like(@like)
	group by 
		l1.[group]--,n,openbalance
	union
	select [group], isnull(sum(isnull(openbalance,0)),0) 
	from line l join customer c on c.city = l.city 
	where l.city not in(select c from ledger_showall  where date <= @balancedate) and [group] like(@like) group by [group]
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[create_closebalance]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[create_closebalance]
@date varchar(20),
@city varchar(100),
@like varchar(120)
as
begin
	declare @balancedate datetime
	set @balancedate = dbo.indvardate(@date)
	select 
		l.n as Name,
		l.c as City,
		isnull(sum(isnull(payment,0)),0)-isnull(sum(isnull(recepit,0)),0) as ClosingBalance
	from 
		ledger_showall l
	where 
		c in(select city from line where [group] like @city) and 
		l.date<=@balancedate and
		l.n like(@like)
	group by 
		l.n,
		l.c
	union
	select name,city,openbalance from customer where name + city not in (select distinct(n+c) from ledger_showall l where l.date<=@balancedate) and city like @city and name like(@like) order by city, name
end
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[get_billdetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[get_billdetail]
@billno nvarchar(50),
@date nvarchar(15)
as
begin
	if(exists(select * from bill_master where convert(varchar,billno) = @billno))
	begin
		select billno , name , city ,dbo.inddatevar(date) , total , expenses , transport , transportcharge , grandtotal ,datediff(day , date , dbo.indvardate(@date)) as [datediff] from view_bill_master where billno = @billno
	end
	else
	begin
		select 0
	end
end

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[add_recepit]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[add_recepit]
@recepitno int,
@date nvarchar(10),
@customername nvarchar(100),
@city nvarchar(100),
@amount numeric(10,2),
@cd numeric(10,2),
@total numeric(10,2),
@manualrecepit nvarchar(50),
@bankname nvarchar(100),
@checknumber nvarchar(20),
@billno nvarchar(50),
@through nvarchar(100),
@note nvarchar(200)
as
begin
	if(not exists(select * from customer where name = @customername and city = @city and type = ''CUSTOMER''))
	begin
		select ''0''
		return 0
	end
	if(@bankname <> '''' and not exists(select * from customer where name = @bankname and type = ''BANK''))
	begin
		select ''1''
		return 1
	end
	declare @customerid int , @bankid int
	select @customerid = id from customer where name = @customername and city = @city and type = ''CUSTOMER''
	if(@bankname <> '''')
	begin
		select @bankid = id from customer where name = @bankname and type = ''BANK''
	end
	else 
	begin
		set @bankid = null
	end
	if(not exists(select * from recepit where recepitno = @recepitno))
	begin
		insert into recepit(recepitno , date , customerid , amount , cd , total , manualrecepit , bankid , checknumber , billno , through , note)
		values(@recepitno , dbo.indvardate(@date) , @customerid , @amount , @cd , @total , @manualrecepit , @bankid , @checknumber , @billno , @through , @note)
	end
	else
	begin
		update recepit set date = dbo.indvardate(@date) , customerid = @customerid , amount = @amount , cd = @cd , total = @total , billno = @billno , through = @through , 
		manualrecepit = @manualrecepit , bankid = @bankid , checknumber = @checknumber , note = @note where recepitno = @recepitno
	end
	select ''2''
end




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[update_customer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[update_customer]	
@name nvarchar(100),
@note nvarchar(500),
@address nvarchar(200),
@city nvarchar(100),
@pincode nvarchar(6),
@phno_1 nvarchar(50),
@phno_2 nvarchar(50),
@openbalance numeric(10,2),
@date nvarchar(20),
@type nvarchar(30),
@accountnumber nvarchar(30),
@accounttype nvarchar(30),
@id int
as
begin
	if(not exists(select * from customer where name = @name and city = @city and id != @id))
	begin
		update customer set name = @name , city = @city , note = @note , address = @address , pincode = @pincode , phno_1 = @phno_1 , 
		phno_2 = @phno_2 , openbalance = @openbalance , date = dbo.indvardate(@date) , type = @type ,
		accountnumber = @accountnumber , accounttype = @accounttype where id = @id
	end
	else
	begin
		raiserror(''Customer Already Exists'' , 16 , 1)	
	end
end

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[check_billdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE procedure [dbo].[check_billdate]
@billno int,
@date nvarchar(20),
@isupdate bit = 0
as
begin
	if(@isupdate = 0 and exists(select * from bill_master where billno = @billno and customer is not null))
	begin
		select ''0''
		return 0
	end
	declare @mindate datetime , @maxdate datetime
	select @mindate = max(date) from bill_master where billno<@billno and customer is not null
	select @maxdate = min(date) from bill_master where billno>@billno and customer is not null
	if(@maxdate is null)
	begin
		set @maxdate = @mindate
	end
	if(dbo.indvardate(@date) >= @maxdate or (dbo.indvardate(@date) between @mindate and @maxdate))
	begin
		select ''1''
		return 1
	end
	else
	begin
		select dbo.inddatevar(@mindate) as mindate , dbo.inddatevar(@maxdate) as maxdate
	end
end


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[add_checkbounceentyr]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[add_checkbounceentyr]
@customername nvarchar(100),
@city nvarchar(100),
@bankname nvarchar(100),
@amount numeric(10,2),
@checkno nvarchar(30),
@date nvarchar(20),
@bounce_charge numeric(10,2),
@recepitno int
as
begin
	if(not exists(select * from customer where name = @customername and city = @city and type = ''CUSTOMER''))
	begin
		select ''0''
		return 0
	end
	if(not exists(select * from customer where name = @bankname and type = ''BANK''))
	begin
		select ''1''
		return 1
	end
	declare @customerid int , @bankid int
	select @customerid = id from customer where name = @customername and city = @city and type = ''CUSTOMER''
	select @bankid = id from customer where name = @bankname and type = ''BANK''
	insert into check_bounse_entry(customerid , bankid , amount , checkno , date , bounce_charge , recepitno)	
	values(@customerid , @bankid , @amount , @checkno , dbo.indvardate(@date) ,@bounce_charge , @recepitno )
	select ''2''
end



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[chk_recepitno]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[chk_recepitno]
@recepitno int,
@date nvarchar(20)
as
begin	
	if(not exists(select * from recepit where recepitno = @recepitno and customerid is null))
	begin
		declare @maxrecepitno int
		select @maxrecepitno = isnull(max(recepitno),0) + 1 from recepit
		if(@recepitno<@maxrecepitno)
		begin
			select ''0'' , max(recepitno) + 1 from recepit
			return 0
		end
		else
		begin
			select ''1''
			return 1
		end
	end
	declare @mindate datetime , @maxdate datetime
	select @mindate = max(date) from recepit where recepitno < @recepitno
	select @maxdate = min(date) from recepit where recepitno > @recepitno
	if(dbo.indvardate(@date) between @mindate and @maxdate)
	begin
		select ''1''
		return 1
	end
	else
	begin
		select dbo.inddatevar(@mindate) as mindate , dbo.inddatevar(@maxdate) as maxdate
	end
end' 
END
GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[insert_line_group]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[insert_line_group]
@city varchar(100),
@group varchar(100)
as
begin
	if(not exists(select * from line where city = @city and [group] = @group))
	begin
		insert into line(city,[group]) values(@city,@group)
	end
end
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[insert_deletion_history]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[insert_deletion_history]
@type varchar(20),
@number int
as
begin
	if(not exists(select * from deletion_history where type = @type and number = @number))
	begin
		insert into deletion_history(type,number) values(@type,@number)
	end
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[check_bill_receipt_number]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[check_bill_receipt_number]
@type varchar(20),
@number int
as
begin
	if(exists(select * from deletion_history where type = @type and number = @number))
	begin
		select ''1''
	end
	else
	begin
		select ''0''
	end
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[add_transport]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[add_transport]
@name nvarchar(50),
@note nvarchar(500),
@city nvarchar(100),
@charge numeric(10,2)
as
begin
	declare @transportid int
	if(not exists(select * from transport where name = @name))
	begin
		insert into transport(name , note) values(@name , @note)
	end
	select @transportid = id from transport where name = @name
	if(exists(select * from transport_charge where transportid = @transportid and city = @city) and @charge != 0 and @charge is not null)
	begin
		update transport_charge set charge = @charge where transportid = @transportid and city = @city
	end
	else
	begin
		insert into transport_charge(transportid , city , charge) values(@transportid , @city , @charge)
	end
end


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[Transport_Detail]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[Transport_Detail]
AS
SELECT     dbo.transport.name, dbo.transport_charge.city, ISNULL(dbo.transport_charge.charge, 0) AS transportcharge, dbo.transport.note
FROM         dbo.transport LEFT OUTER JOIN
                      dbo.transport_charge ON dbo.transport.id = dbo.transport_charge.transportid
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'Transport_Detail', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "transport"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 110
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "transport_charge"
            Begin Extent = 
               Top = 6
               Left = 236
               Bottom = 125
               Right = 396
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Transport_Detail'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'Transport_Detail', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Transport_Detail'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[insert_transport]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[insert_transport]
@name nvarchar(50),
@city nvarchar(50),
@state nvarchar(50),
@charge numeric(10,2),
@note nvarchar(500)
as
begin
	declare @placeid as int , @transportid int
	if(@city is not null or @state is not null or @city <> '''' or @state <> '''')
	begin
		if(not exists(select * from place where city = @city and state = @state))
		begin
			insert into place(city , state) values(@city , @state)
		end
		select @placeid = id from place where city = @city and state = @state
	end
	else
	begin
		set @placeid = null
	end
	if(not exists(select * from transport where [name] = @name))
	begin
		insert into transport(name , note) values(@name , @note)
	end
	select @transportid = id from transport where name = @name
	if(exists(select * from transport_charge where transportid = @transportid and placeid = @placeid))
	begin
		update transport_charge set charge = @charge where transportid = @transportid and placeid = @placeid
	end	
	else
	begin
		insert into transport_charge(transportid , placeid , charge) values(@transportid , @placeid , @charge)
	end
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IsGSTPeriod]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'create function [dbo].[IsGSTPeriod](@date datetime)
returns bit
as
begin
	declare @gst_start_date datetime
	declare @x bit
	declare @gst_end_date datetime

	set @x=0

    select @gst_start_date = gst_start_date, @gst_end_date = gst_end_date from dbo.utility where id = 1
	
	if(@date >= @gst_start_date and @date <= @gst_end_date)
	begin
		set @x = 1
	end
	return @x
end
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IsVATPeriod]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE function [dbo].[IsVATPeriod](@date datetime)
returns bit
as
begin
	declare @vat_start_date datetime
	declare @x bit
	declare @vat_end_date datetime

	set @x=0

    select @vat_start_date = vat_start_date, @vat_end_date = vat_end_date from dbo.utility where id = 1
	
	if(@date >= @vat_start_date and @date <= @vat_end_date)
	begin
		set @x = 1
	end
	return @x
end
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cal_interest]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[cal_interest]
@interestper float,
@customername nvarchar(100),
@city nvarchar(100)
as
begin
	declare @opendate datetime, @opencash float , @opendiff float , @openinterest float , @paymentint float , @recepitint float
	select @opendate = date , @opencash = openbalance from customer where name = @customername and city = @city
	--select @opendate , @opencash
	set @opendiff = datediff(day , @opendate , getdate())
	select @openinterest = dbo.intcal(@opendiff , @opencash , @interestper)
	select @paymentint = sum(dbo.intcal(datedifference , payment , @interestper)) from intrest where name = @customername + '' '' + @city
	select @recepitint = sum(dbo.intcal(datedifference , recepit , @interestper)) from intrest where name = @customername + '' '' + @city
	select @openinterest +@paymentint - @recepitint
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_bill_master]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[view_bill_master]
AS
SELECT     dbo.bill_master.id, dbo.bill_master.billno, dbo.customer.name, dbo.customer.city, dbo.bill_master.date, dbo.bill_master.total, dbo.bill_master.expensesper, dbo.bill_master.expenses, 
                      dbo.bill_master.transport, dbo.bill_master.transportcherge AS transportcharge, dbo.bill_master.transportnumber, dbo.bill_master.grandtotal, dbo.bill_master.through, dbo.bill_master.paymenttype, 
                      dbo.bill_master.note, dbo.bill_master.rgtotal, dbo.bill_master.iscd, dbo.bill_master.vatper, dbo.bill_master.vat, dbo.bill_master.sgst
FROM         dbo.bill_master INNER JOIN
                      dbo.customer ON dbo.bill_master.customer = dbo.customer.id
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'view_bill_master', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[21] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "bill_master"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 15
         End
         Begin Table = "customer"
            Begin Extent = 
               Top = 10
               Left = 424
               Bottom = 129
               Right = 584
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_bill_master'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'view_bill_master', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_bill_master'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_manual_bill_master]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[view_manual_bill_master]
AS
SELECT     dbo.manual_bill_master.id, dbo.manual_bill_master.billno, dbo.customer.name, dbo.customer.city, dbo.manual_bill_master.date, dbo.manual_bill_master.total, 
                      dbo.manual_bill_master.expensesper, dbo.manual_bill_master.expenses, dbo.manual_bill_master.transport, dbo.manual_bill_master.transportcherge AS transportcharge, 
                      dbo.manual_bill_master.transportnumber, dbo.manual_bill_master.grandtotal, dbo.manual_bill_master.through, dbo.manual_bill_master.paymenttype, dbo.manual_bill_master.note, 
                      dbo.manual_bill_master.rgtotal, dbo.manual_bill_master.iscd, dbo.manual_bill_master.vatper, dbo.manual_bill_master.vat, dbo.manual_bill_master.sgst
FROM         dbo.manual_bill_master INNER JOIN
                      dbo.customer ON dbo.manual_bill_master.customer = dbo.customer.id
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'view_manual_bill_master', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "manual_bill_master"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 120
               Right = 200
            End
            DisplayFlags = 280
            TopColumn = 16
         End
         Begin Table = "customer"
            Begin Extent = 
               Top = 6
               Left = 238
               Bottom = 120
               Right = 393
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_manual_bill_master'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'view_manual_bill_master', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_manual_bill_master'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[customer_detail]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[customer_detail]
AS
SELECT     name, address, city, pincode, phno_1, phno_2, openbalance, date, note, id
FROM         dbo.customer
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'customer_detail', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "customer"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'customer_detail'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'customer_detail', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'customer_detail'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[openclosebal]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[openclosebal]
@date nvarchar(20),
@customername nvarchar(100),
@city nvarchar(100)
as
begin
	declare @openingbal numeric(10,2) 
	select @openingbal = isnull(openbalance , 0) from customer where name = @customername and city = @city
	select isnull(sum(isnull(payment , 0)) - sum(isnull(recepit , 0)) , 0) + @openingbal as closebalance, @openingbal as openbalance from ledger where NAME = @CUSTOMERNAME + '' '' + @CITY
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_Recepit]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_Recepit]
AS
SELECT     dbo.recepit.id, dbo.recepit.recepitno, dbo.recepit.date, dbo.customer.name, dbo.customer.city, dbo.recepit.amount, dbo.recepit.cd, dbo.recepit.total, 
                      dbo.recepit.manualrecepit, customer_1.name AS bank, customer_1.city AS bank_city, dbo.recepit.checknumber, dbo.recepit.billno, dbo.recepit.through, 
                      dbo.recepit.note
FROM         dbo.recepit LEFT OUTER JOIN
                      dbo.customer ON dbo.recepit.customerid = dbo.customer.id LEFT OUTER JOIN
                      dbo.customer AS customer_1 ON dbo.recepit.bankid = customer_1.id
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'View_Recepit', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[55] 4[10] 2[8] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "recepit"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 251
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "customer"
            Begin Extent = 
               Top = 6
               Left = 236
               Bottom = 273
               Right = 399
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "customer_1"
            Begin Extent = 
               Top = 6
               Left = 437
               Bottom = 273
               Right = 600
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Recepit'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'View_Recepit', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Recepit'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_cbe]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[view_cbe]
AS
SELECT     dbo.customer.name, dbo.customer.city, customer_1.name AS Bank_Name, customer_1.city AS Bank_City, dbo.check_bounse_entry.checkno, 
                      dbo.check_bounse_entry.date, dbo.check_bounse_entry.bounce_charge, dbo.check_bounse_entry.recepitno, dbo.check_bounse_entry.id
FROM         dbo.check_bounse_entry LEFT OUTER JOIN
                      dbo.customer ON dbo.check_bounse_entry.customerid = dbo.customer.id LEFT OUTER JOIN
                      dbo.customer AS customer_1 ON dbo.check_bounse_entry.bankid = customer_1.id
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'view_cbe', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "check_bounse_entry"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 185
               Right = 193
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "customer"
            Begin Extent = 
               Top = 6
               Left = 231
               Bottom = 304
               Right = 386
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "customer_1"
            Begin Extent = 
               Top = 6
               Left = 424
               Bottom = 275
               Right = 579
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_cbe'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'view_cbe', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_cbe'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[del_billdetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[del_billdetail]
@billno int
as
begin
	declare @billid int
	select @billid = id from bill_master where billno = @billno
	delete from bill_detail where billid = @billid
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_bill_detail]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[view_bill_detail]
AS
SELECT     dbo.bill_master.billno, dbo.bill_detail.company, dbo.bill_detail.[Group], dbo.bill_detail.item, dbo.bill_detail.Meterdetail, dbo.bill_detail.qty, 
                      dbo.bill_detail.meter, dbo.bill_detail.rate, dbo.bill_detail.amount, dbo.bill_detail.isrg
FROM         dbo.bill_detail INNER JOIN
                      dbo.bill_master ON dbo.bill_detail.billid = dbo.bill_master.id
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'view_bill_detail', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "bill_detail"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 120
               Right = 190
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "bill_master"
            Begin Extent = 
               Top = 6
               Left = 228
               Bottom = 120
               Right = 390
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_bill_detail'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'view_bill_detail', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_bill_detail'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bill_del]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[bill_del]
@billno int
as
begin
	declare @billid int
	select @billid = id from bill_master where billno = @billno
	delete from bill_detail where billid = @billid
	delete from bill_master where billno = @billno
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iscd]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[iscd]
@billno int
as
begin
	declare @iscd bit , @grandtotal numeric(12,2) , @total numeric(12,2) , @rgtotal numeric(12,2) , @transportcharge numeric(12,2)
	select @grandtotal = grandtotal , @iscd = iscd , @total = total , @rgtotal = rgtotal , @transportcharge = transportcherge from bill_master where billno = @billno
	if(@rgtotal is null)
	begin
		set @rgtotal = 0
	end
	if(@transportcharge is null)
	begin
		set @transportcharge = 0
	end
	if(@iscd is not null)
	begin
		select @iscd
	end
	else
	begin
		if(@grandtotal - @total + @rgtotal - @transportcharge > 0)
		begin
			select 0
		end
		else
		begin
			select 1
		end
	end
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[check_billno]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[check_billno]
@billno int
as
begin
	
	if(exists(select * from bill_master where billno = @billno and customer is not null))
	begin
		exec maxbillno
	end
	else if(exists(select  * from bill_master where billno = @billno and customer is null))
	begin
		select ''1''
	end
	begin
		select 0
	end
end


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dose_temp_contain_rg]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[dose_temp_contain_rg]
as
begin
	if(exists(select * from temp_bill_detail where isrg = 1))
	begin
		select 1 as isrg
	end
	else
	begin
		select 0 as isrg
	end
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[chk_autobackuppath]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[chk_autobackuppath]
as
begin
	if(exists(select * from autobackuppath))
	begin
		select 1
	end
	else
	begin
		select 0
	end
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[add_item]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[add_item]
@billno int,
@company nvarchar(100),
@group nvarchar(50),
@item nvarchar(150),
@meterdetail nvarchar(100),
@qty int,
@meter nvarchar(500),
@rate numeric(10,2),
@amount numeric(10,2),
@metercount nchar(10),
@update nvarchar(10),
@isrg bit
as
begin
	if(@isrg = 0)
	begin
		declare @billid int , @itemtypeid int , @companyid int, @hsncode nvarchar(50), @date datetime
		select @date = date from bill_master where billno = @billno
		if (dbo.IsGSTPeriod(@date) = 1)
		begin
			select @hsncode = @company
			select @company = ''''
		end
		else 
		begin
			select @hsncode = ''''
		end
	----company insertion and updation starts
		if(not exists(select * from company where name = @company))
		begin
			insert into company(name) values(@company)
		end
		select @companyid = id from company where name = @company
	----cumpany insertion and updation ends
	----itemtype insertion and updation starts
		if(not exists(select * from itemtype where typename = @group or shortcut = @group))
		begin
			insert into itemtype(typename , metercount, hsnCode) values(@group , @metercount, @hsnCode)
		end
		else if(@metercount = ''YES'')
		begin
			update itemtype set metercount = @metercount, hsnCode = @hsnCode where typename = @group or shortcut = @group
		end
		else
		begin
			update itemtype set hsnCode = @hsnCode where typename = @group or shortcut = @group
		end
		select @itemtypeid = id from itemtype where typename = @group or shortcut = @group
	----itemtype insertion and updation ends
	----item insertion and updation starts
		if(not exists(select * from item where name = @item and companyid = @companyid and itemtype_id = @itemtypeid))
		begin
			insert into item(name , companyid , price , date , itemtype_id) values(@item , @companyid , @rate , getdate() , @itemtypeid)
		end
		else if(@update = ''true'')
		begin
			update item set price = @rate where name = @item and companyid = @companyid and itemtype_id = @itemtypeid
		end
	----item insertion and updation complete
		if (dbo.IsGSTPeriod(@date) = 1)
		begin
			select @company=@hsncode
		end
		select @billid = id from bill_master where billno = @billno
		insert into bill_detail(billid , company , [group] , item , meterdetail , qty , meter , rate , amount , isrg)
		values(@billid , @company ,@group, @item , @meterdetail , @qty , @meter , @rate ,@amount , @isrg)
	end
	else
	begin
		declare @bill int
		select @bill = id from bill_master where billno = @billno
		insert into bill_detail([group] , company , billid , item , qty , rate , amount , isrg)
		values(''RG'' , ''RG'' ,@bill , @item , @qty , @rate , @amount , @isrg)
	end
end 







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[temp_manual_bill_allocate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[temp_manual_bill_allocate]
@billno int,
@date varchar(20),
@tax_str nvarchar(10)
as
begin
	declare @billid int 
	select @billid = id from manual_bill_master where billno = @billno and date = dbo.indvardate(@date)
	delete  from temp_bill_master
	insert into temp_bill_master(billid , billno , customer , city , date , total , expenseper , expenses , transport , transportcharge , transportnumber , grandtotal , through , paymenttype , note , [RG Total] , iscd, vatper, vat, tax_str, sgst) 
		select id as billid , billno , name , city , dbo.inddatevar(date) , total , expensesper , expenses , transport , transportcharge , transportnumber , grandtotal , through , paymenttype , note , rgtotal , iscd, vatper, vat, @tax_str, sgst from view_manual_bill_master where id = @billid
	delete  from temp_bill_detail
	insert into temp_bill_detail(billid , company , [group] , item , meterdetail , qty , meter , rate , amt ,isrg) 
		select billid , isnull(company , '''') , isnull([group] , '''') , dbo.grpitem(dbo.rgcal(isrg) , [group] , company , item , meterdetail) , meterdetail , qty , meter , rate , amount , isrg  from manual_bill_detail where billid = @billid and isrg = 0 order by [group] asc
	insert into temp_bill_detail(billid , company , [group] , item , meterdetail , qty , meter , rate , amt ,isrg) 
		select billid , isnull(company , '''') , isnull([group] , '''') , dbo.grpitem('''' , [group] , company , item , meterdetail) , meterdetail , qty , meter , rate , amount ,isrg from manual_bill_detail where billid = @billid and isrg = 1 order by [group] asc
end


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[get_autocomplete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[get_autocomplete]
@type nvarchar(10),
@company nvarchar(50),
@group nvarchar(50),
@item nvarchar(50)
as
begin
	
	if(@type = ''COMPANY'')
	begin
		select distinct(company) from item_detail where [Item Name] like(''%'' + @item + ''%'') and ([Type Name] like(''%'' + @group + ''%'') or shortcut like(''%'' + @group + ''%'')) 
	end
	else if (@type = ''HSNCode'')
	begin
		select distinct(hsnCode) from itemtype where typename like (''%'' + @group + ''%'')
	end
	else if(@type = ''GROUP'')
	begin
		select distinct(shortcut) from item_detail where shortcut <>'''' and shortcut is not null and [Item Name] like(''%'' + @item + ''%'') and Company like(''%'' + @company + ''%'')
		union 
		select distinct([Type Name]) from item_detail where [Item Name] like(''%'' + @item + ''%'') and Company like(''%'' + @company + ''%'')
	end
	else
	begin
		select distinct([Item Name]) from item_detail where Company like(''%'' + @company + ''%'') and ([Type Name] like(''%'' + @group + ''%'') or shortcut like(''%'' + @group + ''%'')) 
	end
end


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[add_manual_bill_master]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[add_manual_bill_master]
@customer nvarchar(100),
@city nvarchar(100),
@date nvarchar(20),
@billno nvarchar(20),
@total numeric(10,2),
@expenseper float,
@expenses numeric(10,2),
@transport nvarchar(100),
@transportcharge numeric(10,2),
@transportnumber nvarchar(30),
@grandtotal numeric(10,2),
@through nvarchar(100),
@type nvarchar(30),
@note nvarchar(200),
@rgtotal numeric(12,2),
@iscd bit,
@vatper float,
@vat numeric(10,2),
@sgst numeric(10,2)
as
begin
	declare @customer_id as int
	if(@type = ''PAID BY CASH'')
	begin
--Check for customer
	exec @customer_id = add_customer @customer , null , null , @city , null , null , null , null , null ,''CUSTOMER'' , null , null , 0
	end
	else if(exists(select * from customer_detail where name = @customer and city = @city))
	begin
		select @customer_id = id from customer_detail where name = @customer and city = @city
	end
	else
	begin
		select 0
		return 0
	end
--transport entry
	exec add_transport @transport , null , @city , @transportcharge
--insert into manual bill master
	if(not exists(select * from manual_bill_master where billno = @billno and  dbo.indvardate(@date) = date))
	begin
		insert into manual_bill_master(billno , customer , date , total , expensesper , expenses , transport , transportcherge
					, transportnumber , grandtotal , through , paymenttype , note , rgtotal , iscd, vatper, vat, sgst) values(@billno , @customer_id , dbo.indvardate(@date) , @total , 
					@expenseper , @expenses , @transport , @transportcharge , @transportnumber , @grandtotal , @through , 
					@type , @note , @rgtotal , @iscd, @vatper, @vat, @sgst)
		select 1
	end
	else
	begin
--bill number date combination already exists cannot save because of unique key constraint
		select 0
	end
end

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[add_bill_master]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[add_bill_master]
@customer nvarchar(100),
@city nvarchar(100),
@date nvarchar(20),
@billno nvarchar(20),
@total numeric(10,2),
@expenseper float,
@expenses numeric(10,2),
@transport nvarchar(100),
@transportcharge numeric(10,2),
@transportnumber nvarchar(30),
@grandtotal numeric(10,2),
@through nvarchar(100),
@type nvarchar(30),
@note nvarchar(200),
@rgtotal numeric(12,2),
@iscd bit,
@vatper float,
@vat numeric(10,2),
@sgst numeric(10,2)
as
begin
	declare @customer_id as int
	if(@type = ''PAID BY CASH'')
	begin
	exec @customer_id = add_customer @customer , null , null , @city , null , null , null , null , null ,''CUSTOMER'' , null , null , 0
	end
	else if(exists(select * from customer_detail where name = @customer and city = @city))
	begin
		select @customer_id = id from customer_detail where name = @customer and city = @city
	end
	else
	begin
		select 0
		return 0
	end
	exec add_transport @transport , null , @city , @transportcharge
	if(not exists(select * from bill_master where billno = @billno	))
	begin
		insert into bill_master(billno , customer , date , total , expensesper , expenses , transport , transportcherge
					, transportnumber , grandtotal , through , paymenttype , note , rgtotal , iscd, vatper, vat, sgst) values(@billno , @customer_id , dbo.indvardate(@date) , @total , 
					@expenseper , @expenses , @transport , @transportcharge , @transportnumber , @grandtotal , @through , 
					@type , @note , @rgtotal , @iscd, @vatper, @vat, @sgst)
		select 1
	end
	else if(exists(select * from bill_master where billno = @billno and customer is null))
	begin
		update bill_master set iscd = @iscd , customer = @customer_id , date = dbo.indvardate(@date) , total = @total , expensesper = @expenseper , expenses = @expenses ,
		transport = @transport , transportcherge = @transportcharge , transportnumber = @transportnumber , grandtotal = @grandtotal , 
		through = @through , paymenttype = @type , note = @note , rgtotal = @rgtotal, vatper = @vatper, vat = @vat, sgst = @sgst where billno = @billno
		select 1
	end
	else
	begin
		select ''-1''
	end
end





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[upd_manual_bill_master]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[upd_manual_bill_master]
@customer nvarchar(100),
@city nvarchar(100),
@date nvarchar(20),
@billno nvarchar(20),
@total numeric(10,2),
@expenseper float,
@expenses numeric(10,2),
@transport nvarchar(100),
@transportcharge numeric(10,2),
@transportnumber nvarchar(30),
@grandtotal numeric(10,2),
@through nvarchar(100),
@type nvarchar(30),
@rgtotal numeric(12,2),
@note nvarchar(200),
@id int,
@iscd bit,
@vatper float,
@vat numeric(10,2),
@sgst numeric(10,2)
as
begin
	declare @customer_id as int
	if(@type = ''PAID BY CASH'')
	begin
	--check for customer
	exec @customer_id = add_customer @customer , null , null , @city , null , null , null , null , null ,''CUSTOMER'' , null , null , 0
	end
	else if(exists(select * from customer_detail where name = @customer and city = @city))
	begin
		select @customer_id = id from customer_detail where name = @customer and city = @city
	end
	else
	begin
		select 0
		return 0
	end
	--add transport
	exec add_transport @transport , null , @city , @transportcharge
	--update manual bill master
	if(exists(select * from manual_bill_master where id = @id))
	begin
		update manual_bill_master set iscd = @iscd , customer = @customer_id , date = dbo.indvardate(@date) , total = @total , expensesper = @expenseper , expenses = @expenses ,
		transport = @transport , transportcherge = @transportcharge , transportnumber = @transportnumber , grandtotal = @grandtotal , 
		through = @through ,note = @note, paymenttype = @type , rgtotal = @rgtotal, vatper = @vatper, vat = @vat, sgst = @sgst where id = @id
		select 1
	end
	else
	begin
		select ''-1''
	end
end

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[upd_bill_master]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[upd_bill_master]
@customer nvarchar(100),
@city nvarchar(100),
@date nvarchar(20),
@billno nvarchar(20),
@total numeric(10,2),
@expenseper float,
@expenses numeric(10,2),
@transport nvarchar(100),
@transportcharge numeric(10,2),
@transportnumber nvarchar(30),
@grandtotal numeric(10,2),
@through nvarchar(100),
@type nvarchar(30),
@rgtotal numeric(12,2),
@note nvarchar(200),
@iscd bit,
@vatper float,
@vat numeric(10,2),
@sgst numeric (10,2)
as
begin
	declare @customer_id as int
	if(@type = ''PAID BY CASH'')
	begin
	exec @customer_id = add_customer @customer , null , null , @city , null , null , null , null , null ,''CUSTOMER'' , null , null , 0
	end
	else if(exists(select * from customer_detail where name = @customer and city = @city))
	begin
		select @customer_id = id from customer_detail where name = @customer and city = @city
	end
	else
	begin
		select 0
		return 0
	end
	exec add_transport @transport , null , @city , @transportcharge
	if(exists(select * from bill_master where billno = @billno))
	begin
		update bill_master set iscd = @iscd , customer = @customer_id , date = dbo.indvardate(@date) , total = @total , expensesper = @expenseper , expenses = @expenses ,
		transport = @transport , transportcherge = @transportcharge , transportnumber = @transportnumber , grandtotal = @grandtotal , 
		through = @through ,note = @note, paymenttype = @type , rgtotal = @rgtotal, vatper = @vatper, vat = @vat, sgst = @sgst where billno = @billno
		select 1
	end
	else
	begin
		select ''-1''
	end
end





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[temp_bill_allocate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[temp_bill_allocate]
@billno int,
@tax_str nvarchar(10)
as
begin
	declare @billid int , @iscd1 bit
	
	-------------
	declare @iscd bit , @grandtotal numeric(12,2) , @total numeric(12,2) , @rgtotal numeric(12,2) , @transportcharge numeric(12,2)
	select @grandtotal = grandtotal , @iscd = iscd , @total = total , @rgtotal = rgtotal , @transportcharge = transportcherge from bill_master where billno = @billno
	if(@rgtotal is null)
	begin
		set @rgtotal = 0
	end
	if(@transportcharge is null)
	begin
		set @transportcharge = 0
	end
	if(@iscd is not null)
	begin
		SET @ISCD1 = @iscd
	end
	else
	begin
		if(@grandtotal - @total + @rgtotal - @transportcharge > 0)
		begin
			SET @ISCD1 = 0
		end
		else
		begin
			SET @ISCD1 = 1
		end
	end
----------------
	declare @cdexp varchar(10)
	if(@iscd1 = 0)
	begin
		set @cdexp = ''EXP''
	end
	else
	begin
		set @cdexp = ''CD''
	end
	select @billid = id from bill_master where billno = @billno
	delete  from temp_bill_master
	insert into temp_bill_master(billid , billno , customer , city , date , total , expenseper , expenses , transport , transportcharge , transportnumber , grandtotal , through , paymenttype , note , [RG Total] , iscd , cdexp, vatper, vat, tax_str, sgst) 
		select id as billid , billno , name , city , dbo.inddatevar(date) , total , expensesper , expenses , transport , transportcharge , transportnumber , grandtotal , through , paymenttype , note , rgtotal , @iscd1 as iscd , @cdexp as cdexp, vatper, vat, @tax_str as tax_str, sgst from view_bill_master where billno = @billno
	delete  from temp_bill_detail
	insert into temp_bill_detail(billid , company , [group] , item , meterdetail , qty , meter , rate , amt ,isrg) 
		select billid , isnull(company , '''') , isnull([group] , '''') , dbo.grpitem(dbo.rgcal(isrg) , [group] , company , item , meterdetail) , meterdetail , qty , meter , rate , amount , isrg  from bill_detail where billid = @billid and isrg = 0 order by [group] asc
	insert into temp_bill_detail(billid , company , [group] , item , meterdetail , qty , meter , rate , amt ,isrg) 
		select billid , isnull(company , '''') , isnull([group] , '''') , dbo.grpitem('''' , [group] , company , item , meterdetail) , meterdetail , qty , meter , rate , amount ,isrg from bill_detail where billid = @billid and isrg = 1 order by [group] asc
end





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[closingbalcal]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[closingbalcal]
@date nvarchar(30),
@customername nvarchar(100),
@city nvarchar(100)
as
begin
	declare @openingbal numeric(10,2)
	--select @openingbal = isnull(openbalance , 0) from customer where name = @customername and city = @city
	select isnull(sum(isnull(payment , 0)) - sum(isnull(recepit , 0)) , 0) as balance from ledger where NAME = @CUSTOMERNAME + '' '' + @CITY
end
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[get_transportcharge]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[get_transportcharge]
@city nvarchar(100),
@name nvarchar(100)
as
begin
	if(exists(select * from transport_detail where city = @city and name = @name))
	begin
		select transportcharge from transport_detail where name = @name and city = @city
	end
	else
	begin
		select ''0''
	end
end' 
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__item__companyid__0425A276]') AND parent_object_id = OBJECT_ID(N'[dbo].[item]'))
ALTER TABLE [dbo].[item]  WITH CHECK ADD  CONSTRAINT [FK__item__companyid__0425A276] FOREIGN KEY([companyid])
REFERENCES [dbo].[company] ([id])
GO
ALTER TABLE [dbo].[item] CHECK CONSTRAINT [FK__item__companyid__0425A276]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__item__itemtype_i__1B0907CE]') AND parent_object_id = OBJECT_ID(N'[dbo].[item]'))
ALTER TABLE [dbo].[item]  WITH CHECK ADD FOREIGN KEY([itemtype_id])
REFERENCES [dbo].[itemtype] ([id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__trancport__trans__36B12243]') AND parent_object_id = OBJECT_ID(N'[dbo].[transport_charge]'))
ALTER TABLE [dbo].[transport_charge]  WITH CHECK ADD  CONSTRAINT [FK__trancport__trans__36B12243] FOREIGN KEY([transportid])
REFERENCES [dbo].[transport] ([id])
GO
ALTER TABLE [dbo].[transport_charge] CHECK CONSTRAINT [FK__trancport__trans__36B12243]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__manual_re__banki__0A688BB1]') AND parent_object_id = OBJECT_ID(N'[dbo].[manual_recepit]'))
ALTER TABLE [dbo].[manual_recepit]  WITH CHECK ADD FOREIGN KEY([bankid])
REFERENCES [dbo].[customer] ([id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__manual_re__custo__09746778]') AND parent_object_id = OBJECT_ID(N'[dbo].[manual_recepit]'))
ALTER TABLE [dbo].[manual_recepit]  WITH CHECK ADD FOREIGN KEY([customerid])
REFERENCES [dbo].[customer] ([id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__check_bou__banki__44CA3770]') AND parent_object_id = OBJECT_ID(N'[dbo].[check_bounse_entry]'))
ALTER TABLE [dbo].[check_bounse_entry]  WITH CHECK ADD  CONSTRAINT [FK__check_bou__banki__44CA3770] FOREIGN KEY([bankid])
REFERENCES [dbo].[customer] ([id])
GO
ALTER TABLE [dbo].[check_bounse_entry] CHECK CONSTRAINT [FK__check_bou__banki__44CA3770]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__check_bou__custo__43D61337]') AND parent_object_id = OBJECT_ID(N'[dbo].[check_bounse_entry]'))
ALTER TABLE [dbo].[check_bounse_entry]  WITH CHECK ADD  CONSTRAINT [FK__check_bou__custo__43D61337] FOREIGN KEY([customerid])
REFERENCES [dbo].[customer] ([id])
GO
ALTER TABLE [dbo].[check_bounse_entry] CHECK CONSTRAINT [FK__check_bou__custo__43D61337]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__manual_bi__custo__02C769E9]') AND parent_object_id = OBJECT_ID(N'[dbo].[manual_bill_master]'))
ALTER TABLE [dbo].[manual_bill_master]  WITH CHECK ADD FOREIGN KEY([customer])
REFERENCES [dbo].[customer] ([id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__recepit__custome__3C34F16F]') AND parent_object_id = OBJECT_ID(N'[dbo].[recepit]'))
ALTER TABLE [dbo].[recepit]  WITH CHECK ADD  CONSTRAINT [FK__recepit__custome__3C34F16F] FOREIGN KEY([customerid])
REFERENCES [dbo].[customer] ([id])
GO
ALTER TABLE [dbo].[recepit] CHECK CONSTRAINT [FK__recepit__custome__3C34F16F]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_bank_customer]') AND parent_object_id = OBJECT_ID(N'[dbo].[recepit]'))
ALTER TABLE [dbo].[recepit]  WITH CHECK ADD  CONSTRAINT [fk_bank_customer] FOREIGN KEY([bankid])
REFERENCES [dbo].[customer] ([id])
GO
ALTER TABLE [dbo].[recepit] CHECK CONSTRAINT [fk_bank_customer]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__bill_data__billi__25869641]') AND parent_object_id = OBJECT_ID(N'[dbo].[bill_detail]'))
ALTER TABLE [dbo].[bill_detail]  WITH CHECK ADD  CONSTRAINT [FK__bill_data__billi__25869641] FOREIGN KEY([billid])
REFERENCES [dbo].[bill_master] ([id])
GO
ALTER TABLE [dbo].[bill_detail] CHECK CONSTRAINT [FK__bill_data__billi__25869641]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__manual_bi__billi__05A3D694]') AND parent_object_id = OBJECT_ID(N'[dbo].[manual_bill_detail]'))
ALTER TABLE [dbo].[manual_bill_detail]  WITH CHECK ADD FOREIGN KEY([billid])
REFERENCES [dbo].[manual_bill_master] ([id])
