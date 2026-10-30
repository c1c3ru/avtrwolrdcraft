namespace Game.Level;

public class LevelInitCharacterStateOnPack : MonoBehaviour, IPDPrefabPackSpawn
{
	[SerializeField]
	private LevelCharacter _character; //Field offset: 0x20
	[SerializeField]
	private LevelItem _item; //Field offset: 0x28
	[SerializeField]
	private AvatarHandType _handType; //Field offset: 0x30
	[SerializeField]
	private bool _isSpecificAnimation; //Field offset: 0x34
	[SerializeField]
	private int _animationIndex; //Field offset: 0x38
	private bool _didInit; //Field offset: 0x3C

	public LevelInitCharacterStateOnPack() { }

	private void Awake() { }

	private void InitIfNeeded() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private override void PWC.PersistentData.IPDPrefabPackSpawn.OnSpawnFromPDPrefabPack() { }

}

