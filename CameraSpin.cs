using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSpin : MonoBehaviour
{
    public float spinRate;
    public BoidController[] dragoids;
    public BoidController[] flockDragoids;
    public Vector3 centerOfFlock;
    public Quaternion rotation;
    public float x;
    public float y;
    public float z;
    public bool spinCamera;
    public Toggle cameraSpinToggle;

    // Start is called before the first frame update
    void Start()
    {
        spinCamera = cameraSpinToggle.isOn;
    }

    public void FixedUpdate()
    {
        x = 0;
        y = 0;
        z = 0;
        if (Time.time >= 0.25f && dragoids.Length == 0)
        {
            this.refreshBoidArray();
        }
        if (flockDragoids != null && flockDragoids.Length > 0)
        {
            //centerOfFlock = Vector3.zero;
            foreach (BoidController dragoid in flockDragoids)
            {
                //centerOfFlock += dragoid.transform.position;
                x += dragoid.transform.position.x;
                y += dragoid.transform.position.y;
                z += dragoid.transform.position.z;
            }
            x /= flockDragoids.Length;
            y /= flockDragoids.Length;
            z /= flockDragoids.Length;
            centerOfFlock = new Vector3(x, y, z);
            //centerOfFlock /= dragoids.Length;
            this.transform.position = centerOfFlock;
        }
        if (spinCamera)
        {
            rotation = Quaternion.Euler(0, this.transform.rotation.eulerAngles.y + spinRate * Time.deltaTime, 0);
            this.transform.rotation = rotation;
        }
    }

    public void refreshBoidArray()
    {
        dragoids = FindObjectsOfType<BoidController>();
        Debug.Log("Number of dragoids " + dragoids.Length.ToString());
        int numberOfFlockDragoids = 0;
        foreach (BoidController boid in dragoids)
        {
            if (boid.gameObject.layer == 8)
            {
                numberOfFlockDragoids++;
            }
        }
        Debug.Log("flock " + numberOfFlockDragoids.ToString());
        flockDragoids = new BoidController[numberOfFlockDragoids];
        int currentDragoid = 0;
        foreach (BoidController boid in dragoids)
        {
            if (boid.gameObject.layer == 8)
            {
                flockDragoids[currentDragoid] = boid;
                currentDragoid++;
            }
        }
    }

    public void toggleCameraSpin()
    {
        spinCamera = cameraSpinToggle.isOn;
    }
}
