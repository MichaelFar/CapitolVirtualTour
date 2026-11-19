using Godot;
using System;

public partial class Paragraph : Label
{
	public void SetUpText(string textInput, LabelSettings settings){
		Text = textInput;
		LabelSettings = settings;
	}
}
