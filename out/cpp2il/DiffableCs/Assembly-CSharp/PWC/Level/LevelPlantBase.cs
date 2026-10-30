namespace PWC.Level;

public abstract class LevelPlantBase : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject, ILevelPlant
{
	[SerializeField]
	protected UnityEvent _onMaxIncrementsAction; //Field offset: 0x20
	protected int _plantIndex; //Field offset: 0x28
	protected LevelPlantPot _plantPot; //Field offset: 0x30
	[CompilerGenerated]
	private Action<Int32> OnIncrementPlantAction; //Field offset: 0x38

	public event Action<Int32> OnIncrementPlantAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	protected LevelPlantBase() { }

	[CompilerGenerated]
	public void add_OnIncrementPlantAction(Action<Int32> value) { }

	private void Awake() { }

	public override bool DidGrowComplete() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	protected abstract int GetStagesCount() { }

	public override bool IsAlive() { }

	private void OnDestroy() { }

	private void OnMaxIncrements() { }

	private void OnPostInit() { }

	public override float PlayIncrementSound() { }

	[CompilerGenerated]
	public void remove_OnIncrementPlantAction(Action<Int32> value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetPlantIndex(int index, bool playSound) { }

	protected abstract void SetPlantIndexInternal(int index, bool playSound) { }

	public override void SetPlantPot(LevelPlantPot plantPot) { }

	public override bool TryIncrementPlant() { }

}

