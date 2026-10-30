namespace Game.Level;

public class LevelSnowEffectItemHandler : MonoBehaviour
{
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x20
	[SerializeField]
	private string _soundName; //Field offset: 0x28
	private LevelItem _levelItem; //Field offset: 0x30
	private bool _shouldPlaySoundEffect; //Field offset: 0x38
	private bool _isShowingSnow; //Field offset: 0x39
	private GameObject _meshCreator; //Field offset: 0x40
	private GameObject _edgeRenderer; //Field offset: 0x48
	private bool _isStaticSnowBlocker; //Field offset: 0x50
	private LevelHoveringItemHandler _hoverHandler; //Field offset: 0x58
	private bool _isSnowyMountain; //Field offset: 0x60

	public bool IsShowingSnow
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public LevelSnowEffectItemHandler() { }

	private void Awake() { }

	private void CheckForStaticSnowBlocker() { }

	private void DisplaySnow() { }

	public bool get_IsShowingSnow() { }

	public static int GetHighestSortingOrderInHierarchy(GameObject root) { }

	public void HideSnow() { }

	public void Init() { }

	public bool IsValidForSnowEffect() { }

	public bool IsValidForSnowEffect(LevelDropArea dropArea) { }

	private void OnBeginDrag(DragDropItemBase dragDropItemBase, PointerEventData eventData) { }

	private void OnDestroy() { }

	private void OnEndLand(LevelDropArea dropArea) { }

	private void OnFallToPositionFirstLand(LevelDropArea dropArea) { }

	private void OnPostInitAction() { }

	public void set_IsShowingSnow(bool value) { }

	public void SetSoundName(string newSoundName) { }

	public void StartSound() { }

}

