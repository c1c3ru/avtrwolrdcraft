# Harness C# sem Unity

Compila `Core/Pointer/*.cs` e `Core/Persistence/*.cs` do cliente e os testes EditMode engine-free
(`DragIntentDetectorTests`, `DropTargetOrderingTests`, `CameraPanMathTests`, `SaveGateTests`) com um shim
mínimo de NUnit (`NUnitShim.cs`) e os executa.

```bash
cd tools/csharp_harness && ../../../../tools/dotnet/dotnet build --no-incremental --nologo -v q && ../../../../tools/dotnet/dotnet bin/Debug/net8.0/Harness.dll     # SDK em tools/dotnet (não versionado; ajuste o caminho se necessário)
```

Saída esperada: `29 passed, 0 failed` (13+5+6+5). Use `build --no-incremental` ao acrescentar arquivos: um binário
reutilizado pode executar menos testes sem avisar. O shim só implementa os `Assert` usados; um `Assert` novo falha na compilação de
propósito. **Não substitui o Unity Test Runner**: serve para checar rápido a lógica pura. Os mesmos arquivos de teste
rodam no Unity (`AvatarWorld.Core.Tests`).
