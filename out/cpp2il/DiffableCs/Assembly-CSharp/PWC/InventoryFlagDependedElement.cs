namespace PWC;

public abstract class InventoryFlagDependedElement : MonoBehaviour
{
	public static readonly List<InventoryFlagDependedElement> List; //Field offset: 0x0

	private static InventoryFlagDependedElement() { }

	protected InventoryFlagDependedElement() { }

	protected override void Awake() { }

	public abstract bool ContainFlagType(InventoryFlagType type) { }

	public static bool IsFlagDependedInCurrentScene(InventoryFlagType flagType) { }

	protected override void OnDestroy() { }

}

