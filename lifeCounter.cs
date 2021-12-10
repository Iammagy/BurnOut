using Godot;
using System;

public class lifeCounter : Label
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	private int lifes = 3;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

	private void _on_Player_Damage()
	{
	// Replace with function body.
		lifes--;
		Text = lifes.ToString();
	}	
	
	private void _on_Player_Respawn()
	{
	// Replace with function body.
		lifes = 3;
		Text = lifes.ToString();
	}
	
}
