//Type is in global namespace

public class RendererSorter : MonoBehaviour
{
	[SerializeField]
	private string _sortingLayer; //Field offset: 0x20
	[SerializeField]
	private int _sortingOrder; //Field offset: 0x28

	public RendererSorter() { }

	private void Apply() { }

	private void Awake() { }

	private void OnValidate() { }

}

