namespace Game.Level;

public class LevelGraffitiPaintableItemHandler : MonoBehaviour
{
	[SerializeField]
	private LevelPaintableArea _paintableArea; //Field offset: 0x20
	[SerializeField]
	private Sprite _nonPaintableMask; //Field offset: 0x28
	private LMask _lMask; //Field offset: 0x30
	private PaintableTexture _paintableTexture; //Field offset: 0x38

	public LevelGraffitiPaintableItemHandler() { }

	private void Awake() { }

	public LMask GetMask() { }

	public LMask GetNegativeMask() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public void SetIsPaintable(bool isOn) { }

}

