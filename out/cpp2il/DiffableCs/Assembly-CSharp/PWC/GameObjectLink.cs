namespace PWC;

public class GameObjectLink : MonoBehaviour
{
	public static readonly Dictionary<Int32, List`1<GameObjectLink>> All; //Field offset: 0x0
	[SerializeField]
	private int _linkId; //Field offset: 0x20

	public int LinkId
	{
		 get { } //Length: 8
	}

	private static GameObjectLink() { }

	public GameObjectLink() { }

	public int get_LinkId() { }

	private void OnDisable() { }

	private void OnEnable() { }

	public void PerformLinkAction(int parameter) { }

	public static void PerformLinkAction(int linkId, int parameter) { }

}

