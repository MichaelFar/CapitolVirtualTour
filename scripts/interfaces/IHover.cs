using Godot;
using System;

public interface IHover
{
    
    public void OnHover();
    public void OffHover();
    public bool CanHover();

    public void SetCanHover(bool new_value);
}
