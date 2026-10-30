namespace PWC.UGC;

public class UGCGridFloor : MonoBehaviour, IUGCGridItemOwner, IUGCEntity, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public UGCGridItem firstGridItem; //Field offset: 0x10

		public <>c__DisplayClass19_0() { }

		internal void <EnsureItemsOnGridInProperPositions>b__0() { }

	}

	public static readonly List<UGCGridFloor> List; //Field offset: 0x0
	[CompilerGenerated]
	private static UGCGridFloorType <LastGridFloorTypeUsedToEnterLevel>k__BackingField; //Field offset: 0x8
	[SerializeField]
	private Transform _gridItemsParent; //Field offset: 0x20
	[SerializeField]
	private Transform _flatItemsParent; //Field offset: 0x28
	[SerializeField]
	private CShape _cShape; //Field offset: 0x30
	[SerializeField]
	private UGCGridFloorType _gridFloorType; //Field offset: 0x38
	[SerializeField]
	private GameObject _gridRenderer; //Field offset: 0x40
	private Vector2 _centerPosition; //Field offset: 0x48
	[CompilerGenerated]
	private bool <IsInteractable>k__BackingField; //Field offset: 0x50

	public bool IsInteractable
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public private static UGCGridFloorType LastGridFloorTypeUsedToEnterLevel
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 92
	}

	private static UGCGridFloor() { }

	public UGCGridFloor() { }

	private void Awake() { }

	private void EnsureItemsOnGridInProperPositions() { }

	[CompilerGenerated]
	public bool get_IsInteractable() { }

	[CompilerGenerated]
	public static UGCGridFloorType get_LastGridFloorTypeUsedToEnterLevel() { }

	public Vector2 GetCetnerPosition() { }

	public static UGCGridFloor GetClosestInteractableGridFloorToPosition(Vector2 position) { }

	public Transform GetGridItemsParentTransform() { }

	public override Vector2 GetZoomInPosition() { }

	private void Init() { }

	private void OnDestroy() { }

	private void OnEditModeChange(bool isEditMode) { }

	protected override void OnUGCPostInit() { }

	private override MonoBehaviour PWC.UGC.IUGCEntity.GetMonoBehaviour() { }

	private override void PWC.UGC.IUGCEntity.OnDeselected() { }

	private override void PWC.UGC.IUGCEntity.OnSelected() { }

	private override bool PWC.UGC.IUGCGridItemOwner.CanHoldFlatFloorItems() { }

	private override bool PWC.UGC.IUGCGridItemOwner.CanHoldGridItems() { }

	private override Transform PWC.UGC.IUGCGridItemOwner.GetParentForFlatItems() { }

	private override Transform PWC.UGC.IUGCGridItemOwner.GetParentForGridItems() { }

	private override ValueTuple<Vector2, Vector2> PWC.UGC.IUGCGridItemOwner.GetProjected2DMinMax() { }

	private override int PWC.UGC.IUGCGridItemOwner.GetSortingOrder() { }

	private override CShape PWC.UGC.IUGCGridItemOwner.GetTopCShape() { }

	private override float PWC.UGC.IUGCGridItemOwner.GetZBottom() { }

	private override float PWC.UGC.IUGCGridItemOwner.GetZTop() { }

	[CompilerGenerated]
	public void set_IsInteractable(bool value) { }

	[CompilerGenerated]
	private static void set_LastGridFloorTypeUsedToEnterLevel(UGCGridFloorType value) { }

	public void SetAsLastGridFloorTypeUsedToEnterALevel() { }

	private override void UnityEngine.EventSystems.IPointerClickHandler.OnPointerClick(PointerEventData eventData) { }

}

