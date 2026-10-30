namespace Game.Level.Locker;

public class LevelLockerSpawnOnPostInit : LevelSpawnOnLevelPostInit
{
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x68
	private PDPrefabReference _item; //Field offset: 0x70
	private string _cloth; //Field offset: 0x78

	public LevelLockerSpawnOnPostInit() { }

	protected virtual void Awake() { }

	protected virtual string GetClothingItem() { }

	public TextAsset GetClothingList() { }

	protected virtual PDPrefabReference GetItemPrefab() { }

	public PDPrefabReference[] GetPDPrefabReference() { }

	protected virtual void OnDestroy() { }

	public void SpawnOnInit(PDPrefabReference item, string cloth) { }

	public virtual void SpawnOnInit() { }

	protected virtual bool UseNormalSpawnAndDestroyBehavior() { }

}

