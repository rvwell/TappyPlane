using Godot;
using System;

public partial class Game : Node2D
{
	[Export] private Marker2D _spawnUpper;
	[Export] private Marker2D _spawnLower;
	[Export] private Timer _spawnTimer;
	// [Export] private Node2D _pipesHolder;
	[Export] private PackedScene _pipesScene;
	//[Export] private Plane _plane;
	
	private bool _gameOver;
	
	public override void _Ready()
	{
		_spawnTimer.Timeout += SpawnPipes;
		SignalManager.Instance.OnPlaneDied += GameOver;
		
		ScoreManager.ResetScore();
		
		SpawnPipes();
	}

	public override void _ExitTree()
	{
		SignalManager.Instance.OnPlaneDied -= GameOver;
	}

	private void StopPipes()
	{
		_spawnTimer.Stop();
		// foreach (Pipes pipe in _pipesHolder.GetChildren())
		// {
		// 	pipe.SetProcess(false);
		// }
	}

	private void GameOver()
	{
		GD.Print("Game Over");
		StopPipes();
		_gameOver = true;
	}


	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("fly") && _gameOver)
		{
			GameManager.LoadMain();
		}
		
		if(Input.IsActionJustPressed("quit"))
		{
			GameManager.LoadMain();
		}
	}

	public double GetSpawnY()
	{
		return GD.RandRange(_spawnUpper.Position.Y, _spawnLower.Position.Y);
	}

	private void SpawnPipes()
	{
		Pipes np = _pipesScene.Instantiate<Pipes>();
		// _pipesHolder.AddChild(np)
		AddChild(np);
		np.Position = new Vector2(_spawnLower.Position.X, (float)GetSpawnY());
	}
	
}