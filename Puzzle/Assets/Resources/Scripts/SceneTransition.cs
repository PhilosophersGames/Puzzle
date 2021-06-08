using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public Animator animator;

    public bool isClosingTransitionFinished = false;
    
    private void Start()
    {
        PlayOpenSceneTransition();
    }
    public void PlayOpenSceneTransition()
    {
        animator.SetTrigger("Open");
    }
        public void PlayCloseSceneTransition()
    {
        animator.SetTrigger("Close");
    }

    public void ClosedSceneTransitionFinished()
    {
            isClosingTransitionFinished = true;
    }
}
