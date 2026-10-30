namespace ExtraAnimations;

public class CAAnimationsExtensions : ScriptableObject
{
	internal class AnimationsGroup
	{
		public LevelCAConfig[] configs; //Field offset: 0x10

		public AnimationsGroup() { }

	}

	[SerializeField]
	private List<AnimationsGroup> _addedCAAnimations; //Field offset: 0x18

	public CAAnimationsExtensions() { }

	private string GetCAHandlerName() { }

	public List<LevelCAConfig> GetExtendedAnimations(int level) { }

}

