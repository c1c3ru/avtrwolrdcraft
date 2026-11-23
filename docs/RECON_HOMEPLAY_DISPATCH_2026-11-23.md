# HomePlayButton.LoadPlayScene — despacho indireto em 0x2058174 (2026-11-23)

Fecha o desconhecido nº 1 de `T025/METHOD/5fe1bb4a25183678` (ver `out/recon/tasks/T025/METHOD/5fe1bb4a25183678/unknowns.jsonl`).
Fonte: `home_play.asm.txt` (`libil2cpp.so` sha256 `b63661fa60c2...`) + `out/cpp2il/.../DeepLinkManager.cs`. Sem Hopper/Ghidra.

## Leitura
- `0x2058104..0x2058110`: carrega um singleton (static fields `+0xb8`, slot 0) e le o campo `[obj+0x28]` em `x20`.
  `DeepLinkManager._mapLinkToLevel` tem `Field offset: 0x28` -> `x20` e o dicionario de links.
- `0x2058118..0x2058160`: busca padrao de interface do IL2CPP: `klass+0x12e` = `interface_offsets_count`,
  `klass+0xb0` = tabela `{interfaceKlass, vtableOffset}` (passo 0x10), `klass+0x138` = inicio da vtable (passo 0x10).
  Se a interface nao esta na tabela cai no helper `0x1b7ba44` (resolucao de metodo de interface em tempo de execucao).
- `0x2058168..0x2058174`: `x0={method ptr, method info}`; `blr x8` com `(this=x20, arg=x19 /*chave*/, methodInfo=x2)`, retorno em `w0`.
- A interface vem da mesma entrada de metadata-usage (`0x41c7a98`) inicializada na prologa; `DeepLinkManager.MapLinkToLevel` e
  `IDictionary<String, LevelType>`.

## Conclusao (inferencia forte, nao prova dinamica)
`0x2058174` e `IDictionary<string, LevelType>.get_Item(key)` (slot 0 da interface), argumento = chave pendente, retorno = `LevelType` (int)
em `w19`, que segue para `0x2058194` (`mov w1, w19`) e para o carregamento da cena. Consequencia: chave ausente do mapa (149 entradas
serializadas) tende a lancar `KeyNotFoundException` (indexador, nao `TryGetValue`) — o caminho de excecao segue sem decodificar.

## Ainda aberto
Corpo/limites independentes, conteudo serializado de `_mapLinkToLevel`, efeitos de `OnClickHomePlayButton`/`SaveBuildingData(0, level)`,
validacao em aparelho. A tarefa fica `partial`; a fila nao foi alterada (hashes novos + revisor independente pendentes).
