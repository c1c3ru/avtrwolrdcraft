namespace Game.Level;

public class LevelLockedYarnCarpet : MonoBehaviour
{
	[SerializeField]
	private LevelDoor _door; //Field offset: 0x20
	[SerializeField]
	private LevelSlider _carpetString; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _onYarnPulledEvent; //Field offset: 0x30

	public LevelLockedYarnCarpet() { }

	[CompilerGenerated]
	private void <OnSliderEndAnimation>b__6_0() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnEndSyncPosition(LevelSlider carpetString, Vector2 position) { }

	private void OnSliderEndAnimation(SliderDestinationType sliderDestinationType) { }

}

