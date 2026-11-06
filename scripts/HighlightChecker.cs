using Godot;
using System;

public partial class HighlightChecker : ShapeCast3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SceneTreeTimer timer = GetTree().CreateTimer(0.01);
		timer.Timeout += () => CheckForHighlightObjects();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void CheckForHighlightObjects()
	{
		for(int i = 0; i < MaxResults; i++)
		{
			IHighlight highlight_object = GetCollider(i) as IHighlight;
			if(highlight_object != null)
			{
				if(highlight_object.CanHighlight())
				{
					highlight_object.OnHighlight();
				}
				
			}
		}
		SceneTreeTimer timer = GetTree().CreateTimer(0.01);
		timer.Timeout += () => CheckForHighlightObjects();
	}
}
