namespace PWC.Street;

public class StreetSection : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<SpriteRenderer> <>9__1_0; //Field offset: 0x8
		public static Action<SpriteRenderer> <>9__2_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <Awake>b__1_0(SpriteRenderer nightLight) { }

		internal void <OnBackgroundPlanetClick>b__2_0(SpriteRenderer nightLight) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public Color color; //Field offset: 0x10
		public SpriteRenderer nightLight; //Field offset: 0x20

		public <>c__DisplayClass2_0() { }

		internal void <OnBackgroundPlanetClick>b__1(float alphaValue) { }

	}

	[SerializeField]
	private List<SpriteRenderer> _nightLights; //Field offset: 0x20

	public StreetSection() { }

	private void Awake() { }

	private void OnBackgroundPlanetClick() { }

	private void OnDestroy() { }

}

