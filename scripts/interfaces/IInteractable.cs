using Godot;
using System;

public interface IInteractable
{
    public void OnInteract(Node3D interaction_source);
    public bool CanInteract();

    public void SetCanInteract(bool new_value);

    public void OnRelease();
}
