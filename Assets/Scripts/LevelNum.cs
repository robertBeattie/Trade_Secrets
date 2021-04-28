using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelNum : MonoBehaviour
{
    public TextMeshProUGUI num;
    LevelTransition levelTransition = new LevelTransition();
    // Start is called before the first frame update
    void Start()
    {
        num.SetText(levelTransition.getLevelnum());
    }
}
