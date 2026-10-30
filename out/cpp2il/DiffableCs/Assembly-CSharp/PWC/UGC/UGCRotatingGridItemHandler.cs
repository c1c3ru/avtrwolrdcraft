namespace PWC.UGC;

public class UGCRotatingGridItemHandler : MonoBehaviour, ILevelMakerRotatableByUIItem
{
	[SerializeField]
	private PDPrefabReference _prefabReference; //Field offset: 0x20
	private UGCItemBase _item; //Field offset: 0x28

	public UGCRotatingGridItemHandler() { }

	private void Awake() { }

	private override bool PWC.Level.Maker.ILevelMakerRotatableByUIItem.CanRotateNow() { }

	private override string PWC.Level.Maker.ILevelMakerRotatableByUIItem.GetTargetPrefabGuid() { }

	private override bool PWC.Level.Maker.ILevelMakerRotatableByUIItem.IsRotationSupported() { }

	private override void PWC.Level.Maker.ILevelMakerRotatableByUIItem.RotateByUIButton() { }

	private void SetCustomizationFromPreviousItem(LevelMakerCustomizationObjectHandlerBase nextRotationcustomizationHandler) { }

}

