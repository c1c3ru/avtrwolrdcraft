namespace PWC.UITools;

public class RectTransformOffsetToScreen : MonoBehaviour
{
	internal class Config
	{
		public float left; //Field offset: 0x10
		public float right; //Field offset: 0x14
		public float top; //Field offset: 0x18
		public float bottom; //Field offset: 0x1C

		public Config() { }

	}

	[SerializeField]
	private bool _setLeft; //Field offset: 0x20
	[SerializeField]
	private bool _setRight; //Field offset: 0x21
	[SerializeField]
	private bool _setTop; //Field offset: 0x22
	[SerializeField]
	private bool _setBottom; //Field offset: 0x23
	[SerializeField]
	private Config _tablet; //Field offset: 0x28
	[SerializeField]
	private Config _wide; //Field offset: 0x30
	[SerializeField]
	private Config _veryWide; //Field offset: 0x38

	public RectTransformOffsetToScreen() { }

	private void ApplyConfig(Config config) { }

	private void ApplyValuesForCurrentScreen() { }

	private void Start() { }

}

