using System;
using System.Diagnostics;
/*Credit: https://github.com/dustinmorman/FPSControllerTutorial*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSControl : MonoBehaviour
{
    [SerializeField] private StatManager statManager;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float gravity = 10f;
    [SerializeField] private float lookSpeed = 8f;
    [SerializeField] private float lookXLimit = 45f;
    [SerializeField] private AudioClip walkingsound;
    [SerializeField] private float sprintTime = 5f;
    
    private Animator _animator;
    private CharacterController _characterController;

    private float _sprintMeter;
    
    private Animator _animator;
    private CharacterController _characterController;
    private AudioSource _audioSource;
    
    private float _rotationX;
    private float _walkSpeed;
    private float _runSpeed;
    private float _jumpPower;
    private bool _isJumping;
    private bool _wasRunning;
    private Vector3 _moveDirection = Vector3.zero;

    private void Awake()
    {
        _sprintMeter = sprintTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();

        //audio initialization
        _audioSource = GetComponent<AudioSource>();
        if(walkingsound != null)
        {
            _audioSource.clip = walkingsound;
            _audioSource.loop = true;
        }
        
        //animation initialization
        _animator = GetComponent<Animator>();
        if(_animator == null)
        {
            UnityEngine.Debug.LogError("Animator not found\n");
        }
        
        RefreshStats();
    }

    // Update is called once per frame
    void Update()
    {
        //Move
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        if (!_wasRunning && _sprintMeter < 0 || _sprintMeter <= -sprintTime) isRunning = false;
        
        // Not the right frame time, but will average out... probably
        if (isRunning) _sprintMeter -= Time.deltaTime;
        else _sprintMeter += Time.deltaTime;
        _sprintMeter = Mathf.Clamp(_sprintMeter, -sprintTime, sprintTime);
        
        _wasRunning = isRunning;
        
        float curSpeedX = (isRunning ? _runSpeed : _walkSpeed) * Input.GetAxis("Vertical");
        float curSpeedY = (isRunning ? _runSpeed : _walkSpeed) * Input.GetAxis("Horizontal");
        float moveDirectionY = _moveDirection.y;
        _moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        //animation update
        bool isWalking = (curSpeedX != 0f || curSpeedY != 0f);
        _animator.SetBool("isWalking", isWalking);
        _animator.SetBool("isRunning", isWalking && isRunning);

        //Jump
        if (Input.GetButton("Jump") && _characterController.isGrounded)
        {
            _moveDirection.y = _jumpPower;
            _isJumping = true;
            _animator.SetBool("isJumping", _isJumping);
        }
        else if (_characterController.isGrounded)
        {
            _isJumping = false;
            _animator.SetBool("isJumping", _isJumping);
        }

        else
        {
            _moveDirection.y = moveDirectionY;
        }

        if(!_characterController.isGrounded)
        {
            _moveDirection.y -= gravity * Time.deltaTime;
        }

        //Camera
        _characterController.Move(_moveDirection * Time.deltaTime);
        _rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        _rotationX = Mathf.Clamp(_rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    
        //audio
        if(isWalking && !_isJumping && !_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
        else if((!isWalking || _isJumping) && _audioSource.isPlaying)
        {
            _audioSource.Pause();
        }
    }

    public void RefreshStats()
    {
        _walkSpeed = statManager.GetStat(EStatType.WalkSpeed);
        _runSpeed = statManager.GetStat(EStatType.RunSpeed);
        _jumpPower = statManager.GetStat(EStatType.JumpPower);
    }
}