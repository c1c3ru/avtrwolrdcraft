using System;
using System.Collections.Generic;
using AvatarWorld.Core.World;
using UnityEngine;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Carros de um WorldCarsController: <c>count</c> carros andando pela rede de pontos de estrada, com as artes
    /// cars/car&lt;N&gt;/{up,down,sideways} do original (Resources/WorldCars). "sideways" olha para a direita; para a
    /// esquerda espelha. Sem farois nem tonalidade por hora do dia. Velocidade: aproximacao (ver WorldCarSim).
    /// </summary>
    public sealed class MapCarsLayer : MonoBehaviour
    {
        sealed class Car
        {
            public CarState State;
            public SpriteRenderer Renderer;
            public int Number;
        }

        static Dictionary<string, Sprite> _sprites;
        readonly List<Car> _cars = new List<Car>();
        List<RoadNode> _nodes;
        System.Random _rng;

        public int CarCount => _cars.Count;

        public void Begin(Transform parent, WorldCarsData data, int seed)
        {
            transform.SetParent(parent, false);
            if (data.points == null || data.points.Count == 0 || data.cars == null || data.cars.Length == 0) return;
            LoadSprites();
            _rng = new System.Random(seed);
            _nodes = new List<RoadNode>(data.points.Count);
            foreach (var p in data.points) _nodes.Add(new RoadNode { X = p.x, Y = p.y, Next = p.next ?? new int[0] });

            for (int i = 0; i < data.count; i++)
            {
                int number = data.cars[i % data.cars.Length];
                int start = data.spawn != null && data.spawn.Length > 0 ? data.spawn[i % data.spawn.Length] : _rng.Next(_nodes.Count);
                float speed = data.speed > 0f ? data.speed : WorldCarSim.DefaultSpeed * (0.8f + 0.4f * (float)_rng.NextDouble());
                var go = new GameObject("Car" + number + "_" + i);
                go.transform.SetParent(transform, false);
                var renderer = go.AddComponent<SpriteRenderer>();
                renderer.sortingOrder = data.rank;
                _cars.Add(new Car { State = WorldCarSim.Spawn(_nodes, start, speed, _rng), Renderer = renderer, Number = number });
            }
            Update();
        }

        static void LoadSprites()
        {
            if (_sprites != null) return;
            _sprites = new Dictionary<string, Sprite>();
            var json = Resources.Load<TextAsset>("WorldCars/cars");
            if (json == null) { Debug.LogWarning("WorldCars/cars.json ausente"); return; }
            foreach (var e in JsonUtility.FromJson<CarSpriteFile>(json.text).sprites)
            {
                var tex = Resources.Load<Texture2D>("WorldCars/" + e.file);
                if (tex == null) continue;
                _sprites[e.file] = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(e.pivotX, e.pivotY), e.ppu);
            }
        }

        void Update()
        {
            if (_nodes == null) return;
            foreach (var car in _cars)
            {
                WorldCarSim.Advance(car.State, _nodes, Time.deltaTime, _rng, out float x, out float y, out var dir);
                car.Renderer.transform.position = new Vector3(x, y, 0f);
                string view = dir == CarDirection.Up ? "up" : dir == CarDirection.Down ? "down" : "sideways";
                if (_sprites.TryGetValue("car" + car.Number + "_" + view, out var sprite)) car.Renderer.sprite = sprite;
                car.Renderer.flipX = dir == CarDirection.Left;
            }
        }

        [Serializable]
        sealed class CarSpriteFile { public List<CarSpriteEntry> sprites; }

        [Serializable]
        sealed class CarSpriteEntry { public int car; public string dir, file; public float pivotX, pivotY, ppu; }
    }
}
