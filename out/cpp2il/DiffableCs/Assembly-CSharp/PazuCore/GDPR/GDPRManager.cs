namespace PazuCore.GDPR;

public class GDPRManager : MonoBehaviour
{
	private const string PLAYERPREFS_KEY = "PazuCore_GDPR_Did_User_Accept"; //Field offset: 0x0
	[SerializeField]
	private Image _bannerImage; //Field offset: 0x20
	[SerializeField]
	private GameObject _termsOfUse; //Field offset: 0x28
	[SerializeField]
	private GameObject _privicyPolicy; //Field offset: 0x30
	[SerializeField]
	private GameObject _content; //Field offset: 0x38
	[SerializeField]
	private CanvasScaler _canvasScaler; //Field offset: 0x40
	[SerializeField]
	private GameObject _gdprAvatar; //Field offset: 0x48
	[SerializeField]
	private GameObject _gdprPortrait; //Field offset: 0x50
	[SerializeField]
	private GameObject _gdprLandscape; //Field offset: 0x58

	public GDPRManager() { }

	private void Awake() { }

	public static bool DidUseAcceptConditions() { }

	private void EnableGDPR() { }

	public void OnAcceptButtonClick() { }

	public void OnPrivacyPolicyClick() { }

	public void OnTermsOfUseClick() { }

}

