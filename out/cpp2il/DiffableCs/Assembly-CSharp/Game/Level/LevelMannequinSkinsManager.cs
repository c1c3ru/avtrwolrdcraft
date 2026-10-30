namespace Game.Level;

public class LevelMannequinSkinsManager : CharacterSpineSkinsManager
{

	public LevelMannequinSkinsManager() { }

	private void InitMannequin() { }

	public void InitMannequinWithData(AvatarSpineData data) { }

	public void InitMannequinWithoutData() { }

	protected virtual void RemoveSkinChainEvent(int categoryType) { }

	public virtual void SaveData() { }

	protected virtual HashSet<String> TryGetExcludedSkins(string skinName) { }

}

