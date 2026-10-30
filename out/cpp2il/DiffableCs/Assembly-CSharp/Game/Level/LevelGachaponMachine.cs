namespace Game.Level;

[AddComponentMenu(null)]
public class LevelGachaponMachine : LevelEntity
{
	[SerializeField]
	private GameObject _handle; //Field offset: 0x40
	[SerializeField]
	private Level1DDropArea _capsuleDropArea; //Field offset: 0x48
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x50
	[SerializeField]
	private LevelSpawn[] _prefabs; //Field offset: 0x58
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x60
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x68

	public LevelGachaponMachine() { }

	[CompilerGenerated]
	private void <OnCoinInSlot>b__6_0(float t) { }

	[CompilerGenerated]
	private void <OnCoinInSlot>b__6_1() { }

	public void OnCoinInSlot() { }

}

