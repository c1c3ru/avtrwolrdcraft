namespace Game.Level;

public class LevelOnSpecificPairAnimationBetweenSpecificAvatars : ConditionResolverComponent
{
	[SerializeField]
	private int _avatarID; //Field offset: 0x28
	[SerializeField]
	private int _pairAvatarID; //Field offset: 0x2C
	[SerializeField]
	private string _animationName; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _onInteractionPlayed; //Field offset: 0x38

	public LevelOnSpecificPairAnimationBetweenSpecificAvatars() { }

	private void Awake() { }

	private bool IsMatchingAvatarPair(int characterID, int pairID) { }

	private void OnDestroy() { }

	private void OnInterationPlayed(ICATarget target, LevelItem item, LevelCAConfig config) { }

}

