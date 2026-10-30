namespace UnityEngine.UIElements;

public class UxmlRootElementFactory : UxmlFactory<VisualElement, UxmlRootElementTraits>
{

	public virtual string uxmlName
	{
		 get { } //Length: 64
	}

	public virtual string uxmlQualifiedName
	{
		 get { } //Length: 116
	}

	public UxmlRootElementFactory() { }

	public virtual VisualElement Create(IUxmlAttributes bag, CreationContext cc) { }

	public virtual string get_uxmlName() { }

	public virtual string get_uxmlQualifiedName() { }

}

