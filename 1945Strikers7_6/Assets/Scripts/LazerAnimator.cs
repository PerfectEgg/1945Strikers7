using UnityEngine;

public class LazerAnimator : MonoBehaviour
{
    Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Stay()
    {
        animator.SetTrigger("isStay");
    }

    public void End()
    {
        animator.SetTrigger("isEnd");
    }
}
