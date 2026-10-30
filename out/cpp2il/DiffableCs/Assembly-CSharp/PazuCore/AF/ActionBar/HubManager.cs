namespace PazuCore.AF.ActionBar;

public class HubManager : AddressablesFeatureBase
{
	public const int SOUND_CHANNEL = 2147483647; //Field offset: 0x0
	[CompilerGenerated]
	private static HubManager <Instance>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private string <GameHomeSceneName>k__BackingField; //Field offset: 0x78
	[CompilerGenerated]
	private bool <StandalonePurchaseOpen>k__BackingField; //Field offset: 0x80

	public private string GameHomeSceneName
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private static HubManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public private bool StandalonePurchaseOpen
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public HubManager() { }

	protected virtual bool AllowNonGameScreenOrientation() { }

	protected virtual void Awake() { }

	[CompilerGenerated]
	public string get_GameHomeSceneName() { }

	[CompilerGenerated]
	public static HubManager get_Instance() { }

	[CompilerGenerated]
	public bool get_StandalonePurchaseOpen() { }

	protected virtual string GetFallbackResourcesPath() { }

	protected virtual string GetFeatureCloudResponseKey() { }

	protected virtual string GetFeatureKey() { }

	public virtual AddressablesFeatureType GetFeatureType() { }

	protected virtual void OnDestroy() { }

	private void OnFeatureViewClose(AddressablesFeatureType type) { }

	private void OnFeatureViewOpen(AddressablesFeatureType type) { }

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) { }

	[CompilerGenerated]
	private void set_GameHomeSceneName(string value) { }

	[CompilerGenerated]
	private static void set_Instance(HubManager value) { }

	[CompilerGenerated]
	private void set_StandalonePurchaseOpen(bool value) { }

}

