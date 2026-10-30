namespace PWC.Level;

public class LevelParticleSystemOnDragItemHandler : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x20
	private LevelItem _levelItem; //Field offset: 0x28

	public LevelParticleSystemOnDragItemHandler() { }

	private void Awake() { }

	public ParticleSystem GetParticleSystem() { }

	private void OnBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void OnDestroy() { }

	private void OnEndDrag(DragDropItemBase item, PointerEventData eventData) { }

	public void PlayParticles() { }

	public void StopParticles() { }

}

