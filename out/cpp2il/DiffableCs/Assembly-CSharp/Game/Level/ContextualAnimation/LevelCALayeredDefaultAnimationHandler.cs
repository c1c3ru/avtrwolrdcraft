namespace Game.Level.ContextualAnimation;

public class LevelCALayeredDefaultAnimationHandler : MonoBehaviour
{
	private const float MixDuration = 0,2; //Field offset: 0x0
	[SerializeField]
	private string _defaultAnimationName; //Field offset: 0x20
	private LevelCAHandlerBase _caHandler; //Field offset: 0x28

	public LevelCALayeredDefaultAnimationHandler() { }

	[CompilerGenerated]
	private bool <TryGetDefaultConfig>b__10_0(LevelCAConfig c) { }

	private void Awake() { }

	private void OnAddedToTarget(LevelCAHandlerBase caHandler, ICATarget target) { }

	private void OnAnimationBegin(LevelCAHandlerBase caHandler, ICATarget target, LevelCAConfig config) { }

	private void OnAnimationEnd(LevelCAHandlerBase caHandler, ICATarget target, LevelCAConfig config) { }

	private void OnDestroy() { }

	private void OnRemovedFromTarget(LevelCAHandlerBase caHandler, ICATarget target) { }

	private void PlayDefaultAnimation(LevelCAHandlerBase caHandler, ICATarget target) { }

	private void TryClearTrack(LevelCAHandlerBase caHandler, ICATarget target, LevelCAConfig config) { }

	private bool TryGetDefaultConfig(LevelCAHandlerBase caHandler, out LevelCAConfig config) { }

}

