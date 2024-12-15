using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class ThrusterFly : MonoBehaviour
{
    public Transform rightHandTransform;
    public Transform leftHandTransform;
    public Rigidbody playerRigidbody;
    public float thrusterAmount = 1.0f;
    public ParticleSystem rightFlameThrower;
    public ParticleSystem leftFlameThrower;
    public AudioClip thrusterSound; // Sound effect to play
    private AudioSource rightThrusterAudio; // Right hand thruster AudioSource
    private AudioSource leftThrusterAudio;  // Left hand thruster AudioSource

    [SerializeField] private InputActionReference toggleRightHandAction;
    [SerializeField] private InputActionReference toggleLeftHandAction;

    private bool isRightHandActive;
    private bool isLeftHandActive;
    private float halfThrusterAmount;

    private void Awake()
    {
        rightThrusterAudio = gameObject.AddComponent<AudioSource>();
        rightThrusterAudio.clip = thrusterSound;
        rightThrusterAudio.loop = true;

        leftThrusterAudio = gameObject.AddComponent<AudioSource>();
        leftThrusterAudio.clip = thrusterSound;
        leftThrusterAudio.loop = true;

        toggleRightHandAction.action.started += OnRightHandStarted;
        toggleRightHandAction.action.canceled += OnRightHandCanceled;

        toggleLeftHandAction.action.started += OnLeftHandStarted;
        toggleLeftHandAction.action.canceled += OnLeftHandCanceled;

        rightFlameThrower.Stop();
        leftFlameThrower.Stop();
    }

    private void Update()
    {
        halfThrusterAmount = thrusterAmount / 1.5f;
    }

    private void OnEnable()
    {
        toggleRightHandAction.action.Enable();
        toggleLeftHandAction.action.Enable();
    }

    private void OnDisable()
    {
        toggleRightHandAction.action.Disable();
        toggleLeftHandAction.action.Disable();
    }

    private void OnRightHandStarted(InputAction.CallbackContext context)
    {
        isRightHandActive = true;
        rightFlameThrower.Play();
        if (!rightThrusterAudio.isPlaying)
        {
            rightThrusterAudio.Play();
        }
    }

    private void OnRightHandCanceled(InputAction.CallbackContext context)
    {
        isRightHandActive = false;
        rightFlameThrower.Stop();
        if (rightThrusterAudio.isPlaying)
        {
            rightThrusterAudio.Stop();
        }
    }

    private void OnLeftHandStarted(InputAction.CallbackContext context)
    {
        isLeftHandActive = true;
        leftFlameThrower.Play();
        if (!leftThrusterAudio.isPlaying)
        {
            leftThrusterAudio.Play();
        }
    }

    private void OnLeftHandCanceled(InputAction.CallbackContext context)
    {
        isLeftHandActive = false;
        leftFlameThrower.Stop();
        if (leftThrusterAudio.isPlaying)
        {
            leftThrusterAudio.Stop();
        }
    }

    private void FixedUpdate()
    {
        Vector3 rightHandThrustDirection = -rightHandTransform.forward;
        Vector3 leftHandThrustDirection = -leftHandTransform.forward;

        Vector3 thrustDirection = Vector3.zero;

        if (isRightHandActive && isLeftHandActive)
        {
            thrustDirection = (rightHandThrustDirection + leftHandThrustDirection).normalized;
            playerRigidbody.AddForce(thrustDirection * thrusterAmount, ForceMode.Acceleration);
        }
        else if (isRightHandActive)
        {
            thrustDirection = rightHandThrustDirection;
            playerRigidbody.AddForce(thrustDirection * halfThrusterAmount, ForceMode.Acceleration);
        }
        else if (isLeftHandActive)
        {
            thrustDirection = leftHandThrustDirection;
            playerRigidbody.AddForce(thrustDirection * halfThrusterAmount, ForceMode.Acceleration);
        }
    }
}