using Godot;
using System;

public class Player : KinematicBody2D
{
	Vector2 motion = new Vector2(0 , 0);
	private float speed_x = 15500;
	
	//Lurping (Linear interpolation), se hace con la biblioteca Mathf y le da un efecto realista de inercia
	private  const float gravedad = 800f;
	private float friction = 0.7f; //variable para el lurping

	private float acceleration = 0.01f; //variable para el lurping

	private float climb_time = 3f;

	private float caida = 100000; //variable para controlar la gravedad cuaando se hace el salto

	private bool isInAir = false;

	public int health = 3;	//sistema de vidas

	public int direccion = 0; // para que el objeto de daño envie al jugador en el lado correcto

	private bool isTakingDamage = false;

	private AnimatedSprite animatedSprite;

	[Signal]

	public delegate void Death();



	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
	}

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {

	if (health > 0) {

		//Comandos para moverse  *************************************************************

		motion.x = 0; //Hace que el personaje se deje de mover al dejar de presionar las teclas
		
		direccion = 0;
		
		climb_time = 1;
		
		if (!isTakingDamage){

			if (Input.IsActionPressed("ui_left")) {
				direccion -= 1;
				animatedSprite.FlipH = true;
			}
			if (Input.IsActionPressed("ui_right")) {
				direccion += 1;
				animatedSprite.FlipH = false;
			}
		}
		if (direccion != 0)
		{
			motion.x = Mathf.Lerp(motion.x, direccion * speed_x, acceleration);	
			animatedSprite.Play("Run"); //animacion correr
			

		} else
		{
			motion.x = Mathf.Lerp(motion.x, 0, friction);
			animatedSprite.Play("Idle"); //animacion quieta

			if (motion.x < 5 && motion.x > -5) //permite que el personaje no se mueva cuando recibe daño
			{
				isTakingDamage = false;
			}
			
		}

		if (IsOnWall()){

			if (Input.IsActionJustPressed("jump")) {

				climb_time -= delta;

				if (climb_time > 0)
					{
					
						motion.y -= 250;
				} else
					{
						motion.y += caida * delta;
						animatedSprite.Play("Fall"); //animacion caida
					}
				}  else {

			animatedSprite.Play("Idle"); //animacion quieta

			}	
		}


	motion.y += gravedad * delta; //Hace que caiga más rápido el personaje
	motion = MoveAndSlide(motion);

  }
  
}

	public void TakeDamage(){
		GD.Print("Damage Taken");
		health -= 1;
		GD.Print("Current Health: "+ health);
		motion = MoveAndSlide(new Vector2 (5000f * -direccion, -200f), Vector2.Up);
		
		isTakingDamage = true;
		if (health <= 0)
		{
			health = 0;
			GD.Print("Has muerto");
			animatedSprite.Stop();
			Hide();
			EmitSignal(nameof(Death));
		}
	}

	public void RespawnPlayer () {
		Show();
		health = 3;
	}

}
