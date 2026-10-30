namespace Game.Level;

public class LevelStashArea : LevelDropArea, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public float value; //Field offset: 0x10

		public <>c__DisplayClass6_0() { }

		internal void <OnLevelPostInit>b__0(LevelItem item) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public List<LevelItem> items; //Field offset: 0x10

		public <>c__DisplayClass7_0() { }

		internal void <OnSliderBeginAnimation>b__0(float value) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_1
	{
		public float value; //Field offset: 0x10

		public <>c__DisplayClass7_1() { }

		internal void <OnSliderBeginAnimation>b__1(LevelItem item) { }

	}

	[SerializeField]
	private LevelSlider _cover; //Field offset: 0xD8
	private int _tweenID; //Field offset: 0xE0
	private SliderDestinationType _lastDestinationType; //Field offset: 0xE4
	private bool _hasPD; //Field offset: 0xE8

	public LevelStashArea() { }

	protected virtual void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnLevelPostInit() { }

	private void OnSliderBeginAnimation(SliderDestinationType destinationType) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

