namespace Game.Level;

public class LevelCameraItem : LevelItem
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public PointerEventData eventData; //Field offset: 0x10
		public LevelCameraPhoto polaroidPhoto; //Field offset: 0x18

		public <>c__DisplayClass7_0() { }

		internal void <OnPointerClickInternal>b__0() { }

	}

	private const string SPRITES_PATH_PREFIX = "Level/"; //Field offset: 0x0
	[SerializeField]
	private string _resourcesFolderName; //Field offset: 0x348
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x350
	[SerializeField]
	private LevelSpawn _prefab; //Field offset: 0x358
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x360
	private Sprite[] _sprites; //Field offset: 0x368

	public LevelCameraItem() { }

	protected virtual void Awake() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

}

