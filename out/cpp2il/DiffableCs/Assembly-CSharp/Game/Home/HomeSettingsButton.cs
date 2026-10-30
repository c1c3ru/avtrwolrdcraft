namespace Game.Home;

public class HomeSettingsButton : ButtonBase
{
	[SerializeField]
	private HomeSettingsMenu _menu; //Field offset: 0x20

	public HomeSettingsButton() { }

	protected virtual void OnClick() { }

}

