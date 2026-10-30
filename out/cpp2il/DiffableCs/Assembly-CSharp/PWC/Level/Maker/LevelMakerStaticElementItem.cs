namespace PWC.Level.Maker;

public class LevelMakerStaticElementItem : MonoBehaviour
{
	private ILevelMakerDisabledWhileInEditMode[] _componentsDisabledWhileInEditMode; //Field offset: 0x20
	protected bool _isInMakerMode; //Field offset: 0x28

	public LevelMakerStaticElementItem() { }

	private void Awake() { }

	private void OnDestroy() { }

	protected override void OnEnterMakerMode() { }

	protected override void OnExitMakerMode() { }

	private void OnLevelPostInit() { }

	protected override void OnReadyPostLoad() { }

	public void SetMakerMode(bool isMakerMode) { }

}

