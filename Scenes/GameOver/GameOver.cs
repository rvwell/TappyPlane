using Godot;
using System;

public partial class GameOver : Control
{
	[Export] private Label _gameOverLabel;
	[Export] private Label _spaceLabel;
	[Export] private AudioStreamPlayer _effectSound;
	[Export] private Timer _timer;
	
	public override void _Ready()
	{
		SignalManager.Instance.OnPlaneDied += OnPlaneDied;
		_timer.Timeout += OnTimerTimeout;
	}
	
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("fly") && _spaceLabel.Visible)
		{
			GameManager.LoadMain();
		}
	}

	public override void _ExitTree()
	{
		SignalManager.Instance.OnPlaneDied -= OnPlaneDied;
	}

	private void OnTimerTimeout()
	{
		_gameOverLabel.Hide();
		_spaceLabel.Show();
	}

	private void OnPlaneDied()
	{
		_timer.Start();
		Show();
		_effectSound.Play();
	}
	
}
