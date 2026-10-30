namespace Game.Level;

[RequireComponent(typeof(SkeletonAnimation))]
public class LevelEattingWhaleStatue : MonoBehaviour
{
	[SerializeField]
	private LevelFountainPlayer _fountainPlayer; //Field offset: 0x20
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x28

	public LevelEattingWhaleStatue() { }

	[CompilerGenerated]
	private void <Eat>b__3_0(TrackEntry track) { }

	private void Awake() { }

	public void Eat() { }

}

