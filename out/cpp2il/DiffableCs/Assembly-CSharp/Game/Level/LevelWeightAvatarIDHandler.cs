namespace Game.Level;

public class LevelWeightAvatarIDHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x20
	[SerializeField]
	protected TextMesh _textMesh; //Field offset: 0x28
	[SerializeField]
	private bool _singleDigitBeforeDot; //Field offset: 0x30
	[CompilerGenerated]
	private Action<Single> OnWeightUpdated; //Field offset: 0x38
	private float _factor; //Field offset: 0x40
	private float _weight; //Field offset: 0x44

	public event Action<Single> OnWeightUpdated
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public LevelWeightAvatarIDHandler() { }

	[CompilerGenerated]
	public void add_OnWeightUpdated(Action<Single> value) { }

	private void Awake() { }

	private void DeleteText(LevelItem levelItem) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private float GetWeight() { }

	private void OnDestroy() { }

	private void OnPostInit() { }

	[CompilerGenerated]
	public void remove_OnWeightUpdated(Action<Single> value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SetScale(LevelItem levelItem) { }

}

