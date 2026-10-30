namespace Game.Level;

public class LevelHoveringItemHandler : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelLight _levelLight; //Field offset: 0x20
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x28
	[SerializeField]
	private float _height; //Field offset: 0x30
	[SerializeField]
	private float _timeToAscend; //Field offset: 0x34
	[SerializeField]
	private float _rangeToHover; //Field offset: 0x38
	private bool _isHovering; //Field offset: 0x3C
	private int _tweenId; //Field offset: 0x40

	public bool IsHovering
	{
		 get { } //Length: 8
	}

	public LevelHoveringItemHandler() { }

	[CompilerGenerated]
	private void <Ascend>b__13_0() { }

	private void Ascend() { }

	private void Awake() { }

	private void Descend() { }

	public bool get_IsHovering() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnPermanentPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

