namespace PWC.DeliverySystem;

public class DeliverySystemDrone : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public LevelItem levelItem; //Field offset: 0x10
		public DeliverySystemDrone <>4__this; //Field offset: 0x18
		public Action <>9__1; //Field offset: 0x20

		public <>c__DisplayClass12_0() { }

		internal void <BringPackage>b__0() { }

		internal void <BringPackage>b__1() { }

	}

	[SerializeField]
	protected SkeletonAnimation _skeletonAnimation; //Field offset: 0x20
	[SerializeField]
	protected LevelDropArea _dropArea; //Field offset: 0x28
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x30
	private int _moveTweenID; //Field offset: 0x38
	private int _rotateTweenID; //Field offset: 0x3C
	private bool _isFlyingAway; //Field offset: 0x40

	public LevelDropArea DropArea
	{
		 get { } //Length: 8
	}

	public DeliverySystemDrone() { }

	[CompilerGenerated]
	private void <FlyUp>b__11_0() { }

	[CompilerGenerated]
	private void <FlyUp>b__11_1(float _) { }

	[CompilerGenerated]
	private void <FlyUp>b__11_2() { }

	private void Awake() { }

	public void BringPackage(LevelItem levelItem) { }

	public void FlyUp() { }

	public LevelDropArea get_DropArea() { }

	private void OnDestroy() { }

	private void OnItemPickUp(LevelItem levelItem) { }

}

