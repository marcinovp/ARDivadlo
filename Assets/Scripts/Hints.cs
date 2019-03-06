using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hints : MonoBehaviour
{
    public Image hintImage;
    public List<HintPair> hintPairs;

    void Start()
    {
        for (int i = 0; i < hintPairs.Count; i++)
        {
            int index = i;
            hintPairs[i].target.TargetFound += (x) => Target_TargetFound(index);
        }

        SetHint(0);
    }

    private void Target_TargetFound(int index)
    {
        int hintIndex = index + 1;
        Debug.Log("Target_TargetFound, index: " + index + ", hintujem index: " + hintIndex);

        SetHint(hintIndex);
    }

    private void SetHint(int index)
    {
        if (index >= 0 && index < hintPairs.Count)
        {
            hintImage.sprite = hintPairs[index].hintImage;
        }
        else
        {
            hintImage.sprite = null;
        }
    }
}

[System.Serializable]
public class HintPair
{
    public EasyAR.ImageTargetBaseBehaviour target;
    public Sprite hintImage;
}
