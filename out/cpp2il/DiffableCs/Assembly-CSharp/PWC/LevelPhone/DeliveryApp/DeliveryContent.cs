namespace PWC.LevelPhone.DeliveryApp;

public class DeliveryContent : ApplicationContentBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__18_2; //Field offset: 0x8
		public static Action <>9__18_1; //Field offset: 0x10
		public static Action <>9__19_0; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal void <AddSelectionToDeliverySystem>b__19_0() { }

		internal void <SyncStepView>b__18_1() { }

		internal void <SyncStepView>b__18_2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass18_0
	{
		public bool isManagerToSetActiveTrueNull; //Field offset: 0x10
		public DeliveryPageManagerBase managerToSetActivetrue; //Field offset: 0x18
		public DeliveryPageManagerBase managerToSetActiveFalse; //Field offset: 0x20

		public <>c__DisplayClass18_0() { }

		internal void <SyncStepView>b__0() { }

	}

	[CompilerGenerated]
	private static DeliveryContent <Instance>k__BackingField; //Field offset: 0x0
	[SerializeField]
	private SerializableDictionaryBase<DeliveryAppStepType, DeliveryPageManagerBase> _pageManagers; //Field offset: 0x38
	private DeliveryAppStepType _stepType; //Field offset: 0x40
	private DeliveryProductsManager _productsManager; //Field offset: 0x48
	private bool _overrideShouldBackToApps; //Field offset: 0x50
	private DeliveryBusinessData _currentBusinessData; //Field offset: 0x58

	public private static DeliveryContent Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public DeliveryContent() { }

	private void AddSelectionToDeliverySystem(List<ProductState> productsStates) { }

	protected virtual void Awake() { }

	[CompilerGenerated]
	public static DeliveryContent get_Instance() { }

	protected virtual bool GetShouldBackToApps() { }

	public bool IsPoductsListEmpty() { }

	protected virtual void OnApplicationEndAnimation(bool value) { }

	protected virtual void OnBackButtonClick() { }

	private void OnBusinessThumbClick(DeliveryBusinessData businessData) { }

	protected virtual void OnDestroy() { }

	private void OnOrderNowButtonClick() { }

	private void OnPhoneBeginAnimate(bool value) { }

	private void OnProgressBarFull() { }

	[CompilerGenerated]
	private static void set_Instance(DeliveryContent value) { }

	private void SyncStepView(Action onEndAnimationAction = null) { }

}

