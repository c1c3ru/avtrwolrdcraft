namespace PWC.Level;

public class LevelActiveForDurationOnClick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public LevelActiveForDurationOnClick <>4__this; //Field offset: 0x10
		public bool isActiveForDuration; //Field offset: 0x18

		public <>c__DisplayClass8_0() { }

		internal void <ProcessClick>b__0() { }

	}

	internal enum Type
	{
		None = 0,
		ActiveForDuration = 1,
		InactiveForDuration = 2,
	}

	[SerializeField]
	private GameObject[] _targets; //Field offset: 0x20
	[SerializeField]
	private Type _type; //Field offset: 0x28
	[SerializeField]
	private float _duration; //Field offset: 0x2C
	private bool _isInProgress; //Field offset: 0x30

	public LevelActiveForDurationOnClick() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	public void PerformRemoteClick() { }

	private void ProcessClick() { }

}

