using Godot;
using System;
public partial class TextBillboard : MeshInstance3D
{
	private PackedScene paragraphScene = GD.Load<PackedScene>("res://Joy/Scenes/paragraph.tscn");

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
		var titleNode = paragraphScene.Instantiate();
		Label titleLabel = titleNode as Label;
		titleLabel.Text = title;
		titleLabel.LabelSettings = labelSet[1];
		vbox.AddChild(titleLabel);

		

		foreach(string lines in paragraphs){
			var labelNode = paragraphScene.Instantiate();
			Label newLabel = labelNode as Label;
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
