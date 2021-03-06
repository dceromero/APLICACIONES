USE [APLICACIONES]
GO
/****** Object:  StoredProcedure [dbo].[GUARDARAI]    Script Date: 17/06/2020 11:13:56 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[GUARDARAI](
@fecinv date,
@centro nvarchar(20),
@cedula bigint,
@docsap nvarchar(20),
@obs nvarchar(max)
)as
begin 
	declare @mailjf nvarchar(max) = (SELECT [dbo].[Func_GHMailJefeAI](@cedula))
	
	insert into AI_MOVCABAJUSTE values(GETDATE(),@fecinv, @centro, @cedula, @docsap, 0,0,0,0,@obs,0, 0 , 0)
	

	select max(ID_MOVCABAJ) AS ID, (@mailjf)AS JEFE  from AI_MOVCABAJUSTE
end