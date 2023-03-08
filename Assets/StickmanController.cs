using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class StickmanController : MonoBehaviour
{

    public Transform obj_Main;

    public Animator animator;
    [SerializeField] private float _animationSpeed;

    public int level;

    private void Start()
    {
        animator.speed = _animationSpeed;
    }

}
