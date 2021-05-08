using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothInsideSceneTransition : MonoBehaviour
{
        public GameObject sceneTransition;
        public GameObject disabledObj;
        public GameObject enabledObj;
        public bool closingTransitionFinished;

    public void SmoothSceneTransition()
    {
        sceneTransition.GetComponent<Animator>().SetTrigger("Close");
        StartCoroutine("OnCompleteCloseAnimation");
    }

    IEnumerator OnCompleteCloseAnimation()
    {
        while(sceneTransition.GetComponent<SceneTransition>().isClosingTransitionFinished == false)
        {
            yield return null;
        }
        sceneTransition.GetComponent<SceneTransition>().isClosingTransitionFinished = false;
        disabledObj.SetActive(false);
        enabledObj.SetActive(true);
        sceneTransition.GetComponent<Animator>().SetTrigger("Open");
    }
}