# Protocolo de loop — recuperação de lógica sem corpos de método

Base: skill `engenharia-de-loop` (ReAct, estado em arquivo, parada verificável, escalação em 5 tentativas) adaptada a engenharia reversa estática.

## Por que loops
O dump Cpp2IL só dá assinaturas. A lógica de cada comportamento (callback do LoadScene, input/drag, save, animações contextuais, NPCs, carros, céu) só aparece em sondas pontuais sobre `libil2cpp.so` + `global-metadata.dat`. Cada sonda responde uma pergunta estreita; o conjunto exige muitas rodadas. Um loop bem desenhado faz isso sem supervisão e **sem inventar**.

## Princípios de engenharia de prompt usados
1. **Papel + premissa explícita**: o prompt repete que o dump não tem corpos, para impedir "adivinhar" a lógica pelo nome do método.
2. **Fatos fixos vs hipóteses**: `known_facts` não são reabertos; tudo o mais precisa de evidência.
3. **Decomposição em unidades verificáveis**: perguntas fechadas (não "entender o save"), cada uma com resposta registrável.
4. **Escala de evidência A/B/C/U**: obriga o modelo a rotular o quanto sabe. C nunca vira regra de jogo.
5. **Prova executável**: toda afirmação A precisa de sonda determinística + teste; "li no disassembly" sem script vale C.
6. **Estado externo**: o ledger JSONL é a memória; o modelo relê o estado a cada ciclo em vez de confiar no contexto.
7. **Parada por máquina**: `tools/recon_loop.py status` decide `converged | open | stalled | max_iterations`. O modelo não se autodeclara pronto.
8. **Anti-loop**: uma unidade por ciclo, mudar de técnica após falha, no máximo 3 ciclos sem progresso, teto de iterações, escalação com duas hipóteses.
9. **Saída ancorada**: linha `result:`/`needs input:`/`failed:` para o rastreio do job.

## Ledger
`out/recon/loops/<ID>/ledger.jsonl`, uma linha por registro:
`{"unit": "...", "grade": "A|B|C|U", "iteration": n, "evidence": "...", "reason": "...", "ts": "..."}`
A linha mais recente por unidade vale. `reason` é obrigatório para C e U. `out/` não é versionado; o resumo versionado fica em `docs/loops/results/<ID>.md`.

## Convergência (calculada por `status`)
- `converged`: toda unidade tem linha; nenhuma está sem `reason` quando C/U; para L01–L07 nenhuma unidade em C (A, B ou U justificado); para L08 qualquer grau com motivo.
- `stalled`: 3 iterações consecutivas sem unidade nova nem grau melhorado.
- `max_iterations`: iteração máxima registrada atingiu o teto do loop.
- `open`: caso contrário.

## Ordem sugerida
L08 (varredura) alimenta os demais, mas L01 e L02 não dependem dela e podem começar já. L05 e L06 se beneficiam de L08 para localizar classes. Rode um loop por vez por worktree; sondas compartilham `tools/` e causam conflito se paralelizadas no mesmo checkout.

## Comandos
```bash
python3 tools/recon_loop.py list
python3 tools/recon_loop.py render L01            # imprime o prompt
python3 tools/recon_loop.py render --all --out docs/loops/prompts
python3 tools/recon_loop.py status [L01]
python3 tools/recon_loop.py next L08 --n 25       # próximas classes não classificadas
python3 tools/recon_loop.py record L01 --unit 1 --grade B --iteration 1 --evidence tools/recon_callback_probe.py:20
```
Para disparar em loop: `/loop` com o conteúdo de `docs/loops/prompts/L01.md` (ritmo dinâmico) ou um job de background por loop.
