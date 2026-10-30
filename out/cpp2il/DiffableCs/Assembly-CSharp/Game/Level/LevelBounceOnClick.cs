namespace Game.Level;

public class LevelBounceOnClick : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private float _time; //Field offset: 0x20
	[SerializeField]
	private float _scaleTo; //Field offset: 0x24
	[SerializeField]
	private int _repeat; //Field offset: 0x28
	[SerializeField]
	private GameObject _bounceObject; //Field offset: 0x30
	private int _currentTweenID; //Field offset: 0x38
	private float _startScale; //Field offset: 0x3C

	public LevelBounceOnClick() { }

	[CompilerGenerated]
	private void <OnPointerClick>b__7_0() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void Start() { }

}

