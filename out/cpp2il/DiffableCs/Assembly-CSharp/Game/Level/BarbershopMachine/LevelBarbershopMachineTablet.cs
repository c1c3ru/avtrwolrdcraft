namespace Game.Level.BarbershopMachine;

public class LevelBarbershopMachineTablet : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	public static List<LevelBarbershopMachineTablet> Tablets; //Field offset: 0x0
	[SerializeField]
	private LevelBarbershopMachineSkinsManager _skinsManager; //Field offset: 0x20
	private LevelBarbershopMachine _mashine; //Field offset: 0x28
	[CompilerGenerated]
	private int <HairIndex>k__BackingField; //Field offset: 0x30

	public private int HairIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	private static LevelBarbershopMachineTablet() { }

	public LevelBarbershopMachineTablet() { }

	private void Awake() { }

	[CompilerGenerated]
	public int get_HairIndex() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public void Init(LevelBarbershopMachine machine) { }

	private void OnDestroy() { }

	public void OnLeftClickButton() { }

	public void OnRightClickButton() { }

	[CompilerGenerated]
	private void set_HairIndex(int value) { }

	public void SetHairBySkinName(string skinName) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

