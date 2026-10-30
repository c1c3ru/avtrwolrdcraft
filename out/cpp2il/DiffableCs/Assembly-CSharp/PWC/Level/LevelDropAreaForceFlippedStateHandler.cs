namespace PWC.Level;

public class LevelDropAreaForceFlippedStateHandler : MonoBehaviour
{
	[SerializeField]
	protected bool _isFlipped; //Field offset: 0x20
	[SerializeField]
	protected bool _dontAffectAvatars; //Field offset: 0x21
	[SerializeField]
	protected bool _dontAffectLevelItems; //Field offset: 0x22
	protected LevelDropArea _dropArea; //Field offset: 0x28

	public LevelDropAreaForceFlippedStateHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	protected override void OnItemBeginDrop(LevelItem levelItem) { }

}

