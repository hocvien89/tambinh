Drop table [TTV_DM_THETICHDIEM_CHUYENDOI]
go
CREATE TABLE [dbo].[TTV_DM_THETICHDIEM_CHUYENDOI](
	[uId_TTDChuyendoi] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[v_Machuyendoi] [varchar](50) NULL,
	[f_Giatri] [float] NULL,
	[i_Diem] [int] NULL,
	[uId_Thetichdiem] [uniqueidentifier] NULL,
	[nv_Tenchuyendoi] [nvarchar](100) null,
	[b_Trangthai] [bit] null,
 CONSTRAINT [PK_TTV_DM_THETICHDIEM_CHUYENDOI] PRIMARY KEY CLUSTERED 
(
	[uId_TTDChuyendoi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TTV_DM_THETICHDIEM_CHUYENDOI] ADD  CONSTRAINT [DF_TTV_DM_THETICHDIEM_CHUYENDOI_uId_TTDChuyendoi]  DEFAULT (newid()) FOR [uId_TTDChuyendoi]
GO


