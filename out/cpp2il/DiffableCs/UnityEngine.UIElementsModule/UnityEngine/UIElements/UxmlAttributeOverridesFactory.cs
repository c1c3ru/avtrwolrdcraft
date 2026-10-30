namespace UnityEngine.UIElements;

public class UxmlAttributeOverridesFactory : UxmlFactory<VisualElement, UxmlAttributeOverridesTraits>
{

	public virtual string uxmlName
	{
		 get { } //Length: 64
	}

	public virtual string uxmlQualifiedName
	{
		 get { } //Length: 116
	}

	public UxmlAttributeOverridesFactory() { }

	public virtual VisualElement Create(IUxmlAttributes bag, CreationContext cc) { }

	public virtual string get_uxmlName() { }

	public virtual string get_uxmlQualifiedName() { }

}

