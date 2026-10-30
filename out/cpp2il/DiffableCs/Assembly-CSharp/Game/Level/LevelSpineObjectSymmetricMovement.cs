namespace Game.Level;

public class LevelSpineObjectSymmetricMovement : MonoBehaviour
{
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x20
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private String[] _transitionAnimationsNames; //Field offset: 0x28
	private bool _isReversed; //Field offset: 0x30

	public LevelSpineObjectSymmetricMovement() { }

	private void Awake() { }

	public void PauseAnimation() { }

	private void PlayAnimation(string animationName) { }

	public void TryPlayAnimation() { }

	public void TryPlayReverseAnimation() { }

}

