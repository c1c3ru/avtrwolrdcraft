namespace TMPro;

public abstract class TMP_InputValidator : ScriptableObject
{

	protected TMP_InputValidator() { }

	public abstract char Validate(ref string text, ref int pos, char ch) { }

}

