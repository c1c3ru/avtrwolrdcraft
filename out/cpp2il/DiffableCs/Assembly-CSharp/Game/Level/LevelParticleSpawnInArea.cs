namespace Game.Level;

public class LevelParticleSpawnInArea : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <DestroyParticles>d__20 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float timeout; //Field offset: 0x20
		public LevelParticleSpawnInArea <>4__this; //Field offset: 0x28

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <DestroyParticles>d__20(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <OnRainIntensityChangeWithDelay>d__12 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelParticleSpawnInArea <>4__this; //Field offset: 0x20
		public WeatherType weatherType; //Field offset: 0x28
		private EmissionModule <emissionModule>5__2; //Field offset: 0x30

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <OnRainIntensityChangeWithDelay>d__12(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[SerializeField]
	private WeatherType _weatherType; //Field offset: 0x20
	[SerializeField]
	private CShape _shape; //Field offset: 0x28
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x30
	[SerializeField]
	private float _emissionRate; //Field offset: 0x38
	private Vector2 _area; //Field offset: 0x3C
	private float _yHeight; //Field offset: 0x44
	private float _intensityChangeDelay; //Field offset: 0x48
	private bool _inTransition; //Field offset: 0x4C

	public LevelParticleSpawnInArea() { }

	public void AddParticleSytem(Vector2 area, float yHeight, bool isLightEffect) { }

	private void Awake() { }

	private void ConfigureParticleSystem(bool isLightEffect) { }

	[IteratorStateMachine(typeof(<DestroyParticles>d__20))]
	public IEnumerator DestroyParticles(float timeout) { }

	public void DestroyParticlesWithTimeout(float timeout) { }

	private void HeavyRainSettings() { }

	private void OnDestroy() { }

	private void OnRainIntensityChange(WeatherType weatherType) { }

	[IteratorStateMachine(typeof(<OnRainIntensityChangeWithDelay>d__12))]
	private IEnumerator OnRainIntensityChangeWithDelay(WeatherType weatherType) { }

	public void SetParticlesSorting(int sortingOrder) { }

	public void SetWeatherType(WeatherType weatherType) { }

	private void SnowSettings(bool isLightEffect = false) { }

	private void Start() { }

}

