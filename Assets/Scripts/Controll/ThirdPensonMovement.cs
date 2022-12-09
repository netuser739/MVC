using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ThirdPensonMovement : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Chracteristics _characteristics;

    private float vertical;

    private string STR_Vertical = "Vertical";

    private readonly float DISTANCE_CAMERA_OFFSET = 5f;

    private CharacterController _controller;
    private Animator _animator;

    private Vector3 direction;
    private Quaternion look;

    private Vector3 TargetRotate => _camera.forward * DISTANCE_CAMERA_OFFSET;


    void Start()
    {
        _controller = GetComponent<CharacterController>();

        _animator = GetComponent<Animator>();

        Cursor.visible = _characteristics.VisiblityCursor;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotate();
    }

    void Movement()
    {
        if (_controller.isGrounded)
        {
            vertical = Input.GetAxis(STR_Vertical);
            direction = transform.TransformDirection(0f, 0f, vertical).normalized;
        }

        direction.y -= _characteristics.Gravity * Time.deltaTime;

        Vector3 dir = direction * _characteristics.MovementSpeed * Time.deltaTime;

        _controller.Move(dir);
    }

    void Rotate()
    {
        Vector3 target = TargetRotate;
        target.y = 0f;

        look = Quaternion.LookRotation(target);

        float speed = _characteristics.AngleSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, look, speed);

    }
}
