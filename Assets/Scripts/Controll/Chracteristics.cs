using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Characteristics", menuName = "Movement / Charactiristics", order = 1)]
public class Chracteristics : ScriptableObject
{
    [SerializeField] private bool _visibleCursor = false;

    [SerializeField] private float _movementSpeed = 1f;

    [SerializeField] private float _angleSpeed = 150f;
    
    [SerializeField] private float _gravity = 15;

    public bool VisiblityCursor => _visibleCursor;
    public float MovementSpeed => _movementSpeed;
    public float AngleSpeed => _angleSpeed;
    public float Gravity => _gravity;

}
