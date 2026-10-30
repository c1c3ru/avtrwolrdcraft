namespace Game.Level;

public class LevelTennisRacketItemHandler : MonoBehaviour
{
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x20

	public LevelTennisRacketItemHandler() { }

	private void Awake() { }

	public void OnBeforeDetachFromParent(LevelItem levelItem, Transform parent) { }

	private void OnDestroy() { }

}

