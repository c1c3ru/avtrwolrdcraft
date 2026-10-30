namespace Game.Level.Supermarket.FoodDelivery;

public class FoodDeliveryDrone : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public FoodDeliveryDrone <>4__this; //Field offset: 0x10
		public Action onFinish; //Field offset: 0x18

		public <>c__DisplayClass9_0() { }

		internal void <BringReward>b__0() { }

	}

	[SerializeField]
	protected SkeletonAnimation _skeletonAnimation; //Field offset: 0x20
	[SerializeField]
	protected LevelDropArea _dropArea; //Field offset: 0x28
	[SerializeField]
	protected LevelLight _topDoor; //Field offset: 0x30
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x38
	private float _originalYPosition; //Field offset: 0x40

	public LevelDropArea MyDropArea
	{
		 get { } //Length: 8
	}

	public FoodDeliveryDrone() { }

	[CompilerGenerated]
	private void <TakeContent>b__8_0() { }

	[CompilerGenerated]
	private void <TakeContent>b__8_1() { }

	private void Awake() { }

	public void BringReward(string rewardPrefabGuid, Action onFinish) { }

	public LevelDropArea get_MyDropArea() { }

	public void TakeContent(Action onFinish) { }

}

