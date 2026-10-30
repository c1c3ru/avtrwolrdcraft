namespace TMPro;

public interface ITextElement
{

	public Material sharedMaterial
	{
		 get { } //Length: 0
	}

	public Material get_sharedMaterial() { }

	public int GetInstanceID() { }

	public void Rebuild(CanvasUpdate update) { }

}

