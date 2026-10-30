namespace Game.Level;

public class LevelFireplace : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public LevelFireplace <>4__this; //Field offset: 0x10
		public FireplaceButtonType buttonType; //Field offset: 0x18

		public <>c__DisplayClass6_0() { }

		internal void <Animate>b__0(float t) { }

		internal void <Animate>b__1() { }

	}

	[SerializeField]
	private LevelUndroppableArea _undroppableArea; //Field offset: 0x20
	[SerializeField]
	private Transform _wallCover; //Field offset: 0x28
	[SerializeField]
	private LevelFireplaceButton[] _buttons; //Field offset: 0x30
	private int _tweenID; //Field offset: 0x38
	private bool _isOpen; //Field offset: 0x3C

	public LevelFireplace() { }

	private void Animate(FireplaceButtonType buttonType) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetState(FireplaceButtonType buttonType) { }

}

