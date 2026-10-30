namespace UnityEngine;

[AttributeUsage(384, AllowMultiple = True)]
public class AssetReferenceUIRestriction : Attribute
{

	public AssetReferenceUIRestriction() { }

	public override bool ValidateAsset(string path) { }

	public override bool ValidateAsset(object obj) { }

}

