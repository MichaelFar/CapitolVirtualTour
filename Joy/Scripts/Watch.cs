using Godot;
using System;
using System.Collections;
using System.Diagnostics;
using System.Threading.Tasks;

public partial class Watch : Area3D
{
	[Export]
	private Timer timer;

	[Export]
	private ProgressBar indicator;

	[Export]
	private String nextScene;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer.Start();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_area_3d_body_entered(Node3D body){
		Debug.Print("Starting Timer");
		timer.Start();
	}

	private void _on_area_3d_body_exited(Node3D body){
		Debug.Print("Stopping Timer");
		timer.Stop();
	}

	private void _on_timer_timeout(){
		GetTree().ChangeSceneToFile(nextScene);
	}
}
