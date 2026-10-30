namespace Game.Level;

public class LevelValueProvider : MonoBehaviour
{
	[Header("Target Component & Methods")]
	public Component TargetComponent; //Field offset: 0x20
	public string MethodName; //Field offset: 0x28
	public string SecondaryMethodName; //Field offset: 0x30
	public string LevelItemMethodName; //Field offset: 0x38
	[Header("Target Value")]
	[SerializeField]
	public ValueWrapper TargetValue; //Field offset: 0x40

	public LevelValueProvider() { }

	public object GetValue() { }

	public bool IsTargetValueMet() { }

	[ContextMenu("Print Current Value")]
	public void PrintCurrentValue() { }

}

