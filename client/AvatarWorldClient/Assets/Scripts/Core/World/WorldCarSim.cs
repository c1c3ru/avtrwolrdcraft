using System;
using System.Collections.Generic;

namespace AvatarWorld.Core.World
{
    public enum CarDirection { Left, Right, Up, Down }

    /// <summary>Ponto da estrada (WorldRoadPoint do original): posicao e os pontos seguintes possiveis.</summary>
    public sealed class RoadNode
    {
        public float X, Y;
        public int[] Next = new int[0];
    }

    /// <summary>Estado de um carro andando do ponto From para o ponto To (t de 0 a 1 no trecho).</summary>
    public sealed class CarState
    {
        public int From, To;
        public float T;
        public float Speed;
    }

    /// <summary>
    /// Movimento dos carros do mapa (WorldCarsController/WorldCar do original): cada carro anda de ponto em ponto e,
    /// ao chegar, sorteia o proximo entre os seguintes (GetRandomNextPoint). A rede de pontos e os carros usados vem dos
    /// dados exportados; a VELOCIDADE padrao nao esta serializada (speed = 0 nos dados) e aqui e uma aproximacao.
    /// </summary>
    public static class WorldCarSim
    {
        /// <summary>Velocidade padrao em unidades de mundo por segundo (aproximacao; o original usa 0 = constante do codigo).</summary>
        public const float DefaultSpeed = 1.6f;

        public static CarDirection DirectionOf(float dx, float dy) =>
            Math.Abs(dx) >= Math.Abs(dy) ? (dx >= 0f ? CarDirection.Right : CarDirection.Left)
                                         : (dy >= 0f ? CarDirection.Up : CarDirection.Down);

        public static CarState Spawn(IReadOnlyList<RoadNode> nodes, int startNode, float speed, Random rng)
        {
            if (nodes == null || nodes.Count == 0) throw new ArgumentException("rede de estrada vazia", nameof(nodes));
            int from = ((startNode % nodes.Count) + nodes.Count) % nodes.Count;
            return new CarState { From = from, To = PickNext(nodes, from, -1, rng), T = (float)rng.NextDouble(), Speed = speed };
        }

        static int PickNext(IReadOnlyList<RoadNode> nodes, int from, int cameFrom, Random rng)
        {
            var next = nodes[from].Next;
            if (next == null || next.Length == 0) return (from + 1) % nodes.Count; // sem saida: segue a lista
            if (next.Length == 1) return next[0];
            // com bifurcacao nao volta de onde veio (se so ha essa saida, volta: beco sem saida)
            int candidates = 0;
            foreach (int n in next) if (n != cameFrom) candidates++;
            if (candidates == 0) return next[rng.Next(next.Length)];
            int choice = rng.Next(candidates);
            foreach (int n in next)
            {
                if (n == cameFrom) continue;
                if (choice-- == 0) return n;
            }
            return next[0];
        }

        /// <summary>Anda dt segundos. Devolve a posicao e a direcao atuais.</summary>
        public static void Advance(CarState s, IReadOnlyList<RoadNode> nodes, float dt, Random rng, out float x, out float y, out CarDirection dir)
        {
            float remaining = Math.Max(0f, dt) * s.Speed;
            for (int guard = 0; guard < 8; guard++)
            {
                var a = nodes[s.From]; var b = nodes[s.To];
                float length = (float)Math.Sqrt((b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y));
                if (length < 1e-4f) { Arrive(s, nodes, rng); continue; }
                float left = (1f - s.T) * length;
                if (remaining < left) { s.T += remaining / length; break; }
                remaining -= left;
                Arrive(s, nodes, rng);
            }
            var p = nodes[s.From]; var q = nodes[s.To];
            x = p.X + (q.X - p.X) * s.T;
            y = p.Y + (q.Y - p.Y) * s.T;
            dir = DirectionOf(q.X - p.X, q.Y - p.Y);
        }

        static void Arrive(CarState s, IReadOnlyList<RoadNode> nodes, Random rng)
        {
            int cameFrom = s.From;
            s.From = s.To;
            s.To = PickNext(nodes, s.From, cameFrom, rng);
            s.T = 0f;
        }
    }
}
