namespace Game.Level;

public class LevelEndKillConveyorDropAreaHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public LevelEndKillConveyorDropAreaHandler <>4__this; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18

		public <>c__DisplayClass13_0() { }

		internal void <MoveItem>b__0() { }

	}

	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x20
	[SerializeField]
	private float _endXPosition; //Field offset: 0x28
	[SerializeField]
	private LevelKillArea _endKillArea; //Field offset: 0x30
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x38
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x40
	[SerializeField]
	private float _speed; //Field offset: 0x48
	[SerializeField]
	protected string _ConveyorMovmentSoundName; //Field offset: 0x50
	private List<LevelItem> _itemsOnConveryor; //Field offset: 0x58

	public LevelEndKillConveyorDropAreaHandler() { }

	private void MoveItem(LevelItem levelItem) { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private void OnItemPickUp(LevelItem levelItem) { }

	private void OnLevelPostInit() { }

	private void Start() { }

}

