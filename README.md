# Avatar World — engenharia reversa (uso pessoal)

Repositório PRIVADO. Análise do app `com.pazugames.avatarworld` v1.227 (Unity 2022.3.70f1, IL2CPP, arm64-v8a).
Não contém APK nem assets do jogo; eles ficam no PC/Google Drive do autor.

## Conteúdo
- `LOOP_STATE.md` — fases, resultados e tentativas do loop de trabalho.
- `tools/catalog.py` — catalogo de objetos de um bundle Unity (UnityPy).
- `tools/extract.py` — extrai Texture2D, AudioClip (lê `resources.resource`) e TextAsset.
- `out/cpp2il/DiffableCs/` — C# recuperado pelo Cpp2IL (Assembly-CSharp = código do jogo).
- `tools/mb_dump.py` — despeja os campos dos MonoBehaviours (tipos gerados do IL2CPP) em `out/mb/*.jsonl.gz`.
- `tools/mb_survey.py` — levantamento das classes de script usadas no bundle.
- `out/mb/` — 879.085 de 881.898 MonoBehaviours decodificados (126 classes com erro).
- `out/catalog_datapack.json` — contagem de objetos do `datapack.unity3d`.

## Reproduzir
1. `adb pull` dos 3 APKs (`pm path com.pazugames.avatarworld`) para `apk/` e `unzip` em `x/{base,arm64,data}`.
2. `python3 -m venv tools/venv && tools/venv/bin/pip install UnityPy`
3. Cpp2IL 2022.1.0-pre-release.21 (metadata v31):
   `Cpp2IL --game-path il2cpp_in --force-binary-path il2cpp_in/libil2cpp.so --force-metadata-path il2cpp_in/global-metadata.dat --force-unity-version 2022.3.70 --output-as diffable-cs --output-to out/cpp2il`
4. `tools/venv/bin/python -I tools/extract.py x/data/assets/bin/Data/datapack.unity3d out/assets AudioClip,TextAsset,Texture2D 0`

## Notas
- O app usa Google Play PairIP (anti-adulteração); não é contornado. O objetivo é analisar e reimplementar o cliente, não rodar o APK modificado.

## Assets (fora do Git)
Ficam no Google Drive do autor, pasta `AvatarWorld-RE/`: `apk/` (3 APKs) e `assets/` (`textures_png.tar`, `audio_wav.tar.zst`, `spine_textasset.tar.zst`, `SHA256SUMS.txt`).
Para usar: baixar, conferir `sha256sum -c SHA256SUMS.txt` e extrair com `tar -xf` / `zstd -dc ... | tar -x`.

## Achados
- O catálogo/preços da loja NÃO está no APK: vem do servidor (`StoreClaimItemCloudResponse`). Moedas: `pazuCurrency` e `loyaltyPoints`.
