using Godot;
using System;

public interface IHighlight
{
    
    public void OnHighlight();
    public void OffHighlight();
    public bool CanHighlight();
}
