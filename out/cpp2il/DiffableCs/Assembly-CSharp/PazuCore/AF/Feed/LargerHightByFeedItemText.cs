namespace PazuCore.AF.Feed;

[RequireComponent(typeof(RectTransform))]
public class LargerHightByFeedItemText : MonoBehaviour
{
	[SerializeField]
	private Text _text; //Field offset: 0x20
	private RectTransform _feedItemRect; //Field offset: 0x28

	public LargerHightByFeedItemText() { }

	private void Awake() { }

	private void Start() { }

}

