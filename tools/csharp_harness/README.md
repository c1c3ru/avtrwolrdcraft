# Harness C# sem Unity

Compila `Core/Pointer/*.cs` do cliente e os testes EditMode engine-free (`DragIntentDetectorTests`,
`DropTargetOrderingTests`, `CameraPanMathTests`) com um shim mínimo de NUnit (`NUnitShim.cs`) e os executa.

```bash
cd tools/csharp_harness && ../dotnet/dotnet run --nologo -v q     # SDK em tools/dotnet (não versionado)
```

Saída esperada: `24 passed, 0 failed`. O shim só implementa os `Assert` usados; um `Assert` novo falha na compilação de
propósito. **Não substitui o Unity Test Runner**: serve para checar rápido a lógica pura. Os mesmos arquivos de teste
rodam no Unity (`AvatarWorld.Core.Tests`).
