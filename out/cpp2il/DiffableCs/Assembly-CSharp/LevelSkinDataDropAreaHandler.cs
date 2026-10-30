//Type is in global namespace

public class LevelSkinDataDropAreaHandler : MonoBehaviour
{
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x20
	[SerializeField]
	private CharacterCategoryType _categoryType; //Field offset: 0x28
	[SerializeField]
	private string _skinName; //Field offset: 0x30
	[SerializeField]
	private bool _shouldKeepExistingColor; //Field offset: 0x38
	[ConditionalField("_shouldKeepExistingColor", False, True, (array) null)]
	[SerializeField]
	private Color _color; //Field offset: 0x3C
	[ConditionalField("_shouldKeepExistingColor", False, True, (array) null)]
	[SerializeField]
	private bool _isGradient; //Field offset: 0x4C
	[ConditionalField("_isGradient", True, True, (array) null)]
	[SerializeField]
	private Color _secondColor; //Field offset: 0x50
	[SerializeField]
	private CharacterCategoryType[] _removedCategoryTypes; //Field offset: 0x60
	protected string _fullSkinName; //Field offset: 0x68

	public LevelSkinDataDropAreaHandler() { }

	public void AddSkin() { }

	private void Awake() { }

	public void RemoveSkin() { }

}

