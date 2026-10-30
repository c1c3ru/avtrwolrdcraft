namespace UnityEngine;

[AttributeUsage(384, AllowMultiple = False)]
public sealed class AssetReferenceUILabelRestriction : AssetReferenceUIRestriction
{
	public String[] m_AllowedLabels; //Field offset: 0x10
	public string m_CachedToString; //Field offset: 0x18

	public AssetReferenceUILabelRestriction(String[] allowedLabels) { }

	public virtual string ToString() { }

	public virtual bool ValidateAsset(object obj) { }

	public virtual bool ValidateAsset(string path) { }

}

