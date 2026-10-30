namespace PWC.DeliverySystem;

public class DeliverySystemManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public DeliverySystemManager <>4__this; //Field offset: 0x10
		public DeliverySystemPackage package; //Field offset: 0x18

		public <>c__DisplayClass13_0() { }

		internal void <OnPreLevelPostInit>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public DeliverySystemManager <>4__this; //Field offset: 0x10
		public DeliverySystemPackage package; //Field offset: 0x18

		public <>c__DisplayClass16_0() { }

		internal void <AddDelivery>b__0() { }

	}

	[CompilerGenerated]
	private static DeliverySystemManager <Instance>k__BackingField; //Field offset: 0x0
	[SerializeField]
	private PDPrefabReference _dronePrefabReference; //Field offset: 0x20
	private DeliverySystemDrone _currentDrone; //Field offset: 0x28
	[CompilerGenerated]
	private DeliverySystemState <CurrentState>k__BackingField; //Field offset: 0x30

	public private DeliverySystemState CurrentState
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private static DeliverySystemManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public DeliverySystemManager() { }

	public void AddDelivery(GameObject owner, DeliverySystemPackage package) { }

	private void Awake() { }

	private void BringDeliveryWithDrone(DeliverySystemPackage package) { }

	private LevelItem CreateBoxWithItems(DeliverySystemPackage package) { }

	[CompilerGenerated]
	public DeliverySystemState get_CurrentState() { }

	[CompilerGenerated]
	public static DeliverySystemManager get_Instance() { }

	private void OnDestroy() { }

	private void OnPreLevelPostInit() { }

	private void OnPreSaveProgress(Scene scene) { }

	[CompilerGenerated]
	private void set_CurrentState(DeliverySystemState value) { }

	[CompilerGenerated]
	private static void set_Instance(DeliverySystemManager value) { }

}

