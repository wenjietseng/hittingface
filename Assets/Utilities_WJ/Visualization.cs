using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Visualization
{
    public class Drawing
    {
        public void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
        {
            // https://answers.unity.com/questions/8338/how-to-draw-a-line-using-script.html
            GameObject myLine = new GameObject();
            myLine.transform.position = start;
            myLine.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            myLine.AddComponent<LineRenderer>();
            LineRenderer lr = myLine.GetComponent<LineRenderer>();
            lr.material = new Material(Shader.Find("Standard")); 
            lr.startColor = color;
            lr.endColor = color;
            lr.startWidth = 0.01f;
            lr.endWidth = 0.01f;
            lr.SetPosition(0, start);
            lr.SetPosition(1, end);
            GameObject.Destroy(myLine, duration);
        }
    }
}