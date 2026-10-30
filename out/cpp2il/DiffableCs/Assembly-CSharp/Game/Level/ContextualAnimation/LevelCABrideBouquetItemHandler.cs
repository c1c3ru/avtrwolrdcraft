namespace Game.Level.ContextualAnimation;

public class LevelCABrideBouquetItemHandler : LevelCAItemHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public Vector2 src; //Field offset: 0x10
		public Vector2 dst; //Field offset: 0x18
		public float arcFactor; //Field offset: 0x20
		public LevelCABrideBouquetItemHandler <>4__this; //Field offset: 0x28
		public bool didOtherCatchAnimation; //Field offset: 0x30

		public <>c__DisplayClass10_0() { }

		internal void <ThrowBouqet>b__0(float t) { }

		internal void <ThrowBouqet>b__1() { }

	}

	[SerializeField]
	private Sprite _thumb; //Field offset: 0x88
	[SerializeField]
	private float _flightSpeed; //Field offset: 0x90
	private LevelCharacter _currentCharacter; //Field offset: 0x98
	private LevelCharacter _closestCharacter; //Field offset: 0xA0
	private int _throwTweenID; //Field offset: 0xA8
	private bool _isThrowing; //Field offset: 0xAC
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB0

	public LevelCABrideBouquetItemHandler() { }

	[CompilerGenerated]
	private void <OnAnimationBegin>b__9_0() { }

	private void CatchBouqet() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	private void ThrowBouqet() { }

	public virtual bool TryOverrideMainThumb(out Sprite spite) { }

}

