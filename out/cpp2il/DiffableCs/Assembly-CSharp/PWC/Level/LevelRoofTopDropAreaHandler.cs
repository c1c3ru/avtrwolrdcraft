namespace PWC.Level;

[RequireComponent(typeof(LevelDropArea))]
public class LevelRoofTopDropAreaHandler : MonoBehaviour
{
	private const string TROLLY_LABEL = "Trolly"; //Field offset: 0x0
	private LevelDropArea _dropArea; //Field offset: 0x20

	public LevelRoofTopDropAreaHandler() { }

	private void Awake() { }

	private void CanConsumeItem(LevelItem levelItem, ref bool canConsume) { }

	private void OnDestroy() { }

	private void OnItemBeginDrop(LevelItem levelItem) { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private void OnItemPickUp(LevelItem levelItem) { }

	private void OnLevelPostInit() { }

	private bool OverrideItemFallTween(LevelItem levelItem, out LTDescr tween) { }

	private bool OverrideItemLendDestination(LevelItem levelItem, Vector2 destination, out Vector2 overrideDestination) { }

	private bool OverridTweenToProperPositionOnDropAreaDestination(Vector2 fromPosition, LevelItem levelItem, out Nullable<Vector2>& overrideLocalPositionDestination) { }

}

