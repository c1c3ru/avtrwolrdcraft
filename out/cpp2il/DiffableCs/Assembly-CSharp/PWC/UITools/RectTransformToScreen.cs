namespace PWC.UITools;

public class RectTransformToScreen : MonoBehaviour
{
	internal class Config
	{
		public Vector2 deltaSize; //Field offset: 0x10
		public Vector2 anchoredPosition; //Field offset: 0x18

		public Config() { }

	}

	[SerializeField]
	private Config _tablet; //Field offset: 0x20
	[SerializeField]
	private Config _wide; //Field offset: 0x28
	[SerializeField]
	private Config _veryWide; //Field offset: 0x30

	public RectTransformToScreen() { }

	private void ApplyConfig(Config config) { }

	private void ApplyValuesForCurrentScreen() { }

	private void Start() { }

}

