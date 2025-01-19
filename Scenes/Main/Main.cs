using Godot;
using System;

public partial class Main : Control
{
	[Export] private Label _highScoreLabel;
	public override void _Ready()
	{
		_highScoreLabel.Text = $"{ScoreManager.GetHighScore():0000}";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("fly"))
		{
			GameManager.LoadGame();
		}
	}
}
