namespace PWC.LevelPhone.AchievementsApp;

public class AchievementData
{
	public string achievementGuid; //Field offset: 0x10
	public string achievementName; //Field offset: 0x18
	public int secretID; //Field offset: 0x20
	public int coinsAmount; //Field offset: 0x24
	public bool isNameHidden; //Field offset: 0x28
	public Sprite overrideBG; //Field offset: 0x30
	public PrizeType prizeType; //Field offset: 0x38
	public PDPrefabReference giftPrefabReference; //Field offset: 0x40

	public AchievementData() { }

}

