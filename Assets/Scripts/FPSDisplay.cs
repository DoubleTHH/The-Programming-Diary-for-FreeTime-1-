using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{
    FPSCounter fPSCounter;
    public Text highestFPSLabel, averageFPSLabel, lowestFPSLabel;

    [System.Serializable]
    private struct FPSColor
    {
        public Color color;
        public int minimumFPS;
    }

    [SerializeField]
    FPSColor[] coloring;
    private void Awake()
    {
        fPSCounter = GetComponent<FPSCounter>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Display(Text label , int fps)
    {
        label.text = Mathf.Clamp(fps, 0, 99).ToString();
        for (int i = 0; i < coloring.Length; i++)
        {
            if (fps >=coloring[i].minimumFPS)
            {
                label.color = coloring[i].color;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        highestFPSLabel.text =  Mathf.Clamp(fPSCounter.HighestFPS,0,99).ToString();
        averageFPSLabel.text = Mathf.Clamp(fPSCounter.AverageFPS,0,99).ToString();
        lowestFPSLabel.text = Mathf.Clamp(fPSCounter.LowestFPS, 0, 99).ToString();


        Display(highestFPSLabel, fPSCounter.HighestFPS);
        Display(averageFPSLabel, fPSCounter.AverageFPS);
        Display(lowestFPSLabel, fPSCounter.LowestFPS);
    }
}
