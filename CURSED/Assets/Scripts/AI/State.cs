using UnityEngine;
public abstract class State : ScriptableObject
{ 
    public bool IsFinished {get ; protected set; }
    [HideInInspector]public NPC NPC;
    public virtual void Init(){}
    public abstract void Run();
}