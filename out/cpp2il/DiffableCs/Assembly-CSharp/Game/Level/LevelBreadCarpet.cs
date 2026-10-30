namespace Game.Level;

public class LevelBreadCarpet : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public LevelItem levelItem; //Field offset: 0x10

		public <>c__DisplayClass9_0() { }

		internal void <GiveGift>b__0() { }

	}

	[SerializeField]
	private SpriteRenderer _renderer; //Field offset: 0x20
	[SerializeField]
	private Sprite[] _sprites; //Field offset: 0x28
	[SerializeField]
	private int _timeBetweenGifts; //Field offset: 0x30
	[SerializeField]
	private PDPrefabReference[] _prefabReferences; //Field offset: 0x38
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x40
	private DateTime _startingTime; //Field offset: 0x48
	private List<Int32> _prefabsIndexes; //Field offset: 0x50
	private int tweenId; //Field offset: 0x58

	public LevelBreadCarpet() { }

	[CompilerGenerated]
	private void <UpdateSpriteOnLanding>b__8_0() { }

	private PDPrefabReference GetItemPrefab() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void GiveGift() { }

	private void ResetPrefabsIndexes() { }

	private void ResetPrefabsIndexListIfNeeded() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void UpdateSpriteOnLanding() { }

}

