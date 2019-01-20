using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : Health
{
    public Slider heathSlider;
    public Text textHPNumber;
    // Start is called before the first frame update
    void Start()
    {
        heathSlider.value = HP/maxHP;
        textHPNumber.text = HP.ToString()+'/'+maxHP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        changeHP(-1);
        heathSlider.value = HP / maxHP;
        textHPNumber.text = HP.ToString() + '/' + maxHP.ToString();
    }
}
