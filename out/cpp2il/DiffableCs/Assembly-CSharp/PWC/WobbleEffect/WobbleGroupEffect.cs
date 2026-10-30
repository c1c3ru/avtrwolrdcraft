namespace PWC.WobbleEffect;

[DisallowMultipleComponent]
public class WobbleGroupEffect : WobbleEffectBase
{
	private const int MaxReportedConflicts = 5; //Field offset: 0x0
	[SerializeField]
	private Material _wobbleMaterial; //Field offset: 0x40
	[SerializeField]
	private List<SpriteRenderer> _spriteRenderers; //Field offset: 0x48
	[SerializeField]
	private List<String> _excludedNames; //Field offset: 0x50
	private Material _groupMaterialInstance; //Field offset: 0x58
	private MaterialPropertyBlock _propertyBlock; //Field offset: 0x60
	private readonly List<Component> _componentBuffer; //Field offset: 0x68

	protected virtual bool RefreshPivotOnDragBegin
	{
		 get { } //Length: 8
	}

	public WobbleGroupEffect() { }

	private void ApplyGroupMaterial() { }

	private void ApplyGroupMaterialTo(SpriteRenderer sr) { }

	protected virtual void ApplyWobble(float wobbleAmount) { }

	protected virtual void ApplyWorldPosition(Vector2 worldPosition) { }

	private void Awake() { }

	private int CollectSpriteRenderers(List<SpriteRenderer> results) { }

	private void DisableConflictingWobbleEffects() { }

	protected virtual bool get_RefreshPivotOnDragBegin() { }

	private bool IsExcluded(SpriteRenderer sr) { }

	private void OnDestroy() { }

	public void RegisterSprite(SpriteRenderer sr) { }

	public void UnregisterSprite(SpriteRenderer sr) { }

}

