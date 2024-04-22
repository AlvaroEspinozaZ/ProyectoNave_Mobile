using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(fileName = "Prefabs_SO", menuName = "ScriptableObject/Prefabs_SO/prefabs", order = 1)]
public class Prefabs_SO : ScriptableObject
{
    public GameObject nave;
    public int id;
    public bool estatico = true;
    
}
