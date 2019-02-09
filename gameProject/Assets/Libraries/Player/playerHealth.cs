using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    private SliderController SliderControl;

    public Slider SliderObject;
    public Text TextSliderObject;
    public float MaxHP = 70;
    public float MinHP = 0;
    public float CurrentHP = 70;
    public bool Alive = true;

    // Start is called before the first frame update
    void Start()
    {
        SliderControl = new SliderController(SliderObject, TextSliderObject, CurrentHP, MinHP, MaxHP);
        //SliderControl.OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Alive)
        //{
        //    SliderControl.SubtractValue(1);
        //    CurrentHP--;
        //    if(CurrentHP <= MinHP)
        //    {
        //        Alive = false;
        //    }
        //}
    }
}
