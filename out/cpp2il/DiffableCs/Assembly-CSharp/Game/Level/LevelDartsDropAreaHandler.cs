namespace Game.Level;

public class LevelDartsDropAreaHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public LevelDartsDropAreaHandler <>4__this; //Field offset: 0x10
		public bool shouldSpawnGift; //Field offset: 0x18

		public <>c__DisplayClass10_0() { }

		internal void <ThrowDart>b__0() { }

	}

	[SerializeField]
	private Transform[] _points; //Field offset: 0x20
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x28
	[SerializeField]
	private LevelSimpleSpawner _spawner; //Field offset: 0x30
	[SerializeField]
	private float _speed; //Field offset: 0x38
	[SerializeField]
	private string _hitSoundName; //Field offset: 0x40
	[SerializeField]
	private UnityEvent _onSpawnAction; //Field offset: 0x48
	private int _tweenID; //Field offset: 0x50
	private bool _isGiftSpawned; //Field offset: 0x54

	public LevelDartsDropAreaHandler() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private void OnItemPickUp(LevelItem levelItem) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void ThrowDart(LevelItem dart, LevelCharacter character, string animationName, Random random) { }

}

