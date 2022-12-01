using System;

[Serializable]
public struct Hint
{
    public string hintText;
    public int hintID;
    public bool active;

    public Hint(string text, int iD, bool isActive)
    {
        this.hintText = text;
        this.hintID = iD;
        this.active = isActive;
    }

}
