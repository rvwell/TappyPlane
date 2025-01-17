using Godot;
using System;

public partial class GameManager : Node
{
	public static GameManager Instance { get; private set;}
	
	private PackedScene _gameScene = GD.Load<PackedScene>("res://Scenes/Game/Game.tscn");
	private PackedScene _mainScene = GD.Load<PackedScene>("res://Scenes/Main/Main.tscn");
	public override void _Ready()
	{
		Instance = this;
	}

	public static void LoadMain()
	{
		Instance.GetTree().ChangeSceneToPacked(Instance._mainScene);
	}
	
	public static void LoadGame()
	{
		Instance.GetTree().ChangeSceneToPacked(Instance._gameScene);
	}
	
}
