namespace StarsPass;

public class SuperStarCompletionPassPanel : MonoBehaviour
{
	private const string SUPERSTAR_START_ANIM = "Superstar_Start"; //Field offset: 0x0
	[SerializeField]
	private SkeletonGraphic _pinkySuperStarSkeletonGraphic; //Field offset: 0x20
	[SerializeField]
	private GameObject _superStarPanel; //Field offset: 0x28
	private Action _onConfirmClaimAction; //Field offset: 0x30
	private bool _isShown; //Field offset: 0x38

	public SuperStarCompletionPassPanel() { }

	public void OnClickExitButton() { }

	public void OpenSuperStarPanel(Action onConfirmClaim) { }

}

