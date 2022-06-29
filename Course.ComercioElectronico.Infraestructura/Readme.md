#Comandos para crear las migraciones
#Agregar migracion
add-migration nombredeMigracion -Context ComercioElectronicoDBContext

#Aplicar migracion
update-database -Context ComercioElectronicoDBContext

# Realizar migracion por script
script-migration -Context ComercioElectronicoDBContext -From Inicial

# Genera script desde la primera migracion hasta la ultima
script-migration -Context ComercioElectronicoDBContext 0


# Script para ver claves foraneas
SELECT
OBJECT_NAME(parent_object_id) as [FK TABLE], name as [Foreing Key],
OBJECT_NAME(referenced_object_id) as [PK TABLE] FROM sys.foreign_keys

