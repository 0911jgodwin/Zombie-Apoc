using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HordeBehaviour : ScriptableObject
{
    public abstract Vector2 CalculateMove(Zombie zombie, List<Transform> context, Horde horde);

}
