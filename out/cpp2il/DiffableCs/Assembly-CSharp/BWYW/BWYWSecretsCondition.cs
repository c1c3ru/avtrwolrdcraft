namespace BWYW;

public class BWYWSecretsCondition : BWYWConditionBase
{
	public List<SecretFullId> secrets; //Field offset: 0x10

	public BWYWSecretsCondition() { }

	public virtual bool IsValid(ILevelAvatar avatar) { }

}

