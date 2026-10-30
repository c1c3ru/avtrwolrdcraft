namespace PazuCore;

[RequireComponent(typeof(Button))]
public abstract class ButtonBase : MonoBehaviour
{

	protected ButtonBase() { }

	protected override void Awake() { }

	protected abstract void OnClick() { }

}

