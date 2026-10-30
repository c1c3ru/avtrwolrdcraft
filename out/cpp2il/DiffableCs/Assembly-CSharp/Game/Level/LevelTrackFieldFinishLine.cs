namespace Game.Level;

public class LevelTrackFieldFinishLine : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<LevelItem> <>9__3_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <Awake>b__3_0(LevelItem x) { }

	}

	[SerializeField]
	protected LevelDragActionArea _dragActionArea; //Field offset: 0x20
	[SerializeField]
	private bool _isFinishLineTorn; //Field offset: 0x28
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x30

	public LevelTrackFieldFinishLine() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnItemEnter(LevelItem levelItem) { }

	public void PlayCenterTornAnimation() { }

	public void PlayLeftTornAnimation() { }

	public void PlayRightTornAnimation() { }

	protected void PlaySound(string soundName) { }

}

