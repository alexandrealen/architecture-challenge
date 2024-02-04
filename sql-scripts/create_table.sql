USE [master]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Lancamentos](
	[Id] [uniqueidentifier] NOT NULL,
	[Valor] [decimal](20, 2) NOT NULL,
	[DataLancamento] [datetimeoffset](7) NOT NULL,
	[NaturezaLancamento] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Lancamentos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

