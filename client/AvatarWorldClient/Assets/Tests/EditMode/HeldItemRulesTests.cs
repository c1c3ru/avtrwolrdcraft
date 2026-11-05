using AvatarWorld.Core.Avatar;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    public class HeldItemRulesTests
    {
        [Test]
        public void LeftHandWinsWhenBothHold()
        {
            Assert.AreEqual("left", HeldItemRules.PickMovementOverride("left", "right"));
        }

        [Test]
        public void RightHandIsUsedWhenLeftIsEmpty()
        {
            Assert.AreEqual("right", HeldItemRules.PickMovementOverride<string>(null, "right"));
        }

        [Test]
        public void NoHandHoldingGivesNull()
        {
            Assert.IsNull(HeldItemRules.PickMovementOverride<string>(null, null));
        }

        [Test]
        public void LookupOrderIsLeftThenRight()
        {
            Assert.AreEqual(2, HeldItemRules.LookupOrder.Length);
            Assert.AreEqual(HandKind.Left, HeldItemRules.LookupOrder[0]);
            Assert.AreEqual(HandKind.Right, HeldItemRules.LookupOrder[1]);
        }
    }
}
