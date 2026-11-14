# Regras de desenvolvimento

## Objetivo
Entregar soluções funcionais, verificáveis e sustentáveis,
minimizando tokens, retrabalho e alterações desnecessárias.

## Estratégia
- Investigue o código existente antes de implementar.
- Escolha a abordagem de menor complexidade que atenda aos requisitos.
- Reutilize componentes e testes existentes.
- Trabalhe em incrementos pequenos e verificáveis.
- Delegue pesquisas mecânicas ao subagente `inventario` (Haiku).
- Evite repetir análises já documentadas.
- Consulte o Advisor (Opus) só em decisões críticas ou bloqueios
  que não cederam a evidências novas.

## Qualidade
- Não invente resultados de testes ou evidências.
- Não confunda testes simulados com validação real.
- Execute os testes diretamente relacionados à alteração.
- Verifique regressões antes de concluir.
- Não altere arquivos fora do escopo sem necessidade.
- Não sobrescreva trabalho não commitado de outra sessão.
- Preserve compatibilidade e contratos existentes.

## Gestão de falhas
- Ao falhar, investigue a causa antes de tentar de novo.
- Após duas tentativas equivalentes sem progresso, reavalie a
  hipótese e consulte o Advisor se for útil.
- Nunca repita indefinidamente o mesmo comando.

## Comandos de verificação
- Testes (scripts `tools/test_recon_*.py`): `python3 -m unittest discover -s tools -p 'test_recon_*.py' -v`
- Lint/análise estática: não há lint automatizado configurado neste projeto (sem flake8/pylint/ruff ou linter C# no repo).
- Build (cliente Unity, quando a validação exigir build real): `unity run client/AvatarWorldClient -- -nographics -executeMethod AvatarWorld.EditorTools.ProjectSetup.BuildAndroidDevelopment`
  - Testes EditMode/PlayMode do Unity e validação em APK/dispositivo físico ficam deferidos para um lote único (ver memória `feedback_defer_tests_backlog`); não execute por alteração isolada.

## Conclusão
Registre de forma sucinta:
- O que foi alterado.
- Quais testes passaram ou falharam.
- Quais evidências comprovam o resultado.
- O que permanece pendente.

## Limites
Sem merge, deploy ou ações destrutivas sem autorização.
