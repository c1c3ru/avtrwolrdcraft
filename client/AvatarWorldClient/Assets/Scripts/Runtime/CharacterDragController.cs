using System;
using AvatarWorld.Core.Avatar;
using AvatarWorld.Core.Pointer;
using UnityEngine;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Liga os contratos extraidos do original (docs/RECON_*_CONTRACT.md) a um personagem na cena:
    /// ponteiro -> DragIntentDetector (limiar de 10 px, clique contra arraste) -> posicao por quadro (Pre/Post)
    /// -> velocidade -> LocomotionStateMachine -> nome de animacao.
    /// A velocidade e medida em unidades de mundo por segundo (inferido: o original usa sqrt(a^2+b^2)/t, a unidade nao foi provada).
    /// Nao toca em Spine: expoe CurrentAnimation e eventos para quem renderiza.
    /// </summary>
    public sealed class CharacterDragController : MonoBehaviour
    {
        public Camera Cam;
        public LocomotionFamily Family = LocomotionFamily.Character;
        public PostureKind Posture = PostureKind.Standing;
        public bool HasRunningAnimations;

        /// <summary>SpineType do catalogo (1 Character, 2 Baby, 3 Cat, 4 Dog, 13 Toddler, 14 Horse); escolhe handlers de CA e prefixo.</summary>
        public int SpineType = 1;

        /// <summary>Area de descanso atual (LevelCharacter.CurrentRestArea): decide idle de cadeira/cama e a variante __Sitting.</summary>
        public RestAreaKind RestArea = RestAreaKind.None;
        public float GrabRadius = 1.4f;

        /// <summary>Se maior que zero, substitui Time.deltaTime no Update (testes com velocidade deterministica).</summary>
        public float DeltaTimeOverride;

        /// <summary>Esqueleto Spine a animar (opcional). Sem ele, so CurrentAnimation e eventos sao atualizados.</summary>
        public Spine.Unity.SkeletonAnimation Skeleton;

        /// <summary>Conversao tela -> mundo; injetavel para testes. Padrao: Cam.ScreenToWorldPoint.</summary>
        public Func<Vector2, Vector2> ScreenToWorld;

        public MovementKind Movement { get; private set; } = MovementKind.Stand;
        public string CurrentAnimation { get; private set; }
        public DragPhase Phase { get { return _intent.Phase; } }

        public event Action<MovementKind> MovementChanged;
        public event Action DragStarted;
        public event Action DragEnded;
        public event Action Clicked;
        public event Action CAEnded;

        public CAPlayType CurrentCAPlayType { get; private set; }
        public string CurrentCAHandlerName { get; private set; }
        public int ContextualAnimationCounter { get; private set; }

        /// <summary>Etapas opcionais Pre/Post por quadro (slots 25/26 do original). Nulas = identidade.</summary>
        public Func<DragPoint, DragPoint> PreModifications;
        public Func<DragPoint, DragPoint> PostModifications;

        readonly DragIntentDetector _intent = new DragIntentDetector();
        bool _wasPressed;
        Vector2 _grabOffset;
        Vector2 _lastPosition;

        void Awake()
        {
            CurrentAnimation = LocomotionAnimations.NameFor(Family, Movement, Posture);
        }

        void Start()
        {
            // Family/Posture costumam ser configurados depois do AddComponent: recalcula com a configuracao final.
            CurrentAnimation = LocomotionAnimations.NameFor(Family, Movement, Posture);
            PlayOnSkeleton(CurrentAnimation);
        }

        void Update()
        {
#if ENABLE_INPUT_SYSTEM
            var pointer = UnityEngine.InputSystem.Pointer.current;
            if (pointer == null) return;
            Tick(pointer.press.isPressed, pointer.position.ReadValue(), DeltaTimeOverride > 0f ? DeltaTimeOverride : Time.deltaTime);
#endif
        }

        /// <summary>Um quadro de entrada. Separado de Update para ser testavel sem dispositivo.</summary>
        public void Tick(bool pressed, Vector2 screenPosition, float deltaTime)
        {
            Vector2 world = ToWorld(screenPosition);
            bool down = pressed && !_wasPressed;
            bool up = !pressed && _wasPressed;
            _wasPressed = pressed;

            if (down)
            {
                if (Vector2.Distance(world, (Vector2)transform.position) <= GrabRadius)
                {
                    _intent.PointerDown(screenPosition.x, screenPosition.y);
                    _grabOffset = (Vector2)transform.position - world;
                    _lastPosition = transform.position;
                }
                return;
            }

            if (up)
            {
                var result = _intent.PointerUp();
                if (result == PointerReleaseResult.Click) { if (Clicked != null) Clicked(); }
                else if (result == PointerReleaseResult.EndDrag)
                {
                    SetMovement(MovementKind.None);       // OnEndMovement grava 0
                    SetMovement(MovementKind.Stand);      // e o idle volta no quadro seguinte
                    if (DragEnded != null) DragEnded();
                }
                return;
            }

            if (_intent.Phase == DragPhase.Idle) return;

            if (_intent.PointerMove(screenPosition.x, screenPosition.y) && DragStarted != null)
                DragStarted();
            if (_intent.Phase != DragPhase.Dragging) return;

            var raw = new DragPoint(world.x + _grabOffset.x, world.y + _grabOffset.y);
            var p = DragPositionPipeline.Compute(raw, PreModifications, PostModifications);
            var target = new Vector2(p.X, p.Y);
            transform.position = new Vector3(target.x, target.y, transform.position.z);

            float speed = deltaTime > 0f ? Vector2.Distance(target, _lastPosition) / deltaTime : 0f;
            _lastPosition = target;
            SetMovement(LocomotionStateMachine.Next(LocomotionAnimations.ConfigFor(Family), Movement, speed, HasRunningAnimations));
        }

        Vector2 ToWorld(Vector2 screen)
        {
            if (ScreenToWorld != null) return ScreenToWorld(screen);
            if (Cam == null) return screen;
            Vector3 w = Cam.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 10f));
            return new Vector2(w.x, w.y);
        }

        void SetMovement(MovementKind next)
        {
            if (next == Movement && CurrentAnimation != null) return;
            bool changed = next != Movement;
            Movement = next;
            string previous = CurrentAnimation;
            CurrentAnimation = LocomotionAnimations.NameFor(Family, Movement, Posture);
            if (CurrentAnimation != previous) PlayOnSkeleton(CurrentAnimation);
            if (changed && MovementChanged != null) MovementChanged(Movement);
        }

        public bool HasAnimation(string animationName)
        {
            return Skeleton != null && Skeleton.valid && Skeleton.Skeleton.Data.FindAnimation(animationName) != null;
        }

        /// <summary>
        /// Toca uma animacao contextual do catalogo (docs/RECON_CHARACTER_CONTRACT.md, secoes 15 e 16): valida alvo e nome,
        /// resolve o nome pela regra de CreateAnimationName, usa __Sitting no Character sentado, toca em loop=false na faixa da config
        /// e, no fim, toca o idle alternativo (se houver) ou volta ao idle apropriado. Inferido: loop=false e o retorno ao idle.
        /// </summary>
        public bool PlayContextualAnimation(CAHandlerEntry handler, int configIndex)
        {
            bool alive = handler != null && handler.configs != null && configIndex >= 0 && configIndex < handler.configs.Length;
            var check = ContextualAnimationRules.ValidateStart(alive, alive ? handler.configs[configIndex].name : null);
            if (check == CAStartCheck.TargetNull) { Debug.LogError(ContextualAnimationRules.TargetNullMessage); return false; }
            if (check == CAStartCheck.ConfigNameEmpty) { Debug.LogError(ContextualAnimationRules.ConfigNameEmptyMessage); return false; }

            var cfg = handler.configs[configIndex];
            string name = handler.AnimationName(configIndex);
            if (Family == LocomotionFamily.Character)
                name = ContextualAnimationRules.CharacterAnimationName(name, RestArea == RestAreaKind.Sit, HasAnimation);

            bool hasSkeleton = Skeleton != null && Skeleton.valid;
            if (hasSkeleton && !HasAnimation(name))
            {
                Debug.LogError("CharacterDragController: No animation found for animationName[" + name + "]");
                return false;
            }

            ContextualAnimationCounter++;
            CurrentCAPlayType = CAPlayType.PlayingNormalAnimation;
            CurrentCAHandlerName = handler.name;
            CurrentAnimation = name;
            if (hasSkeleton)
            {
                var entry = Skeleton.AnimationState.SetAnimation(cfg.trackIndex, name, false);
                entry.Complete += e => OnCAComplete(handler, cfg);
            }
            return true;
        }

        void OnCAComplete(CAHandlerEntry handler, CAConfigEntry cfg)
        {
            if (!string.IsNullOrEmpty(cfg.alternateIdleAnimation))
            {
                string alt = cfg.alternateIdleAnimation;
                if (!HasAnimation(alt))
                {
                    bool prefix = ContextualAnimationRules.HasCAPrefix(handler.spineType) ?? false;
                    string folder = string.IsNullOrEmpty(cfg.folderNameOverride) ? handler.folderName : cfg.folderNameOverride;
                    alt = (prefix ? "CA/" : "") + folder + "/" + cfg.alternateIdleAnimation;
                }
                if (HasAnimation(alt))
                {
                    CurrentCAPlayType = CAPlayType.PlayingAlternateIdle;
                    CurrentAnimation = alt;
                    Skeleton.AnimationState.SetAnimation(cfg.trackIndex, alt, true);
                    return;
                }
            }
            CurrentCAPlayType = CAPlayType.None;
            CurrentCAHandlerName = null;
            string idle = Family == LocomotionFamily.Character
                ? ProperIdleSelector.AnimationFor(ProperIdleSelector.Choose(false, false, RestArea))
                : LocomotionAnimations.NameFor(Family, MovementKind.Stand, Posture);
            CurrentAnimation = idle;
            if (cfg.trackIndex != 0 && Skeleton != null && Skeleton.valid) Skeleton.AnimationState.ClearTrack(cfg.trackIndex);
            PlayOnSkeleton(idle);
            if (CAEnded != null) CAEnded();
        }

        /// <summary>Toca a animacao no esqueleto (faixa 0, em loop). Nome ausente no esqueleto vira erro de log, como no original.</summary>
        public void PlayOnSkeleton(string animationName)
        {
            if (Skeleton == null || !Skeleton.valid) return;
            if (Skeleton.Skeleton.Data.FindAnimation(animationName) == null)
            {
                Debug.LogError("CharacterDragController: No animation found for animationName[" + animationName + "]");
                return;
            }
            Skeleton.AnimationState.SetAnimation(0, animationName, true);
        }
    }
}
