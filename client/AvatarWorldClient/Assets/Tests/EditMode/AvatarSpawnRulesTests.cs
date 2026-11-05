using AvatarWorld.Core.Avatar;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    /// <summary>Decisao de LevelAvatarOneTimeSpawner.OnLevelPrePostInit (0x2299144).</summary>
    public class AvatarSpawnRulesTests
    {
        [Test]
        public void SpawnsWhenNothingBlocksIt()
        {
            Assert.AreEqual(SpawnDecision.Spawn, AvatarSpawnRules.Decide(true, false, false, false, false));
        }

        [Test]
        public void InvalidSpawnerNeverSpawnsAndDoesNotMarkDidSpawn()
        {
            var d = AvatarSpawnRules.Decide(false, false, true, false, false);
            Assert.AreEqual(SpawnDecision.SkipInvalid, d);
            Assert.IsFalse(AvatarSpawnRules.SetsDidSpawn(d));
        }

        [Test]
        public void AlreadySpawnedIsSkippedBeforeAnyOtherCheck()
        {
            var d = AvatarSpawnRules.Decide(true, true, false, true, true);
            Assert.AreEqual(SpawnDecision.SkipAlreadySpawned, d);
            Assert.IsFalse(AvatarSpawnRules.SetsDidSpawn(d));
            Assert.IsFalse(AvatarSpawnRules.LogsError(d));
        }

        [Test]
        public void AvatarAlreadyInGameIsSkippedWithErrorAndMarksDidSpawn()
        {
            var d = AvatarSpawnRules.Decide(true, false, false, true, false);
            Assert.AreEqual(SpawnDecision.SkipAlreadyInGame, d);
            Assert.IsTrue(AvatarSpawnRules.LogsError(d));
            Assert.IsTrue(AvatarSpawnRules.SetsDidSpawn(d));
        }

        [Test]
        public void AllowSpawnWhenAlreadyInGameIgnoresTheGameDataCheck()
        {
            Assert.AreEqual(SpawnDecision.Spawn, AvatarSpawnRules.Decide(true, false, true, true, false));
        }

        [Test]
        public void AvatarAlreadyInCurrentLevelIsStillSkippedEvenWhenAllowedInGame()
        {
            var d = AvatarSpawnRules.Decide(true, false, true, true, true);
            Assert.AreEqual(SpawnDecision.SkipAlreadyInCurrentLevel, d);
            Assert.IsTrue(AvatarSpawnRules.LogsError(d));
            Assert.IsTrue(AvatarSpawnRules.SetsDidSpawn(d));
        }

        [Test]
        public void GameDataCheckComesBeforeTheCurrentLevelCheck()
        {
            Assert.AreEqual(SpawnDecision.SkipAlreadyInGame, AvatarSpawnRules.Decide(true, false, false, true, true));
        }

        [Test]
        public void SpawningMarksDidSpawnWithoutAnError()
        {
            Assert.IsTrue(AvatarSpawnRules.SetsDidSpawn(SpawnDecision.Spawn));
            Assert.IsFalse(AvatarSpawnRules.LogsError(SpawnDecision.Spawn));
        }

        [Test]
        public void MessagesMatchTheOriginalLiterals()
        {
            Assert.AreEqual("LevelAvatarOneTimeSpawner: Already in game! _avatarId[", AvatarSpawnRules.AlreadyInGameMessage);
            Assert.AreEqual("LevelAvatarOneTimeSpawner: Already in current level! _avatarId[", AvatarSpawnRules.AlreadyInCurrentLevelMessage);
        }
    }
}
