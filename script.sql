USE [dborder]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 05/04/2018 16:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[dni] [int] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 05/04/2018 16:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Venta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Producto] [varchar](45) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [decimal](8, 2) NOT NULL,
	[Subtotal] [decimal](8, 2) NOT NULL,
	[Descuento] [decimal](8, 2) NOT NULL,
	[Neto] [decimal](8, 2) NOT NULL,
	[idcliente] [int] NULL,
 CONSTRAINT [PK__Venta__3214EC075A2A1A70] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Cliente] FOREIGN KEY([idcliente])
REFERENCES [dbo].[Cliente] ([id])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Cliente]
GO
/****** Object:  StoredProcedure [dbo].[addOrder]    Script Date: 05/04/2018 16:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[addOrder]
	@producto varchar(45),
	@cantidad int,
	@precio decimal(8,2),	
	@subtotal decimal(8,2),	
	@descuento decimal(8,2),	
	@neto decimal(8,2),
	@idcliente int	
AS
	INSERT INTO Venta VALUES(@producto,@cantidad,@precio,@subtotal,@descuento,@neto,@idcliente)
RETURN 0

GO
/****** Object:  StoredProcedure [dbo].[deleteOrder]    Script Date: 05/04/2018 16:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[deleteOrder]
	-- Add the parameters for the stored procedure here
	 @id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE Venta
	WHERE id=@id
END

GO
/****** Object:  StoredProcedure [dbo].[listClienteByDNI]    Script Date: 05/04/2018 16:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[listClienteByDNI]
	-- Add the parameters for the stored procedure here
	@Dni int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id,nombre,dni from Cliente where dni=@Dni;
END

GO
/****** Object:  StoredProcedure [dbo].[listOrder]    Script Date: 05/04/2018 16:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[listOrder]
		
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT v.Id,v.Producto,v.Cantidad,v.Precio,v.Subtotal,v.Descuento,v.Neto,
	       c.nombre,c.id as idcliente
	FROM Venta v inner join Cliente c
	ON v.idcliente=c.id
END

GO
/****** Object:  StoredProcedure [dbo].[listOrderById]    Script Date: 05/04/2018 16:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[listOrderById]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id,Producto,Cantidad,Precio,Subtotal,Descuento,Neto 
	FROM Venta
	WHERE id=@id
END

GO
/****** Object:  StoredProcedure [dbo].[updateOrder]    Script Date: 05/04/2018 16:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[updateOrder]
    @id int,
	@producto varchar(45),
	@cantidad int,
	@precio decimal(8,2),	
	@subtotal decimal(8,2),	
	@descuento decimal(8,2),	
	@neto decimal(8,2)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Venta 
	SET Producto=@Producto,
	Cantidad=@cantidad,
	Precio=@precio,
	Subtotal=@subtotal,
	Descuento=@descuento,
	Neto=@Neto
	WHERE Id=@Id
END

GO
