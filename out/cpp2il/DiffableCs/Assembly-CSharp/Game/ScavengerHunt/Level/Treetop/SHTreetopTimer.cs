namespace Game.ScavengerHunt.Level.Treetop;

public class SHTreetopTimer : MonoBehaviour
{
	private const string TIME_FORMAT = "mm\:ss"; //Field offset: 0x0
	[SerializeField]
	private TextMesh _textMesh; //Field offset: 0x20
	private TimeSpan _timeSpan; //Field offset: 0x28

	public SHTreetopTimer() { }

	public void OnTimeLeftChanged(int timeLeft) { }

	public void SyncAppearance(int timeLeft) { }

	private void UpdateText() { }

}

