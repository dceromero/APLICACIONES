create procedure PROC_PRVMDSOLICITUD(
@IDMCSOLICITUD int,
@IDCENCOS bigint, 
@IDPERIODICIDAD int,
@OBS nvarchar(max),
@CONCEPTO nvarchar(max),
@VALOR numeric,
@ORDMERCADEO bigint,
@IDPROVEEDORES bigint,
@NOMBRE nvarchar(150)
)
as 
begin
	begin tran
		begin try
			
			insert into PRV_MDSOLICITUD values(@IDMCSOLICITUD, @IDCENCOS, 0, @IDPERIODICIDAD, @OBS, @CONCEPTO, @VALOR, @ORDMERCADEO, @IDPROVEEDORES, @NOMBRE)
			
			select @IDMCSOLICITUD AS ID, CONCAT('j.robayo@gloria.com.co','|Error PROC_PRVMDSOLICITUD','||', 'Por favor revisar la Tabla de Errores')AS JEFE    from AI_MOVCABAJUSTE PRV_MCSOLICITUD
			

			commit
		end try
		begin catch
			rollback			
			
			delete from PRV_MCSOLICITUD where ID_MCSOLICITUD = @IDMCSOLICITUD
			delete from PRV_MDSOLICITUD where ID_MCSOLICITUD = @IDMCSOLICITUD

			select -1 AS ID, CONCAT('j.robayo@gloria.com.co','|Error PROC_PRVMDSOLICITUD','||', 'Por favor revisar la Tabla de Errores')AS JEFE    from AI_MOVCABAJUSTE PRV_MCSOLICITUD
			
			insert into ERRORES SELECT GETDATE(),concat('PROC_PRVMDSOLICITUD y el id',@IDMCSOLICITUD) , ERROR_LINE()  ,ERROR_MESSAGE() 
		end catch


end