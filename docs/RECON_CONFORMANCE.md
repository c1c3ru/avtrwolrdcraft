# Harness de conformidade diferencial (T027, parcial)

Objetivo: impedir que o C# se afaste da evidência extraída do original. Não substitui replays no aparelho (T056); confere o que dá para provar estaticamente.

## Como usar
```
python3 -m venv /tmp/capvenv && /tmp/capvenv/bin/pip install capstone      # só para os imediatos fmov
/tmp/capvenv/bin/python tools/recon_conformance.py                          # sai com 0 se tudo conforme, 1 se não
/tmp/capvenv/bin/python tools/recon_conformance.py --checkout <outra-arvore>  # confere outra árvore de fontes
```
Dados do original (`out/`, não versionados) vêm de `--root` (padrão `/home/deppi/avatarworld-re`). O manifesto é `tools/conformance_manifest.json`.

## O que confere (24 checagens)
| Tipo | Lado do original | Lado do C# |
|---|---|---|
| `float_rodata` | float lido de `.rodata` pelo VA (0.06, 0.006) | regex no preset `Animal` de `LocomotionStateMachine.cs` |
| `fmov_immediate` | imediato da instrução `fmov` (18.0 e 6.0 em `LevelAnimal.OnMovement`) | idem |
| `serialized_value` | `m_DragThreshold` de todas as `EventSystem` (deve ser um único valor, 10) | `DefaultThresholdPixels` |
| `enum` | enum do stub do Cpp2IL (`CAPlayType`, `MovementType`, `PostureType`, `AvatarHandType`) | enum equivalente (com mapa de nomes) |
| `string_literal` | literal presente nos metadados do original | **literal exato entre aspas** no C# |
| `animations` | nomes presentes no esqueleto (`Avatar_Spine`, `Toddler_Spine`, `Pet_Dog_Spine`, `Pet_Cat_Spine`) | nomes entre aspas no C# |

## Verificação do próprio harness (teste de mutação)
Numa cópia dos fontes foram adulteradas 4 coisas: `StartWalkSpeed` 0.06→0.07, `PlayingAlternateIdle` 2→5, `Crawling_Loop`→`Crawling_Loopx` e o limiar 10→12. O verificador acusou as 4 (20/24). A primeira versão deixava passar a adulteração de string porque testava substring; passou a exigir o literal entre aspas.

## Limites
- Só confere valores que estão no manifesto; não prova que a **lógica** (ordem, condições) é igual. Para isso valem os testes unitários de cada contrato e, depois, replays no aparelho.
- `fmov_immediate` e `float_rodata` apontam VAs de binário específico (`libil2cpp.so` v1.227); outro build exige reapontar.
- Literais "presentes nos metadados" provam existência no original, não o ponto de uso (isso foi provado método a método nas seções 12–17 de `RECON_CHARACTER_CONTRACT.md`).
- Constantes de Character/Toddler iguais às do animal foram conferidas pela leitura do assembly, mas só o preset `Animal` está no manifesto.
