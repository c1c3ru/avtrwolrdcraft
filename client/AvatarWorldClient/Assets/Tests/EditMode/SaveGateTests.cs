using AvatarWorld.Core.Persistence;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    /// <summary>CanSaveScene (0x21e5f74) e os dois gatilhos automaticos de gravacao do original.</summary>
    public class SaveGateTests
    {
        [Test]
        public void CannotSaveWhileSceneIsChanging()
        {
            Assert.IsFalse(SaveGate.CanSaveScene(true, false, false));
            Assert.IsFalse(SaveGate.CanSaveScene(true, true, true));
        }

        [Test]
        public void WithoutLevelManagerSavingIsAllowed()
        {
            Assert.IsTrue(SaveGate.CanSaveScene(false, false, false));
        }

        [Test]
        public void WithLevelManagerSavingNeedsPostInit()
        {
            Assert.IsFalse(SaveGate.CanSaveScene(false, true, false));
            Assert.IsTrue(SaveGate.CanSaveScene(false, true, true));
        }

        [Test]
        public void SceneChangeAlwaysSavesEvenWhileChanging()
        {
            Assert.IsTrue(SaveGate.ShouldSave(SaveTrigger.SceneChange, false, true, true, false));
        }

        [Test]
        public void PauseSavesOnlyWhenPausingAndAllowed()
        {
            Assert.IsTrue(SaveGate.ShouldSave(SaveTrigger.ApplicationPause, true, false, true, true));
            Assert.IsFalse(SaveGate.ShouldSave(SaveTrigger.ApplicationPause, false, false, true, true));
            Assert.IsFalse(SaveGate.ShouldSave(SaveTrigger.ApplicationPause, true, true, true, true));
            Assert.IsFalse(SaveGate.ShouldSave(SaveTrigger.ApplicationPause, true, false, true, false));
        }
    }
}
