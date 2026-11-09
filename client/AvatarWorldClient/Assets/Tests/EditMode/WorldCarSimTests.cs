using System;
using AvatarWorld.Core.World;
using NUnit.Framework;
using UnityEngine;

namespace AvatarWorld.Core.Tests
{
    public class WorldCarSimTests
    {
        static RoadNode[] Square() => new[]
        {
            new RoadNode { X = 0, Y = 0, Next = new[] { 1 } },
            new RoadNode { X = 10, Y = 0, Next = new[] { 2 } },
            new RoadNode { X = 10, Y = 10, Next = new[] { 3 } },
            new RoadNode { X = 0, Y = 10, Next = new[] { 0 } },
        };

        [TestCase(5f, 1f, CarDirection.Right)]
        [TestCase(-5f, 1f, CarDirection.Left)]
        [TestCase(1f, 5f, CarDirection.Up)]
        [TestCase(1f, -5f, CarDirection.Down)]
        public void Direction_FollowsTheDominantAxis(float dx, float dy, CarDirection expected) =>
            Assert.AreEqual(expected, WorldCarSim.DirectionOf(dx, dy));

        [Test]
        public void Car_DrivesTheLoopAtItsSpeed()
        {
            var nodes = Square();
            var s = new CarState { From = 0, To = 1, T = 0f, Speed = 2f };
            var rng = new System.Random(1);
            WorldCarSim.Advance(s, nodes, 2.5f, rng, out float x, out float y, out var dir); // 5 unidades
            Assert.AreEqual(5f, x, 1e-3f); Assert.AreEqual(0f, y, 1e-3f); Assert.AreEqual(CarDirection.Right, dir);
            WorldCarSim.Advance(s, nodes, 5f, rng, out x, out y, out dir); // +10: passa o canto (10,0) e sobe 5
            Assert.AreEqual(10f, x, 1e-3f); Assert.AreEqual(5f, y, 1e-3f); Assert.AreEqual(CarDirection.Up, dir);
        }

        [Test]
        public void Car_NeverLeavesTheNetwork()
        {
            var nodes = Square();
            var rng = new System.Random(7);
            var s = WorldCarSim.Spawn(nodes, 0, 3f, rng);
            for (int i = 0; i < 2000; i++)
            {
                WorldCarSim.Advance(s, nodes, 0.05f, rng, out float x, out float y, out _);
                Assert.That(x, Is.InRange(-0.01f, 10.01f)); Assert.That(y, Is.InRange(-0.01f, 10.01f));
            }
        }

        [Test]
        public void Fork_PrefersNotToTurnBack()
        {
            var nodes = new[]
            {
                new RoadNode { X = 0, Y = 0, Next = new[] { 1 } },
                new RoadNode { X = 5, Y = 0, Next = new[] { 0, 2 } }, // bifurcacao: volta ou segue
                new RoadNode { X = 10, Y = 0, Next = new[] { 1 } },
            };
            var rng = new System.Random(3);
            int forward = 0;
            for (int i = 0; i < 100; i++)
            {
                var s = new CarState { From = 0, To = 1, T = 0.99f, Speed = 1f };
                WorldCarSim.Advance(s, nodes, 0.2f, rng, out _, out _, out _);
                if (s.To == 2) forward++;
            }
            Assert.AreEqual(100, forward);
        }

        [Test]
        public void ShippedCarSprites_Exist()
        {
            var json = Resources.Load<TextAsset>("WorldCars/cars");
            Assert.IsNotNull(json);
            for (int n = 1; n <= 14; n++)
                foreach (var dir in new[] { "up", "down", "sideways" })
                    Assert.IsNotNull(Resources.Load<Texture2D>("WorldCars/car" + n + "_" + dir), "car" + n + "_" + dir);
        }
    }
}
