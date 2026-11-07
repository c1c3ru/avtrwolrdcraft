using System;
using System.Collections.Generic;
using UnityEngine;

namespace AvatarWorld.Runtime
{
    // Formato gerado por tools/export_world_motion.py (level4 do original).

    [Serializable] public sealed class MotionPoint { public string go; public float x, y; }

    [Serializable]
    public sealed class MotionCloud
    {
        public string go;
        public float x, y;
        public bool active = true;
        public MotionPoint clear, rain;
    }

    [Serializable]
    public sealed class MotionTrain
    {
        public string go;
        public float x, y;
        public MotionPoint start, goTo;
        public float toInitialSeconds, toGoToSeconds;
    }

    [Serializable]
    public sealed class MotionSpine
    {
        public string go;
        public float x, y, sx = 1f, sy = 1f;
        public bool active = true;
        public bool loop = true;
        public string animation;
    }

    [Serializable] public sealed class MotionCloudBounds { public float minY, maxY, endX; }

    [Serializable] public sealed class MotionSprite { public string file; public float pivotX = 0.5f, pivotY, ppu = 100f; }

    [Serializable]
    public sealed class MotionCloudSprites
    {
        public List<MotionSprite> clear = new List<MotionSprite>(), rain = new List<MotionSprite>(), heavy = new List<MotionSprite>();
    }

    [Serializable]
    public sealed class WorldMotionData
    {
        public MotionCloudBounds cloudBounds;
        public MotionCloudSprites cloudSprites;
        public List<MotionCloud> clouds = new List<MotionCloud>();
        public List<MotionTrain> trains = new List<MotionTrain>();
        public List<MotionSpine> spines = new List<MotionSpine>();
    }

    /// <summary>
    /// Partes moveis do mapa World: nuvens, trem e esqueletos Spine (sol/lua e reflexo na agua).
    /// Posicoes, limites e tempos vem da cena (WorldCloud, WorldCloudsSpawner, WorldTrain,
    /// SkeletonAnimation). O Cpp2IL nao traz o corpo dos metodos, entao velocidade das nuvens,
    /// pausa e curva do trem e a escolha da animacao Spine sao aproximacoes (ver NOT_REPRODUCED.md).
    /// </summary>
    public sealed class WorldMapMotion : MonoBehaviour
    {
        const string DataResource = "WorldSlice/motion";
        // aproximacoes (nao constam no dump): nuvens andam para a direita ate endX e reaparecem a esquerda
        const float CloudMinSpeed = 0.15f, CloudMaxSpeed = 0.45f;
        const float TrainStationWait = 4f, TrainOffscreenWait = 3f;

        sealed class Cloud { public Transform t; public float speed; public SpriteRenderer clear, overcast, heavy; }
        sealed class Train { public Transform t; public MotionTrain data; public float timer; public int phase; }

        readonly List<Cloud> _clouds = new List<Cloud>();
        readonly List<Train> _trains = new List<Train>();
        float _cloudWrapX, _cloudEndX;
        int _weather;

        /// <summary>Procura os GameObjects criados por WorldMapRuntime (nome + posicao) e liga o movimento.</summary>
        public void Begin(WorldMapData world, int weather, IDictionary<string, List<GameObject>> byName)
        {
            var asset = Resources.Load<TextAsset>(DataResource);
            if (asset == null) { Debug.LogWarning("WorldMapMotion: " + DataResource + " ausente"); return; }
            var data = JsonUtility.FromJson<WorldMotionData>(asset.text);
            _weather = weather;
            BuildClouds(data);
            BuildTrains(data, byName);
            BuildSpines(data);
            Debug.Log("WorldMapMotion: " + _clouds.Count + " nuvens, " + _trains.Count + " trem(ns), " + data.spines.Count + " spines");
        }

        static GameObject Find(IDictionary<string, List<GameObject>> byName, string name, float x, float y)
        {
            if (name == null || !byName.TryGetValue(name, out var list)) return null;
            GameObject best = null;
            float bestDist = 0.05f;
            foreach (var go in list)
            {
                if (go == null) continue;
                var p = go.transform.position;
                float d = Mathf.Abs(p.x - x) + Mathf.Abs(p.y - y);
                if (d < bestDist) { best = go; bestDist = d; }
            }
            return best;
        }

        // No original os WorldCloud do level4 nascem sem sprite: o WorldCloudsSpawner sorteia uma de tres listas
        // (clear / rain / heavyRain). Qual lista vale em cada clima nao esta no dump: usa clear no sol, rain na neve
        // (ceu fechado) e heavyRain na chuva (aproximacao).
        void BuildClouds(WorldMotionData data)
        {
            if (data.cloudBounds == null || data.cloudSprites == null) return;
            _cloudEndX = data.cloudBounds.endX;
            float minX = float.MaxValue;
            foreach (var c in data.clouds) minX = Mathf.Min(minX, c.x);
            _cloudWrapX = minX - 6f;
            int i = 0;
            foreach (var c in data.clouds)
            {
                if (!c.active) continue;
                var root = new GameObject("WorldCloud");
                root.transform.SetParent(transform, false);
                root.transform.position = new Vector3(c.x, c.y, -0.05f);
                var cloud = new Cloud { t = root.transform };
                cloud.clear = AddCloudPart(root.transform, "ClearCloud", Pick(data.cloudSprites.clear, i));
                cloud.overcast = AddCloudPart(root.transform, "RainCloud", Pick(data.cloudSprites.rain, i));
                cloud.heavy = AddCloudPart(root.transform, "HeavyRainCloud", Pick(data.cloudSprites.heavy, i));
                // velocidade deterministica por nuvem, para nuvens vizinhas nao andarem juntas
                cloud.speed = Mathf.Lerp(CloudMinSpeed, CloudMaxSpeed, (i * 0.6180339f) % 1f);
                _clouds.Add(cloud);
                i++;
            }
            SetWeather(_weather);
        }

        static MotionSprite Pick(List<MotionSprite> list, int i) => list.Count == 0 ? null : list[(i * 7 + i / 3) % list.Count];

        SpriteRenderer AddCloudPart(Transform parent, string name, MotionSprite m)
        {
            if (m == null) return null;
            var tex = Resources.Load<Texture2D>("WorldSlice/sprites/" + m.file);
            if (tex == null) { Debug.LogWarning("WorldMapMotion: sprite ausente " + m.file); return null; }
            var go = new GameObject(name);
            go.transform.SetParent(parent, false);
            var sr = go.AddComponent<SpriteRenderer>();
            sr.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(m.pivotX, m.pivotY), m.ppu);
            sr.sortingOrder = 0; // sobre o ceu (rank 0, z 0), atras dos fundos e predios
            return sr;
        }

        /// <summary>Troca o conjunto de nuvens conforme o clima (ver comentario de BuildClouds).</summary>
        public void SetWeather(int weather)
        {
            _weather = weather;
            foreach (var c in _clouds)
            {
                if (c.clear != null) c.clear.enabled = weather == WorldWeather.Clear;
                if (c.overcast != null) c.overcast.enabled = weather == WorldWeather.Snow;
                if (c.heavy != null) c.heavy.enabled = weather == WorldWeather.Rain;
            }
        }

        void BuildTrains(WorldMotionData data, IDictionary<string, List<GameObject>> byName)
        {
            foreach (var t in data.trains)
            {
                var go = Find(byName, t.go, t.x, t.y);
                if (go == null || t.start == null || t.goTo == null) continue;
                go.transform.position = new Vector3(t.start.x, t.y, go.transform.position.z);
                _trains.Add(new Train { t = go.transform, data = t });
            }
        }

        void BuildSpines(WorldMotionData data)
        {
            foreach (var s in data.spines)
            {
                if (!s.active) continue;
                // "Spine GameObject (Sun_Moon)" -> nome do esqueleto
                int open = s.go.IndexOf('('), close = s.go.LastIndexOf(')');
                if (open < 0 || close <= open) continue;
                string skeletonName = s.go.Substring(open + 1, close - open - 1);
                var asset = SpineLibrary.Load(skeletonName);
                if (asset == null) continue;
                var go = new GameObject(s.go);
                go.transform.SetParent(transform, false);
                go.transform.position = new Vector3(s.x, s.y, -0.1f);
                go.transform.localScale = new Vector3(s.sx, s.sy, 1f);
                var anim = Spine.Unity.SkeletonAnimation.AddToGameObject(go, asset);
                if (!anim.valid) { Debug.LogWarning("WorldMapMotion: spine invalido " + skeletonName); Destroy(go); continue; }
                string name = PickAnimation(anim, s.animation);
                if (name != null) anim.state.SetAnimation(0, name, true);
                var mr = go.GetComponent<MeshRenderer>();
                if (mr != null) mr.sortingOrder = 0; // sobre o ceu (rank 0, z = 0), atras dos predios
            }
        }

        static string PickAnimation(Spine.Unity.SkeletonAnimation anim, string wanted)
        {
            var items = anim.skeleton.Data.Animations;
            if (items.Count == 0) return null;
            if (!string.IsNullOrEmpty(wanted) && anim.skeleton.Data.FindAnimation(wanted) != null) return wanted;
            // a escolha por hora do dia depende de TimeOfDay do original (nao reproduzido): prefere "Day"/"Idle"
            foreach (var key in new[] { "Day", "Idle", "Loop" })
                foreach (var a in items)
                    if (a.Name.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0) return a.Name;
            return items.Items[0].Name;
        }

        void Update()
        {
            float dt = Time.deltaTime;
            foreach (var c in _clouds)
            {
                var p = c.t.position;
                p.x += c.speed * dt;
                if (p.x > _cloudEndX) p.x = _cloudWrapX;
                c.t.position = p;
            }
            foreach (var tr in _trains) StepTrain(tr, dt);
        }

        // fases: 0 chega ao ponto inicial (toInitialSeconds), 1 espera na estacao, 2 sai ate goTo (toGoToSeconds),
        // 3 fora de cena, depois volta ao start. Os tempos 3,5 s / 5 s vem da cena; as esperas sao aproximadas.
        void StepTrain(Train tr, float dt)
        {
            var d = tr.data;
            tr.timer += dt;
            var pos = tr.t.position;
            switch (tr.phase)
            {
                case 0:
                {
                    float k = Mathf.Clamp01(tr.timer / Mathf.Max(0.01f, d.toInitialSeconds));
                    pos.x = Mathf.Lerp(d.start.x, d.x, 1f - (1f - k) * (1f - k)); // desacelera ao parar
                    if (k >= 1f) Next(tr);
                    break;
                }
                case 1:
                    pos.x = d.x;
                    if (tr.timer >= TrainStationWait) Next(tr);
                    break;
                case 2:
                {
                    float k = Mathf.Clamp01(tr.timer / Mathf.Max(0.01f, d.toGoToSeconds));
                    pos.x = Mathf.Lerp(d.x, d.goTo.x, k * k); // acelera ao sair
                    if (k >= 1f) Next(tr);
                    break;
                }
                default:
                    pos.x = d.goTo.x;
                    if (tr.timer >= TrainOffscreenWait) { tr.phase = -1; Next(tr); pos.x = d.start.x; }
                    break;
            }
            tr.t.position = pos;
        }

        static void Next(Train tr) { tr.phase = (tr.phase + 1) % 4; tr.timer = 0f; }
    }
}
