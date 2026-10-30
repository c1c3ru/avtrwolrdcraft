namespace PWC.Level.Maker.Customization;

[Extension]
public static class CustomizationCategoryTypeExtensions
{

	public static CustomizationCategoryType GetCategoryTypeFromString(string categoryTypeName) { }

	[Extension]
	public static CustomizationCategoryType GetMainCategory(CustomizationCategoryType category) { }

	[Extension]
	public static bool IsUntiled(CustomizationCategoryType category) { }

}

