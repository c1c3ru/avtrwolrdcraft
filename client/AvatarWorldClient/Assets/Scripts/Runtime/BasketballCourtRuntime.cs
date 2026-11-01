using System;
using AvatarWorld.Core.Economy;
using UnityEngine;

namespace AvatarWorld.Runtime
{
    /// <summary>Primeira fatia offline de gameplay: quadra original, avatar salvo e arremesso por arraste.</summary>
    public sealed class BasketballCourtRuntime : MonoBehaviour
    {
        SaveStore _saves;
        PlayerState _state;
        Action _onExit;
        Camera _camera;
        SpriteRenderer _ball;
        Vector3 _ballHome;
        Vector3 _shotStart;
        Vector3 _shotTarget;
        float _shotTime;
        int _score;
        bool _dragging;
        bool _shooting;
        string _message = "Arraste a bola para cima para arremessar";

        public int Score => _score;
        public bool IsDragging => _dragging;

        public void Begin(SaveStore saves, PlayerState state, Action onExit)
        {
            _saves = saves ?? throw new ArgumentNullException(nameof(saves));
            _state = state ?? throw new ArgumentNullException(nameof(state));
            _onExit = onExit;
            BuildCourt();
        }

        void BuildCourt()
        {
            _camera = new GameObject("CourtCamera", typeof(Camera)).GetComponent<Camera>();
            _camera.transform.SetParent(transform, false);
            _camera.tag = "MainCamera";
            _camera.orthographic = true;
            _camera.orthographicSize = 5.25f;
            _camera.clearFlags = CameraClearFlags.SolidColor;
            _camera.backgroundColor = new Color(0.72f, 0.76f, 0.82f);
            _camera.transform.position = new Vector3(0, 0, -10);

            AddSprite("Quadra", "BasketballCourt/BG_01", Vector3.zero, 0, true);
            AddSprite("Cesta esquerda", "BasketballCourt/Hoop", new Vector3(-6.25f, -0.4f, 0), 2, false);
            AddSprite("Cesta direita", "BasketballCourt/Hoop", new Vector3(6.25f, -0.4f, 0), 2, false);
            _ball = AddSprite("Bola arremessável", "BasketballCourt/Ball", new Vector3(0, -2.25f, 0), 5, false);
            _ballHome = _ball.transform.position;

            var avatarHost = new GameObject("Avatar salvo na quadra");
            avatarHost.transform.SetParent(transform, false);
            var avatar = avatarHost.AddComponent<AvatarGpuRuntime>();
            avatar.ConfigureAsWorldAvatar(_saves, _state, new Vector3(-3.2f, -2.7f, 0), 0.55f);
            Debug.Log("BasketballCourt: quadra e avatar carregados; arraste a bola para jogar");
        }

        SpriteRenderer AddSprite(string objectName, string resource, Vector3 position, int order, bool fitCourt)
        {
            var texture = Resources.Load<Texture2D>(resource);
            if (texture == null) throw new InvalidOperationException("Asset da quadra ausente: " + resource);
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100f);
            var go = new GameObject(objectName);
            go.transform.SetParent(transform, false);
            go.transform.localPosition = position;
            var renderer = go.AddComponent<SpriteRenderer>();
            renderer.sprite = sprite;
            renderer.sortingOrder = order;
            if (fitCourt)
            {
                float width = _camera.orthographicSize * 2f * _camera.aspect;
                go.transform.localScale = new Vector3(width / sprite.bounds.size.x,
                    (_camera.orthographicSize * 2f) / sprite.bounds.size.y, 1f);
            }
            else if (objectName.StartsWith("Cesta")) go.transform.localScale = Vector3.one * 0.8f;
            else go.transform.localScale = Vector3.one * 0.65f;
            return renderer;
        }

        void Update()
        {
            if (_shooting)
            {
                _shotTime += Time.deltaTime * 1.6f;
                float t = Mathf.Clamp01(_shotTime);
                var p = Vector3.Lerp(_shotStart, _shotTarget, t);
                p.y += Mathf.Sin(t * Mathf.PI) * 2.4f;
                _ball.transform.position = p;
                if (t >= 1f)
                {
                    _shooting = false;
                    _score++;
                    _message = "Cesta! Toque e arraste para tentar de novo";
                    _ballHome = new Vector3(0, -2.25f, 0);
                }
                return;
            }

#if ENABLE_INPUT_SYSTEM
            var touchscreen = UnityEngine.InputSystem.Touchscreen.current;
            if (touchscreen != null && (touchscreen.primaryTouch.press.isPressed || touchscreen.primaryTouch.press.wasReleasedThisFrame))
            {
                var touch = touchscreen.primaryTouch;
                Vector2 position = touch.position.ReadValue();
                Vector3 world = _camera.ScreenToWorldPoint(new Vector3(position.x, position.y, 10));
                if (touch.press.wasPressedThisFrame && Vector2.Distance(world, _ball.transform.position) < 1.4f)
                {
                    _dragging = true;
                    _shotStart = _ball.transform.position;
                }
                else if (_dragging && touch.press.isPressed)
                    _ball.transform.position = new Vector3(world.x, world.y, 0);
                else if (_dragging && touch.press.wasReleasedThisFrame)
                    FinishDrag(world);
                return;
            }
#endif
#if ENABLE_INPUT_SYSTEM
            var mouse = UnityEngine.InputSystem.Mouse.current;
            if (mouse != null)
            {
                Vector2 position = mouse.position.ReadValue();
                Vector3 world = _camera.ScreenToWorldPoint(new Vector3(position.x, position.y, 10));
                if (mouse.leftButton.wasPressedThisFrame && Vector2.Distance(world, _ball.transform.position) < 1.4f)
                {
                    _dragging = true;
                    _shotStart = _ball.transform.position;
                }
                else if (_dragging && mouse.leftButton.isPressed)
                    _ball.transform.position = new Vector3(world.x, world.y, 0);
                else if (_dragging && mouse.leftButton.wasReleasedThisFrame)
                    FinishDrag(world);
                if (mouse.leftButton.isPressed || mouse.leftButton.wasReleasedThisFrame) return;
            }
#endif
#if ENABLE_LEGACY_INPUT_MANAGER
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                Vector3 world = _camera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                if (touch.phase == TouchPhase.Began && Vector2.Distance(world, _ball.transform.position) < 1.4f)
                {
                    _dragging = true;
                    _shotStart = _ball.transform.position;
                }
                else if (_dragging && (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary))
                    _ball.transform.position = new Vector3(world.x, world.y, 0);
                else if (_dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
                    FinishDrag(world);
            }
            else
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 world = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                if (Vector2.Distance(world, _ball.transform.position) < 1.4f) { _dragging = true; _shotStart = _ball.transform.position; }
            }
            else if (_dragging && Input.GetMouseButton(0))
            {
                Vector3 world = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                _ball.transform.position = new Vector3(world.x, world.y, 0);
            }
            else if (_dragging && Input.GetMouseButtonUp(0))
            {
                Vector3 world = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                FinishDrag(world);
            }
#endif
        }

        void FinishDrag(Vector3 release)
        {
            _dragging = false;
            float upward = release.y - _shotStart.y;
            if (upward < 0.55f)
            {
                _ball.transform.position = _ballHome;
                _message = "Puxe a bola para cima para arremessar";
                return;
            }
            _shotStart = _ball.transform.position;
            _shotTarget = new Vector3(release.x < 0 ? -6.15f : 6.15f, -0.45f, 0);
            _shotTime = 0;
            _shooting = true;
            _message = "Arremessando…";
        }

        void OnGUI()
        {
            GUIStyle label = new GUIStyle(GUI.skin.label) { fontSize = Mathf.Max(18, Screen.height / 32), alignment = TextAnchor.MiddleCenter };
            label.normal.textColor = Color.white;
            GUI.Box(new Rect(Screen.width * 0.38f, 12, Screen.width * 0.24f, 100), "");
            GUI.Label(new Rect(Screen.width * 0.38f, 16, Screen.width * 0.24f, 42), "CESTAS  " + _score, label);
            GUI.Label(new Rect(Screen.width * 0.2f, 62, Screen.width * 0.6f, 40), _message, label);
            if (GUI.Button(new Rect(16, 16, Mathf.Max(120, Screen.width * 0.12f), 56), "Voltar à Home")) _onExit?.Invoke();
        }
    }
}
