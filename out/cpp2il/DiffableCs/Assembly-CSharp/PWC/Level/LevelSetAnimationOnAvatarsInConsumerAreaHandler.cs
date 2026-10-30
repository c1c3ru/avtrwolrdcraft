namespace PWC.Level;

public class LevelSetAnimationOnAvatarsInConsumerAreaHandler : MonoBehaviour
{
	[SerializeField]
	private List<LevelConsumerAreaBase> _consumerAreas; //Field offset: 0x20
	[SerializeField]
	private List<String> _animationNames; //Field offset: 0x28
	[SerializeField]
	private bool _randomOrder; //Field offset: 0x30
	[SerializeField]
	private int _trackIndex; //Field offset: 0x34
	private int _nextAnimationIndex; //Field offset: 0x38
	private Random _random; //Field offset: 0x40

	public LevelSetAnimationOnAvatarsInConsumerAreaHandler() { }

	private void Awake() { }

	private string GetNextAnimationName() { }

	public void PlayAnimationsOnAllAvatars() { }

}

