using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private Vector2 MoveInput => new (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    
    [SerializeField] private float _speed;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _rigidbody2D.velocity = MoveInput * _speed;
    }
}
