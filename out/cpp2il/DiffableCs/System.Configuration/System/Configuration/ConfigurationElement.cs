namespace System.Configuration;

[DefaultMember("Item")]
public abstract class ConfigurationElement
{

	protected private override ConfigurationPropertyCollection Properties
	{
		private get { } //Length: 56
	}

	protected private override ConfigurationPropertyCollection get_Properties() { }

	protected private override bool IsModified() { }

	protected private override void Reset(ConfigurationElement parentElement) { }

	protected private override void ResetModified() { }

}

