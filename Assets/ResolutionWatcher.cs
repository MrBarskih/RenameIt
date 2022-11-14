using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionWatcher : MonoBehaviour
{
    private int savedScreenWidth, savedScreenHeight;

    [Range(0.5f, 5f)]
    public float sec_in_check_window;

    void Start()
    {
        savedScreenWidth = Screen.width;
        savedScreenHeight = Screen.height;

        StartCoroutine(CheckIfScreenSizeWasChanged());
    }

    void Update()
    {
        
    }

    private IEnumerator CheckIfScreenSizeWasChanged()
    {
        while (true)
        {
            yield return new WaitForSeconds(sec_in_check_window);
            if (savedScreenHeight != Screen.height || savedScreenWidth != Screen.width)
            {
                savedScreenHeight = Screen.height;
                savedScreenWidth = Screen.width;
 
            }
        }
    }

}


