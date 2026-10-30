namespace PWC.Level.ContextualAnimation;

[CreateAssetMenu(menuName = "PazuWorld/Level/CA/InspectorConfig")]
public class LevelCAInspectorConfig : ScriptableObject
{
	internal class ExtraConfig
	{
		public AvatarHandType forceHandType; //Field offset: 0x10

		public ExtraConfig() { }

		public bool HasValues() { }

	}

	public string folderName; //Field offset: 0x18
	public string lockedAnimation; //Field offset: 0x20
	public bool tryUseItemAsMainThumb; //Field offset: 0x28
	public List<LevelCAConfig> configs; //Field offset: 0x30
	public ExtraConfig[] extraConfigs; //Field offset: 0x38

	public LevelCAInspectorConfig() { }

}

