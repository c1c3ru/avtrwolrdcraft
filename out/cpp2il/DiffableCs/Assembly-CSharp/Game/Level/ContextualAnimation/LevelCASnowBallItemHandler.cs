namespace Game.Level.ContextualAnimation;

public class LevelCASnowBallItemHandler : LevelCAItemHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass21_0
	{
		public LevelCASnowBallItemHandler <>4__this; //Field offset: 0x10
		public int randomCatchAnimationIndex; //Field offset: 0x18

		public <>c__DisplayClass21_0() { }

		internal void <ThrowBallOnCharacter>b__0(float t) { }

		internal void <ThrowBallOnCharacter>b__1() { }

	}

	private const string THROW_FOOD_ANIMATION_NAME = "Throw_Food"; //Field offset: 0x0
	private const string THROW_AND_CATCH_ANIMATION_NAME = "Throw_And_Catch_Loop"; //Field offset: 0x0
	private const string THROW_UP_FACE_ANIMATION_NAME = "Throw_Ball_Up_Face"; //Field offset: 0x0
	private const float FLIGHT_SPEED = 20; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<Int32> OnAnyBallThrown; //Field offset: 0x0
	private bool _isDestroyingBall; //Field offset: 0x88
	private String[] _catchAnimations; //Field offset: 0x90
	private LevelCharacter _currentCharacter; //Field offset: 0x98
	private LevelCharacter _closestCharacter; //Field offset: 0xA0
	private int _throwTweenID; //Field offset: 0xA8
	private bool _cancelHit; //Field offset: 0xAC
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB0

	public static event Action<Int32> OnAnyBallThrown
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public LevelCASnowBallItemHandler() { }

	[CompilerGenerated]
	private void <ThrowBallOnFloor>b__22_0() { }

	[CompilerGenerated]
	public static void add_OnAnyBallThrown(Action<Int32> value) { }

	public virtual bool AllowReturnToIdleAnimationWhenRemovedFromTarget() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void OnHitInterup(DragDropItemBase arg1, PointerEventData arg2) { }

	[CompilerGenerated]
	public static void remove_OnAnyBallThrown(Action<Int32> value) { }

	private void ThrowBall() { }

	private void ThrowBallOnCharacter() { }

	private void ThrowBallOnFloor() { }

	private bool TryGetClosestCharacter() { }

}

