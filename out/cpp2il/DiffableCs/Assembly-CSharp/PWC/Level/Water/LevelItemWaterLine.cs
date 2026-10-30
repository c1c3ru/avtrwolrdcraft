namespace PWC.Level.Water;

public class LevelItemWaterLine : MonoBehaviour
{
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x20
	private Vector3 _calculatedScale; //Field offset: 0x28

	public LevelItemWaterLine() { }

	public void FitWidth(float width) { }

	private void RefreshSkeletonAnimation() { }

	public void ReturnToCalculatedScale() { }

	public void SetAltScale(Vector3 scale) { }

	public void SetVisible(bool isVisible) { }

	public void SetYPositionAndClearRotation(float yPosition) { }

}

