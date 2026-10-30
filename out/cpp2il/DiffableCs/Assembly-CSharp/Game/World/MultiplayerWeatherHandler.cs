namespace Game.World;

public class MultiplayerWeatherHandler : MonoBehaviour
{
	[SerializeField]
	private RectTransform _buttonsHolderToMove; //Field offset: 0x20
	[SerializeField]
	private List<Button> _buttonsToDisable; //Field offset: 0x28
	[SerializeField]
	private List<GameObject> _graphicsToDisable; //Field offset: 0x30
	[SerializeField]
	private float _xPadding; //Field offset: 0x38

	public MultiplayerWeatherHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnEnterMultiplayer() { }

	private void OnPostInitAction() { }

	private void UpdateLevel() { }

}

