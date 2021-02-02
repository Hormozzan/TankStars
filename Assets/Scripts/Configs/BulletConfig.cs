using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "BulletConfig")]
public class BulletConfig : ScriptableObject
{
    public float force;
    public float damage;
    public float colision_radius;
}
