using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUI : MonoBehaviour
{
    public float value=0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Slider>().value = value;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
