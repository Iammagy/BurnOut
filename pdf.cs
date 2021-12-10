using Godot;
using System;

public class pdf : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	
	[Signal]
	public delegate void PDF();
	
	public override void _Ready()
	{
		
	}
	
	private void _on_Area2D_body_entered(object body) {

		GD.Print("Body: "+ body + " has entered to pdf");
		if (body is KinematicBody2D){
			if (body is Player)
			{
				Player pc = body as Player;
				EmitSignal(nameof(PDF));

			}
		}

	}

}
