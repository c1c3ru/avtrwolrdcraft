namespace PWC.Level.ContextualAnimation;

public class LevelCAReleaseOnAnimationBeginDropAreaHandler : MonoBehaviour
{
	private LevelDropArea _dropArea; //Field offset: 0x20

	public LevelCAReleaseOnAnimationBeginDropAreaHandler() { }

	private void Awake() { }

	private void OnAnimationBegin(LevelCAHandlerBase handler, ICATarget target, LevelCAConfig config) { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private void OnItemPickUp(LevelItem levelItem) { }

}

