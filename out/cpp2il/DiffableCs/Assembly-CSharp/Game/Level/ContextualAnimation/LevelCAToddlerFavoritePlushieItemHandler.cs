namespace Game.Level.ContextualAnimation;

public class LevelCAToddlerFavoritePlushieItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x88
	[SerializeField]
	private Sprite _heldSprite; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98
	private bool _isSwitchHands; //Field offset: 0xA0
	private Vector3 _lastHandPosition; //Field offset: 0xA4
	private LevelToddler _toddler; //Field offset: 0xB0
	private Sprite _normalSprite; //Field offset: 0xB8

	public LevelCAToddlerFavoritePlushieItemHandler() { }

	protected virtual void Awake() { }

	private void EnsureToyState(ICATarget target) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetAnimationSuffix() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	protected virtual void OnDestroy() { }

	private void OnEndLand(LevelDropArea dropArea) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private void ToggleHeldSprite(bool isHeld) { }

}

