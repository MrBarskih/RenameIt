using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ResolutionWatcher : MonoBehaviour
{
    private int savedScreenWidth, savedScreenHeight;

    [Range(0.5f, 5f)]
    public float sec_in_check_window;

    private IEnumerable<IResizable> resObjs;

    void Start()
    {
        savedScreenWidth = Screen.width;
        savedScreenHeight = Screen.height;

        resObjs = FindObjectsOfType<MonoBehaviour>().OfType<IResizable>();

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

                foreach (IResizable resObj in resObjs)
                    resObj.ResizeIfWindowsWasChanged();
            }
        }
    }

}


