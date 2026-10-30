namespace PWC.Level;

public class LevelPositionPerSpineTypeSitAreaHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public SpineType spineType; //Field offset: 0x10
		public SizeTypeSitAreaPositionConfig sizeTypeConfig; //Field offset: 0x18
		public AvatarSizeType sizeType; //Field offset: 0x20
		public Predicate<SizeTypeSitAreaPositionConfig> <>9__1; //Field offset: 0x28

		public <>c__DisplayClass4_0() { }

		internal bool <TryGetPosition>b__0(SpineTypeSitAreaPositionConfig x) { }

		internal bool <TryGetPosition>b__1(SizeTypeSitAreaPositionConfig y) { }

	}

	[SerializeField]
	private List<SpineTypeSitAreaPositionConfig> _configs; //Field offset: 0x20
	[SerializeField]
	private bool _useOnlyWithSitAreaCA; //Field offset: 0x28

	public bool UseOnlyWithSitAreaCA
	{
		 get { } //Length: 8
	}

	public LevelPositionPerSpineTypeSitAreaHandler() { }

	public bool get_UseOnlyWithSitAreaCA() { }

	public bool TryGetPosition(SpineType spineType, AvatarSizeType sizeType, out Vector2 position) { }

}

