using Godot;
using System;
public partial class TextBillboard : MeshInstance3D
{

	[Export]
	private string[] _paragraphs;

	private VBoxContainer vbox;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//vbox = GetChild(0, true);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
