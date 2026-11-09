# T026 — inventário, fluxo de corrotinas e wrappers de scheduling

Rodada de 2026-11-08. Trabalho estático sobre o par IL2CPP/metadata já identificado. Esse conjunto cria um mapa verificável para dividir a recuperação das máquinas de estado; um inventário ou censo de fluxo não equivale a recuperar a semântica do jogo.

## Universo encontrado

`tools/recon_t026_inventory.py` reconcilia o inventário histórico de 437 entradas com 449 tipos atuais que implementam IEnumerator/IAsyncStateMachine em Assembly-CSharp: 387 com interface enumerator e 62 com interface async. Foram encontrados 12 tipos novos. Os escopos resultantes são:

| Disposição | Quantidade | Significado |
| --- | ---: | --- |
| Obrigatórios do conjunto histórico | 169 | Permanecem no objetivo de análise |
| Candidatos adicionais de gameplay | 38 | Incluídos na recuperação pendente |
| Helper concreto obrigatório | 1 | Dependência reconhecida e delimitada |
| Dependências condicionais | 115 | Escopo depende da cadeia de uso/feature |
| Exclusão apenas do reimplementador | 92 | Não remove itens do inventário original; é decisão da reconstrução |
| Escopo ainda não resolvido | 34 | Exige triagem antes de qualquer conclusão |

O relatório [t026_inventory.json](../reports/recon/t026_inventory.json) também registra 458 sites eventuais e 1.147 candidatos de closure. São sinais de planejamento, não edges semânticos certificados. A revisão independente [t026_inventory_review.json](../reports/recon/t026_inventory_review.json) aceita somente inventário e planejamento pendente.

Para dividir a revisão por identidade, [t026_machine_children_2026-11-08.json](../reports/recon/t026_machine_children_2026-11-08.json) gerou 448 especificações, reutilizando o filho `execute-next-frame` já existente. As 448 foram importadas à fila como `pending`, cada uma ligada a uma identidade de máquina e às dependências T022–T025; nenhuma disposição nem semântica foi automaticamente aceita.

## Censo limitado de `MoveNext`

`tools/recon_t026_flow_census.py` produziu slices para os 449 registros: 445 têm ponteiro/janela analisável e quatro têm ponteiro nativo nulo (`0x020000e8`, `0x02000143`, `0x02000144`, `0x020013cf`). As 445 janelas cobrem 411.168 bytes e 86.204 instruções alcançáveis no decoder local. Cada janela termina no próximo início metadata; o limite não garante corpo inteiro, blocos não contíguos ou regiões de exceção.

Todos os 445 foram classificados apenas `bounded_flow_only`; os quatro nulos permanecem `unresolved_pointer`. **Nenhuma das 449 máquinas teve semântica aceita.** A revisão independente [t026_flow_census_review.json](../reports/recon/t026_flow_census_review.json) reconstruiu identidades, slices, edges de chamada e controles a partir das entradas raw e manteve todos os flags de conclusão false.

## Contratos concretos adicionais

### `ExecuteOnConditionCoroutine`

[t026_condition.json](../reports/recon/t026_condition.json) liga oito métodos (factory, wrapper e lifecycle) e nove campos aos offsets de `fieldOffsets`. No caminho local observado:

- estado 0 grava `-1`, aplica o clamp ordenado para `checkInterval >= 0,1f`, prepara `WaitForSeconds` e inicia o timer;
- após retomada, o estado 1 incrementa `safeTimer` por `checkInterval`; um `maxWaitTime > 0` alcançado precede a avaliação da condição;
- callback de timeout é opcional; a condição e o Action principal têm guards distintos;
- Dispose é `RET` sem escrita local; Reset cria `NotSupportedException` e cruza um helper de exceção não modelado.

A revisão [t026_condition_review.json](../reports/recon/t026_condition_review.json) aceita contrato estático delimitado. Tempo escalado, agendamento real, callback efetivo, exceções e comportamento do scheduler Unity não foram observados.

### Wrappers `StartCoroutine`/`StopCoroutine`

[t026_scheduler.json](../reports/recon/t026_scheduler.json) verifica oito wrappers do CoreModule, onze strings/icalls e guards/construtores de erro. A revisão [t026_scheduler_review.json](../reports/recon/t026_scheduler_review.json) confirma identidade e bytes dos wrappers e separa as referências externas de API. Os destinos nativos resolvidos por icall não foram ligados às implementações de libunity; timing, disposal, propagação de erro e ciclo de vida do host continuam desconhecidos.

## Verificação e limites

`python3 -m unittest discover -s tools -p 'test_recon_t026_*.py' -v` passou **46 testes** em **60,981 s**. O teste de condição também passou isoladamente (15 casos). A primeira tentativa de discovery reportou um erro transitório no setup da condition; uma segunda execução da suíte completa não reproduziu o erro.

```bash
python3 tools/recon_t026_inventory.py
python3 tools/recon_t026_flow_census.py
python3 tools/recon_t026_condition.py
python3 tools/recon_t026_scheduler.py
python3 -m unittest discover -s tools -p 'test_recon_t026_*.py' -v
```

O pai T026 continua pendente e bloqueado por dependências anteriores. O censo não foi convertido em 449 aceites; callbacks indiretos, exceções completas, fluxo real do scheduler, runtime Android e equivalência da cópia continuam fora dos resultados desta rodada. Não houve execução do jogo, build, alteração do cliente ou evidência REA nova.
