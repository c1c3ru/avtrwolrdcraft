namespace BWYW;

public class CirclesUIManager : MonoBehaviour
{
	[SerializeField]
	private LevelContextualAnimationPanelCircle _circlePrefab; //Field offset: 0x20
	[SerializeField]
	private LayoutGroup _layoutGroup; //Field offset: 0x28
	[SerializeField]
	private Sprite[] OnBulletSprites; //Field offset: 0x30
	[SerializeField]
	private Sprite[] OffBulletSprites; //Field offset: 0x38
	private List<LevelContextualAnimationPanelCircle> _circles; //Field offset: 0x40

	public CirclesUIManager() { }

	public void InitCircles(int numOfCircles, int selectedCircle) { }

}

