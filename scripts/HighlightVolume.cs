using Godot;
using System;

public partial class HighlightVolume : Area3D, IHighlight
{
	// Called when the node enters the scene tree for the first time.

	[Export] Material highlightMaterial;
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public void OnHighlight()
    {
        if(highlightMaterial != null)
		{
			if(highlightMaterial.NextPass != null)
			{
				ShaderMaterial shader = highlightMaterial.NextPass as ShaderMaterial;
				if(shader != null)
				{
					shader.SetShaderParameter("size", 1.02);
				}
			}
		}
    }

    public bool CanHighlight()
    {
        return true;
    }

    public void OffHighlight()
    {
        if(highlightMaterial != null)
		{
			if(highlightMaterial.NextPass != null)
			{
				ShaderMaterial shader = highlightMaterial.NextPass as ShaderMaterial;
				if(shader != null)
				{
					shader.SetShaderParameter("size", 1.00);
				}
			}
		}
    }
}
