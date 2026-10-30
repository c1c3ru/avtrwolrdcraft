namespace PWC.UGC;

public class UGCStorePackRequiredBlocker : StoreContextualPacksBase, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public string packName; //Field offset: 0x10

		public <>c__DisplayClass8_0() { }

		internal bool <EnsureItemData>b__0(Item x) { }

	}

	[SerializeField]
	[SpineAnimation(null, null, True, False, False, dataField = "_skeletonAnimation")]
	private string _animationName; //Field offset: 0x38
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x40
	[SerializeField]
	private CShape _clickBlocker; //Field offset: 0x48
	private StorePackType _storePackType; //Field offset: 0x50
	private UGCStorePackGridFloorHandler _gridFloorHandler; //Field offset: 0x58

	public UGCStorePackRequiredBlocker() { }

	[CompilerGenerated]
	private void <OpenGift>b__10_0(TrackEntry x) { }

	private void EnsureItemData() { }

	private void Init(UGCStorePackGridFloorHandler gridFloorHandler, StorePackType storePackType) { }

	public void OpenGift() { }

	public static UGCStorePackRequiredBlocker Show(UGCStorePackGridFloorHandler gridFloorHandler, StorePackType storePackType) { }

	protected virtual void TryOverrideOnClaimItemSuccess(StoreClaimItemCloudResponse response, ref bool didOverride) { }

	private static bool TrySpawn(Transform parent, Vector2 position, out UGCStorePackRequiredBlocker instance) { }

	private override void UnityEngine.EventSystems.IPointerClickHandler.OnPointerClick(PointerEventData eventData) { }

}

