namespace Game.Level.Arcade.ClawMachine;

public class LevelClawMachineClaw : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass15_0
	{
		public LevelClawMachineClaw <>4__this; //Field offset: 0x10
		public float initialHeight; //Field offset: 0x18
		public Action <>9__1; //Field offset: 0x20

		public <>c__DisplayClass15_0() { }

		internal void <LowerClaw>b__0() { }

		internal void <LowerClaw>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass15_1
	{
		public LevelItem caughtToy; //Field offset: 0x10
		public <>c__DisplayClass15_0 CS$<>8__locals1; //Field offset: 0x18
		public Action <>9__3; //Field offset: 0x20
		public Action <>9__4; //Field offset: 0x28

		public <>c__DisplayClass15_1() { }

		internal void <LowerClaw>b__2() { }

		internal void <LowerClaw>b__3() { }

		internal void <LowerClaw>b__4() { }

	}

	[SerializeField]
	private float _minX; //Field offset: 0x20
	[SerializeField]
	private float _maxX; //Field offset: 0x24
	[SerializeField]
	private float _speed; //Field offset: 0x28
	[SerializeField]
	private LevelClawMachine _levelClawMachine; //Field offset: 0x30
	[SerializeField]
	private LevelDropArea _toySpawnArea; //Field offset: 0x38
	[SerializeField]
	private LevelDropArea _toyDropArea; //Field offset: 0x40
	[SerializeField]
	private float _catchDistance; //Field offset: 0x48
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x50
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x58
	[SerializeField]
	private bool _dropOnMin; //Field offset: 0x60
	private int _movementTweenID; //Field offset: 0x64

	public int MovementTweenID
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public LevelClawMachineClaw() { }

	[CompilerGenerated]
	private void <StopSound>b__17_0() { }

	public int get_MovementTweenID() { }

	public LevelItem GetClosestLevelItemToClaw() { }

	public void LowerClaw() { }

	public void MoveClaw(int direction) { }

	public void set_MovementTweenID(int value) { }

	public void StopMovement() { }

	public void StopSound() { }

}

