using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhaseText : MonoBehaviour
{
    public TMP_Text phase;
    private float appearTime = 2f;
    private float disappearTime;
    // Start is called before the first frame update
    void Start()
    {
        phase.enabled = true;
        disappearTime = Time.time + appearTime;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (phase.enabled && (Time.time >= disappearTime))
        {
            phase.enabled = false;
        }
    }
}
