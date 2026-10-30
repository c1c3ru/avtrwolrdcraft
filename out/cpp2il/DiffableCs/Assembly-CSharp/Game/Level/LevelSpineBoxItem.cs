namespace Game.Level;

[AddComponentMenu(null)]
public class LevelSpineBoxItem : LevelItem
{
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x348
	[SerializeField]
	private LevelContainerArea _containerArea; //Field offset: 0x350
	[SerializeField]
	private LevelDropArea _topDropArea; //Field offset: 0x358
	[SerializeField]
	private GameObject _front; //Field offset: 0x360
	private bool _isOpen; //Field offset: 0x368

	public LevelSpineBoxItem() { }

	[CompilerGenerated]
	private void <OnPointerClickInternal>b__5_0(TrackEntry x) { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	private void SyncElements() { }

}

