namespace Game.Level;

public abstract class LevelDigArea : LevelConsumerAreaBase, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private bool <IsInteractable>k__BackingField; //Field offset: 0x51

	public bool IsInteractable
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	protected LevelDigArea() { }

	[CompilerGenerated]
	public bool get_IsInteractable() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	protected override void OnSetPersistentData() { }

	public abstract void OnShovelDig() { }

	[CompilerGenerated]
	protected void set_IsInteractable(bool value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

