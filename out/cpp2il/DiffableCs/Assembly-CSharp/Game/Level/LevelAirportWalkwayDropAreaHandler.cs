namespace Game.Level;

public class LevelAirportWalkwayDropAreaHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public LevelItem levelItem; //Field offset: 0x10
		public int direction; //Field offset: 0x18
		public LevelAirportWalkwayDropAreaHandler <>4__this; //Field offset: 0x20

		public <>c__DisplayClass6_0() { }

		internal void <SyncMovement>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_1
	{
		public LevelFloorArea floorArea; //Field offset: 0x10
		public <>c__DisplayClass6_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass6_1() { }

		internal void <SyncMovement>b__1() { }

	}

	private const float MAX_LOCAL_X = 17; //Field offset: 0x0
	[SerializeField]
	private LevelDropArea _walkwayDropArea; //Field offset: 0x20
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x28
	private Dictionary<LevelItem, Int32> _tweenIDs; //Field offset: 0x30

	public LevelAirportWalkwayDropAreaHandler() { }

	private void Awake() { }

	private void CancelMovement(LevelItem levelItem) { }

	private void OnDestroy() { }

	private void OnLevelItemClick(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	public void SwitchItemsDirection() { }

	private void SyncMovement(LevelItem levelItem) { }

}

