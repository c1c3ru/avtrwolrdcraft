# Bootstrap IL2CPP — primeiras identidades, endereços e chamadas reais

Rodada: 2026-11-01. Pacotes do plano mestre: T004/T021/T022, com evidência parcial para T025/T029. O trabalho reutiliza o APK base, split arm64, stubs e ferramentas existentes. Nenhum arquivo original, save ou código do cliente foi modificado.

## Resultado executado

`tools/recon_il2cpp.py` extraiu os dois membros abaixo para `out/recon/il2cpp/`, verificando o conteúdo contra os membros ZIP originais. A extração derivada é reaproveitada se tamanho e SHA-256 coincidirem.

| Input | Tamanho | SHA-256 |
| --- | ---: | --- |
| `assets/base.apk` → `assets/bin/Data/Managed/Metadata/global-metadata.dat` | 16.072.324 | `1ea14cf5829d5c31e5e967b1608b5701020ab0d24bd4ab69d9f1e2b243467bc6` |
| `assets/split_config.arm64_v8a.apk` → `lib/arm64-v8a/libil2cpp.so` | 74.680.624 | `b63661fa60c23ebef1c2da4bb5288ad787eb3da36b22d4bdf285401f1643d728` |

**STATIC:** metadata com magic `0xFAB11BAF`, versão 31; ELF64 little-endian `EM_AARCH64`, `ET_DYN`. Os VAs abaixo são endereços de link, não endereços observados num processo Android.

**DERIVED:** a interpretação estreita de layout v31 usa registros de método de 36 bytes, tipos de 88 bytes e imagens de 40 bytes. Não é um parser genérico de qualquer release IL2CPP. Foi corroborada neste par por:

1. offsets/tamanhos das tabelas dentro do arquivo e divisibilidade pelos strides;
2. strings válidas, imagem e ranges de tipos;
3. tipo declarante de todos os métodos selecionados consistente com o range do tipo;
4. tokens MethodDef com RIDs únicos e densos por imagem;
5. módulo codegen reconhecido por ponteiro relocável para o nome exato da imagem, contagem igual e tabela legível;
6. ponteiros não nulos alinhados a quatro bytes e dentro de LOAD executável/file-backed.

O módulo candidato de `Assembly-CSharp.dll` está no VA `0x3fccf10`; contagem 36.421; tabela de ponteiros em `0x4280260`. Os ponteiros foram resolvidos por relocations `R_AARCH64_RELATIVE`, sem aplicar ou modificar o ELF original.

## Cobertura obtida e limites

| Recorte | Resultado |
| --- | ---: |
| Métodos definidos em todas as 96 imagens metadata | 120.743 indexados estruturalmente |
| Ponteiros nulos nessas imagens | 10.336, não resolvidos por esse procedimento |
| Métodos de Assembly-CSharp | 36.421 |
| Ponteiros não nulos executáveis de Assembly-CSharp | 35.831 |
| Endereços não nulos únicos de Assembly-CSharp | 35.831 |
| Ponteiros nulos de Assembly-CSharp | 590 |
| Métodos piloto nas três classes de navegação | 55 |

**Indexar endereço não recupera lógica.** Ponteiros nulos podem representar métodos abstratos, genéricos, compartilhados ou resolvidos em runtime; permanecem desconhecidos. Instanciações genéricas, RGCTX, invokers, funções nativas sem metadata, vtables e chamadas indiretas não foram fechados. As estruturas completas CodeRegistration/MetadataRegistration ainda não foram recuperadas.

## Primeiros métodos do fluxo Play

| Classe e método | Token | VA | Offset de arquivo |
| --- | --- | --- | --- |
| `Game.Home.HomePlayButton.LoadPlayScene` | `0x060054ef` | `0x2057fa8` | `0x2053fa8` |
| `PWC.GameSceneManager.LoadScene` | `0x060056fe` | `0x20728d4` | `0x206e8d4` |
| `PWC.GameSceneManager.LoadSceneImplement` | `0x060056ff` | `0x2072cc8` | `0x206ecc8` |
| `PWC.GameSceneManager.GetCurrentWorldSceneName` | `0x06005708` | `0x2073238` | `0x206f238` |
| `PWC.World.Buildings.WorldBuilding.ClickOnLevel` | `0x06006081` | `0x2108e90` | `0x2104e90` |

Foi localizado o LLVM objdump já instalado no Android NDK `29.0.13599879`. Ele produziu cinco janelas limitadas de assembly, com no máximo 2.048 bytes por janela e corte no próximo ponteiro distinto conhecido. **Esse corte é uma janela operacional, não prova de tamanho/corpo completo.** Uma função pode ter regiões separadas, handlers e destinos fora da janela.

Os labels `__start_il2cpp+...` e `JNI_OnUnload+...` impressos pelo objdump são aproximações ao símbolo exportado mais próximo; não são nomes recuperados das funções. Usar o join metadata em `pilot_disassembly.json` para nomear alvos reais.

### Cadeia estática já sustentada por instruções

| Origem | Instrução | Alvo mapeado |
| --- | --- | --- |
| LoadPlayScene, `0x20580c8` | `BL 0x2073238` | GetCurrentWorldSceneName |
| LoadPlayScene, `0x20581e4` | `B 0x20728d4` | LoadScene, tail branch |
| LoadScene, `0x2072c54` | `B 0x20fe2d8` | LoadingScreenManager.StartSceneTransition |
| LoadSceneImplement, `0x2072d80` | `B 0x3cdc604` | UnityEngine.SceneManagement.SceneManager.LoadSceneAsync |
| ClickOnLevel, `0x2108f90` | `BL 0x2109138` | WorldBuilding.IsCurrentlyFree |
| ClickOnLevel, `0x2108f9c` | `BL 0x1cbb7a8` | PazuCore.Utils.IsGameUnlocked |
| ClickOnLevel, `0x2109008` | `BL 0x20feda8` | WorldBuildingPreviewPopup.Show |

LoadPlayScene também possui caminho com PlayerPrefs.HasKey/GetString/DeleteKey/Save e chamada indireta `BLR x8` em `0x2058174`. LoadScene contém três chamadas indiretas e limpeza de caches de avatar/SUT/CarMaker. Essa rodada não resolveu os alvos dessas chamadas indiretas nem todas as condições. Não substituir o método inteiro por “sempre abrir World” sem fechar esses caminhos.

### Getter do mundo salvo: contrato estático candidato

A janela `0x2073238..0x207330c` contém `RET` em `0x2073308`. O assembly faz Enum.ToString, PlayerPrefs.GetString, IsSceneAvailable e seleção condicional da string de retorno. A resolução dos operandos por metadata usage foi conferida para o hash exato do binário:

- Referência GOT `0x41c85b8` → usage `0x43498a0`, codificação `0xa0003319` → literal índice 6540: **`GAME_CURRENT_WORLD`**.
- Referência GOT `0x41b7d08` → usage `0x42f4268`, codificação `0x2000ce33` → type index 26393: **`PWC.Game.LevelWorldType`**.
- Imediato enum no código: 1. O enum existente em Cpp2IL identifica **World = 1**.

Interpretação sustentada para revisão:

```text
defaultWorldName = LevelWorldType.World.ToString()
candidate = PlayerPrefs.GetString("GAME_CURRENT_WORLD", defaultWorldName)
return IsSceneAvailable(candidate) ? candidate : defaultWorldName
```

Esse é um **contrato estático candidato**, não equivalência certificada. Ainda faltam corpo/efeitos de IsSceneAvailable, inicialização de classes, exceções, domínio de strings e comparação contra o original. O probe é explicitamente ligado ao SHA-256 acima, verifica opcodes esperados e não aplica os endereços a outra versão.

## Ferramentas e artefatos

```bash
python3 tools/recon_il2cpp.py
python3 tools/recon_il2cpp.py --self-test
```

- `reports/recon/il2cpp_bootstrap.json`: manifesto pequeno, contagens, segmentos, verificações, ferramentas, 55 métodos piloto e limitações.
- `out/recon/il2cpp/assembly_csharp_methods.jsonl`: índice detalhado de 36.421 métodos do jogo.
- `out/recon/il2cpp/metadata_methods.jsonl`: índice leve das 96 imagens para nomear callees.
- `out/recon/il2cpp/pilot_disassembly.json`: janelas, comando exato, branches codificados e alvos metadata quando resolvidos.
- `out/recon/il2cpp/*.asm.txt`: assembly limitado dos cinco métodos.
- `out/recon/il2cpp/getter_operands.json`: probe de literal/tipo e contrato candidato do getter.
- `out/recon/il2cpp/self_test.json`: sete verificações negativas, zero falhas.

O índice completo e os binários extraídos são derivados volumosos locais, não devem ser adicionados ao Git indiscriminadamente.

## Verificações executadas

O comando normal passou as verificações de ranges, owners/tokens, joins das 96 imagens e alinhamento/mapeamento executável. Os sete testes negativos rejeitaram: ELF sem magic, arquitetura x86-64 não suportada, metadata de versão diferente, tamanho de tabela incompatível com stride, owner de método inconsistente, VA sem mapeamento e contagem codegen incompatível com metadata. As cópias inválidas foram apenas em memória; originais intactos.

Esses testes verificam os guardas do bootstrap, não são testes diferenciais do jogo. Não houve instalação de dependência, rede, execução Android, emulação, compra ou contorno de PairIP.

O coordenador relatou que a tentativa nativa REA/Hopper nesta rodada falhou em `provider_timeout` aguardando readiness da bridge por 120 segundos, com sugestão de verificar diálogo de loader/licença. Nenhuma semântica do REA resultou dessa tentativa; o alvo foi fechado pelo coordenador. Essa evidência de falha pertence ao registro do coordenador. O trabalho acima é resultado de parser local e LLVM, não Evidence REA.

## Próximos passos concretos

1. Revisar independentemente o join metadata↔codegen e os opcodes dos métodos piloto; conservar desconhecidos dos 10.336 ponteiros nulos.
2. Recuperar IsSceneAvailable, SetCurrentWorldSceneName, o callback `<LoadScene>b__0`, StartSceneTransition e estado do loading; seguir chamadas indiretas relevantes.
3. Fechar os dois caminhos de LoadPlayScene (mundo salvo e chave temporária) e identificar a interface chamada em `BLR x8`.
4. Mapear guardas de acesso/preview de ClickOnLevel sem tratar `_isFree=0` como disponibilidade real.
5. Usar os endereços agora conhecidos num provider nativo funcional ou continuar com LLVM/contratos locais; não repetir timeout do Hopper sem mudança no bloqueio.
6. Criar fixtures e observação original Home→mapa→ambiente→retorno antes de promover a cadeia a comportamento validado.

T021 e T022 estão **parciais**, não concluídos: há identidade forte do par e índice estrutural útil, mas registrations completas, generic dispatch, regiões fora da metadata e lógica ainda pendentes.
