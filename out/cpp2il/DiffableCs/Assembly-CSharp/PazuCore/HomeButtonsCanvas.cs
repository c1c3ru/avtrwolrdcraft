namespace PazuCore;

public class HomeButtonsCanvas : SceneButtonsCanvasBase
{
	private GameObject _fullGamePackButton; //Field offset: 0x30
	private GameObject _moreGamesButton; //Field offset: 0x38
	private GameObject _connectDevicesButton; //Field offset: 0x40
	private GameObject _rateUsButton; //Field offset: 0x48

	public HomeButtonsCanvas() { }

	protected virtual void Awake() { }

	public void ClearBottomLeft() { }

	public void ClearBottomRight() { }

	private void CreateConnectDevicesButton() { }

	protected virtual void CreateDefaultButtons() { }

	private void CreateFullGamePackButton() { }

	private void CreateMoreGamesButton() { }

	private void CreateRateUsButton() { }

	private void Start() { }

}

