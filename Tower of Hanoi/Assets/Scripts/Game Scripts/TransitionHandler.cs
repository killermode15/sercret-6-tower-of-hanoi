using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransitionHandler : MonoBehaviour
{
    [Header("Transition Properties")]
    [SerializeField] private float transitionTime = 0.5f;

    [Header("References")]
    [Space(10)]
    [SerializeField] private Animator transitionAnimator = null;

    [Header("Transition Events")]
    [Space(10)]
    [SerializeField] private UnityEvent onTransitionStart = null;
    [SerializeField] private UnityEvent onTransitionEnd = null;

    private bool isTransitioning = false;

    public void StartTransition()
    {
        if(isTransitioning)
        {
            return;
        }

        isTransitioning = true;
        StartCoroutine(Transition_CR());
    }

    private IEnumerator Transition_CR()
    {
        transitionAnimator.SetTrigger("Start");
        onTransitionStart.Invoke();
        yield return new WaitForSeconds(transitionTime);
        transitionAnimator.SetTrigger("End");
        onTransitionEnd.Invoke();
        isTransitioning = false;
    }
}
