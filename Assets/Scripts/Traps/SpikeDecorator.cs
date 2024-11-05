using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDecorator : DecoratorBase
{
    public enum TrajectoryLine
    {
        Line = 0,
        Circle,
        Square,
        Ellipse,    // hinh eclip
        Spiral,     // hinh xoan oc
    }

    public Transform center;
    public TrajectoryLine trajectoryLine;
    public float radius;
    public float speed;
    public int numRepeat;

    // Private
    private bool bMoveLeft = true;
    private int nRepeatedCount = 0;

    private void Update()
    {
        switch (trajectoryLine)
        {
            case TrajectoryLine.Line:
                MoveLine();
                break;
            case TrajectoryLine.Circle:
                MoveCircle();
                break;
            case TrajectoryLine.Square:
                MoveSquare();
                break;
            case TrajectoryLine.Ellipse:
                MoveEllipse();
                break;
            case TrajectoryLine.Spiral:
                MoveSpiral();
                break;
            default:
                break;
        }
    }

    private void MoveLine() 
    {
        if ((nRepeatedCount < numRepeat) || (numRepeat == 0))
        {
            if (bMoveLeft)
            {
                transform.position = new Vector3(transform.position.x + Time.deltaTime * speed, transform.position.y, transform.position.z);
                if (transform.position.x >= (center.position.x + radius))
                {
                    bMoveLeft = false;
                }
            } 
            else
            {
                transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);
                if (transform.position.x <= (center.position.x - radius))
                {
                    bMoveLeft = true;
                    nRepeatedCount++;
                }
            }                   
        }        
    }
    private void MoveCircle() { }
    private void MoveSquare() { }
    private void MoveEllipse() { }
    private void MoveSpiral() { }

}
