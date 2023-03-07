using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class StickmanController : MonoBehaviour
{

    public Animator animator;
    [SerializeField] private float _animationSpeed;

    public int level;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = _animationSpeed;
    }

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            EventManager.E_StickmansManager.Invoke().AddObj(this);
        }
    }
    private void OnDisable()
    {
        if (!gameObject.activeInHierarchy)
        {
            EventManager.E_StickmansManager.Invoke().RemoveObj(this);
        }
    }

}
