namespace Game.Level;

public class LevelGiftPack : LevelStoreContextualPacksBase, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public string packName; //Field offset: 0x10

		public <>c__DisplayClass6_0() { }

		internal bool <EnsureItemData>b__0(Item x) { }

	}

	[SerializeField]
	private StorePackType _storePackType; //Field offset: 0x38
	[SerializeField]
	private SpriteRenderer _widget; //Field offset: 0x40

	public LevelGiftPack() { }

	protected virtual void Awake() { }

	private void DestroyPack(StorePackType storePackType) { }

	private void EnsureItemData() { }

	private void Init() { }

	protected virtual void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

