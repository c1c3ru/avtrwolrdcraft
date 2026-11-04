# Atlas completo do avatar — pesquisa

## Evidencia do original

- `Avatar_Spine.atlas` contem 2.172 paginas unicas.
- `SpineAtlasAsset` `resources.assets/724126` contem exatamente 2.172 referencias de Material,
  na mesma ordem das paginas.
- A leitura de `_MainTex` desses 2.172 Materials mostrou 2.171 texturas `1x1` e apenas uma
  textura com a dimensao declarada pela pagina.
- Portanto as paginas do atlas sao templates. As texturas visuais de roupa nao possuem um unico
  valor canonico por pagina: o SUT troca `Material.mainTexture` conforme o item/variante selecionado.
- `MaterialsTextureLoader` casa pagina e Material pelo nome de `Material.mainTexture`; um dummy
  generico nao resolve nenhuma pagina e produz um erro para cada nome ausente.

## Codigo atual

- `Assets/Scripts/Runtime/AvatarGpuRuntime.cs` fornece Materials apenas para corpo e para as
  variantes do manifesto reduzido, adiciona um dummy sem nome correspondente e silencia os erros
  durante o parse.
- O mesmo arquivo ja implementa corretamente a troca SUT de uma textura real por template.

## Resultado necessario

- Criar uma textura nomeada e um Material para cada uma das 2.172 paginas antes do parse.
- Substituir os placeholders pelas texturas reais ja disponiveis para corpo e roupas conhecidas.
- Manter a troca dinamica SUT existente.
- Nao silenciar logs: qualquer pagina sem Material deve voltar a ser falha observavel.
- Validar que todas as paginas possuem `rendererObject` e que a contagem e 2.172.

## Restricoes

- Nao escolher arbitrariamente um PNG entre variantes SUT de mesmo template.
- Nao embutir as 24.100 variantes SUT no player; elas pertencem aos itens e devem ser carregadas
  conforme o catalogo crescer.
- Preservar o comportamento visual atual das selecoes ja implementadas.
