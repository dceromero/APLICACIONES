alter procedure Proc_AIbUSQUEDAAPROBADOR(@cedula as bigint)
as
begin
	declare @idcargo as nvarchar(5) = (select ID_CARGO from EMPLEADO where CEDULA = @cedula)

	if @idcargo = 'C0001' 
	begin
		select * from VIEW_AI
		where ID_MOVCABAJ in (select ID_MOVCABAJ from AI_MOVCABAJUSTE where APROBCONTB = 0)
	end
	else if @idcargo = 'C0077' 
	begin
		select * from VIEW_AI
		where ID_MOVCABAJ in (select ID_MOVCABAJ from AI_MOVCABAJUSTE where APROBCONTB = 2 and APROBJFCD = 0)
	end
	else if @idcargo = 'C0643' 
	begin
		select * from VIEW_AI
		where ID_MOVCABAJ in (select ID_MOVCABAJ from AI_MOVCABAJUSTE where APROBJFCD = 2 and APROBJFAL = 0)	
	end
	else if @idcargo = 'C0349' 
	begin
		select * from VIEW_AI
		where ID_MOVCABAJ in (select ID_MOVCABAJ from AI_MOVCABAJUSTE where APROBJFCD = 2 and APROBJFAL = 2 and APROBGTSC=0)	
	end
	else if @idcargo = 'C0492'
	begin 
		select * from VIEW_AI
		where ID_MOVCABAJ in (select ID_MOVCABAJ from AI_MOVCABAJUSTE where APROBJFCD = 2 and APROBJFAL = 2 and APROBGTSC=2 and APROBGRFI=0)	
	end
	else if @idcargo = 'C0456'
	begin 
		select * from VIEW_AI
		where ID_MOVCABAJ in (select ID_MOVCABAJ from AI_MOVCABAJUSTE where APROBJFCD = 2 and APROBJFAL = 2 and APROBGTSC=2 and APROBGRFI=2 and APROBGERGEN = 0)	
	end

end