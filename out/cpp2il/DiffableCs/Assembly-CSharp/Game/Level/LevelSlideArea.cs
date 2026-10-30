namespace Game.Level;

public class LevelSlideArea : LevelDropArea
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public LevelItem levelItem; //Field offset: 0x10
		public LevelSlideArea <>4__this; //Field offset: 0x18
		public Action <>9__1; //Field offset: 0x20

		public <>c__DisplayClass19_0() { }

		internal void <OnItemEndDrop>b__0() { }

		internal void <OnItemEndDrop>b__1() { }

	}

	internal enum SlideType
	{
		LandSlide = 0,
		Firefighter_Pole = 1,
	}

	[SerializeField]
	private bool _isFlipped; //Field offset: 0xD8
	[SerializeField]
	private Transform _slopeEndPoint; //Field offset: 0xE0
	[SerializeField]
	private Transform _dropPoint; //Field offset: 0xE8
	[SerializeField]
	private string _startSoundName; //Field offset: 0xF0
	[FormerlySerializedAs("_soundName")]
	[SerializeField]
	private string _endSoundName; //Field offset: 0xF8
	[SerializeField]
	private float _slideSpeed; //Field offset: 0x100
	[SerializeField]
	private SlideType _slideType; //Field offset: 0x104
	private bool _isFlippedOnStart; //Field offset: 0x108
	private LevelMakerItem _levelMakerItem; //Field offset: 0x110
	private LevelItem _levelItem; //Field offset: 0x118

	public LevelSlideArea() { }

	protected virtual void Awake() { }

	public virtual bool CanConsumeCharacters() { }

	public virtual Vector2 GetProperPositionToDropOnFromPosition(Vector2 fromPosition, LevelItem levelItem) { }

	protected virtual void OnDestroy() { }

	public virtual void OnItemBeginDrop(LevelItem levelItem) { }

	public virtual void OnItemEndDrop(LevelItem levelItem) { }

	protected virtual void OnReadyPostLoad() { }

	private void OnSyncIsItemFlippedState(LevelItem _, bool isFlipped) { }

	private void OnSyncMakerItemIsFlippedState(LevelMakerItem _, bool isFlipped) { }

	public virtual bool OverrideAvatarEndDropAnimation(ILevelAvatar avatar) { }

	public virtual bool OverrideItemFallTween(LevelItem levelItem, out LTDescr tween) { }

	private void SetFlipped(bool isFlipped) { }

	private bool TryOverrideGetPointerPositionForDragAction(DragDropItemBase item, out Vector2 position) { }

}

