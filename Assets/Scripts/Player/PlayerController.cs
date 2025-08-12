using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator PlayerAnimator;

    void Awake()
    {
        PlayerAnimator = GetComponent<Animator>();
    }

    
    public void PlaySuccessAnimation()
    {
        PlayerAnimator.SetTrigger("Success");
    }

    public void PlayFailAnimation()
    {
        PlayerAnimator.SetTrigger("Fail");
    }
    
}
