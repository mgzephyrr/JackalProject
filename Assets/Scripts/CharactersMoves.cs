using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersMoves : MonoBehaviour
{
    public Vector2 direction;
    public float Speed;

    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        transform.Translate(direction.normalized*Speed);
    }
}
