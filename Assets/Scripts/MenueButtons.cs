using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenueButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject camrea1;
    public GameObject camrea2;
    public GameObject menue;
    public void OpenMenue()
    {
        if (menue.activeSelf == true)
        {
            menue.SetActive(false);
        }
        else
        {
            menue.SetActive(true);
        }
    }
    public void ChangeCamera()
    {
        if (camrea1.activeSelf == true)
        {
            camrea1.SetActive(false);
            if (camrea2.activeSelf == false) camrea2.SetActive(true);
        }
        else
        {
            if (camrea2.activeSelf == true)
            {
                camrea2.SetActive(false);
                if (camrea1.activeSelf == false) camrea1.SetActive(true);

            }
        }
    }
}
