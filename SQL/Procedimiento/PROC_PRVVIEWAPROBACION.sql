use PRB_APLICACIONESII
go 
create procedure PROC_PRVVIEWAPROBACION(
@CEDULA bigint
)
as
begin 
	declare @cargo as nvarchar(10)=(Select ID_CARGO from EMPLEADO where CEDULA = @CEDULA)
	if(@cargo = 'C0515')
		begin
			--Javier
			select * from VIEW_PROVLISTAPROBACION where APRBLIDCON=0
		end
		else if(@cargo = 'C0432')
				begin
					-- Ippolito					
					select * from VIEW_PROVLISTAPROBACION where APRBCONTAB=2 and APRBGTEFIN=0
				end
		else if(@cargo = 'C0464')
				begin
					-- Juliett
					select * from VIEW_PROVLISTAPROBACION where APRBGTE=2 and APRBCONTAB=0
				end
		else
			begin
				select * from VIEW_PROVLISTAPROBACION where APRBLIDCON=2 and APRBGTE=0 and 
				CEDULASOLID in(select CEDULA from EMPLEADO
								where ID_CARGO in(
								select CARGOSOLICITANTE from APROBXPROYECTO
								where CARGOAUTORIZAADOR in(
								select ID_CARGO from EMPLEADO
								where CEDULA = @CEDULA)) )
			end
end