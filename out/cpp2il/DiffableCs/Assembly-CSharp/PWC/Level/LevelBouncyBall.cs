namespace PWC.Level;

public class LevelBouncyBall : LevelItem
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__2_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <OverrideItemFallTween>b__2_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public bool didComplete; //Field offset: 0x10
		public LevelBouncyBall <>4__this; //Field offset: 0x18
		public float velocity; //Field offset: 0x20
		public LTDescr localTween; //Field offset: 0x28

		public <>c__DisplayClass2_0() { }

		internal void <OverrideItemFallTween>b__1(float value) { }

	}

	[SerializeField]
	private string _soundName; //Field offset: 0x348
	[SerializeField]
	private float _bounceFactor; //Field offset: 0x350

	public LevelBouncyBall() { }

	protected virtual bool OverrideItemFallTween(LevelDropArea dropArea, out LTDescr tween) { }

}

