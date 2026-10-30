namespace PWC;

public class BackgroundSky : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass30_0
	{
		public int index; //Field offset: 0x10
		public Color[] topColors; //Field offset: 0x18
		public BackgroundSky <>4__this; //Field offset: 0x20
		public Color[] bottomColors; //Field offset: 0x28
		public float durationPerTween; //Field offset: 0x30

		public <>c__DisplayClass30_0() { }

		internal void <Animate>g__AnimateNext|0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass30_1
	{
		public Color fromTopColor; //Field offset: 0x10
		public Color toTopColor; //Field offset: 0x20
		public Color fromBottomColor; //Field offset: 0x30
		public Color toBottomColor; //Field offset: 0x40
		public <>c__DisplayClass30_0 CS$<>8__locals1; //Field offset: 0x50

		public <>c__DisplayClass30_1() { }

		internal void <Animate>b__1(float value) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass33_0
	{
		public Color fromTopColor; //Field offset: 0x10
		public Color toTopColor; //Field offset: 0x20
		public Color fromBottomColor; //Field offset: 0x30
		public Color toBottomColor; //Field offset: 0x40
		public BackgroundSky <>4__this; //Field offset: 0x50

		public <>c__DisplayClass33_0() { }

		internal void <AnimateSkyParameters>b__0(float value) { }

	}

	[FormerlySerializedAs("_config")]
	[SerializeField]
	private BackgroundSkyConfig _clearConfig; //Field offset: 0x20
	[SerializeField]
	private BackgroundSkyConfig _rainConfig; //Field offset: 0x28
	[SerializeField]
	private BackgroundSkyConfig _snowConfig; //Field offset: 0x30
	[SerializeField]
	private BackgroundSkyConfig _halloweenConfig; //Field offset: 0x38
	[SerializeField]
	private float _clearSmoothness; //Field offset: 0x40
	[SerializeField]
	private float _clearMiddle; //Field offset: 0x44
	[SerializeField]
	private float _rainSmoothness; //Field offset: 0x48
	[SerializeField]
	private float _rainMiddle; //Field offset: 0x4C
	[SerializeField]
	private float _snowSmoothness; //Field offset: 0x50
	[SerializeField]
	private float _snowMiddle; //Field offset: 0x54
	[SerializeField]
	private float _halloweenSmoothness; //Field offset: 0x58
	[SerializeField]
	private float _halloweenMiddle; //Field offset: 0x5C
	private BackgroundSkyConfig _config; //Field offset: 0x60
	private BackgroundSkyConfig _previousConfig; //Field offset: 0x68
	private float _smoothness; //Field offset: 0x70
	private float _middle; //Field offset: 0x74
	private float _previousSmoothness; //Field offset: 0x78
	private float _previousMiddle; //Field offset: 0x7C
	private Material _material; //Field offset: 0x80
	private bool _isAfterSnap; //Field offset: 0x88

	public float RainMiddle
	{
		 get { } //Length: 8
	}

	public float RainSmoothness
	{
		 get { } //Length: 8
	}

	public BackgroundSky() { }

	public void Animate(TimeOfDay timeOfDay, float duration, bool hasWeatherChanged = false) { }

	public void AnimateSkyParameters(float duration, Color toTopColor, Color toBottomColor, float toSmoothness, float toMiddle) { }

	private void Awake() { }

	public float get_RainMiddle() { }

	public float get_RainSmoothness() { }

	public void GetSkyParameters(out Color topColor, out Color bottomColor, out float smoothness, out float middle) { }

	private void OnDestroy() { }

	private void OnPostInitAction() { }

	private void OnValidate() { }

	private void OnWeatherChange(WeatherType weatherType) { }

	public void SetSkyParameters(Color topColor, Color bottomColor, float smoothness, float middle) { }

	public void SnapToAppearance(TimeOfDay timeOfDay) { }

	private void UpdateConfig() { }

}

