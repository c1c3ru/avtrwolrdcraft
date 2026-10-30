namespace PWC.GamePopups;

public class BWYWTimedGamePopup : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass22_0
	{
		public Vector2 localPosition; //Field offset: 0x10
		public BWYWTimedGamePopup <>4__this; //Field offset: 0x18
		public bool value; //Field offset: 0x20

		public <>c__DisplayClass22_0() { }

		internal void <Animate>b__0(float localYPosition) { }

		internal void <Animate>b__1() { }

	}

	private const int BG_OFFSET = 46; //Field offset: 0x0
	[SerializeField]
	private Image _image; //Field offset: 0x20
	[SerializeField]
	private TMP_Text _titleText; //Field offset: 0x28
	[SerializeField]
	private TMP_Text _descriptionText; //Field offset: 0x30
	[SerializeField]
	private TMP_Text _doneTasksText; //Field offset: 0x38
	[SerializeField]
	private TMP_Text _xpText; //Field offset: 0x40
	[SerializeField]
	private DeliveryProgressBar _progressBar; //Field offset: 0x48
	[SerializeField]
	private GameObject _claimButton; //Field offset: 0x50
	private RectTransform _rectTransform; //Field offset: 0x58
	public Action OnNotificationEndAction; //Field offset: 0x60
	public Action OnClaimAction; //Field offset: 0x68
	public Action OnPressAction; //Field offset: 0x70
	public float _startPosition; //Field offset: 0x78
	public float _endPosition; //Field offset: 0x7C
	private float _duration; //Field offset: 0x80
	private LTDescr _tween; //Field offset: 0x88
	private bool _isMoving; //Field offset: 0x90

	public BWYWTimedGamePopup() { }

	private void Animate(bool value) { }

	public void Init(string title, string description, int xp, Sprite sprite, int subTasksDone, int target, float duration) { }

	public void OnClaimClick() { }

	public void OnDestroy() { }

	public void OnPopupClick() { }

	public void UpdatePopUp(int xp, int subTasksDone, int target) { }

}

