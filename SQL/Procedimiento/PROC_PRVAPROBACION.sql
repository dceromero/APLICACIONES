use PRB_APLICACIONESII
go 
create procedure PROC_PRVAPROBACION(
@CEDULA bigint,
@IDMC int,
@APROB int,
@OBS nvarchar(max)
)
as
begin 
	begin tran
		begin try
			DECLARE @CANT as smallint =(select COUNT(*) from PRV_APROBACION where ID_MCSOLICITUD= @IDMC and CEDULA= @CEDULA)
			if(@CANT = 0)
				begin
					declare @cargo as nvarchar(10)=(Select ID_CARGO from EMPLEADO where CEDULA = @CEDULA)
					declare @validar as int

					
					declare @mail nvarchar(100) = (select dbo.Func_JefaturaMasMail(@CEDULA, 5))
					
					declare @empleado nvarchar(100)=(select CONCAT(NOMBRES,' ',APELLIDO) from EMPLEADO where CEDULA = @CEDULA) 


					SELECT  @validar = dbo.FUNC_VALIDARAPROBACION(@CEDULA, CEDULASOLID, 5) FROM PRV_MCSOLICITUD WHERE ID_MCSOLICITUD = @CEDULA

					insert into PRV_APROBACION values(@IDMC, @CEDULA, GETDATE())




					if(@cargo = 'C0515')
						begin
							update PRV_MCSOLICITUD set APRBLIDCON = @APROB, OBS_CONTAB = @OBS
							where ID_MCSOLICITUD= @IDMC
						end
					else if(@cargo = 'C0432')
							begin
								update PRV_MCSOLICITUD set APRBGTEFIN = @APROB
								where ID_MCSOLICITUD= @IDMC
							end
					else if(@cargo = 'C0464')
							begin
								update PRV_MCSOLICITUD set APRBCONTAB = @APROB
								where ID_MCSOLICITUD= @IDMC
							end
					else 
						begin
							if(@validar >=1)
							begin
								update PRV_MCSOLICITUD set APRBGTE = @APROB
								where ID_MCSOLICITUD= @IDMC
							end
							else
								begin
									set @IDMC= -1
									set @mail='j.robayo@gloria.com.co'
									set @empleado='Ya existe una aprobación'
								end
						end
					
					
					select max(@IDMC) AS ID, CONCAT(isnull(@mail,'j.robayo@gloria.com.co'),'|Autorización','||',@empleado, '|', 'pendiente para aprobación')AS JEFE    
				end
			commit
		end try
		begin catch
			rollback			
			delete from PRV_APROBACION where ID_MCSOLICITUD = @IDMC and CEDULA = @CEDULA

			select -1 AS ID, CONCAT('j.robayo@gloria.com.co','|Error','||',@cedula, '|', 'Por favor revisar la Tabla de Errores')AS JEFE    from AI_MOVCABAJUSTE PRV_MCSOLICITUD
			
			insert into ERRORES SELECT GETDATE(),concat('PROC_PRVAPROBACION y Usuario',@CEDULA) , ERROR_LINE()  ,ERROR_MESSAGE() 
		end catch
end