using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{
    private Animator mAnimator;
    public InputActionReference triggerRight;

    private bool hasTriggered = false;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (triggerRight.action.WasPressedThisFrame() && !hasTriggered)
        {
            mAnimator.SetTrigger("Shoot");
            hasTriggered = true;
        }
        else if (triggerRight.action.WasReleasedThisFrame())
        {
            hasTriggered = false;
        }
    }
}
