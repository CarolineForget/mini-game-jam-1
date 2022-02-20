using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Source : https://www.youtube.com/watch?v=8ZxVBCvJDWk&list=WL&index=89&t=47s&ab_channel=Tarodev

    // Inputs variables
    private PlayerInput _inputs;

    private Vector2 _moveInput;

    // Character variables
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _initialSpeed = 12.5f;
    private float playerSpeed;
    [SerializeField] private float _turnSpeed = 360f;

    private float speedRamp = 0; //
    private float smoothTime = 0.085f;
    private float smoothingV = 0;

    private Vector3 moveDirection;

    // TEST
    [SerializeField] AudioSource _audiosrc;
    [SerializeField] AudioClip _crash_sound;
    [SerializeField] AudioClip _horn_sound;
    [SerializeField] AudioClip _start_sound;


    private void Awake() {
        _inputs = new PlayerInput();

        _inputs.Player.Move.performed += OnMove;
        _inputs.Player.Move.canceled += OnMove;

        _inputs.Player.Interact.performed += OnInteractPerformed;
        _inputs.Player.Interact.canceled += OnInteractCanceled;

         _audiosrc.PlayOneShot(_start_sound, 2f);
         Invoke("StopStart", 5f);
    }

    private void StopStart() {
        _audiosrc.Stop();
    }

    private void Start()
    {
        playerSpeed = _initialSpeed;
    }


    private void OnEnable() {
        _inputs.Enable();
    }

    private void OnDisable() {
        _inputs.Disable();
    }

    private void FixedUpdate() {
        Move();
        Look();
    }

    public void OnMove(InputAction.CallbackContext context) {
        _moveInput = context.ReadValue<Vector2>();
    }

    public void OnInteractPerformed(InputAction.CallbackContext context) {
        _audiosrc.PlayOneShot(_horn_sound);
    }

    public void OnInteractCanceled(InputAction.CallbackContext context) {
        _audiosrc.Stop();
    }

    private void Look() {
        if (moveDirection != Vector3.zero) {
            var relative = (transform.position + moveDirection) - transform.position;
            var rotation = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _turnSpeed * Time.deltaTime);
        }
    }

    private void Move() {
        speedRamp = Mathf.SmoothDamp(speedRamp, _moveInput.x, ref smoothingV, smoothTime);

        moveDirection = new Vector3(speedRamp, 0, 0);

        _rb.MovePosition(transform.position + moveDirection * playerSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.tag == "Box") {
            _audiosrc.PlayOneShot(_crash_sound);
            SceneManager.LoadScene("EndingScene");
        }

        if (collision.gameObject.tag == "Wall") {
            _audiosrc.PlayOneShot(_crash_sound, 0.2f);
        }

    }


}
