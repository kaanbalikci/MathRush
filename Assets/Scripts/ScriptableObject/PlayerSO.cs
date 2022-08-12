using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new player settings",menuName ="Player Settings")]
public class PlayerSO : ScriptableObject
{
    public GameObject Camera;
    public float speed = 10f;
}
