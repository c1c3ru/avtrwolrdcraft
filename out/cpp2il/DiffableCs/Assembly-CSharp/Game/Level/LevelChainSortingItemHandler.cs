namespace Game.Level;

public class LevelChainSortingItemHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	private class LabelListAndResult
	{
		public List<String> labels; //Field offset: 0x10
		public UnityEvent onSuccess; //Field offset: 0x18

		public LabelListAndResult() { }

	}

	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x20
	[SerializeField]
	private int _numOfLinks; //Field offset: 0x28
	[SerializeField]
	private int _indexPositionInLebelOfItem; //Field offset: 0x2C
	[SerializeField]
	private UnityEvent _onGiveGift; //Field offset: 0x30
	[SerializeField]
	private bool _destroyOnGiftGiven; //Field offset: 0x38
	[ConditionalField("_destroyOnGiftGiven", True, True, (array) null)]
	[SerializeField]
	private bool _destroyAllChain; //Field offset: 0x39
	[SerializeField]
	private bool _isUsingResultsList; //Field offset: 0x3A
	[SerializeField]
	private List<LabelListAndResult> _resultsList; //Field offset: 0x40
	private bool _isGiftTaken; //Field offset: 0x48
	private int _nextLinkId; //Field offset: 0x4C
	private LevelItem _levelItem; //Field offset: 0x50

	public LevelChainSortingItemHandler() { }

	private void Awake() { }

	private void DestroyChain(LevelItem levelItem) { }

	private int GetIndexOfLink(LevelItem linkItem) { }

	private string GetLabel(LevelItem linkItem) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnHierarchyDropOnDropArea(LevelDropArea dropArea, LevelItem levelItem) { }

	private void OnSolve(int eventId = 0) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

