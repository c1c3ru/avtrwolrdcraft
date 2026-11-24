# Tabela de usos de metadata do IL2CPP: um bloco de 6.390 entradas nao decodifica — 2026-11-24

Continuacao do T025 (despacho indireto de `HomePlayButton.LoadPlayScene` em `0x2058174`, ver `RECON_T025_BODY_BOUNDS_2026-11-23.md`).
Ferramenta: `tools/recon_usage_table.py` (reproduz tudo abaixo). Binario: `libil2cpp.so` sha256 `b63661fa60c2...`.

## Como o jogo resolve uma referencia de metadata (lido, `0x1b561d0`)
O codigo carrega `ldr xN, [slot_da_.got]` e obtem um endereco **A** na `.data`; antes de usar chama `InitializeRuntimeMetadata(A)` (`0x1b886e8` -> `0x1bc8270` -> `0x1b561d0`),
que le `*A`:
- **bit0 == 0**: ja e um ponteiro resolvido; devolve como esta.
- **bit0 == 1**: e um token. `tag = (v >> 29) & 7`, `indice = (v >> 1) & 0x0FFFFFFF`. Tags vistas no binario: 1 = tipo/classe, 3 = metodo (MethodDef),
  4 = campo (via `fieldRefs`: tipo + indice no tipo), 5 = string literal, 6 = MethodRef (generico). Depois da resolucao, o runtime grava o ponteiro em `*A`.
O `recon_disasm.py` usa a mesma ideia para anotar `; type X` e `; "string"`.

## O achado
Das **66.844** entradas da `.data` apontadas pela `.got`: 6.946 tag 1, 14.344 tag 3, 646 tag 4, 22.095 tag 5, 16.417 tag 6, 4 tag 7, 2 zero, e **6.390 que nao sao token**.
Essas 6.390 formam **um unico bloco contiguo**: `0x42e55f8`..`0x42f1da0`. Nao e zero nem token de 32 bits:
- 64 bits cheios, todas as metades baixas distintas, metades altas com so **1.407** valores distintos (cada um repetido de 3 a 7 vezes), bit0=1 em 48% das entradas;
- `zlib` comprime a 0,58 (aleatorio puro daria ~1,0) e as 16 bytes consecutivos nunca se repetem.
Ou seja, ha estrutura, mas nao e um token de IL2CPP e nao decodifica pela regra acima. XOR/soma/rotacao simples entre as duas metades nao produz tokens (taxa ~37%, igual ao acaso).

## O que isso explica
- Os dois slots do despacho do `HomePlayButton` (`0x41c7a98` -> `0x42eb4d8` e `0x41aeea8` -> `0x42f08b0`) caem nesse bloco: por isso a interface alvo e o campo do singleton nao decodificam.
- Idem o slot da propria classe `HolidayGameModeButton` (`0x42f1a68`) e outros "type"/"method" sem anotacao em varios `.asm` desta serie.
- Nenhuma das 24 funcoes de `.init_array` referencia esse bloco (olhei so as primeiras ~600 bytes de cada), entao nao achei um decodificador dentro da `libil2cpp.so`.

## O que NAO sei
- Se o bloco e **cifrado/ofuscado** (por exemplo por protecao do app, como o PairIP ja documentado) e reescrito antes do uso, ou se e outra estrutura (uma tabela diferente que a `.got` aponta por outro motivo). Os dados so mostram que nao e token.
- Quantos metodos usam entradas do bloco. Nao varri os 36 mil metodos.
- Nao tentei quebrar a transformacao: sem texto claro conhecido para esse bloco nao ha como validar uma hipotese.

## Consequencia para o T025
Metodos cujo corpo depende dessas entradas (classe do proprio tipo, interfaces, campos estaticos) ficam com tipos/classes **nao resolvidos** estaticamente; so os de tag 1/3/4/5/6 fora do bloco resolvem. O despacho do `HomePlayButton`
continua **inferido** (slot 0 de uma interface de dicionario), agora com a causa documentada. Resolver exige olhar o runtime (dump de memoria apos a inicializacao) ou achar a rotina que escreve o bloco.

## Versao do IL2CPP e do Unity (conferido em 2026-11-24)
- Original: **Unity 2022.3.70f1** (string `2022.3.70f1` na `libil2cpp.so`) e **`global-metadata.dat` versao 31**. (O cliente reimplementado usa Unity 6000.6.6f1; nao tem relacao com o original.)
- O despachante `0x1b561d0` bate com o esquema de tokens do IL2CPP 2022.3: `bit0 == 0` ponteiro pronto, `bit0 == 1` token com tag em 29..31 e indice em 1..28. Tabela de saltos das tags (`0xec3eec`):
  tag 1 -> classe a partir de indice de tipo; tag 2 -> `registration->types[idx]` (`Il2CppType*`); tags 3 e 6 -> o mesmo tratador de metodo (`0x1b56430`);
  tag 4 -> `FieldInfo` via `fieldRefs`; tag 5 -> string literal (com cache); tag 7 -> tratador proprio (`0x1b562f8`, 4 entradas no binario). A regra que usei esta certa para a versao.
- **Portanto a versao nao explica o bloco**: a decodificacao esta correta e as 6.390 entradas continuam sem ser token.

### Layout da tabela (novo)
Os alvos da `.got` na `.data` formam **uma regiao contigua unica** (`0x42e55f8`..`0x4367ec0`, 66.842 entradas), agrupada por tipo de uso, nesta ordem de endereco:
`[6.390 nao-token]` → `[6.946 tag 1]` → `[tag 6 e tag 3 em trechos alternados]` → `[tag 4, 646]` → `[22.095 tag 5, strings]`.
Ou seja, o bloco e o **primeiro grupo da tabela**, nao um pedaco no meio de outro grupo.

### O que os slots do bloco sao (inferencia pelo uso no codigo)
Os usos conhecidos tratam o valor como `Il2CppClass*`: a classe do proprio tipo (`ldr x8,[x20]; ldr x8,[x8,#0xb8]` = `static_fields` em `HolidayGameModeButton..cctor`),
a classe de array de `LevelWorldType` (`SzArrayNew(classe, 4)`) e a interface procurada na tabela de offsets de interface do `HomePlayButton`.
Isso sugere que o grupo guarda referencias de classe que precisam de montagem em tempo de execucao (tipo proprio, arrays, instancias genericas). **Nao confirmado**: so vi 3 usos.

## Quantos metodos usam o bloco (medido, `tools/recon_usage_impact.py`)
Para cada metodo de Assembly-CSharp (35.831 com endereco), desmonta o corpo e segue o par `adrp` + `ldr` ate o slot da `.got`; conta o metodo se o slot aponta
para uma entrada do bloco nao-token. Heuristica: so enxerga o par direto, nao copias de registrador.

| | |
|---|---|
| Metodos analisados | 35.831 |
| Com pelo menos um uso do bloco | **9.364 (26,1%)** |
| Tipos com algum metodo afetado | 3.089 de 4.715 |

- Nao e um canto isolado: **um em cada quatro metodos** carrega ao menos uma referencia desse grupo (classe do proprio tipo para estaticos, arrays, instancias genericas...).
  Entre os tipos de que ja falamos: `HomePlayButton` (6 metodos), `HolidayGameModeButton` (7), `ClothesDropUtils` (5), `GameSceneManager` (22), `WorldBuilding` (13);
  `ClothesDropDataMap` nao tem nenhum.
- Efeito pratico: em quase todo metodo afetado so a **referencia de classe/instancia** fica sem nome; o corpo continua legivel (fluxo, chamadas diretas, strings, campos por offset),
  como vimos em todas as leituras desta serie.
- Nota de medicao: a primeira execucao leu `assembly_csharp_methods.jsonl` e `metadata_methods.jsonl`, que repetem os metodos de Assembly-CSharp, e contou o dobro
  (71.662 / 18.728); os numeros acima sao os valores **sem repeticao por endereco**, obtidos deduplicando o JSON dessa execucao. O script ja foi corrigido, mas **nao foi reexecutado por inteiro**
  (a varredura leva ~25 min); so testei a versao corrigida com `--limit 300`.
