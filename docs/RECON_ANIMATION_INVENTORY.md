# Inventário de animações do jogo

Data: 2026-11-04. O inventário foi gerado por `tools/venv/bin/python tools/recon_animation_inventory.py` e cobre todos os arquivos Spine extraídos, os clips/controladores Unity presentes no `resources.assets` local e as classes de animação contextual encontradas no assembly.

## Conteúdo encontrado

- **587 de 587 esqueletos Spine** foram parseados, sem erro: **7.206 associações arquivo/animação**, com **5.067 nomes distintos**. O relatório inclui duração, skins, slots, ossos, eventos e SHA256 de cada arquivo; [spine-animation-rows.csv](/home/deppi/avatarworld-re/out/recon/tasks/T035/spine-animation-rows.csv) oferece uma linha por associação.
- O `resources.assets` contém **23 AnimationClips**, **5 AnimatorControllers**, **10 componentes Animator** e **55 componentes Animation legados**. O relatório liga controladores a nomes de estado/clips, componentes a GameObjects e path IDs a caminhos do ResourceManager. Duração dos clips Unity é aproximada pelas últimas chaves/eventos parseados; estados de transição também estão listados.
- O assembly tem **821 classes `LevelCA*`**. O inventário de MonoBehaviours serializados liga **577 classes** a **24.983 instâncias** e aos arquivos de cena em que aparecem. As classes estão agrupadas pela classe-base e incluem classes sem instância encontrada.
- A amostra estática dos métodos de `LevelCharacterAnimator` contém 13 literais que coincidem exatamente com nomes de animação Spine, entre movimento, idle, interação em cadeira/cama e outros. O relatório conserva também literais diagnósticos que não são animações.

## Artefatos completos

- `out/recon/tasks/T035/animation-inventory.json`: inventário por esqueleto, clips Unity, controladores, estados, handlers contextuais, instâncias por arquivo, hashes e limites.
- `out/recon/tasks/T035/spine-animation-rows.csv`: 7.206 linhas de animação Spine com duração e esqueleto de origem.
- `tools/recon_animation_inventory.py`: extração e cruzamento reproduzíveis, com verificação de cobertura do dump contra os 587 arquivos-fonte.

Os grupos de esqueleto por família são heurísticos e dependem de nomes de arquivo. A listagem de handlers mostra presença e herança, não reconstrói transições de entrada/saída/cancelamento nem todos os efeitos em cena. Também não inclui conteúdo entregue remotamente que não está neste APK/bundle. Assim, o inventário local dos nomes está completo para as fontes extraídas; a semântica de execução segue parcial e T035 permanece aberto.
