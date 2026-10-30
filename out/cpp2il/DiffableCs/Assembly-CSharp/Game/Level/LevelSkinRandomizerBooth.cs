namespace Game.Level;

public class LevelSkinRandomizerBooth : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public LevelSkinRandomizerBooth <>4__this; //Field offset: 0x10
		public LevelCharacter character; //Field offset: 0x18

		public <>c__DisplayClass11_0() { }

		internal void <OnItemsHolderItemEndDrop>b__0() { }

	}

	[SerializeField]
	private LevelConsumerAreaBase _consumerArea; //Field offset: 0x20
	[SerializeField]
	private GameObject _clickBlocker; //Field offset: 0x28
	[SerializeField]
	private SpriteRenderer _smokeShapeRenderer; //Field offset: 0x30
	[SerializeField]
	private LevelDoor _door; //Field offset: 0x38
	[SerializeField]
	private string _openSoundName; //Field offset: 0x40
	[SerializeField]
	private string _closeSoundName; //Field offset: 0x48
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x50
	[SerializeField]
	private LevelSkinsRandomizer _skinsRandomizer; //Field offset: 0x58
	[SerializeField]
	private LevelMaskedSitArea _levelMaskedSitArea; //Field offset: 0x60

	public LevelSkinRandomizerBooth() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnItemsHolderItemEndDrop(LevelItem levelItem) { }

	private float PlaySound(bool value) { }

}

