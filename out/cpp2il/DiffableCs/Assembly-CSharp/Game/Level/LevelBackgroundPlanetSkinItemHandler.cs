namespace Game.Level;

public class LevelBackgroundPlanetSkinItemHandler : MonoBehaviour
{
	[SerializeField]
	private string _skinName; //Field offset: 0x20
	private LevelItem _levelItem; //Field offset: 0x28

	public LevelBackgroundPlanetSkinItemHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void TryDropInteraction(ILevelConsumer consumer, ref bool didInteract, ref MPEventIdentifierData mpData) { }

}

