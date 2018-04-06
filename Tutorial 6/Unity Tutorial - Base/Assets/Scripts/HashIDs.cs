using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashIDs : MonoBehaviour
{
    public int dyingState;
    public int deadBool;
    public int walkState;
    public int shoutState;
    public int speedFloat;
    public int sneakingbool;
    public int shoutingbool;
    public int backwardsbool;
    public int jumpbool;
    void Awake()
    {
        dyingState = Animator.StringToHash("Base Layer.dying");
        deadBool = Animator.StringToHash("Dead");
        walkState = Animator.StringToHash("Walk");
        shoutState = Animator.StringToHash("Shouting.Shout");
        speedFloat = Animator.StringToHash("Speed");
        sneakingbool = Animator.StringToHash("Sneaking");
        shoutingbool = Animator.StringToHash("Shouting");
        backwardsbool = Animator.StringToHash("Backward");
        jumpbool = Animator.StringToHash("Jump");
    }

    void Update ()
    {
        
    }
    
}
