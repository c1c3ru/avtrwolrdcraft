# Helpers do runtime IL2CPP nos metodos recuperados (U4 de T025/HANDLER/000032a8) — 2026-11-23

Estatico (Capstone + strings), `libil2cpp.so` sha256 `b63661fa60c2...`. Valem para todo metodo gerado do jogo, nao so DestroyCurrentItems.

| Endereco | Papel | Evidencia | Confianca |
|---|---|---|---|
| `0x1b88980` | lanca `System.NullReferenceException` | chama `0x1b48f78`, que monta a excecao com namespace `System` (`0xb32dce`) e nome `NullReferenceException` (`0xb42dd5`); sem retorno | alta |
| `0x1b88988` | lanca `System.IndexOutOfRangeException` | chama `0x1b48fc4`, mesmo namespace e nome em `0xb49f4d` | alta |
| `0x1b8885c` | garante o construtor estatico da classe (`ClassInit`) | tail-call para `0x1bbd2d8`, que retorna se `[klass+0xe0] != 0` (cctor concluido) e senao executa o cctor; o chamador ja testa `ldr w8,[x0,#0xe0]; cbnz` antes | media-alta |
| `0x1b886e8` | resolve lazy uma entrada de metadata-usage (type/method/string) | `x0` = slot do GOT; chama `0x1bc8270` + `dmb ish`; o chamador depois grava o byte "inicializado" (ex. `strb w8,[x20,#0xc5]`) | media |

## Leitura nos metodos ja recuperados
- `cbz x, 0x...8c; bl 0x1b88980` = deref de nulo -> `NullReferenceException`. `cmp idx,len; b.hs; bl 0x1b88988` = checagem de limite -> `IndexOutOfRangeException`.
- Em `DestroyCurrentItems`: `_points` nulo, ponto nulo ou `GetChild(0)` nulo lancam NRE; indice fora de `_points.Length` lanca IOORE (nao ocorre no laco normal).
- Em `DestroyLevelItem`: `levelItem` nulo e tratado antes (log) e o caminho feliz nao lanca; NRE so se um dos componentes/`gameObject` intermediarios for nulo
  (ex. `GetComponentInParent<ICATarget>()` ja testado, mas `levelItem.gameObject` apos destruicao parcial nao).
- Os blocos `if (cctor nao concluido) 0x1b8885c` e `if (!flag) 0x1b886e8 ... flag=1` sao so inicializacao preguicosa; nao tem semantica de jogo.

## Ainda aberto em T025/HANDLER/000032a8
Virtuais e genericos ja fechados (`RECON_LEVELITEM_VTABLE`, `RECON_GENERIC_USAGES`); revisao independente feita em `REVIEW_INDEPENDENT_RE_2026-11-23.md`. Fila nao alterada.
