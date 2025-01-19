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

	public void SetScore(int score)
	{
		_score = score;
	}

	public int GetHighScore()
	{
		return _highScore;
	}

	public void ResetScore()
	{
		_score = 0;
	}

	public void IncrementScore()
	{
		_score++;
	}

}
