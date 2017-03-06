# px-dotnet

# Contenido: # 
- Instalacion


## Instalación 

### Usando nuget
### COMANDOS DE INTEGRACIÓN NUGET:

- Creación de Metadata - Spec XML: nuget spec

- Empaquetado: nuget pack [projectName].csproj -IncludeReferencedProjects

- Push a repositorio de staging nuget: nuget.exe push [packageName].[version].nupkg [appKey] -Source [repositoryName]

### Ejemplos aplicables a paquete SDK:
- Empaquetado: nuget pack px-dotnet.csproj -IncludeReferencedProjects
- Push a nuget staging: nuget.exe push MercadoPagoSDKBETA.1.nupkg e7261db2-921d-46dd-bb8d-512c3e62ddd0 -Source https://int.nugettest.org/api/v2/package
