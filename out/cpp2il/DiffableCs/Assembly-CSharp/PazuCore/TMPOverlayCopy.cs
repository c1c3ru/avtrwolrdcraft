namespace PazuCore;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshProUGUI))]
public class TMPOverlayCopy : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__10_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <UpdateOverlay>b__10_0() { }

	}

	private static bool _canCallForceUpdateCanvases; //Field offset: 0x0
	[Header("Solid copy of the text (on top of the original)")]
	[SerializeField]
	private Color _overlayColor; //Field offset: 0x20
	[Range(-10, 10)]
	[SerializeField]
	private float _offsetX; //Field offset: 0x30
	[Range(-10, 10)]
	[SerializeField]
	private float _offsetY; //Field offset: 0x34
	[SerializeField]
	private bool _matchAlpha; //Field offset: 0x38
	[SerializeField]
	private Material _overlayFontSharedMaterial; //Field offset: 0x40
	private TextMeshProUGUI _mainText; //Field offset: 0x48
	private TextMeshProUGUI _overlayText; //Field offset: 0x50

	private static TMPOverlayCopy() { }

	public TMPOverlayCopy() { }

	private void CreateOverlayCopy() { }

	private void Start() { }

	private void UpdateOverlay() { }

}

