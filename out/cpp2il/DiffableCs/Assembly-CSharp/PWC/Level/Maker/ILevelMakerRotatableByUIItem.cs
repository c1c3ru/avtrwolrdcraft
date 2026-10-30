namespace PWC.Level.Maker;

public interface ILevelMakerRotatableByUIItem
{
	public static Action<ILevelMakerRotatableByUIItem> OnRotatingItemByUIButtonAction; //Field offset: 0x0

	public bool CanRotateNow() { }

	public string GetTargetPrefabGuid() { }

	public bool IsRotationSupported() { }

	public void RotateByUIButton() { }

}

