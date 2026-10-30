namespace UnityEngine.UIElements;

public class UxmlTemplateFactory : UxmlFactory<VisualElement, UxmlTemplateTraits>
{

	public virtual string uxmlName
	{
		 get { } //Length: 64
	}

	public virtual string uxmlQualifiedName
	{
		 get { } //Length: 116
	}

	public UxmlTemplateFactory() { }

	public virtual VisualElement Create(IUxmlAttributes bag, CreationContext cc) { }

	public virtual string get_uxmlName() { }

	public virtual string get_uxmlQualifiedName() { }

}

