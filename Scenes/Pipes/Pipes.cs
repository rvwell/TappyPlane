using Godot;
using System;

public partial class Pipes : Node2D
{
	const float SCROLL_SPEED = 120f;
	[Export] private VisibleOnScreenNotifier2D _visibleOnScreenNotifier;
	[Export] private Area2D _upperPipe;
	[Export] private Area2D _lowerPipe;
	[Export] private Area2D _laser;
	
	public override void _Ready()
	{
		_visibleOnScreenNotifier.ScreenExited += OnScreenExited;
		_lowerPipe.BodyEntered += OnPipeBodyEntered;
		_upperPipe.BodyEntered += OnPipeBodyEntered;
		_laser.BodyEntered += OnLaserBodyEntered;

		SignalManager.Instance.OnPlaneDied += OnPlaneDied;
	}

	public override void _ExitTree()
	{
		SignalManager.Instance.OnPlaneDied -= OnPlaneDied;
	}

	private void OnPlaneDied()
	{
		SetProcess(false);
	}

	private void OnLaserBodyEntered(Node2D body)
	{
		GD.Print("Scored");
	}

	private void OnPipeBodyEntered(Node2D body)
	{
		if (body is Plane)
		{
			(body as Plane).Die();
			GD.Print("Died", body.Name);
		}
		// if (body.IsInGroup("Plane"))
		// {
		// 	(body as Plane).Die();
		// }
	}

	public override void _Process(double delta)
	{
		Position -= new Vector2(SCROLL_SPEED*(float)delta,0);
	}
	
	private void OnScreenExited()
	{
		QueueFree();
	}
}
