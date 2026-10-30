//Type is in global namespace

public class TestReporter : MonoBehaviour
{
	public int logTestCount; //Field offset: 0x20
	public int threadLogTestCount; //Field offset: 0x24
	public bool logEverySecond; //Field offset: 0x28
	private int currentLogTestCount; //Field offset: 0x2C
	private Reporter reporter; //Field offset: 0x30
	private GUIStyle style; //Field offset: 0x38
	private Rect rect1; //Field offset: 0x40
	private Rect rect2; //Field offset: 0x50
	private Rect rect3; //Field offset: 0x60
	private Rect rect4; //Field offset: 0x70
	private Rect rect5; //Field offset: 0x80
	private Rect rect6; //Field offset: 0x90
	private Thread thread; //Field offset: 0xA0
	private float elapsed; //Field offset: 0xA8

	public TestReporter() { }

	private void OnDestroy() { }

	private void OnGUI() { }

	private void Start() { }

	private void threadLogTest() { }

	private void Update() { }

}

