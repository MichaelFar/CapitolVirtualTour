using Godot;
using System;
using System.Collections.Generic;

public partial class HoverChecker : ShapeCast3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		CheckForHoverObjects();
	}
	private List<IHover> hoverObjectList = new List<IHover>();

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public void CheckForHoverObjects()
	{
		if(hoverObjectList.Count > 0)
		{
			foreach(IHover i in hoverObjectList)
			{
				i.OffHover();
			}
			hoverObjectList = new List<IHover>();
		}
		for(int i = 0; i < GetCollisionCount(); i++)
		{
			IHover hover_object = GetCollider(i) as IHover;
			if(hover_object != null)
			{
				hoverObjectList.Add(hover_object);
				GD.Print("Hover collider not null!");
				if(hover_object.CanHover())
				{
					hover_object.OnHover();
				}
				
			}
		}
		
		SceneTreeTimer timer = GetTree().CreateTimer(0.01);
		timer.Timeout += () => CheckForHoverObjects();
	}
}
