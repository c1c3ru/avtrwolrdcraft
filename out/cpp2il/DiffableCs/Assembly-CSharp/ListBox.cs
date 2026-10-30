//Type is in global namespace

public class ListBox : MonoBehaviour
{
	private class CurveResolver
	{
		private AnimationCurve _curve; //Field offset: 0x10
		private float _maxValue; //Field offset: 0x18
		private float _minValue; //Field offset: 0x1C

		public CurveResolver(AnimationCurve curve, float minValue, float maxValue) { }

		public float Evaluate(float value) { }

	}

	[SerializeField]
	private bool _useScaleCurve; //Field offset: 0x20
	[HideInInspector]
	public int listBoxID; //Field offset: 0x24
	[HideInInspector]
	public ListBox lastListBox; //Field offset: 0x28
	[HideInInspector]
	public ListBox nextListBox; //Field offset: 0x30
	private int _contentID; //Field offset: 0x38
	private ListPositionCtrl _positionCtrl; //Field offset: 0x40
	private CurveResolver _positionCurve; //Field offset: 0x48
	private CurveResolver _scaleCurve; //Field offset: 0x50
	[CompilerGenerated]
	private Action<Single> <UpdatePosition>k__BackingField; //Field offset: 0x58
	[CompilerGenerated]
	private Action<Single> <OnUpdatePosition>k__BackingField; //Field offset: 0x60
	private float _unitPos; //Field offset: 0x68
	private float _lowerBoundPos; //Field offset: 0x6C
	private float _upperBoundPos; //Field offset: 0x70
	private float _changeSideLowerBoundPos; //Field offset: 0x74
	private float _changeSideUpperBoundPos; //Field offset: 0x78

	public Action<Single> OnUpdatePosition
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public private Action<Single> UpdatePosition
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public ListBox() { }

	[CompilerGenerated]
	private void <AddClickEvent>b__24_0() { }

	private void AddClickEvent() { }

	[CompilerGenerated]
	public Action<Single> get_OnUpdatePosition() { }

	[CompilerGenerated]
	public Action<Single> get_UpdatePosition() { }

	public int GetContentID() { }

	private float GetMajorPosition(float positionValue, ref bool needToUpdateToLastContent, ref bool needToUpdateToNextContent) { }

	private float GetPassivePosition(float majorPosition) { }

	private void InitialContent() { }

	public void Initialize(ListPositionCtrl listPositionCtrl) { }

	private void InitialPosition() { }

	private void MoveHorizontally(float delta) { }

	private void MoveVertically(float delta) { }

	[CompilerGenerated]
	public void set_OnUpdatePosition(Action<Single> value) { }

	[CompilerGenerated]
	private void set_UpdatePosition(Action<Single> value) { }

	public void ShowBoxInfo() { }

	private void UpdateScale(float majorPosition) { }

	private void UpdateToLastContent() { }

	private void UpdateToNextContent() { }

}

