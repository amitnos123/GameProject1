using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController
{
    private Slider SliderObject;
    private Text TextSliderObject;

    public float CurrentValue;
    public float MinValue;
    public float MaxValue;
    public string TextFormat;

    public Text TextSlider
    {
        get { return this.TextSliderObject; }
    }

    public Slider SliderObj
    {
        get { return this.SliderObject; }
    }

    private float SliderValue
    {
        get { return CurrentValue / ValueRangeSize; }
        set { CurrentValue = value * ValueRangeSize; }
    }

    private float ValueRangeSize
    {
        get { return (MaxValue - MinValue); }
    }

    private string TextValue
    {
        get { return String.Format(TextFormat, CurrentValue, MaxValue); }
    }


    public SliderController(Slider SliderObject)
    {
        this.SliderObject = SliderObject;
        TextSliderObject = null;

        UpdateScreen();
        this.SliderObject.maxValue = 1;
        this.SliderObject.minValue = 0;
    }

    public SliderController(Slider SliderObject, Text TextSliderObject)
    {
        this.SliderObject = SliderObject;
        this.TextSliderObject = TextSliderObject;
        this.TextFormat = "{0}/{1}";

        UpdateScreen();
        this.SliderObject.maxValue = 1;
        this.SliderObject.minValue = 0;
    }

    public SliderController(Slider SliderObject, Text TextSliderObject, string TextFormat)
    {
        this.SliderObject = SliderObject;
        this.TextSliderObject = TextSliderObject;
        this.TextFormat = TextFormat;

        UpdateScreen();
        this.SliderObject.maxValue = 1;
        this.SliderObject.minValue = 0;
    }

    public SliderController(Slider SliderObject, Text TextSliderObject, float CurrentValue, float MinValue, float MaxValue)
    {
        this.SliderObject = SliderObject;
        this.TextSliderObject = TextSliderObject;
        this.CurrentValue = CurrentValue;
        this.MinValue = MinValue;
        this.MaxValue = MaxValue;
        this.TextFormat = "{0}/{1}";

        UpdateScreen();
        this.SliderObject.maxValue = 1;
        this.SliderObject.minValue = 0;
    }

    public SliderController(Slider SliderObject, Text TextSliderObject, string TextFormat, float CurrentValue, float MinValue, float MaxValue)
    {
        this.SliderObject = SliderObject;
        this.TextSliderObject = TextSliderObject;
        this.CurrentValue = CurrentValue;
        this.TextFormat = TextFormat;
        this.MinValue = MinValue;
        this.MaxValue = MaxValue;

        UpdateScreen();
        this.SliderObject.maxValue = 1;
        this.SliderObject.minValue = 0;
    }


    public void ChangeValue(float Change)
    {
        if (CurrentValue + Change > MaxValue)
        {
            CurrentValue = MaxValue;
        }
        else if (CurrentValue + Change < MinValue)
        {
            CurrentValue = MinValue;
        }
        else
        {
            CurrentValue += Change;
        }
        
        UpdateScreen();
    }

    public void AddValue(float Add)
    {
        if (CurrentValue + Add > MaxValue)
        {
            CurrentValue = MaxValue;
        }
        else
        {
            CurrentValue += Add;
        }

    
        UpdateScreen();
    }

    public void SubtractValue(float Subtract)
    {
        if (CurrentValue - Subtract < MinValue)
        {
            CurrentValue = MinValue;
        }
        else
        {
            CurrentValue -= Subtract;
        }
        
        UpdateScreen();
    }


    private void UpdateScreen()
    {
        SliderObject.value = SliderValue;
        if (TextSliderObject != null)
        {
            TextSliderObject.text = TextValue;
        }
    }
}
