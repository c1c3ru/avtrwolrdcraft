namespace Spine;

public interface IUpdatable
{

	public bool Active
	{
		 get { } //Length: 0
	}

	public bool get_Active() { }

	public void Update(Physics physics) { }

}

