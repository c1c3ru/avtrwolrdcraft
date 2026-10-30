namespace PWC.UGC;

public class UGCSelectionIndicator : MonoBehaviour
{
	private static UGCSelectionIndicator _instance; //Field offset: 0x0
	[SerializeField]
	private GameObject _view; //Field offset: 0x20
	private int _tweenId; //Field offset: 0x28

	public UGCSelectionIndicator() { }

	private static UGCSelectionIndicator GetPrefab() { }

	public static void Hide() { }

	private void HideInternal() { }

	public static void Show(Vector2 position, Transform target) { }

	private void ShowInternal(Vector2 position, Transform target) { }

}

