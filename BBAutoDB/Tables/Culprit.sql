CREATE TABLE [dbo].[Culprit](
	[culprit_id] [int] IDENTITY(1,1) NOT NULL,
	[culprit_name] NVARCHAR(50) NOT NULL,
 CONSTRAINT [PK_Culprit] PRIMARY KEY CLUSTERED 
(
	[culprit_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
