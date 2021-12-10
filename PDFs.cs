using Godot;
using System;

public class PDFs : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	Sprite sprite;
	[Signal]
	public delegate void Add();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
	  
  }

	public void _on_Area2D_body_entered(object body) {

		if (body is Player)
		{
			Player jugador = body as Player;
			GD.Print("PDF recolectado!");
			Hide();
			EmitSignal(nameof(Add));
		}

	}


}
