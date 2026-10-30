namespace PWC.Multiplayer;

public class MPOwnership
{
	private static readonly Dictionary<GameObject, Object> _dataOnSet; //Field offset: 0x0
	private static readonly Dictionary<GameObject, Int32> _map; //Field offset: 0x8
	private static readonly Dictionary<GameObject, Int32> _previousOwnersMap; //Field offset: 0x10
	private static int _lastOwnerSet; //Field offset: 0x18
	private static int _lastOwnerSetFrame; //Field offset: 0x1C

	private static MPOwnership() { }

	public MPOwnership() { }

	public static void Clear(GameObject gameObject) { }

	public static void Clear() { }

	public static bool HasRemoteOwner(GameObject gameObject) { }

	public static bool IsOwnedByMe(GameObject gameObject) { }

	public static bool IsOwnedByOtherPlayer(GameObject gameObject) { }

	public static bool IsOwnedOrWasOwnedByMe(GameObject gameObject) { }

	public static void Set(GameObject gameObject, int playerUID, object dataOnSet = null) { }

	public static void SetOwnerForThisFrameWithoutGameObject(int playerUID) { }

	public static bool TryGet(GameObject gameObject, out int playerUID) { }

	public static bool TryGetDataOnSet(GameObject gameObject, out object dataOnSet) { }

	public static bool TryGetOwnerSetThisFrame(out int playerUID) { }

	public static bool TryGetPrevious(GameObject gameObject, out int playerUID) { }

}

