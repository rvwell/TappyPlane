using Godot;


public partial class ScoreManager : Node
{
	public static ScoreManager Instance { get; private set; }
	
	private uint _score;
	private uint _highScore;

	private const string ScoreFile = "user://tappy.save";
	
	public override void _Ready()
	{
		Instance = this;
		LoadScoreFromFile();
	}

	public override void _ExitTree()
	{
		SaveScoreToFile();
	}

	public static uint GetScore()
	{
		return Instance._score;
	}

	public static void SetScore(uint score)
	{
		Instance._score = score;
		if (Instance._score > Instance._highScore)
		{
			Instance._highScore = Instance._score;
		}
		SignalManager.EmitOnScored();
	}

	public static uint GetHighScore()
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

	private void LoadScoreFromFile()
	{
		using FileAccess file = FileAccess.Open(ScoreFile, FileAccess.ModeFlags.Read);
		if (file != null)
		{
			_highScore = file.Get32();
		}
	}
	
	private void SaveScoreToFile()
	{
		using FileAccess file = FileAccess.Open(ScoreFile, FileAccess.ModeFlags.Write);
		if (file != null)
		{
			file.Store32(_highScore);
		}
	}

}
