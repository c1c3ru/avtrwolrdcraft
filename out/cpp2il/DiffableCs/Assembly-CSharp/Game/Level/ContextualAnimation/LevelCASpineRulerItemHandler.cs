namespace Game.Level.ContextualAnimation;

public class LevelCASpineRulerItemHandler : LevelCAItemHandlerBase, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x88
	private bool _isOpen; //Field offset: 0x90
	private bool _isFirstEvent; //Field offset: 0x91
	private readonly List<LevelCAConfig> _openConfigs; //Field offset: 0x98
	private readonly List<LevelCAConfig> _closedConfigs; //Field offset: 0xA0

	public LevelCASpineRulerItemHandler() { }

	private void ChangeState() { }

	public void Editor_PerformDiagnosticsTest(bool isInScene) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

