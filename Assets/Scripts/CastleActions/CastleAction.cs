using UnityEngine;
public abstract class CastleAction : ScriptableObject
{
    public string _name;
    
    public abstract void TriggerAction(Castle target,int val);
}
