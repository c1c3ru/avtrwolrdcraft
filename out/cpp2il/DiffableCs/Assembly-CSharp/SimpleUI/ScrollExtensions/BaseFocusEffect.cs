namespace SimpleUI.ScrollExtensions;

public class BaseFocusEffect : MonoBehaviour
{
	public DynamicScrollPoint dynamicScrollPoint; //Field offset: 0x20
	[Range(0, 1)]
	public float minEffectDistance; //Field offset: 0x28
	public float minEffectValue; //Field offset: 0x2C
	public float maxEffectValue; //Field offset: 0x30
	public EasingTypes interpolation; //Field offset: 0x34
	private Func<Single, Single, Single, Single> interpolationFunction; //Field offset: 0x38
	protected float effectStrength; //Field offset: 0x40

	public BaseFocusEffect() { }

	private void CalculateEffectStrength(float normalizedDistance) { }

	protected override void SetEffect(float strength) { }

	protected override void Start() { }

}

