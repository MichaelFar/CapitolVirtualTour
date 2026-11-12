using Godot;
using System;
public partial class TextBillboard : MeshInstance3D
{

	[Export]
	private string title;

	[Export]
	private string[] paragraphs;

	[Export]
	private VBoxContainer vbox;

	[Export]
	private LabelSettings[] labelSet;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Label titleLabel = new Label();
		titleLabel.Text = title;
		titleLabel.LabelSettings = labelSet[1];
		vbox.AddChild(titleLabel);

		foreach(string lines in paragraphs){
			Label newLabel = new Label();
			newLabel.Text = lines;
			newLabel.LabelSettings = labelSet[0];
			vbox.AddChild(newLabel);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
