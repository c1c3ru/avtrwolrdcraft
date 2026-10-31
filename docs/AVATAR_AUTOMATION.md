# Automação local da investigação de avatares

`tools/avatar_pipeline.py` executa o ciclo de diagnóstico, inventário, probes e relatório, com estado retomável. O orquestrador usa apenas a biblioteca padrão do Python. Ele **não implementa o editor de avatares, não monta roupas finais e não gera APK por padrão**. Os previews do probe são rasterização CPU da geometria Spine: não comprovam o desenho por GPU, interação, persistência ou gameplay completo.

Execute a partir da raiz do repositório. Os caminhos de entrada são resolvidos em relação à localização do script, não ao diretório atual.

## Preparar o ambiente

Python 3.10 ou superior. O inventário do bundle exige UnityPy no mesmo ambiente Python usado para executar o pipeline:

```sh
python3 -m venv tools/venv
tools/venv/bin/python -m pip install UnityPy
```

Esses comandos são explícitos: o pipeline nunca instala dependências. A execução `doctor` verifica disponibilidade de UnityPy sem importar nem executar o inventário. É possível executar `doctor` e `report` sem Unity e sem UnityPy; se faltarem entradas/dependências, `doctor` registra isso e retorna código 1.

Entradas locais esperadas, fora do Git:

- `assets/split_UnityDataAssetPack.apk`;
- `assets/spine_textasset/TextAsset/Avatar_Spine.skel_108595.txt`;
- `assets/spine_textasset/TextAsset/Avatar_Spine.atlas_109005.txt`;
- `assets/spine_textasset/TextAsset/PremadeCharactersJson_109356.txt`;
- oito PNGs básicos em `assets/textures_png/Texture2D/`, listados no diagnóstico e em `docs/AVATAR_ASSET_FINDINGS.md`.

Os probes também exigem o projeto `client/AvatarWorldClient`, suas dependências Spine, os scripts `Assets/Editor/AvatarAssetProbe.cs` e `AvatarRenderProbe.cs`, Unity Editor **6000.6.6f1** e licença válida. A presença de um executável não comprova licença, instalação do Editor ou módulo Android. Não é necessário Android para estes probes CPU.

## Comandos

```sh
# Ajuda e diagnóstico: não executam Unity nem instalam pacotes.
tools/venv/bin/python tools/avatar_pipeline.py --help
tools/venv/bin/python tools/avatar_pipeline.py doctor

# Somente resumir artefatos existentes e suas limitações.
tools/venv/bin/python tools/avatar_pipeline.py report

# Diagnóstico + inventário do bundle + relatório, SEM Unity.
tools/venv/bin/python tools/avatar_pipeline.py all --timeout 1800

# Inclui os dois probes Unity, sempre em sequência.
tools/venv/bin/python tools/avatar_pipeline.py all --with-unity --timeout 1800

# Apenas probes + relatório; "probe" já solicita execução Unity explicitamente.
tools/venv/bin/python tools/avatar_pipeline.py probe --timeout 900

# Caminho explícito da CLI Unity, evitando o comando unity do desktop GNOME.
tools/venv/bin/python tools/avatar_pipeline.py probe --unity "$HOME/.local/bin/unity"

# Também aceita diretamente o binário do Editor chamado Unity/Unity.exe.
tools/venv/bin/python tools/avatar_pipeline.py probe --unity "$HOME/Unity/Hub/Editor/6000.6.6f1/Editor/Unity"

# Repetir as etapas mesmo quando há resultados anteriores válidos.
tools/venv/bin/python tools/avatar_pipeline.py all --with-unity --force
```

As opções ficam **depois do subcomando**, como nos exemplos. `--timeout` é o limite de cada processo, não do pipeline inteiro. `--with-unity` só muda o comportamento de `all`; `probe` sempre executa Unity. Feche um Editor que já tenha este projeto aberto e não inicie dois pipelines simultaneamente no mesmo checkout.

A seleção automática procura `unity` no PATH, depois `~/.local/bin/unity`. Caso o PATH contenha outro programa com esse nome, use `--unity`. A CLI é chamada como `unity run`; o binário chamado `Unity` ou `Unity.exe` é chamado diretamente com `-batchmode -quit`. Executáveis com outro nome devem ser a CLI. A licença permanece sob controle da sua instalação: não há ativação nem reparo automático.

## Saídas, retomada e falhas

Em `out/avatar-pipeline/`:

- `doctor.json`: entradas ausentes, Python e dependências encontrados;
- `state.json`: estado de cada etapa, comandos, horários, retorno, assinaturas e erros;
- `bundle-inventory.log`, `inspect.log`, `render.log`: stdout/stderr dos processos;
- `inspect-editor.log`, `render-editor.log`: logs nativos do Unity;
- `report.json`: inventários existentes, cobertura de nomes dos presets, resultados do probe e limitações.

Os probes existentes continuam gravando `out/avatar-spine-inventory.json`, `out/avatar-render-probe.json`, `out/avatar-preview.png` e `out/avatar-preview-hair-2.png`. O inventário do bundle grava `out/assets/avatar-resources.json` e seus artefatos auxiliares. Os arquivos pesados e relatórios são locais; não os adicione indiscriminadamente ao Git.

O estado JSON é atualizado por arquivo temporário + troca atômica. Uma etapa só recebe `succeeded` se o processo retorna zero, as saídas esperadas existem, os JSONs são legíveis e os artefatos foram atualizados. Estado `succeeded` significa **etapa de investigação executada**, nunca “jogo completo”. Não há conclusão fictícia quando existem apenas arquivos antigos.

Ao repetir o mesmo comando, etapas anteriormente bem-sucedidas são reaproveitadas somente se as assinaturas dos inputs/comandos e metadados das saídas continuam iguais. As assinaturas usam caminho, tamanho e mtime; não releem gigabytes para calcular hashes. Use `--force` quando editar arquivos preservando tamanho/mtime ou alterar dependências transitivas não listadas. Etapas interrompidas, em execução antiga ou com falha são tentadas novamente. A retomada é entre etapas; o próprio inventariador controla a reutilização de suas extrações internas.

Timeout e Ctrl+C encerram o grupo de processos iniciado pelo pipeline em POSIX e registram a falha. Em outros sistemas, o encerramento dos subprocessos descendentes não é garantido. Após interrupção externa abrupta ou falha da máquina, verifique se ficou um processo Unity antes de retomar. Nenhum processo Unity alheio é encerrado pelo script.

`all` só executa os probes após o inventário terminar com sucesso. Mesmo em falha de uma etapa, tenta produzir um relatório final e retorna código 1. `report` pode ler artefatos já existentes sem executar novamente suas etapas e deixa isso explícito; presença de arquivo não prova origem/atualidade. Falha ao gravar os próprios relatórios, por exemplo disco cheio, aparece como erro do Python.

## O que ainda precisa virar jogo

O objetivo seguinte continua sendo uma cena utilizável: avatar visível, troca real de cabelo/roupas/acessórios, look persistido, acesso pela Home e APK validado no aparelho. Este pipeline prepara evidências para isso. Resolver SUT, colisões de materiais/texturas, montagem de roupas, duas cores e o desenho final permanece trabalho de implementação descrito em `docs/AVATAR_GAMEPLAY_PLAN.md`.
