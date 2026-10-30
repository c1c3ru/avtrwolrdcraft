namespace PWC.AWCloud;

public class AWCloudSceneManager : MonoBehaviour
{
	public static Action OverrideNextSceneCloseAction; //Field offset: 0x0
	[SerializeField]
	private GameObject _mainPanel; //Field offset: 0x20
	[SerializeField]
	private GameObject _registerPanel; //Field offset: 0x28
	[SerializeField]
	private GameObject _loginPanel; //Field offset: 0x30
	[SerializeField]
	private GameObject _finishPanel; //Field offset: 0x38
	[SerializeField]
	private GameObject _backButton; //Field offset: 0x40
	[SerializeField]
	private GameObject _mainPanelLoginSection; //Field offset: 0x48
	[SerializeField]
	private RectTransform _mainPanelRegisterSection; //Field offset: 0x50

	public AWCloudSceneManager() { }

	[CompilerGenerated]
	private void <OnRegisterButtonClick>b__13_0(bool isSuccess, bool didTryToUploadProgress) { }

	private void Awake() { }

	private void CloseScene() { }

	public void OnBackButtonClick() { }

	private void OnDestroy() { }

	public void OnFinishButtonClick() { }

	public void OnLoginButtonClick() { }

	public void OnRegisterButtonClick() { }

	private void OnUserSync(SyncType syncType) { }

	private void SyncMainView() { }

}

