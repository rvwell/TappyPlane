using Godot;


public partial class ScoreManager : Node
{
	public static ScoreManager Instance { get; private set; }
	
	private int _score;
	private int _highScore;
	
	public override void _Ready()
	{
		Instance = this;
	}
	
	public static int GetScore()
	{
		return Instance._score;
	}

	public static void SetScore(int score)
	{
		Instance._score = score;
		if (Instance._score > Instance._highScore)
		{
			Instance._highScore = Instance._score;
		}
		GD.Print($"Score: {Instance._score}, High Scor: {Instance._highScore}");
		SignalManager.EmitOnScored();
	}

	public static int GetHighScore()
	{
		return Instance._highScore;
	}

	public static void ResetScore()
	{
		SetScore(0);
	}

	public static void IncrementScore()
	{
		SetScore(GetScore() + 1);
	}

}
