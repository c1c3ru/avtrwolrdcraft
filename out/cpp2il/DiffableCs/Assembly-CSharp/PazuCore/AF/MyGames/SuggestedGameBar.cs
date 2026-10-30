namespace PazuCore.AF.MyGames;

public class SuggestedGameBar : MonoBehaviour
{
	[SerializeField]
	private Text _gameNameText; //Field offset: 0x20
	[SerializeField]
	private Image _image; //Field offset: 0x28
	[SerializeField]
	private Slider _starsSlider; //Field offset: 0x30
	[SerializeField]
	private Image icon; //Field offset: 0x38
	public int gameId; //Field offset: 0x40
	public SuggestedGameWidget gameIcon; //Field offset: 0x48

	public SuggestedGameBar() { }

	public void OpenStore() { }

	public void SetGameName(string gameName) { }

	public void SetImageNativeSize() { }

	public void SetIndicatorIcon(Sprite sprite) { }

	public void SetStars(float rating) { }

}

