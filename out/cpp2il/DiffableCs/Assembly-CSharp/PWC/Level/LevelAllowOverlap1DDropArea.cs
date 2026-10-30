namespace PWC.Level;

[AddComponentMenu(null)]
public class LevelAllowOverlap1DDropArea : Level1DDropArea
{

	public LevelAllowOverlap1DDropArea() { }

	public virtual bool ShouldAllowOverlappingItems() { }

}

