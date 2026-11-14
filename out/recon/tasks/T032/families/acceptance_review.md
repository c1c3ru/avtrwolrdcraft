# Revisão independente da auditoria T032

Arquivo revisado: `tools/recon_t032_acceptance.py`, 2026-11-08.

A auditoria distingue adequadamente recuperação estática, implementação T049, runtime e aceite do pai: os três aceites permanecem false e nenhuma escrita no cliente é realizada. As pendências de overlay, corrida, Baby/tech e delegates não canônicos são explícitas. Não encontrei alegação indevida de implementação.

Limite de integridade: o audit valida identidades e fontes por hash, manifests de ASM de famílias e cardinalidades de JSONs; não reexecuta probes nem confere sozinho cada conclusão contra bytes. As condições `seven_capabilities` e `running_is_false` não substituem `families/check.py`; o hash registrado para um resultado novo apenas identifica esse resultado. Isso é consistente com a docstring que exige probes antes, mas `evidence_integrity_passed` deve ser comunicado como resultado dessa auditoria limitada, não como prova independente de todas as semânticas. A execução dos probes e o relatório de revisão por opcode do agente callbacks dão a evidência adicional necessária.

A revisão de NPC foi ampliada: o novo relatório limita sua busca negativa de autonomia ao universo de nomes e aos corpos examinados; não transforma 0 nomes AI/NPC em ausência de autonomia global. Os sete censos foram conferidos contra todos os registros gzip originais (`npc_review.json`). O consumo de position como ownerPosition para roupas restauradas é explicitamente separado de posição final de roupa ou spawn de NPC.

Requisitos de patch para T049, sem aceite de implementação: usar Forced_To_Walk no caminho Animal desbloqueado; manter track0 para ele; implementar overlay track1 e limpeza no caso locked; capacidade de corrida false para o artefato; Baby e cinco techs seguem movimento físico da base sem cair no default Character; preservar swimming=false do Horse. Validar integração e runtime separadamente.

## Revisão da correção da auditoria

O coordenador atualizou `audit()` para executar seis probes em cada chamada e registrar script, hash e exit code. A objeção sobre aceitar os JSONs de capabilities/dispatch em cache foi resolvida para esses resultados: eles são regenerados a partir das fontes antes da avaliação. Um probe com erro lança RuntimeError e impede resultado positivo. Não executei uma segunda auditoria concorrente, por orientação do coordenador; a execução final está com ele.

Limite restante não impeditivo: a auditoria continua sem reextrair o census a cada execução. Os censos foram conferidos independentemente por `review_npc.py`; caso se queira tornar a verificação repetível do census parte do aceite automatizado, esse script pode ser acrescentado a PROBES. O manifesto atual guarda hash das fontes de binário/metadata/índice, mas não valida sozinho cada gzip usado no census; a revisão independente guarda esse elo.
