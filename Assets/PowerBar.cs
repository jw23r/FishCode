using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    public Scrollbar powerBar;
    public float powerBarSpeed;
    bool goingUp = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") && powerBar.value < 1 && goingUp == true)
        {
            print("its going up");

            powerBar.value += powerBarSpeed;
        }
        if(powerBar.value >= 1)
        {
            goingUp = false;
        }
        if (Input.GetKey("w") && goingUp == false)
        {
            print("its going down");

            powerBar.value -= powerBarSpeed;
        }
        if(powerBar.value <= 0)
        {
            goingUp = true;
        }
        if (Input.GetKeyUp("w") )
        {
            print("w's up");
            powerBar.value = 0;
        }
    }
}
