namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCCanvasScalerToScreen : AFCScreenHandlerBase
{
	[SerializeField]
	private Vector2 _tablet; //Field offset: 0x24
	[FormerlySerializedAs("_tall")]
	[SerializeField]
	private Vector2 _long; //Field offset: 0x2C
	[FormerlySerializedAs("_veryTall")]
	[SerializeField]
	private Vector2 _veryLong; //Field offset: 0x34
	[Header("Match Width Or Height")]
	[Range(0, 1)]
	[SerializeField]
	private float _tabletMatch; //Field offset: 0x3C
	[FormerlySerializedAs("_tallMatch")]
	[Range(0, 1)]
	[SerializeField]
	private float _longMatch; //Field offset: 0x40
	[FormerlySerializedAs("_veryTallMatch")]
	[Range(0, 1)]
	[SerializeField]
	private float _veryLongMatch; //Field offset: 0x44
	private CanvasScaler _canvasScaler; //Field offset: 0x48

	public AFCCanvasScalerToScreen() { }

	public virtual void Apply() { }

}

