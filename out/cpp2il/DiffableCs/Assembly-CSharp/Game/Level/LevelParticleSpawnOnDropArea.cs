namespace Game.Level;

public class LevelParticleSpawnOnDropArea : MonoBehaviour, ILevelSpawnDuringGameplay
{
	[CompilerGenerated]
	private sealed class <OnRainIntensityChangeWithDelay>d__20 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelParticleSpawnOnDropArea <>4__this; //Field offset: 0x20

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
		public <OnRainIntensityChangeWithDelay>d__20(int <>1__state) { }

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
	private float _worldIntensityChangeDelay; //Field offset: 0x3C
	private float _levelIntensityChangeDelay; //Field offset: 0x40
	private float _intensityChangeDelay; //Field offset: 0x44
	private bool _isInit; //Field offset: 0x48

	public ParticleSystem ParticleSystem
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public WeatherType WeatherType
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public LevelParticleSpawnOnDropArea() { }

	public void AddParticleSytem(GameObject particleSystem, LevelVFXArea vfxArea = null, Mesh preCalculatedMesh = null) { }

	private void Awake() { }

	private float CalculateAreaBasedOnMesh(Mesh mesh) { }

	private float CalculateEmissionRateBasedOnMesh(Mesh mesh) { }

	private float CalculateEmissionRateBasedOnPolygons(Vector2[][] polygons) { }

	private void ConfigureParticleSystem(LevelVFXArea vfxArea = null, Mesh preCalculatedMesh = null) { }

	public static Mesh CreatePolygonMesh(Vector2[][] polygons) { }

	private static List<Vector2> EnsureCounterClockwise(Vector2[] polygon) { }

	public ParticleSystem get_ParticleSystem() { }

	public WeatherType get_WeatherType() { }

	private static bool IsConvex(Vector2 prev, Vector2 current, Vector2 next) { }

	private static bool IsEar(Vector2 prev, Vector2 current, Vector2 next, List<Vector2> polygon) { }

	private static bool IsPointInTriangle(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 point) { }

	private void OnDestroy() { }

	private void OnRainIntensityChange(WeatherType weatherType) { }

	[IteratorStateMachine(typeof(<OnRainIntensityChangeWithDelay>d__20))]
	private IEnumerator OnRainIntensityChangeWithDelay() { }

	public override void OnSpawnDuringGameplay() { }

	public void set_ParticleSystem(ParticleSystem value) { }

	public void set_WeatherType(WeatherType value) { }

	public void SetEmissionRateMultiplier(float newMultiplier) { }

	private void Start() { }

	private static List<Int32> TriangulatePolygon(List<Vector2> polygon) { }

	public static bool TryGetIntersection(Vector2 A1, Vector2 A2, Vector2 B1, Vector2 B2, out Vector2 intersection) { }

}

