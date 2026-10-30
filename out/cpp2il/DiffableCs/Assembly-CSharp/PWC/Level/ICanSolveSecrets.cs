namespace PWC.Level;

public interface ICanSolveSecrets
{

	public Action OnSolvedSecretAction
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public Action OnUnsolvedSecretAction
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public Action get_OnSolvedSecretAction() { }

	public Action get_OnUnsolvedSecretAction() { }

	public void set_OnSolvedSecretAction(Action value) { }

	public void set_OnUnsolvedSecretAction(Action value) { }

}

