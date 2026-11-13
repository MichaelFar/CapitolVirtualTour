using Godot;
using System;

public partial class Pickup : RigidBody3D, IInteractable
{
	// Called when the node enters the scene tree for the first time.

	private bool isPickedUp = false;
	[Signal]public delegate void PickedUpStateChangedEventHandler(bool is_picked_up);
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public void OnInteract(Node3D interaction_source)
    {
        Reparent(interaction_source);
		GlobalPosition = interaction_source.GlobalPosition;
		Freeze = true;
		SetCanInteract(false);
		GD.Print("Picking up object");
    }

    public bool CanInteract()
    {
        return !isPickedUp;
    }

    public void OnRelease()
    {
		Freeze = false;
        SetCanInteract(true);
		Reparent(GetTree().Root);
    }

    public void SetCanInteract(bool new_value)
    {
        isPickedUp = !new_value;
		EmitSignal(SignalName.PickedUpStateChanged, !isPickedUp);
    }
}
