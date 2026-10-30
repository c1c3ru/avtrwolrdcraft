namespace CShapes;

public class CShape : MonoBehaviour
{
	public static readonly List<CShape> List; //Field offset: 0x0
	public static readonly List<CShape> LockEventsToTheseShapes; //Field offset: 0x8
	[SerializeField]
	private bool _dontInitOnAwake; //Field offset: 0x20
	private SortingElement _sortingElement; //Field offset: 0x28
	private SortingGroup _sortingGroup; //Field offset: 0x30
	public CShapeModel cShapeModel; //Field offset: 0x38
	private bool _isTransformDirty; //Field offset: 0x40
	private TransformChangedHandler _transformChangedHandler; //Field offset: 0x48
	[CompilerGenerated]
	private Renderer <MyRenderer>k__BackingField; //Field offset: 0x50
	private bool _didAwake; //Field offset: 0x58
	[CompilerGenerated]
	private Action OnUpdateTransformDataIfNeededAction; //Field offset: 0x60

	public event Action OnUpdateTransformDataIfNeededAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public private Renderer MyRenderer
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	private static CShape() { }

	public CShape() { }

	[CompilerGenerated]
	public void add_OnUpdateTransformDataIfNeededAction(Action value) { }

	private void Awake() { }

	[CompilerGenerated]
	public Renderer get_MyRenderer() { }

	public int GetSortingLayerID() { }

	public long GetSortingOrderForY() { }

	public void Init() { }

	public bool IsPointInsideShape(Vector2 point) { }

	public bool IsTouching(CShape otherShape) { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnEnable() { }

	public void PerformAwakeIfNeeded() { }

	[CompilerGenerated]
	public void remove_OnUpdateTransformDataIfNeededAction(Action value) { }

	[CompilerGenerated]
	private void set_MyRenderer(Renderer value) { }

	private void SetTransformDirty() { }

	public void UpdateTransformDataIfNeeded(bool forceUpdate = false) { }

}

