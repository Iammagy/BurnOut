using Godot;
using System;

public class BeerEnemy : KinematicBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	Sprite sprite;
	RayCast2D bottomLeft;
	RayCast2D bottomRight;
	RayCast2D Right;
	RayCast2D Left;
	private Vector2 velocity;
	private int gravity = 200;
	private int speed = 100;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sprite = GetNode<Sprite>("Sprite");
		bottomLeft = GetNode<RayCast2D>("LeftRaycast");
		bottomRight = GetNode<RayCast2D>("RightRaycast");
		Right = GetNode<RayCast2D>("Right");
		Left = GetNode<RayCast2D>("Left");
		velocity.x = speed;
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
public override void _PhysicsProcess(float delta)
	{
	
	velocity.y += gravity * delta;

	if (velocity.y > gravity){
		velocity.y = gravity;
	}

	if (!bottomRight.IsColliding())
	{
		velocity.x = -speed;
		sprite.FlipH = false;

	}else if (!bottomLeft.IsColliding())
	{
		velocity.x = speed;
		sprite.FlipH = true;

	} else if (Right.IsColliding())
	{
		velocity.x = -speed;
		sprite.FlipH = true;

	} else if (Left.IsColliding())
	{
		velocity.x = speed;
		sprite.FlipH = false;
	}

	MoveAndSlide(velocity, Vector2.Up);
}
	public void _on_Area2D_body_entered(object body){

		if (body is Player)
		{
			Player jugador = body as Player;
			jugador.TakeDamage();
		}

	}

}
