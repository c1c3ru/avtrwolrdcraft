namespace PWC.Level.Maker.Customization;

public class LevelMakerButtonsView : MonoBehaviour
{
	[SerializeField]
	private LevelMakerItemCustomizationMenu _menu; //Field offset: 0x20
	[SerializeField]
	private GameObject _buttonsView; //Field offset: 0x28
	[SerializeField]
	private GameObject _buttonsViewContent; //Field offset: 0x30

	public LevelMakerButtonsView() { }

	private void Awake() { }

	private void OnCustomizationItemHandlerEndClick() { }

	private void OnDestroy() { }

}

