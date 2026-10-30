namespace Store.Level;

public class LevelStoreContextualPacksBase : StoreContextualPacksBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<KeyValuePair`2<StorePackType, LevelStorePackSpawnLocation>, StorePackType> <>9__1_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal StorePackType <TryOverrideOnClaimItemSuccess>b__1_0(KeyValuePair<StorePackType, LevelStorePackSpawnLocation> x) { }

	}


	public LevelStoreContextualPacksBase() { }

	[CompilerGenerated]
	internal static void <HandleSpawnInstance>g__TryDropAsLevelItem|2_0(Transform instance) { }

	private void HandleSpawnInstance(Transform instance) { }

	protected override bool ShouldSpawnClaimedPrefabInCurrentScene(PDPrefab prefab) { }

	protected virtual void TryOverrideOnClaimItemSuccess(StoreClaimItemCloudResponse response, ref bool didOverride) { }

}

