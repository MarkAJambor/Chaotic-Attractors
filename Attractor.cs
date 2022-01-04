using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attractor : MonoBehaviour
{
    public float deltax = 1;
    public float deltay = 1;
    public float deltaz = 1;
    public float w = 1;
    public float x = 0;
    public float y = 0;
    public float z = 0;
    public TrailRenderer trail;
    public Dropdown attractorSelecter;
    public Text equationText;
    public GameObject cameraObject;
    public bool selecterWasUpdated = true;
    public Toggle equationToggle;

    // Start is called before the first frame update
    void Start()
    {
        //Time.fixedDeltaTime = (1 / 300);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void FixedUpdate()
    {
        if (attractorSelecter.captionText.text == "Lorenz")
        {
            equationText.text = ("x=10(-x+y)" + "\n" + "y=(-xz+28x-y)" + "\n" + "z=xy-(8/3)z");
            //Lorenz
            //starting point: 6, 8, 20
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(6, 8, 20);
                trail.Clear();
            }
            cameraObject.transform.localScale = new Vector3(1, 1, 1);
            cameraObject.transform.position = new Vector3(0, 0, 28);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            deltax = (10 * (-x + y)) * Time.deltaTime / 2;
            deltay = (-x * z + 28 * x - y) * Time.deltaTime / 2;
            deltaz = (x * y - (8 / 3) * z) * Time.deltaTime / 2;
        }
        else if (attractorSelecter.captionText.text == "Lorenz84")
        {
            equationText.text = ("x=-0.95x-y^2-z^2+4.59" + "\n" + "y=-y+xy-7.91xz+4.66" + "\n" + "z=-z+7.91xy+xz");
            //Lorenz84
            //starting point: 1, 1, 1
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(1, 1, 1);
                trail.Clear();
            }
            this.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            cameraObject.transform.position = new Vector3(0f, 0f, 0f);
            cameraObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            deltax = (-0.95f * x - y * y - z * z + 0.95f * 4.83f) * Time.deltaTime * 0.7f;
            deltay = (-y + x * y - 7.91f * x * z + 4.66f) * Time.deltaTime * 0.7f;
            deltaz = (-z + 7.91f * x * y + x * z) * Time.deltaTime * 0.7f;
        }
        else if (attractorSelecter.captionText.text == "Aizawa")
        {
            equationText.text = ("x=(z-0.7)x-3.5y" + "\n" + "y=3.5x+(z-0.7)y" + "\n" + "z=0.6+0.95z-z^3/3-(x^2+y^2)(1+0.25z)+0.1zx^3");
            //Aizawa
            //starting point: 1.01, 1.02, 1.03
            //timestep 1/300
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(1.01f, 1.02f, 1.03f);
                trail.Clear();
            }
            Time.fixedDeltaTime = 0.003f;
            this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            cameraObject.transform.position = new Vector3(0f, 0f, 0f);
            cameraObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            deltax = ((z - 0.7f) * x - 3.5f * y) * Time.deltaTime;
            deltay = (3.5f * x + (z - 0.7f) * y) * Time.deltaTime;
            deltaz = (0.6f + 0.95f * z - (z * z * z) / 3 - (x * x + y * y) * (1 + 0.25f * z) + 0.1f * z * x * x * x) * Time.deltaTime;
        }
        else if (attractorSelecter.captionText.text == "Dadras")
        {
            equationText.text = ("x=y-3x+2.7yz" + "\n" + "y=1.7y-xz+z" + "\n" + "z=2xy-9z");
            //Dadras
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(1, 1, 1);
                trail.Clear();
            }
            Time.fixedDeltaTime = 0.01f;
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            cameraObject.transform.position = new Vector3(0f, 0f, 0f);
            cameraObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            deltax = (y - 3 * x + 2.7f * y * z) * Time.deltaTime;
            deltay = (1.7f * y - x * z + z) * Time.deltaTime;
            deltaz = (2 * x * y - 9 * z) * Time.deltaTime;
        }
        else if (attractorSelecter.captionText.text == "Thomas")
        {
            equationText.text = ("x=sin(y)-xpi/15.7" + "\n" + "y=sin(z)-ypi/15.7" + "\n" + "z=sin(x)-zpi/15.7");
            //Thomas
            //starting point: 1.001, 2.002, 3.003
            //starting point: 1.1, 1.1, -0.01
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(1.1f, 1.1f, -0.01f);
                trail.Clear();
            }
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            cameraObject.transform.position = new Vector3(0f, 0f, 0f);
            cameraObject.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            deltax = (Mathf.Sin(y) - Mathf.PI / 15.7f * x) * Time.deltaTime * 2;
            deltay = (Mathf.Sin(z) - Mathf.PI / 15.7f * y) * Time.deltaTime * 2;
            deltaz = (Mathf.Sin(x) - Mathf.PI / 15.7f * z) * Time.deltaTime * 2;
        }
        else if (attractorSelecter.captionText.text == "Chen")
        {
            equationText.text = ("x=400(y-x)" + "\n" + "y=-120x-10xz+280y" + "\n" + "z=10xy-30z");
            //Chen
            //starting point: -10, -4.4, 28.6
            //Time.fixedDeltaTime = 0.0004f; //without the "/50" after deltaTime
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(-10, -4.4f, 28.6f);
                trail.Clear();
            }
            cameraObject.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
            cameraObject.transform.position = new Vector3(1.2f, -1.1f, 20.4f);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            deltax = (400 * (y - x)) * Time.deltaTime / 50;
            deltay = (-120 * x - 10 * x * z + 280 * y) * Time.deltaTime / 50;
            deltaz = (10 * x * y - 30 * z) * Time.deltaTime / 50;
        }
        else if (attractorSelecter.captionText.text == "Lu Chen")
        {
            equationText.text = ("x=36(y-x)" + "\n" + "y=x-xz+20y" + "\n" + "z=xy-3z");
            //Lu Chen
            //starting point: 1, 2, 3
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(1, 2, 3);
                trail.Clear();
            }
            cameraObject.transform.localScale = new Vector3(2, 2, 2);
            cameraObject.transform.position = new Vector3(3.3f, 3.1f, 27.1f);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            deltax = (36 * (y - x)) * Time.deltaTime / 10;
            deltay = (x - x * z + 20 * y) * Time.deltaTime / 10;
            deltaz = (x * y - 3 * z) * Time.deltaTime / 10;
        }
        else if (attractorSelecter.captionText.text == "Chua")
        {
            equationText.text = ("x=10.82(y-h)" + "\n" + "y=x-y+z" + "\n" + "z=-14.286y" + "\n" + "h=-0.11sin(xpi/2.6)");
            //cameraObject.GetComponentInChildren<CameraRotator>().shouldRotate = false;
            //Chua
            //starting point: 1, 1, 0
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(1, 1, 0);
                trail.Clear();
            }
            cameraObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            cameraObject.transform.position = new Vector3(-3, 0, 4);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            float h = -0.11f * Mathf.Sin(Mathf.PI * x / (2 * 1.3f));
            deltax = (10.82f * (y - h)) * Time.deltaTime * 1.5f;
            deltay = (x - y + z) * Time.deltaTime * 1.5f;
            deltaz = (-14.286f * y) * Time.deltaTime * 1.5f;
        }
        else if (attractorSelecter.captionText.text == "Rabinovich Fabrikant")
        {
            equationText.text = ("x=y(z-1+x^2)_0.1x" + "\n" + "y=x(3z+1-x^2)" + "\n" + "z=-2z(0.14+xy)");
            //Rabinovich Fabrikant
            //starting point: -1, 0, 0.5
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(-1, 0, 0.5f);
                trail.Clear();
            }
            Time.fixedDeltaTime = 0.001f;
            cameraObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            cameraObject.transform.position = new Vector3(-1.37f, 0.245f, 0.34f);
            this.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            //deltax = (y * (z - 1 + x * x) + 0.87f * x) * Time.deltaTime;
            //deltay = (x * (3 * z + 1 - x * x) + 0.87f * y) * Time.deltaTime;
            //deltaz = (-2 * z * (1.1f + x * y)) * Time.deltaTime;
            deltax = (y * (z - 1 + x * x) + 0.1f * x) * Time.deltaTime;
            deltay = (x * (3 * z + 1 - x * x) + 0.1f * y) * Time.deltaTime;
            deltaz = (-2 * z * (0.14f + x * y)) * Time.deltaTime;
        }
        else if (attractorSelecter.captionText.text == "Rabinovich Fabrikant Unstable")
        {
            equationText.text = ("x=y(z-1+x^2)+0.05" + "\n" + "y=x(3z+1-x^2)+0.05" + "\n" + "z=-2z(0.05+xy)");
            //Rabinovich Fabrikant 2 (unstable eventually)
            //starting point: -0.37, -0.2, 0.5
            if (selecterWasUpdated || this.transform.position.magnitude > 6)
            {
                this.transform.position = new Vector3(-0.37f, -0.2f, 0.5f);
                trail.Clear();
            }
            Time.fixedDeltaTime = 0.002f;
            cameraObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            cameraObject.transform.position = new Vector3(0.46f, 0f, 0.14f);
            this.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            deltax = (y * (z - 1 + x * x) + 0.05f * x) * Time.deltaTime;
            deltay = (x * (3 * z + 1 - x * x) + 0.05f * y) * Time.deltaTime;
            deltaz = (-2 * z * (0.05f + x * y)) * Time.deltaTime;
        }
        else if (attractorSelecter.captionText.text == "Rabinovich Fabrikant 2")
        {
            equationText.text = ("x=y(z-1+x^2)+0.1x" + "\n" + "y=x(3z+1-x^2)+0.1y" + "\n" + "z=-2z(0.14+xy)");
            //Rabinovich Fabrikant 3 (really cool after some time)
            //starting point: -1, 0, 0.5
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(-1, 0, 0.5f);
                trail.Clear();
            }
            Time.fixedDeltaTime = 0.001f;
            cameraObject.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            cameraObject.transform.position = new Vector3(-0.08f, -0.09f, 0.34f);
            this.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            deltax = (y * (z - 1 + x * x) + 0.1f * x) * Time.deltaTime;
            deltay = (x * (3 * z + 1 - x * x) + 0.1f * y) * Time.deltaTime;
            deltaz = (-2 * z * (0.14f + x * y)) * Time.deltaTime;
        }
        else if (attractorSelecter.captionText.text == "Rossler")
        {
            equationText.text = ("x=-(y+z)" + "\n" + "y=x+0.16y" + "\n" + "z=0.73+z(x-7.85)");
            //Rossler
            //starting point: -7.7, -3.29, 8.94
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(-7.7f, -3.29f, 8.94f);
                trail.Clear();
            }
            Time.fixedDeltaTime = 0.01f;
            cameraObject.transform.localScale = new Vector3(1f, 1f, 1f);
            cameraObject.transform.position = new Vector3(0,0,0);
            this.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            deltax = (-(y + z)) * Time.deltaTime * 2;
            deltay = (x + 0.16f * y) * Time.deltaTime * 2;
            deltaz = (0.73f + z * ( x - 7.85f)) * Time.deltaTime * 2;
        }
        else if (attractorSelecter.captionText.text == "Rossler 2")
        {
            equationText.text = ("x=-(y+z)" + "\n" + "y=x+0.47y" + "\n" + "z=6.85+z(x-8.89)");
            //Rossler 2
            //starting point: -7.7, -3.29, 8.94
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(-7.7f, -3.29f, 8.94f);
                trail.Clear();
            }
            Time.fixedDeltaTime = 0.01f;
            cameraObject.transform.localScale = new Vector3(1f, 1f, 1f);
            cameraObject.transform.position = new Vector3(0, 0, 0);
            this.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            deltax = (-(y + z)) * Time.deltaTime * 2;
            deltay = (x + 0.47f * y) * Time.deltaTime * 2;
            deltaz = (6.85f + z * (x - 8.89f)) * Time.deltaTime * 2;
        }
        else if (attractorSelecter.captionText.text == "Halvorsen")
        {
            equationText.text = ("x=-1.89x-4y-4z-y^2" + "\n" + "y=-1.89y-4z-4x-z^2" + "\n" + "z=-1.89z-4x-4y-x^2");
            //Halvorsen
            //starting point: -1.48, -1.51, 2.04
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(-1.48f, -1.51f, 2.04f);
                trail.Clear();
            }
            Time.fixedDeltaTime = 0.02f;
            cameraObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            cameraObject.transform.position = new Vector3(-3.89f, -3.13f, -3.19f);
            this.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            deltax = (-1.89f * x - 4* y - 4 * z - y * y) * Time.deltaTime / 2;
            deltay = (-1.89f * y - 4 * z - 4 * x - z * z) * Time.deltaTime / 2;
            deltaz = (-1.89f * z - 4 * x - 4 * y - x * x) * Time.deltaTime / 2;
        }
        else if (attractorSelecter.captionText.text == "Sprott")
        {
            equationText.text = ("x=y+2.07xy+xz" + "\n" + "y=1-1.79x^2+yz" + "\n" + "z=x-x^2-y^2");
            //Sprott
            //starting point: 0.63, 0.47, -0.54
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(-0.63f, 0.47f, -0.54f);
                trail.Clear();
            }
            Time.fixedDeltaTime = 0.01f;
            cameraObject.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);
            cameraObject.transform.position = new Vector3(0.754f, 0.087f, -0.112f);
            this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            float a = 2.07f;
            float b = 1.79f;
            deltax = (y + a * x * y + x * z) * Time.deltaTime;
            deltay = (1 - b * x * x + y * z) * Time.deltaTime;
            deltaz = (x - x * x - y * y) * Time.deltaTime;
        }
        else if (attractorSelecter.captionText.text == "Sprott 2")
        {
            equationText.text = ("x=y+2.08xy+xz" + "\n" + "y=1-1.72x^2+yz" + "\n" + "z=x-x^2-y^2");
            //Sprott 2
            //starting point: 0.57, 0.1, 0.01
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(0.57f, 0.1f, 0.01f);
                trail.Clear();
            }
            Time.fixedDeltaTime = 0.01f;
            cameraObject.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);
            cameraObject.transform.position = new Vector3(0.754f, 0.087f, -0.112f);
            this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            float a = 2.08f;
            float b = 1.72f;
            deltax = (y + a * x * y + x * z) * Time.deltaTime;
            deltay = (1 - b * x * x + y * z) * Time.deltaTime;
            deltaz = (x - x * x - y * y) * Time.deltaTime;
        }
        else if (attractorSelecter.captionText.text == "Four-Wing")
        {
            equationText.text = ("x=0.1x+yz" + "\n" + "y=0.01x-0.4y-xz" + "\n" + "z=-z-xy");
            //Four Wing
            //starting point: 1.3, -0.18, 0.01
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(1.3f, -0.18f, 0.01f);
                trail.Clear();
            }
            Time.fixedDeltaTime = 0.02f;
            cameraObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            cameraObject.transform.position = new Vector3(0, 0, 0);
            this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            float a = 0.2f;
            float b = 0.01f;
            float c = -0.4f;
            deltax = (a * x + y * z) * Time.deltaTime * 3;
            deltay = (b * x + c * y - x * z) * Time.deltaTime * 3;
            deltaz = (-z - x * y) * Time.deltaTime * 3;
        }
        else if (attractorSelecter.captionText.text == "Hyperchaotic 4D")
        {
            equationText.text = ("x=x(1-y)-2z" + "\n" + "y=(x^2-1)y" + "\n" + "z=0.2(1-y)w" + "\n" + "w=z");
            //Hyperchaotic 4D
            //starting point: 1,2,3,1
            //starting point2: 1,1,1,1
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(1, 1, 1);
                w = 1;
                trail.Clear();
            }
            Time.fixedDeltaTime = 0.02f;
            cameraObject.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            cameraObject.transform.position = new Vector3(-0.4f, 5f, -0.09f);
            this.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            float a = -2;
            float b = 1;
            float c = 0.2f;
            float d = 1;
            deltax = (x * (1 - y) + a * z) * Time.deltaTime * 2;
            deltay = (b * ( x * x - 1) * y) * Time.deltaTime * 2;
            deltaz = (c * (1 - y) * w) * Time.deltaTime * 2;
            w += d * z * Time.deltaTime * 2;
        }
        else if (attractorSelecter.captionText.text == "Circuit Attractor")
        {
            equationText.text = ("x=y/100" + "\n" + "y=z/100" + "\n" + "z=-z/100-y/100+(1-x)x/40");
            //Circuit Chaotic
            //starting point: 0.1, 0.1, 0.1 
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(0.1f, 0.1f, 0.1f);
                trail.Clear();
            }
            Time.fixedDeltaTime = 0.02f;
            cameraObject.transform.localScale = new Vector3(0.08f, 0.08f, 0.08f);
            cameraObject.transform.position = new Vector3(0,0,0);
            this.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            deltax = (y / 100) * Time.deltaTime * 150;
            deltay = (z / 100) * Time.deltaTime * 150;
            deltaz = (- (z/100) - (y/100) + x/40 - (Mathf.Abs(x) * x / 40)) * Time.deltaTime * 150;
        }
        else if (attractorSelecter.captionText.text == "Lorenz Mod 2")
        {
            equationText.text = ("x=-0.9x+y^2-z^2+8.9" + "\n" + "y=x(y-5z)+0.5" + "\n" + "z=-z+x(5y+z)");
            //Lorenz Mod 2
            //starting point: 0.1, 0.1, 0.1 
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(0.1f, 0.1f, 0.1f);
                trail.Clear();
            }
            Time.fixedDeltaTime = 0.001f;
            cameraObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            cameraObject.transform.position = new Vector3(0, 0, 0);
            this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            float a = 0.9f;
            float b = 5;
            float c = 9.9f;
            float d = 0.5f;
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            deltax = (-a * x + y * y - z * z + a * c) * Time.deltaTime / 5;
            deltay = (x * (y - b * z) + d) * Time.deltaTime / 5;
            deltaz = (-z + x * (b * y + z)) * Time.deltaTime / 5;
        }
        else if (attractorSelecter.captionText.text == "Strange Unknown")
        {
            equationText.text = ("x=sin(2.24x)-zcos(0.43y)" + "\n" + "y=zsin(-0.65x)-cos(-2.43y)" + "\n" + "z=1/sin(x)");
            //Strange mystery
            //starting point: 0.1, 0.1, 0.1 
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(0.1f, 0.1f, 0.1f);
                trail.Clear();
            }
            Time.fixedDeltaTime = 0.001f;
            cameraObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            cameraObject.transform.position = new Vector3(0, 0, 0);
            this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            float a = 2.24f;
            float b = 0.43f;
            float c = -0.65f;
            float d = -2.43f;
            float e = 1;
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            deltax = (Mathf.Sin(a * x) - z * Mathf.Cos(b * y)) * Time.deltaTime;
            deltay = (z * Mathf.Sin(c * x) - Mathf.Cos(d * y)) * Time.deltaTime;
            deltaz = (e / Mathf.Sin(x)) * Time.deltaTime;
        }
        else if (attractorSelecter.captionText.text == "Lorenz Mod 3")
        {
            equationText.text = ("x=x-y+7.6825z+sin(sin(z)-y+3.9819)" + "\n" + "y=28x-xz-y" + "\n" + "z=sin(x)");
            //Lorenz Mod3
            //starting point: 2, 3, 1
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(2, 3, 1);
                trail.Clear();
            }
            Time.fixedDeltaTime = 0.001f;
            cameraObject.transform.localScale = new Vector3(2.7f, 2.7f, 2.7f);
            cameraObject.transform.position = new Vector3(2.2f, 17.1f, 3.4f);
            this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            float a = 1f;
            float b = 7.6825f;
            float c = 1f;
            float d = 3.9819f;
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            deltax = (x - a * y + b * z + Mathf.Sin(Mathf.Sin(z) - c * y + d)) * Time.deltaTime;
            deltay = (28 * x - x * z - y) * Time.deltaTime;
            deltaz = (Mathf.Sin(x)) * Time.deltaTime;
        }
        else if (attractorSelecter.captionText.text == "Lorenz Mod 4")
        {
            equationText.text = ("x=10(y-x)" + "\n" + "y=-sin(y+z)(z-sin(y)+7.6203)" + "\n" + "z=-34.054sin(x)");
            //Lorenz Mod4
            //starting point: 2, 3, 1
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(2, 3, 1);
                trail.Clear();
            }
            Time.fixedDeltaTime = 0.001f;
            cameraObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            cameraObject.transform.position = new Vector3(3.17f, 3.14f, -6.28f);
            this.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            deltax = (10 * (y - x)) * Time.deltaTime;
            deltay = (-Mathf.Sin(y + z)*(z - Mathf.Sin(y) + 7.6203f)) * Time.deltaTime;
            deltaz = (-34.054f * Mathf.Sin(x)) * Time.deltaTime;
        }
        else if (attractorSelecter.captionText.text == "Lorenz Mod 5")
        {
            equationText.text = ("x=-1.2154z-0.45577y(x-y)" + "\n" + "y=28x-xz-y" + "\n" + "z=xy-2.666z");
            //Lorenz Mod5
            //starting point: 2, 3, 1
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(2, 3, 1);
                trail.Clear();
            }
            Time.fixedDeltaTime = 0.001f;
            cameraObject.transform.localScale = new Vector3(1,1,1);
            cameraObject.transform.position = new Vector3(10.68f, 5f, 24.54f);
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            deltax = (-1.2154f * z - 0.45577f * y * (x - y)) * Time.deltaTime;
            deltay = (28 * x - x * z - y) * Time.deltaTime;
            deltaz = (x * y - 2.6667f * z) * Time.deltaTime;
        }
        else if (attractorSelecter.captionText.text == "Lorenz Mod 6")
        {
            equationText.text = ("x=10(y-x)" + "\n" + "y=-x(z-28)" + "\n" + "z=x(x+4.1059)-2.666z");
            //Lorenz Mod6
            //starting point: 2, 3, 1
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(2, 3, 1);
                trail.Clear();
            }
            Time.fixedDeltaTime = 0.001f;
            cameraObject.transform.localScale = new Vector3(2,2,2);
            cameraObject.transform.position = new Vector3(-7, -3.2f, 38.8f);
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            deltax = (10 * (y - x)) * Time.deltaTime / 2;
            deltay = (-x * (z - 28)) * Time.deltaTime / 2;
            deltaz = (x * (x + 4.1059f) - 2.667f * z) * Time.deltaTime / 2;
        }
        else if (attractorSelecter.captionText.text == "Lissajous")
        {
            equationText.text = ("x=cos(t)" + "\n" + "y=cos(pi*t)" + "\n" + "z=cos(e*t)");
            //Lissajous
            //starting point: 1,1,1
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(1, 1, 1);
                trail.Clear();
            }
            Time.fixedDeltaTime = 0.01f;
            cameraObject.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);
            cameraObject.transform.position = new Vector3(0,0,0);
            this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            deltax = Mathf.Cos(Time.time);
            deltay = Mathf.Cos(Time.time * Mathf.PI);
            deltaz = Mathf.Cos(Time.time * Mathf.Exp(1));
            x = 0;
            y = 0;
            z = 0;
        }
        else if (attractorSelecter.captionText.text == "Lissajous Chaotic 1")
        {
            equationText.text = ("x=cos(0.85t+yz)" + "\n" + "y=cos(pi*t/3.5+xz)" + "\n" + "z=cos(e*t/3.5+xy)");
            //Lissajous Chaotic 1
            //starting point: 1,1,1
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(1, 1, 1);
                trail.Clear();
            }
            Time.fixedDeltaTime = 0.001f;
            cameraObject.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);
            cameraObject.transform.position = new Vector3(0, 0, 0);
            this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            //deltax = Mathf.Cos(0.5f * Time.time + y * z);
            //deltay = Mathf.Cos(0.5f * Time.time * Mathf.PI + x * z);
            //deltaz = Mathf.Cos(0.5f * Time.time * Mathf.Exp(1) + x * y);
            deltax = Mathf.Cos(0.85f * Time.time + y * z);
            deltay = Mathf.Cos(Time.time * Mathf.PI / 3.5f + x * z);
            deltaz = Mathf.Cos(Time.time * Mathf.Exp(1) / 3.5f + x * y);
            x = 0;
            y = 0;
            z = 0;
        }
        else if (attractorSelecter.captionText.text == "Lissajous Chaotic 2")
        {
            equationText.text = ("x=cos(0.5t+yz)" + "\n" + "y=cos(0.5*pi*t+xz)" + "\n" + "z=(0.5*e*t+xy)");
            //Lissajous Chaotic 2
            //starting point: 1,1,1
            if (selecterWasUpdated)
            {
                this.transform.position = new Vector3(1, 1, 1);
                trail.Clear();
            }
            Time.fixedDeltaTime = 0.001f;
            cameraObject.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);
            cameraObject.transform.position = new Vector3(0, 0, 0);
            this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            x = this.transform.position.x;
            y = this.transform.position.y;
            z = this.transform.position.z;
            deltax = Mathf.Cos(0.5f * Time.time + y * z);
            deltay = Mathf.Cos(0.5f * Time.time * Mathf.PI + x * z);
            deltaz = Mathf.Cos(0.5f * Time.time * Mathf.Exp(1) + x * y);
            x = 0;
            y = 0;
            z = 0;
        }
        //Debug.Log(deltax + " " + deltay + " " + deltaz);
        trail.startWidth = this.transform.localScale.x * 0.3f;
        trail.endWidth = this.transform.localScale.x * 0.3f;
        this.transform.position = new Vector3(x + deltax, y + deltay, z + deltaz);
        if (selecterWasUpdated)
        {
            selecterWasUpdated = false;
        }
    }

    public void onEquationToggleChange()
    {
        equationText.gameObject.SetActive(equationToggle.isOn);
    }
    public void selectAttractor()
    {
        selecterWasUpdated = true;
    }
}
