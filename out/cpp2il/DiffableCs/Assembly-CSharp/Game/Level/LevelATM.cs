namespace Game.Level;

[AddComponentMenu(null)]
public class LevelATM : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public LevelATM <>4__this; //Field offset: 0x10
		public LevelSpawn levelSpawnPrefab; //Field offset: 0x18

		public <>c__DisplayClass4_0() { }

		internal void <OnPointerClick>b__0() { }

	}

	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x20
	[SerializeField]
	private PDPrefabReference _prefab; //Field offset: 0x28
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x30
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x38

	public LevelATM() { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

