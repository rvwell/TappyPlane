using Godot;
using System;

public partial class Plane : CharacterBody2D
{
	const float GRAVITY = 1200f;
	private const float POWER = -400f;
	
	private AnimationPlayer _animationPlayer;
	private AnimatedSprite2D _animatedSprite2D;

	// [Signal] public delegate void OnPlaneDiedEventHandler(); 
	public override void _Ready()
	{
		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		_animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		velocity.Y += GRAVITY * (float)delta;
		
		if (Input.IsActionJustPressed("fly"))
		{
			velocity.Y = POWER;
			_animationPlayer.Play("power");
		}
		
		Velocity = velocity;
		MoveAndSlide();

		if (IsOnFloor())
		{
			Die();
		}
	}

	public void Die()
	{
		SetPhysicsProcess(false);
		_animatedSprite2D.Stop();
		// EmitSignal(SignalName.OnPlaneDied);
		SignalManager.Instance.EmitSignal("OnPlaneDied");
	}
}
