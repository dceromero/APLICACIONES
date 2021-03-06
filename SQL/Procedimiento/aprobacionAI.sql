USE [APLICACIONES]
GO
/****** Object:  StoredProcedure [dbo].[GUARDARAI]    Script Date: 8/06/2020 8:25:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[AI_ACTUALIZAR](
@ID BIGINT,
@CEDULA BIGINT,
@APROB SMALLINT
)as
begin 
	declare @mailjf nvarchar(max) = (SELECT [dbo].[Func_GHMailJefeAI](@cedula))
	
	declare @idcargo as nvarchar(5) = (select ID_CARGO from EMPLEADO where CEDULA = @cedula)

	if @idcargo = 'C0001' 
	begin
		INSERT INTO AI_APROBACION VALUES(@CEDULA, @ID, GETDATE())
		UPDATE AI_MOVCABAJUSTE SET APROBCONTB = @APROB WHERE ID_MOVCABAJ = @ID

		set @CEDULA = (select CEDULASUPRV from AI_MOVCABAJUSTE where ID_MOVCABAJ = @ID)
		set @mailjf = (SELECT [dbo].[Func_GHMailJefeAI](@cedula))
	end
	else if @idcargo = 'C0077' 
	begin
		INSERT INTO AI_APROBACION VALUES(@CEDULA, @ID, GETDATE())
		UPDATE AI_MOVCABAJUSTE SET APROBJFCD = @APROB WHERE ID_MOVCABAJ = @ID
	end
	else if @idcargo = 'C0643' 
	begin
		INSERT INTO AI_APROBACION VALUES(@CEDULA, @ID, GETDATE())
		UPDATE AI_MOVCABAJUSTE SET APROBJFAL = @APROB WHERE ID_MOVCABAJ = @ID	
	end
	else if @idcargo = 'C0349' 
	begin
		INSERT INTO AI_APROBACION VALUES(@CEDULA, @ID, GETDATE())
		UPDATE AI_MOVCABAJUSTE SET APROBGTSC = @APROB WHERE ID_MOVCABAJ = @ID
	end
	else if @idcargo = 'C0492'
	begin 
		INSERT INTO AI_APROBACION VALUES(@CEDULA, @ID, GETDATE())
		UPDATE AI_MOVCABAJUSTE SET APROBGRFI = @APROB WHERE ID_MOVCABAJ = @ID	
	end
	else if @idcargo = 'C0456'
	begin 
		INSERT INTO AI_APROBACION VALUES(@CEDULA, @ID, GETDATE())
		UPDATE AI_MOVCABAJUSTE SET APROBGERGEN = @APROB WHERE ID_MOVCABAJ = @ID	
	end

	select max(@ID) AS ID, (@mailjf)AS JEFE  from AI_MOVCABAJUSTE
end