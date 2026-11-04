using System.Collections.Generic;
using AvatarWorld.Core.Pointer;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    /// <summary>Ordem Pre -> Post -> OnSyncPosition da corrotina de arraste do original.</summary>
    public class DragPositionPipelineTests
    {
        [Test]
        public void PreRunsBeforePostAndOnSyncReceivesTheModifiedPosition()
        {
            var log = new List<string>();
            DragPoint received = default(DragPoint);
            DragPositionPipeline.RunFrame(new DragPoint(1f, 1f),
                p => { log.Add("pre"); return new DragPoint(p.X + 10f, p.Y); },
                p => { log.Add("post"); return new DragPoint(p.X * 2f, p.Y); },
                p => { log.Add("sync"); received = p; });
            Assert.AreEqual("pre,post,sync", string.Join(",", log.ToArray()));
            Assert.AreEqual(22f, received.X); // (1 + 10) * 2, nao 1 * 2 + 10
            Assert.AreEqual(1f, received.Y);
        }

        [Test]
        public void MissingStagesAreIdentity()
        {
            var r = DragPositionPipeline.Compute(new DragPoint(3f, 4f), null, null);
            Assert.AreEqual(3f, r.X);
            Assert.AreEqual(4f, r.Y);
        }

        [Test]
        public void OnlyPostStillApplies()
        {
            var r = DragPositionPipeline.Compute(new DragPoint(3f, 4f), null, p => new DragPoint(p.X, 0f));
            Assert.AreEqual(3f, r.X);
            Assert.AreEqual(0f, r.Y);
        }

        [Test]
        public void RunFrameReturnsTheDeliveredPosition()
        {
            var r = DragPositionPipeline.RunFrame(new DragPoint(1f, 2f), null, null, null);
            Assert.AreEqual(1f, r.X);
            Assert.AreEqual(2f, r.Y);
        }
    }
}
