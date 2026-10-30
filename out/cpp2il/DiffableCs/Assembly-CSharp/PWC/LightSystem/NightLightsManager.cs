namespace PWC.LightSystem;

public class NightLightsManager : MonoBehaviour
{
	[SerializeField]
	private List<SpriteRenderer> _lights; //Field offset: 0x20
	private int _lightsTween; //Field offset: 0x28

	public NightLightsManager() { }

	private void ApplyAlphaToLights(float alpha) { }

	private void Awake() { }

	private float GetCurrentAlpha() { }

	private void OnBackgroundPlanetClick() { }

	private void OnDestroy() { }

	private void OnLoadIsDay() { }

	private void SetLightsStateBatched(bool isDay, bool isImmediate) { }

}

