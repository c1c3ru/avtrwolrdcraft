namespace PWC.Game.Level;

public class SecretToAchievementMap : ScriptableObject
{
	internal class SecretToAchivmentEntry
	{
		public string secretName; //Field offset: 0x10
		public string achivmentGuid; //Field offset: 0x18

		public SecretToAchivmentEntry(string secretName, string achivmentGuid) { }

	}

	private static Dictionary<String, String> dictionary; //Field offset: 0x0
	[SerializeField]
	public List<SecretToAchivmentEntry> SecretToAchivmentList; //Field offset: 0x18

	public SecretToAchievementMap() { }

	public Dictionary<String, String> GetDictionary() { }

}

