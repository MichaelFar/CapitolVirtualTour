using Godot;
using System;

public partial class HoverVolume : StaticBody3D, IHover
{
	// Called when the node enters the scene tree for the first time.

	[Export] MeshInstance3D highlightMeshNode;
	private ShaderMaterial highlightShader;
	public override void _Ready()
	{
		if(highlightMeshNode != null)
		{
			highlightShader = highlightMeshNode.Mesh.SurfaceGetMaterial(0).NextPass as ShaderMaterial;
		}
			
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//GD.Print("Hello?");
	}

    public void OnHover()
    {
        if(highlightShader != null)
		{
			
			highlightShader.SetShaderParameter("size", 1.02);
			GD.Print(highlightShader.GetShaderParameter("size") + " is the value of size parameter");
			GD.Print("Shader is not null!");
			GD.Print(highlightShader);
			GD.Print(highlightShader.ResourceName);
				
		}
		else
		{
			GD.Print("Hover shader is null!");
		}
    }

    public bool CanHover()
    {
        return true;
    }

    public void OffHover()
    {
        
		if(highlightShader != null)
		{
			highlightShader.SetShaderParameter("size", 1.00);
		}
	}
}
