using Godot;
using System;
using System.Collections.Generic;

public partial class HighlightChecker : ShapeCast3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		CheckForHighlightObjects();
	}
	private List<IHighlight> highlightObjectList = new List<IHighlight>();

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public void CheckForHighlightObjects()
	{
		if(highlightObjectList.Count > 0)
		{
			foreach(IHighlight i in highlightObjectList)
			{
				i.OffHighlight();
			}
			highlightObjectList = new List<IHighlight>();
		}
		for(int i = 0; i < GetCollisionCount(); i++)
		{
			IHighlight highlight_object = GetCollider(i) as IHighlight;
			if(highlight_object != null)
			{
				highlightObjectList.Add(highlight_object);
				GD.Print("Highlight collider not null!");
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
