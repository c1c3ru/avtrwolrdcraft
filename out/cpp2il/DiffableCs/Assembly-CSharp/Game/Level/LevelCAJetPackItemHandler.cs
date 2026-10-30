namespace Game.Level;

public class LevelCAJetPackItemHandler : LevelCAItemWithSkinHandlerBase
{
	[SerializeField]
	private int _jetPackNumber; //Field offset: 0xB0
	[SerializeField]
	private ParticleSystem[] _particles; //Field offset: 0xB8
	[SerializeField]
	private CShape _leftWingCShape; //Field offset: 0xC0
	[SerializeField]
	private CShape _rightWingCShape; //Field offset: 0xC8
	private Vector2 _lastPos; //Field offset: 0xD0
	private Coroutine _rotationCoroutine; //Field offset: 0xD8
	private int _floatingTweenID; //Field offset: 0xE0
	private int _rotateTweenID; //Field offset: 0xE4
	private int _smokeTweenID; //Field offset: 0xE8
	private float _rightXBound; //Field offset: 0xEC
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xF0

	public LevelCAJetPackItemHandler() { }

	[CompilerGenerated]
	private void <OnAddedToTarget>b__26_0() { }

	private void FlyUpAndReturn() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	protected virtual string GetSkinName() { }

	public virtual SpineType GetSpineType() { }

	private void Init() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnReadyPostLoad() { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	protected virtual void OnSkinAdded() { }

	protected virtual void OnSkinRemoved() { }

	protected virtual void OnTargetBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	protected virtual void OnTargetClick(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	protected virtual void OnTargetEndDrag(DragDropItemBase item, PointerEventData eventData) { }

	private bool OverrideOnDropBehaviorAction(LevelItem arg1, PointerEventData arg2) { }

	private void ReturnToBoundsIfNeeded(Action action) { }

	protected virtual bool ShouldRegisterToEventSystemTargetEvents() { }

	private void StartLevitate() { }

	private void ToggleParticlesEffect(bool active) { }

}

