using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingEffect : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private static readonly int _bounceParameterHash = Animator.StringToHash("Bounce");

    public void PlayBounce()
    {
        animator.Play(_bounceParameterHash);
    }
}
