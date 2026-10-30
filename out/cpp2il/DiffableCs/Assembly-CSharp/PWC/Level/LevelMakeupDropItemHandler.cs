namespace PWC.Level;

public class LevelMakeupDropItemHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject, IInteractableItem, IMultiplayer_NetworkIdentityBase
{
	[SerializeField]
	private CharacterCategoryType _categoryType; //Field offset: 0x20
	[SerializeField]
	private string _skinName; //Field offset: 0x28
	[SerializeField]
	private bool _dontDestroyOnDrop; //Field offset: 0x30
	[SerializeField]
	private bool _isGradient; //Field offset: 0x31
	[SerializeField]
	private Color _color; //Field offset: 0x34
	[ConditionalField("_isGradient", True, True, (array) null)]
	[SerializeField]
	private Color _secondColor; //Field offset: 0x44
	[SerializeField]
	private UnityEvent _onSkinChangedAction; //Field offset: 0x58
	private LevelItem _levelItem; //Field offset: 0x60
	private string _fullSkinName; //Field offset: 0x68
	[CompilerGenerated]
	private int <Multiplayer_ComponentIndex>k__BackingField; //Field offset: 0x70

	public override int Multiplayer_ComponentIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public LevelMakeupDropItemHandler() { }

	private void Awake() { }

	public void DropOnCharacter(LevelCharacter character) { }

	[CompilerGenerated]
	public override int get_Multiplayer_ComponentIndex() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private string Multiplayer_GetKey() { }

	private void OnDestroy() { }

	private override void PWC.Multiplayer.MPDataHelper_ItemDropCharacterInteraction.IInteractableItem.Multiplayer_DropInteractWithCharacter(LevelCharacter character, MPEventIdentifierData idData) { }

	[CompilerGenerated]
	public override void set_Multiplayer_ComponentIndex(int value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetSkinName(string skinName) { }

	private void TryDropInteractionWithCharacter(LevelCharacter character, ref bool didInteract, ref MPEventIdentifierData mpData) { }

}

