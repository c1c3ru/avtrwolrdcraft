# Configurações e nomes de animação contextual — T035

Atualizado em 2026-11-05. O extrator `tools/recon_contextual_links.py` conecta componentes serializados às configurações e reações contextuais, preservando a identidade `(arquivo, path_id)` de cada objeto. A presença de um nome no rig é evidência estática; seleção, cancelamento e efeitos em jogo seguem abertos.

## Dados e ligações recuperadas

A varredura de 2.305 inventários MonoBehaviour examinou 878.040 registros, além dos dois inventários de dados contextualizados. Há 974 assets `LevelCAItemHandlerData` com 3.150 configurações e 71 assets `LevelCAReactionsData` com 114 reações.

Foram resolvidas 5.704 referências para esses assets, provenientes de 5.678 componentes. Elas alcançam 894 assets de configuração e 66 de reação. Os 85 assets restantes não têm referência direta encontrada nesses dumps; podem exigir carregamento por nome ou outras fontes. Não houve referência declarada `Data` de `LevelCA*` sem resolução neste recorte.

O extrator lê as tabelas de referências externas de 239 arquivos serializados, diretamente dos intervalos necessários do UnityFS. O cache depende do SHA256 integral do bundle e registra o hash de cada prefixo de metadados. Uma retomada com o mesmo conteúdo reutilizou as 239 tabelas sem descomprimir blocos. Uma segunda reconstrução das identidades verificou todas as 5.704 ligações.

## Construção do nome

A janela nativa de `LevelCAConfig.CreateAnimationName` em `0x212fe74`, os campos recuperados e os getters com dados sustentam esta regra:

1. Se `isNameFullAnimationName` estiver ativo, retornar `config.name` diretamente.
2. Caso contrário, concatenar o prefixo, a pasta, `/`, o nome e o sufixo do handler.
3. `HasCAPrefixForCAAnimations` em `0x2187938` retorna verdadeiro para SpineType 1 (Character), 2 (Baby) e 13 (Toddler); nesses casos o prefixo é `CA/`.
4. A pasta usa `folderNameOverride` quando preenchida; nos handlers com dados, o getter básico usa `Data.FolderName`.

As 3.150 configurações têm o nome-base presente no rig correspondente, incluindo aves, peixes, roedores e outros animais. Isso confere o conteúdo disponível, mas uma classe pode alterar a pasta, trocar os dados ou acrescentar um sufixo em execução.

## Treze regras de sufixo

As 13 declarações de override encontradas foram cobertas por janelas nativas e literais:

- Nove handlers de toddler retornam `"_" + toddler.PostureType.ToString()`. O campo é lido em `LevelToddler + 0x440`; os valores declarados são `None=0`, `Standing=1`, `Sitting=2`.
- `LevelCACatOnToddlerHandler`, `LevelCADogOnToddlerHandler` e `LevelCASmallPetOnToddlerHandler` retornam `_Standing`.
- `LevelCAToddlerDancingClothingSpineSkinHandler` retorna `_Sitting` se a postura for Sitting e uma string vazia nos outros casos.
- O getter básico de `LevelCAHandlerBase` retorna uma string vazia.

As fórmulas e evidências por classe estão em `suffix_rules` no relatório. O extrator confere os literais e os acessos nativos esperados antes de aceitar essas classificações.

## Reações e diferenças de nomes

O predicado nativo de `FindReactionIfExist` em `0x1ee91b0` compara o nome da animação iniciadora usando `String.op_Equality`. `GetResolvedReactionAnimationName` em `0x22483d0` escolhe uma alternativa aleatória quando a lista está preenchida; caso contrário devolve `reactionAnimationName` sem alterar o nome.

Das 114 entradas, 113 nomes iniciadores existem em pelo menos um dos rigs mapeados e 111 nomes de reação existem no rig do ator que reage. O SpineType da reação identifica o ator que reage; ele não identifica necessariamente o ator iniciador.

Quatro entradas em dois assets precisam de reconciliação:

- `Bubble_Blower_Tube_L209_Baby_ReactionData` contém três reações com `CA/General/Look_Around_Amazed`, ausente no rig Baby. Esse rig contém `General/Look_Around_Amazed`.
- `ToddlerBookReadingAnimationsReactionsData2` usa o iniciador `CA/Infant_Book/Reading_Aloud_Hand_Motions`, não encontrado nos rigs mapeados. O rig Character contém `CA/Reading/Reading_Aloud_Hand_Motions`.

Essas alternativas são candidatas sustentadas pelos arquivos, sem alteração dos dados originais nem conclusão de defeito em runtime. Os campos e fontes completos estão em `followups`.

## Reprodução e continuidade

Executar a preparação canônica de T035 e, então:

```sh
python3 tools/recon_save_static.py --scope contextual
python3 tools/recon_string_literals.py out/recon/tasks/T035/contextual-asm/GetAnimationSuffix_*.asm.txt --output out/recon/tasks/T035/contextual-suffix-literals.json
tools/venv/bin/python tools/recon_contextual_links.py
```

O relatório completo fica em `out/recon/tasks/T035/contextual-links.json`; o cache em `contextual-metadata-cache.json`; as 33 janelas ARM64 em `contextual-asm/`. O estado canônico de T035 permanece parcial, com dependências pendentes. O próximo recorte é recuperar o ciclo de adicionar/remover/cancelar/concluir dos handlers básicos e reconciliar os dois assets de reação e os carregamentos indiretos. A validação no aparelho continua adiada conforme combinado.
