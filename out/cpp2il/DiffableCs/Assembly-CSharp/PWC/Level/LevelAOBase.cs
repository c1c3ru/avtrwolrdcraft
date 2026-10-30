namespace PWC.Level;

public abstract class LevelAOBase : MonoBehaviour
{
	private static readonly List<LevelAOBase> _list; //Field offset: 0x0

	private static LevelAOBase() { }

	protected LevelAOBase() { }

	protected override void Awake() { }

	public static List<T> GetAO(bool includeInactive = false, Predicate<LevelAOBase> filter = null) { }

	public static List<T> GetAOInDistance(Vector2 position, float distance, bool includeInactive = false, Predicate<LevelAOBase> filter = null) { }

	private static bool IsPassingBasicConditions(LevelAOBase item, bool includeInactive, Predicate<LevelAOBase> filter) { }

	protected override void OnDestroy() { }

}

