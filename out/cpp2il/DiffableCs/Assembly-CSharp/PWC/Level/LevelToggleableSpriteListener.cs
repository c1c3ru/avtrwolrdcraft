namespace PWC.Level;

[AddComponentMenu(null)]
public class LevelToggleableSpriteListener : MonoBehaviour
{
	[SerializeField]
	protected LevelToggleableSprite _toggleableSprite; //Field offset: 0x20

	public LevelToggleableSpriteListener() { }

	protected override void Awake() { }

	protected override void OnClick(int index) { }

	protected override void OnClickImplement() { }

	protected override void OnDestroy() { }

	protected override void OnFirstIndexClickImplement() { }

	protected override void OnLastIndexClickImplement() { }

}

