namespace PWC.Level;

public abstract class LevelPumpableItemHandler : LevelConsumerAreaBase, IHasPersistentData, IRequirePDSceneObject
{
	public static readonly List<LevelPumpableItemHandler> PumpableItems; //Field offset: 0x0
	[CompilerGenerated]
	private bool <IsPumped>k__BackingField; //Field offset: 0x51
	public UnityEvent OnFullyPumped; //Field offset: 0x58

	public bool IsPumped
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	private static LevelPumpableItemHandler() { }

	protected LevelPumpableItemHandler() { }

	[CompilerGenerated]
	public bool get_IsPumped() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	public override void OnPumped() { }

	[CompilerGenerated]
	protected void set_IsPumped(bool value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

