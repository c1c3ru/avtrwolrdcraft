namespace PWC.Level;

public interface ILevelPaintableTarget
{

	public void DisablePainting() { }

	public void EnablePainting(Color color, LTexture brush) { }

	public void Paint(Vector2 position) { }

}

