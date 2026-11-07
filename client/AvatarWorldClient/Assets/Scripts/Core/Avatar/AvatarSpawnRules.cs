namespace AvatarWorld.Core.Avatar
{
    public enum SpawnDecision
    {
        Spawn = 0,
        SkipInvalid = 1,                 // !_isValid (0x42)
        SkipAlreadySpawned = 2,          // _didSpawn (0x41), persistido como BoolPD
        SkipAlreadyInGame = 3,           // LevelAvatarData.TryGetData(avatarId) achou e !_allowSpawnWhenAlreadyInGame
        SkipAlreadyInCurrentLevel = 4    // ja existe avatar com esse id no nivel atual
    }

    /// <summary>
    /// Decisao de LevelAvatarOneTimeSpawner.OnLevelPrePostInit (0x2299144), lida do disassembly
    /// (docs/RECON_CHARACTER_CONTRACT.md, secao 12). Ordem das condicoes e efeitos sobre _didSpawn sao as do original.
    /// </summary>
    public static class AvatarSpawnRules
    {
        public static SpawnDecision Decide(bool isValid, bool didSpawn, bool allowSpawnWhenAlreadyInGame,
                                           bool existsInGameData, bool existsInCurrentLevel)
        {
            if (!isValid) return SpawnDecision.SkipInvalid;
            if (didSpawn) return SpawnDecision.SkipAlreadySpawned;
            if (!allowSpawnWhenAlreadyInGame && existsInGameData) return SpawnDecision.SkipAlreadyInGame;
            if (existsInCurrentLevel) return SpawnDecision.SkipAlreadyInCurrentLevel;
            return SpawnDecision.Spawn;
        }

        /// <summary>
        /// O original grava _didSpawn = true ao spawnar e tambem nos dois casos "Already in ..." (que registram erro);
        /// nao grava quando invalido ou ja spawnado.
        /// </summary>
        public static bool SetsDidSpawn(SpawnDecision decision)
        {
            return decision == SpawnDecision.Spawn
                || decision == SpawnDecision.SkipAlreadyInGame
                || decision == SpawnDecision.SkipAlreadyInCurrentLevel;
        }

        /// <summary>Os dois casos "Already in ..." registram erro no original.</summary>
        public static bool LogsError(SpawnDecision decision)
        {
            return decision == SpawnDecision.SkipAlreadyInGame || decision == SpawnDecision.SkipAlreadyInCurrentLevel;
        }

        public const string AlreadyInGameMessage = "LevelAvatarOneTimeSpawner: Already in game! _avatarId[";
        public const string AlreadyInCurrentLevelMessage = "LevelAvatarOneTimeSpawner: Already in current level! _avatarId[";
    }
}
