USE [APLICACIONES]
GO
/****** Object:  UserDefinedFunction [dbo].[Func_GHMailJefe]    Script Date: 5/06/2020 8:29:57 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create function [dbo].[Func_AIMailJefe](@cedula bigint)
returns nvarchar(50)
begin
return(
select distinct concat(rtrim(us.MAIL_CORP),'-',emp.NOMBRES,' ',emp.APELLIDO)
from APROBXPROYECTO as apr
inner join EMPLEADO as emp on emp.ID_CARGO = apr.CARGOAUTORIZAADOR and emp.ESTADO=1 
inner join GH_USUARIO as us on us.CEDULA = emp.CEDULA 
where  ID_PROYECTO = 2 and CARGOSOLICITANTE in(
select ID_CARGO from EMPLEADO 
WHERE CEDULA =@cedula
)
)
end
