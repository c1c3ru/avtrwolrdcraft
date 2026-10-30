//Type is in global namespace

public class LTSeq
{
	public LTSeq previous; //Field offset: 0x10
	public LTSeq current; //Field offset: 0x18
	public LTDescr tween; //Field offset: 0x20
	public float totalDelay; //Field offset: 0x28
	public float timeScale; //Field offset: 0x2C
	private int debugIter; //Field offset: 0x30
	public uint counter; //Field offset: 0x34
	public bool toggle; //Field offset: 0x38
	private uint _id; //Field offset: 0x3C

	public int id
	{
		 get { } //Length: 16
	}

	public LTSeq() { }

	private LTSeq addOn() { }

	private float addPreviousDelays() { }

	public LTSeq append(float delay) { }

	public LTSeq append(Action callback) { }

	public LTSeq append(Action<Object> callback, object obj) { }

	public LTSeq append(GameObject gameObject, Action callback) { }

	public LTSeq append(GameObject gameObject, Action<Object> callback, object obj) { }

	public LTSeq append(LTDescr tween) { }

	public int get_id() { }

	public void init(uint id, uint global_counter) { }

	public LTSeq insert(LTDescr tween) { }

	public void reset() { }

	public LTSeq reverse() { }

	public LTSeq setScale(float timeScale) { }

	private void setScaleRecursive(LTSeq seq, float timeScale, int count) { }

}

