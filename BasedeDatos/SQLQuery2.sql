use APLICACIONES
go
create procedure PROC_SaveMDDESCTO(
@idmc as bigint,
@codprod as nvarchar(20),
@porc as tinyint,
@cant as int,
@tpsolicitud as smallint
)as
begin
begin tran
	begin try
		insert into MDDESCUENTO values(@idmc,@codprod,@porc,0,0,0,0,0,'oki',@cant)
		if(@tpsolicitud=1)
			begin
				select 1 as id, mail as [message] from USUARIOS where CEDULA in('')
			end
		else 
			begin
				select 1 as id, mail as [message] from USUARIOS where CEDULA in('')
			end
		commit
	end try
	begin catch		
		rollback
		delete from MDDESCUENTO where ID_MCDESCUENTO=@idmc
		delete from MCDESCUENTOS where ID_MCDESCUENTO=@idmc
		insert into Errores SELECT GETDATE(),ERROR_PROCEDURE() AS Procedimiento, ERROR_LINE() AS Linea ,ERROR_MESSAGE() AS Mensaje
		select 0 as id,  ERROR_MESSAGE() as [message]		
	end catch
end

