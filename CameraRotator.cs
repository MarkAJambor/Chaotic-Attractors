using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRotator : MonoBehaviour
{
    public float rotationRate;
    public Quaternion rotation;
    public bool shouldRotate = true;
    public Slider directionSlider;
    public Slider speedSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FixedUpdate()
    {
        if (shouldRotate)
        {
            if (directionSlider.value == 0)
            {
                //rotation = Quaternion.Euler(this.transform.localRotation.eulerAngles.x, this.transform.localRotation.eulerAngles.y + rotationRate * Time.deltaTime * speedSlider.value, 0);
                this.transform.Rotate(0, rotationRate * Time.deltaTime * speedSlider.value, 0);
            }
            else
            {
                //rotation = Quaternion.Euler(this.transform.localRotation.eulerAngles.x + rotationRate * Time.deltaTime * speedSlider.value, this.transform.localRotation.eulerAngles.y, 0);
                this.transform.Rotate(rotationRate * Time.deltaTime * speedSlider.value, 0, 0);
            }
            //this.transform.localRotation = rotation;
        }
        if (Mathf.Abs(speedSlider.value) < 0.1f)
        {
            speedSlider.value = 0;
        }
    }

    
}
