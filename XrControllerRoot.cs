using Godot;
using System;
public partial class XrControllerRoot : Node3D
{
    private XRInterface _xrInterface;

    public override void _Ready()
    {
        _xrInterface = XRServer.FindInterface("OpenXR");
        if(_xrInterface != null && _xrInterface.IsInitialized())
        {
            GD.Print("OpenXR initialized successfully");
            GD.Print("OS is " + OS.GetName());
            GD.Print("Device is " + OS.GetModelName());
            // Turn off v-sync!
            DisplayServer.WindowSetVsyncMode(DisplayServer.VSyncMode.Disabled);

            // Change our main viewport to output to the HMD
            GetViewport().UseXR = true;
        }
        else
        {
            GD.Print("OpenXR not initialized, please check if your headset is connected");
        }
    }
}