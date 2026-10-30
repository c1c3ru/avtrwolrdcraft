namespace Game.Level.ContextualAnimation;

public class LevelConductorsBatonReactionOnToddlersItemHandler : MonoBehaviour
{
	[SerializeField]
	private LevelCAItemHandlerBase _caRef; //Field offset: 0x20

	public LevelConductorsBatonReactionOnToddlersItemHandler() { }

	private void Awake() { }

	private void OnAnimationBegin(LevelCAHandlerBase ca, ICATarget target, LevelCAConfig config) { }

	private void OnAnimationEnd(LevelCAHandlerBase ca, ICATarget target, LevelCAConfig config) { }

	private void OnDestroy() { }

	private void SetAnimationOnOther(IHaveAnimationSearch specialAnimationNames, LevelToddler toddler, LevelCAConfig givenConfig, bool isActive) { }

}

