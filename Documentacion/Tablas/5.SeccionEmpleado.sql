CREATE TABLE [dbo].[SeccionEmpleado](
	[IdSeccionEmpleado] [uniqueidentifier] NOT NULL,
	[IdEmpleado] [uniqueidentifier] NOT NULL,
	[IdSeccion] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_SeccionEmpleado] PRIMARY KEY CLUSTERED 
(
	[IdSeccionEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_SeccionEmpleado] UNIQUE NONCLUSTERED 
(
	[IdEmpleado] ASC,
	[IdSeccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SeccionEmpleado]  WITH CHECK ADD  CONSTRAINT [FK_SeccionEmpleado_Empleado] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleado] ([IdEmpleado])
GO

ALTER TABLE [dbo].[SeccionEmpleado] CHECK CONSTRAINT [FK_SeccionEmpleado_Empleado]
GO

ALTER TABLE [dbo].[SeccionEmpleado]  WITH CHECK ADD  CONSTRAINT [FK_SeccionEmpleado_Seccion] FOREIGN KEY([IdSeccion])
REFERENCES [dbo].[Seccion] ([IdSeccion])
GO

ALTER TABLE [dbo].[SeccionEmpleado] CHECK CONSTRAINT [FK_SeccionEmpleado_Seccion]
GO


