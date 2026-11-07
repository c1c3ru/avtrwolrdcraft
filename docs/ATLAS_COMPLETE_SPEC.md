# Especificacao — atlas completo do avatar

## `Assets/Scripts/Runtime/AvatarAtlasLoader.cs` — CRIAR

- Extrair os nomes unicos das paginas do texto Spine.
- Exigir a contagem esperada fornecida pelo chamador.
- Criar uma textura transparente `1x1`, com o nome exato, para cada pagina sem textura real.
- Usar texturas reais fornecidas por nome de pagina quando disponiveis.
- Criar o `SpineAtlasAsset` com um Material por pagina e devolver o mapa pagina→Material.
- Depois do parse, exigir que todas as paginas tenham `rendererObject` nao nulo.

## `Assets/Scripts/Runtime/AvatarGpuRuntime.cs` — MODIFICAR

- Carregar atlas/esqueleto antes da montagem dos materiais.
- Reunir em um mapa as texturas reais de corpo e das roupas conhecidas.
- Delegar a criacao completa do atlas ao `AvatarAtlasLoader`.
- Remover dummy generico, lista parcial de Materials e supressao de logs.
- Preservar `_materialByPage` para as trocas SUT existentes.
- Registrar 2.172 paginas resolvidas; abortar com erro se a validacao falhar.

## `Assets/Tests/EditMode/AvatarAtlasLoaderTests.cs` — CRIAR

- Usar o `Avatar_Spine.atlas` real do projeto.
- Validar 2.172 nomes unicos.
- Criar o atlas completo e verificar 2.172 paginas, zero `rendererObject` nulo e zero logs de erro.
- Verificar que uma textura real fornecida substitui o placeholder da pagina correspondente.
