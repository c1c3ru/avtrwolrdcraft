namespace PWC.Level;

public abstract class LevelTransformableObjectHandlerBase : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, ILevelSpawnDuringGameplay
{
	[SerializeField]
	private bool _useEffectColorHandler; //Field offset: 0x20
	[ConditionalField("_useEffectColorHandler", False, True, (array) null)]
	[SerializeField]
	private Color _particleSystemColor; //Field offset: 0x24
	[SerializeField]
	private ParticleSystem _overrideEffectPrefab; //Field offset: 0x38
	[SerializeField]
	private bool _useVanishEffect; //Field offset: 0x40
	[SerializeField]
	private string _soundName; //Field offset: 0x48
	[SerializeField]
	private bool _canBeClicked; //Field offset: 0x50
	[SerializeField]
	private bool _deleteChildrenLevelItems; //Field offset: 0x51
	[SerializeField]
	private bool _shouldTryToColor; //Field offset: 0x52
	[ConditionalField("_shouldTryToColor", True, True, (array) null)]
	[SerializeField]
	private Color _color; //Field offset: 0x54
	[ConditionalField("_shouldTryToColor", True, True, (array) null)]
	[SerializeField]
	private PWSpriteColorType _colorType; //Field offset: 0x64
	public Func<Boolean> CanClickAction; //Field offset: 0x68
	private LevelMakerCustomizationObjectHandlerBase _makerCustomizationHandler; //Field offset: 0x70
	private bool _didOnReadyPostLoad; //Field offset: 0x78

	protected LevelTransformableObjectHandlerBase() { }

	protected override void Awake() { }

	protected override bool CanBeClicked() { }

	protected abstract void DestroySelf() { }

	private void EnsureOnReadyPostLoad() { }

	public void ForceClick() { }

	protected abstract int GetSortingOrder() { }

	public abstract string GetTransformTargetPrefabName() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	protected override void OnPointerClickInternal(PointerEventData eventData) { }

	private void OnReadyPostLoad() { }

	public override void OnSpawnDuringGameplay() { }

	protected abstract bool TrySpawnImplement(out PDPrefab pdPrefabInstance) { }

}

