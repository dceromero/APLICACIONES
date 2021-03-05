use PRB_APLICACIONESII
go 
create procedure PROC_PRVMCSOLICITUD(
@CEDULASOL bigint,
@IDTPMOTIVO int,
@IDTPBENEFIC int,
@JUSTIFICACION nvarchar(max)
)
as
begin 
	begin tran
		begin try
			declare @area int 
			declare @cencos bigint
			declare @mail nvarchar(50)
			declare @empleado nvarchar(70)

			select @area=ID_AREA, @cencos=ID_CENCOS from GH_CARGO where ID_CARGO in(
			select ID_CARGO from EMPLEADO where CEDULA =@CEDULASOL)

			select @empleado= CONCAT(NOMBRES,' ', APELLIDO,' ', APELLIDO2) from EMPLEADO
			where CEDULA = @CEDULASOL


			set @mail = (select dbo.Func_JefaturaMasMail(@CEDULASOL, 5))

			insert into PRV_MCSOLICITUD values(@IDTPMOTIVO, @area, @cencos,@IDTPBENEFIC, @CEDULASOL, GETDATE(), @JUSTIFICACION, 0, 'oki', 0, 0, 0)

			
			select max(ID_MCSOLICITUD) AS ID, CONCAT(isnull(@mail,'j.robayo@gloria.com.co'),'|Autorización','||',@empleado, '|', 'pendiente para aprobación')AS JEFE    
			from  PRV_MCSOLICITUD

			commit
		end try
		begin catch
			rollback			
			
			select -1 AS ID, CONCAT('j.robayo@gloria.com.co','|Error','||',@empleado, '|', 'Por favor revisar la Tabla de Errores')AS JEFE    from  PRV_MCSOLICITUD
			
			insert into ERRORES SELECT GETDATE(),concat('PROC_PRVMVSOLICITUD y Usuario',@CEDULASOL) , ERROR_LINE()  ,ERROR_MESSAGE() 
		end catch
end