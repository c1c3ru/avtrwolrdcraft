namespace BWYW;

public class BWYWTaskSlot : BWYWSlotBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass20_0
	{
		public BWYWTaskSlot <>4__this; //Field offset: 0x10
		public Vector3 minSize; //Field offset: 0x18
		public Color color; //Field offset: 0x24
		public Image renderer; //Field offset: 0x38

		public <>c__DisplayClass20_0() { }

		internal void <AnimateReveal>b__0() { }

		internal void <AnimateReveal>b__1(float alpha) { }

	}

	[SerializeField]
	private TMP_Text _titleText; //Field offset: 0x50
	[SerializeField]
	private TMP_Text _detailsText; //Field offset: 0x58
	[SerializeField]
	private DeliveryProgressBar _progressBar; //Field offset: 0x60
	[SerializeField]
	private Image _image; //Field offset: 0x68
	[SerializeField]
	private Image _locationImage; //Field offset: 0x70
	[SerializeField]
	private TMP_Text _xpText; //Field offset: 0x78
	[SerializeField]
	private TMP_Text _targetText; //Field offset: 0x80
	[SerializeField]
	private TMP_Text _progressText; //Field offset: 0x88
	[SerializeField]
	private GameObject _backSide; //Field offset: 0x90
	[SerializeField]
	private GameObject _frontSide; //Field offset: 0x98
	[SerializeField]
	private GameObject _shadowObject; //Field offset: 0xA0
	[SerializeField]
	private GameObject _taskCompletedGameObject; //Field offset: 0xA8
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0xB0
	private bool _isOpen; //Field offset: 0xB8
	private bool _isLocked; //Field offset: 0xB9

	public BWYWTaskSlot() { }

	private void AnimateLocked(float duration) { }

	private void AnimateReveal() { }

	public void Init(DailyTaskBase task, int taskId, int tasksFinished, bool canBeClaimed, bool isOpen, bool isLocked, bool isShowShadow) { }

	public virtual void OnClaimClick() { }

	public virtual void OnClick() { }

	public virtual bool OnClickInternal() { }

	protected virtual void OnDestroy() { }

	public void RestoreInteractabilityAfterFTUEIfNeeded() { }

}

