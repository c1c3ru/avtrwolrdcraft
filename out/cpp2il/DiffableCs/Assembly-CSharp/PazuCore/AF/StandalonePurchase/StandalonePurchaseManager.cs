namespace PazuCore.AF.StandalonePurchase;

public class StandalonePurchaseManager : AddressablesFeatureBase
{
	[CompilerGenerated]
	private static StandalonePurchaseManager <Instance>k__BackingField; //Field offset: 0x0

	public private static StandalonePurchaseManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public StandalonePurchaseManager() { }

	protected virtual void Awake() { }

	[CompilerGenerated]
	public static StandalonePurchaseManager get_Instance() { }

	protected virtual string GetFallbackResourcesPath() { }

	protected virtual string GetFeatureCloudResponseKey() { }

	protected virtual string GetFeatureKey() { }

	public virtual AddressablesFeatureType GetFeatureType() { }

	protected virtual void OnDestroy() { }

	[CompilerGenerated]
	private static void set_Instance(StandalonePurchaseManager value) { }

	public void TryInstantiateViewWithTigger(string trigger) { }

}

