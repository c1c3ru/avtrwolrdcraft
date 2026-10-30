//Type is in global namespace

public class LevelFloatingHooksDaycareHandler : MonoBehaviour
{
	[SerializeField]
	private LevelSlider _levelSlider; //Field offset: 0x20
	[SerializeField]
	private float _range; //Field offset: 0x28
	private int _tweenID; //Field offset: 0x2C

	public LevelFloatingHooksDaycareHandler() { }

	[CompilerGenerated]
	private void <StartFloating>b__6_0() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnPostLevelInit() { }

	private void StartFloating(SliderDestinationType sliderType) { }

	private void StopFloating(SliderDestinationType _) { }

}

