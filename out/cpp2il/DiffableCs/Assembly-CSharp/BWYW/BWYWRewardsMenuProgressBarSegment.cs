namespace BWYW;

public class BWYWRewardsMenuProgressBarSegment : MonoBehaviour
{
	[SerializeField]
	private Sprite _onBarSprite; //Field offset: 0x20
	[SerializeField]
	private Sprite _offBarSprite; //Field offset: 0x28
	[SerializeField]
	private Sprite _shortOnBarSprite; //Field offset: 0x30
	[SerializeField]
	private Sprite _shortOffBarSprite; //Field offset: 0x38
	[SerializeField]
	private Sprite _onCircleSprite; //Field offset: 0x40
	[SerializeField]
	private Sprite _offCircleSprite; //Field offset: 0x48
	[SerializeField]
	private Image _barImage; //Field offset: 0x50
	[SerializeField]
	private Image _fillImage; //Field offset: 0x58
	[SerializeField]
	private Image _circleImage; //Field offset: 0x60
	[SerializeField]
	private TMP_Text _circleText; //Field offset: 0x68
	[SerializeField]
	private DeliveryProgressBar _progressBar; //Field offset: 0x70

	public BWYWRewardsMenuProgressBarSegment() { }

	public void SetState(bool isShort, float progress, int level, bool isFinal) { }

}

