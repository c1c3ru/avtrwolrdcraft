namespace PWC.UGC;

public class UGCTooltip : MonoBehaviour
{
	private static readonly Dictionary<String, UGCTooltip> _currentInstances; //Field offset: 0x0
	private StoreTweenToolipHandle _handle; //Field offset: 0x20

	private static UGCTooltip() { }

	public UGCTooltip() { }

	private void Init(float duration = 3) { }

	public static UGCTooltip Show(string path, Transform parent, float duration = 3, Vector2 positionOffset = null) { }

}

