drop table [dbo].[TNTP_QT_Dieutri_Hinhanh]
go
CREATE TABLE [dbo].[TNTP_QT_Dieutri_Hinhanh](
	[uId_Hinhanh_Congdoan] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[uId_QT_Dieutri] [uniqueidentifier] NULL,
	[nv_Hinhanh_vn] [nvarchar](200) NULL,
 CONSTRAINT [PK_TNTP_QT_Dieutri_Hinhanh] PRIMARY KEY CLUSTERED 
(
	[uId_Hinhanh_Congdoan] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TNTP_QT_Dieutri_Hinhanh] ADD  CONSTRAINT [DF_TNTP_QT_Dieutri_Hinhanh_uId_Hinhanh_Congdoan]  DEFAULT (newid()) FOR [uId_Hinhanh_Congdoan]
GO


