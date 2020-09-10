/* Transferencias de materiales (Entradas, Proceso y Salidas)*/
DECLARE @PEDIDO VARCHAR(10) = '62344';

SELECT --Selecciono los datos del Pedido 
	Cte_1.Nombre AS Cliente -- Cliente
	,CONCAT( RTRIM( Venta.[Mov]),' ',Venta.[MovID]) as Movimiento  --Movimiento
	,'' as Estatus --Estatus
	,Art_1.Linea as AlmacenOrg -- Almacen Origen
	,'' as AlmacenDes -- Almacen Destino
	,Art_1.Articulo as Articulo -- Articulo
	,Art_1.Descripcion1 as ArticuloDescripcion -- Descripcion Articulo
	,VentaD.Cantidad as Cantidad -- Cantidad
	,CASE 
		WHEN UPPER(VentaD.Unidad) = 'PZA' THEN 'PZAS'
		WHEN UPPER(VentaD.Unidad) = 'PIEZA' THEN 'PZAS'
		ELSE UPPER(VentaD.Unidad)
	END
	 as Unidad -- Unidad Articulo
	,isnull((select Top 1 AU.[Factor] from ArtUnidad AU where AU.Articulo= Art_1.Articulo and AU.Unidad= VentaD.Unidad),1) as Factor  -- Factor
	,(VentaD.Cantidad * isnull((select Top 1 AU.[Factor] from ArtUnidad AU where AU.Articulo= Art_1.Articulo and AU.Unidad= VentaD.Unidad),1))as CantidadInventario -- Cantidad Inventario
	,VentaD.DescripcionExtra as DescripcionExtra -- Descripcion extra
	,Venta.Usuario as Usuario -- Usuario (quien realiza el movimiento)
	,UPPER(RTrim(Venta.Referencia)) as Referencia -- Referencia al pedido u OT
	,CURRENT_TIMESTAMP AS FechaConclusion -- Fecha Conclusion (para traer los pedidos, aun no cuentan con fecha de conclusion)
	,CURRENT_TIMESTAMP as FechaEmision -- FEcha Emision del movimiento
	,Art_1.Grupo AS ArticuloGrupo -- Grupo del articulo
	,Art_1.Categoria as ArticuloCategoria -- Categoria del Articulo
	,Art_1.Familia as ArticuloFamilia -- Familia del Articulo
	,'Pedido' AS TipoElemento -- Tipo de Elemento
	,'' AS LineaOrg
	,'' as LineaDes
	,'PEDIDO' AS TipoMovimiento -- Tipo de Movimientos (obsoleto para formato con separacion de movimientos por linea)
	, 0 as Componente -- Componente
FROM Venta AS Venta 
	INNER JOIN Cte AS Cte_1 ON Venta.Cliente = Cte_1.Cliente 
	INNER JOIN VentaD ON Venta.ID = VentaD.ID 
	INNER JOIN Art AS Art_1 ON Art_1.Articulo = VentaD.Articulo
WHERE (Venta.Mov = 'PEDIDO') 
	AND (Venta.MovID = @PEDIDO) 
	AND (Cte_1.Nombre <> 'EXCEL NOBLEZA, S.A. DE C.V.') 
	AND (Venta.Estatus <> 'CANCELADO')

UNION

SELECT 
	'',
	CONCAT( RTRIM([Mov]),' ',[MovID])
    ,LTRIM(RTRIM(I.[Estatus]))
    ,I.[Almacen]
	,I.[AlmacenDestino]   
	,ID.[Articulo] 
	,A.[Descripcion1]
	,[Cantidad]  
	,LTRIM(RTRIM(UPPER(ID.[Unidad])))
	,ID.[Factor]
	,[CantidadInventario]
	,[DescripcionExtra]
	,I.[Usuario]
	,UPPER(RTrim([Referencia]))
	,I.FechaConclusion
	,I.FechaEmision
	,A.Grupo
	,A.Categoria
	,A.Familia
	,'Transferencia'
	, CASE I.Almacen 
		WHEN 'TERMINADO' THEN 'TERMINADO' 
		WHEN 'RCALMACEN' THEN 'RCALMACEN' 
		WHEN 'TINTAS' THEN 'TINTAS' 
		WHEN 'MATPRIMA' THEN 'MATPRIMA' 
		WHEN 'RECHAZADOS' THEN 'RECHAZADOS' 
		WHEN 'RE-LAMXEST' THEN 'LAMXEXT'
		ELSE SUBSTRING(I.Almacen, 4, len(I.Almacen) - 3) 
		END
	, CASE I.AlmacenDestino 
		WHEN 'TERMINADO' THEN 'TERMINADO' 
		WHEN 'RCALMACEN' THEN 'RCALMACEN' 
		WHEN 'TINTAS' THEN 'TINTAS' 
		WHEN 'MATPRIMA' THEN 'MATPRIMA' 
		WHEN 'RECHAZADOS' THEN 'RECHAZADOS'
		WHEN 'RE-LAMXEST' THEN 'LAMXEXT'
		ELSE SUBSTRING(I.AlmacenDestino, 4, len(I.AlmacenDestino) - 3) 
		END
	,CASE 
		WHEN I.almacenDestino = 'TERMINADO' THEN 'TERMINADO'
		WHEN (I.AlmacenDestino = 'RECHAZADOS' OR LEFT(I.AlmacenDestino,3)='RE-') THEN 'RECHAZADO'
		WHEN (I.AlmacenDestino IN( 'RCALMACEN', 'RC-CALIDAD')) THEN 'DESPERDICIOS'
		WHEN (I.AlmacenDestino) IN ( 'MATPRIMA' ) THEN 'DEVOLUCION'
		WHEN A.Categoria IN ('ME-Material Empaque') THEN 'MATERIAL DE EMPAQUE'
		WHEN A.Grupo IN ('MP-Tintas', 'MP-Solventes', 'Mp-Barniz') THEN 'TINTAS'
		WHEN A.Grupo IN ('MP-Adh Impr') THEN 'ADHESIVOS'
		WHEN A.Grupo IN ('MP-Aditivo', 'MP-Recuperado', 'MP-Pigmento', 'MP-Resinas', 'Ribete', 'MP-Telas') THEN 'ENTRADA MP'
		WHEN CASE I.Almacen 
				WHEN 'TERMINADO' THEN 'TERMINADO' 
				WHEN 'RCALMACEN' THEN 'RCALMACEN' 
				WHEN 'TINTAS' THEN 'TINTAS' 
				WHEN 'MATPRIMA' THEN 'MATPRIMA' 
				WHEN 'RECHAZADOS' THEN 'RECHAZADOS' 
				ELSE SUBSTRING(I.Almacen, 4, len(I.Almacen) - 3) 
			END = CASE I.AlmacenDestino 
						WHEN 'TERMINADO' THEN 'TERMINADO' 
						WHEN 'RCALMACEN' THEN 'RCALMACEN' 
						WHEN 'TINTAS' THEN 'TINTAS' 
						WHEN 'MATPRIMA' THEN 'MATPRIMA' 
						WHEN 'RECHAZADOS' THEN 'RECHAZADOS'
						ELSE SUBSTRING(I.AlmacenDestino, 4, len(I.AlmacenDestino) - 3) 
					END THEN 'PROCESO DE LINEA'		
		WHEN (A.Categoria IN('MP-Materia Prima')) THEN 'MATERIA PRIMA'
		WHEN (A.Categoria IN('PT-Producto Terminado')) THEN 'PRODUCTO TERMINADO'
	END 
	,CASE 
		WHEN A.Grupo IN ('MP-Solventes') THEN 0
		WHEN A.Grupo IN ('MP-Tintas','Mp-Barniz') THEN 0.34
		ELSE 1
	END
FROM [ExcelNobleza].[dbo].[InvD] ID
  INNER JOIN [ExcelNobleza].[dbo].[Inv] I ON I.ID= ID.ID
  INNER JOIN [ExcelNobleza].[dbo].[Art] A ON A.Articulo = ID.Articulo
  WHERE [Mov]='Transferencia' and Referencia like '%' + @Pedido + '%'

UNION

SELECT 
	'',
	CONCAT( RTRIM([Mov]),' ',[MovID])
    ,LTRIM(RTRIM(I.[Estatus]))
    ,I.[Almacen]
	,I.[AlmacenDestino]   
	,ID.[Articulo] 
	,A.[Descripcion1]
	,[Cantidad]  
	,LTRIM(RTRIM(UPPER(ID.[Unidad])))
	,ID.[Factor]
	,[CantidadInventario]
	,[DescripcionExtra]
	,I.[Usuario]
	,UPPER(RTrim([Referencia]))
	,ISNULL(I.FechaConclusion,0)
	,ISNULL(I.FechaEmision,0)
	,A.Grupo
	,A.Categoria
	,A.Familia
	,'Consumos'
	, CASE I.Almacen 
		WHEN 'TERMINADO' THEN 'TERMINADO' 
		WHEN 'RCALMACEN' THEN 'RCALMACEN' 
		WHEN 'TINTAS' THEN 'TINTAS' 
		WHEN 'MATPRIMA' THEN 'MATPRIMA' 
		WHEN 'RECHAZADOS' THEN 'RECHAZADOS' 
		ELSE SUBSTRING(I.Almacen, 4, len(I.Almacen) - 3) 
		END
	,''
	,'CONSUMO'
	, 0
FROM [ExcelNobleza].[dbo].[InvD] ID
  INNER JOIN [ExcelNobleza].[dbo].[Inv] I ON I.ID= ID.ID
  INNER JOIN [ExcelNobleza].[dbo].[Art] A ON A.Articulo = ID.Articulo
  WHERE [Mov] like 'Consumo Material' and Referencia like '%' + @Pedido + '%'

UNION

SELECT 
	''
	,CONCAT( RTRIM([Mov]),' ',[MovID])
	,LTRIM(RTRIM(I.[Estatus]))
    ,I.[Almacen]
	,I.[AlmacenDestino]   
	,ID.[Articulo] 
	,A.[Descripcion1]
	,[Cantidad]  
	,LTRIM(RTRIM(UPPER(ID.[Unidad])))
	,ID.[Factor]
	,[CantidadInventario]
	,[DescripcionExtra]
	,I.[Usuario]
	,UPPER(RTrim([Referencia]))
	,ISNULL(I.FechaConclusion,0)
	,ISNULL(I.FechaEmision,0)
	,A.Grupo
	,A.Categoria
	,A.Familia
	,'Requerido'
	, CASE I.Almacen 
		WHEN 'TERMINADO' THEN 'TERMINADO' 
		WHEN 'RCALMACEN' THEN 'RCALMACEN' 
		WHEN 'TINTAS' THEN 'TINTAS' 
		WHEN 'MATPRIMA' THEN 'MATPRIMA' 
		WHEN 'RECHAZADOS' THEN 'RECHAZADOS' 
		ELSE SUBSTRING(I.Almacen, 4, len(I.Almacen) - 3) 
		END
	, CASE I.AlmacenDestino 
		WHEN 'TERMINADO' THEN 'TERMINADO' 
		WHEN 'RCALMACEN' THEN 'RCALMACEN' 
		WHEN 'TINTAS' THEN 'TINTAS' 
		WHEN 'MATPRIMA' THEN 'MATPRIMA' 
		WHEN 'RECHAZADOS' THEN 'RECHAZADOS'
		WHEN 'RE-LAMXEST' THEN 'LAMXEXT'
		ELSE SUBSTRING(I.AlmacenDestino, 4, len(I.AlmacenDestino) - 3) 
		END
	,'REQUERIDO'
	, 0
FROM Inv AS I INNER JOIN InvD AS ID ON I.ID = ID.ID INNER JOIN Art AS A ON ID.Articulo = A.Articulo
WHERE (I.Empresa = 'GRAL') 
	AND (I.Mov = 'Orden Transferencia') 
	AND (I.Referencia LIKE '%' + @PEDIDO) 
	AND (I.Estatus = 'CONCLUIDO'  or I.Estatus = 'Pendiente') 
	AND (I.Usuario in ('JOSECG', 'HECTORH', 'LAMXEXT'))
	AND (RTRIM(UPPER(ID.Unidad)) = 'KG') AND (SUBSTRING(I.AlmacenDestino, 1, 3) = 'MP-')

UNION

SELECT 
	''
	,CONCAT( RTRIM([Mov]),' ',[MovID])
	,LTRIM(RTRIM(P.[Estatus]))
	,PD.[Almacen]
	,'PRODUCCION'
	,CONCAT(PD.[Articulo],' -Desperdicio')
	,CONCAT(A.[Descripcion1],' -Desperdicio')
	,PD.Desperdicio
	,LTRIM(RTRIM(UPPER(PD.[Unidad])))
	,PD.Factor
	,PD.Desperdicio * PD.Factor
	,PD.DescripcionExtra
	,P.Usuario
	,UPPER(RTrim(P.[Referencia]))
	,P.FechaConclusion
	,P.FechaEmision
	,A.Grupo
	,A.Categoria
	,A.Familia
	,'Transferencia'
	,SUBSTRING(P.Almacen, 4, len(P.Almacen) - 3)
	,'PRODUCCION'
	,'DESPERDICIOS'
	,0
  FROM [ExcelNobleza].[dbo].[ProdD] PD
	INNER JOIN [ExcelNobleza].[dbo].[Prod] P ON  P.ID= PD.ID
	INNER JOIN Art AS A ON PD.Articulo = A.Articulo
  WHERE P.Referencia LIKE '%' + @PEDIDO + '%'
	AND P.Almacen like '%PEXTRUS%'
	AND P.Mov ='Entrada Produccion'

UNION
	
SELECT 
	''
	,CONCAT( RTRIM([Mov]),' ',[MovID])
	,LTRIM(RTRIM(I.[Estatus]))
	,ID.[Almacen]
	,''
	,ID.[Articulo]
	,A.[Descripcion1]
	,ID.Cantidad
	,LTRIM(RTRIM(UPPER(ID.[Unidad])))
	,ID.Factor
	,ID.Cantidad * ID.Factor
	,ID.DescripcionExtra
	,I.Usuario
	,UPPER(RTrim(I.[Referencia]))
	,I.FechaConclusion
	,I.FechaEmision
	,A.Grupo
	,A.Categoria
	,A.Familia
	,'Transferencia'
	,SUBSTRING(I.Almacen, 4, len(I.Almacen) - 3)
	,'PRODUCCION'
	,'CAMBIO PRESENTACION'
	,1
  FROM [ExcelNobleza].[dbo].[InvD] ID
	INNER JOIN [ExcelNobleza].[dbo].[Inv] I ON  I.ID= ID.ID
	INNER JOIN Art AS A ON ID.Articulo = A.Articulo
  WHERE I.Referencia LIKE '%' + @PEDIDO + '%'
	AND I.Almacen like '%PEXTRUS%'
	AND A.Grupo like '%PT-Película'
	AND I.Mov ='Salida Cambio Pres'

UNION
	SELECT 
	''
	,CONCAT( RTRIM([Mov]),' ',[MovID])
	,LTRIM(RTRIM(P.[Estatus]))
	,''
	,PD.[Almacen]
	,PD.[Articulo]
	,A.[Descripcion1]
	,PD.Cantidad
	,LTRIM(RTRIM(UPPER(PD.[Unidad])))
	,PD.Factor
	,PD.Cantidad * PD.Factor
	,PD.DescripcionExtra
	,P.Usuario
	,UPPER(RTrim(P.[Referencia]))
	,P.FechaConclusion
	,P.FechaEmision
	,A.Grupo
	,A.Categoria
	,A.Familia
	,'Transferencia'
	,''
	,SUBSTRING(P.Almacen, 4, len(P.Almacen) - 3)
	,'PRODUCTO TERMINADO'
	,1
  FROM [ExcelNobleza].[dbo].[InvD] PD
	INNER JOIN [ExcelNobleza].[dbo].[Inv] P ON  P.ID= PD.ID
	INNER JOIN Art AS A ON PD.Articulo = A.Articulo
  WHERE P.Referencia LIKE '%' + @PEDIDO + '%'
	AND P.Almacen LIKE '%PEXTRUS%'
	AND A.Grupo like '%PT-Película'
	AND P.Mov ='Entrada Cambio Pres'

order by LineaOrg