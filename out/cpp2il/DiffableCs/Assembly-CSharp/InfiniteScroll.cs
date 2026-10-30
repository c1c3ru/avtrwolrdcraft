//Type is in global namespace

public abstract class InfiniteScroll : ScrollRect
{
	[HideInInspector]
	public bool initOnAwake; //Field offset: 0x130
	private RectTransform _t; //Field offset: 0x138
	private RectTransform[] prefabItems; //Field offset: 0x140
	private int itemTypeStart; //Field offset: 0x148
	private int itemTypeEnd; //Field offset: 0x14C
	private bool init; //Field offset: 0x150
	private Vector2 dragOffset; //Field offset: 0x154

	protected RectTransform t
	{
		 get { } //Length: 160
	}

	protected InfiniteScroll() { }

	private void Add(ref int i) { }

	private void Awake() { }

	protected RectTransform get_t() { }

	protected abstract float GetDimension(Vector2 vector) { }

	protected abstract float GetPos(RectTransform item) { }

	protected abstract float GetSize(RectTransform item) { }

	protected abstract Vector2 GetVector(float value) { }

	public void Init() { }

	private RectTransform InstantiateNextItem(int itemType) { }

	private RectTransform NewItemAtEnd() { }

	private RectTransform NewItemAtStart() { }

	public virtual void OnBeginDrag(PointerEventData eventData) { }

	public virtual void OnDrag(PointerEventData eventData) { }

	protected abstract int OneOrMinusOne() { }

	private void Subtract(ref int i) { }

	private void Update() { }

}

