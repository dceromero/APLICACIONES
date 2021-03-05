CREATE VIEW VIEW_AI as
SELECT AICAB.FECING, AICAB.FECINV, AICAB.DOCUMENSAP, CONCAT(EMP.NOMBRES,' ', EMP.APELLIDO) AS NOMBRE, AICAB.ID_MOVCABAJ, AICAB.OBSERVACION, 
concat(AICAB.CODCENTRO, '-', C.NOMBRE)AS CD
FROM AI_MOVCABAJUSTE AS AICAB
INNER JOIN EMPLEADO AS EMP ON EMP.CEDULA = AICAB.CEDULASUPRV
INNER JOIN CENTRO AS C ON C.CODCENTRO = AICAB.CODCENTRO