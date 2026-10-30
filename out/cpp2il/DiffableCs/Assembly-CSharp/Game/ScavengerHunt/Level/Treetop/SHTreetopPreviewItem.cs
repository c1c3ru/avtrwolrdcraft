namespace Game.ScavengerHunt.Level.Treetop;

public class SHTreetopPreviewItem : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	private GameObject _doneIndicator; //Field offset: 0x28
	private PDPrefab _pdPrefab; //Field offset: 0x30

	public SHTreetopPreviewItem() { }

	public string GetPDPrefabGuid() { }

	public SpriteRenderer GetSpriteRenderer() { }

	public void Init(PDPrefab pdPrefab) { }

	public void ShowDoneIndicator(bool show) { }

}

