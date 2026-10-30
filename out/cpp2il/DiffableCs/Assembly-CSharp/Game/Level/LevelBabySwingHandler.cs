namespace Game.Level;

public class LevelBabySwingHandler : MonoBehaviour
{
	[SerializeField]
	private LevelBabyDropArea _levelBabyDropArea; //Field offset: 0x20
	[SerializeField]
	private LevelSingleItemCharactersOnlyDropArea _levelSingleItemCharactersOnlyDropArea; //Field offset: 0x28
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x30
	private LevelBaby _baby; //Field offset: 0x38

	public LevelBabySwingHandler() { }

	[CompilerGenerated]
	private void <SetToDangle>b__13_0(TrackEntry op) { }

	[CompilerGenerated]
	private void <SwingForLullaby>b__11_0(TrackEntry op) { }

	private void Awake() { }

	private void OnBabyArrival(LevelItem levelItem) { }

	private void OnBabyLeaving(LevelItem levelItem) { }

	private void OnDestroy() { }

	public void OnParentArrival(LevelItem levelItem) { }

	public void OnParentLeaving(LevelItem levelItem) { }

	public void SetToDangle() { }

	public void SetToIdle() { }

	public void SwingForLaugh() { }

	public void SwingForLullaby() { }

}

