using Godot;
using System;

public class pdfLabel : Label
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	private int count = 0;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
	private void _on_PDFs_Add()
	{
		// Replace with function body.
		count++;
		Text = count.ToString();
	}

	private void _on_PDFs2_Add()
	{
		// Replace with function body.
		count++;
		Text = count.ToString();
	}


	private void _on_PDFs3_Add()
	{
		// Replace with function body.
		count++;
		Text = count.ToString();
	}


	private void _on_PDFs4_Add()
	{
		// Replace with function body.
		count++;
		Text = count.ToString();
	}


	private void _on_PDFs5_Add()
	{
		// Replace with function body.
		count++;
		Text = count.ToString();
	}

}
