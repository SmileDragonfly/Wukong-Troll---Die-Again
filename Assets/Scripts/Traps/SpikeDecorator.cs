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

    public enum LineDirection 
    {
        Unk = 0,
        Up, 
        Left, 
        Down,
        Right,
    }

    public Transform center;
    public TrajectoryLine trajectoryLine;
    public float radius = 1f;
    public float speed = 1f;
    public float radiusX = 1.5f;
    public float radiusY = 0.5f;

    // Private
    private int nMoveDirection = 1;
    private int nRepeatedCount = 0;
    private float angle = 0;
    private LineDirection direction = LineDirection.Unk;

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
        if ((nRepeatedCount < numberOfRepeating) || (numberOfRepeating == 0))
        {
            if (nMoveDirection == 1)
            {
                transform.position = new Vector3(transform.position.x + Time.deltaTime * speed, transform.position.y, transform.position.z);
                if (transform.position.x >= (center.position.x + radius))
                {
                    nMoveDirection = -1;
                }
            } 
            else
            {
                transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);
                if (transform.position.x <= (center.position.x - radius))
                {
                    nMoveDirection = 1;
                    nRepeatedCount++;
                }
            }                   
        }        
    }
    private void MoveCircle() 
    {
        if ((nRepeatedCount < numberOfRepeating) || (numberOfRepeating == 0))
        {
            angle += speed * Time.deltaTime;
            transform.position = new Vector3(center.position.x + radius * Mathf.Cos(angle), center.position.y + radius * Mathf.Sin(angle), 0);
            if (angle > 2 * Mathf.PI)
            {
                angle -= 2 * Mathf.PI;
                nRepeatedCount++;
            }
        }
    }
    private void MoveSquare() 
    {
        if (direction == LineDirection.Unk)
        {
            direction = LineDirection.Up;
            transform.position = center.position + new Vector3(-radius, 0, 0);
        }
        if ((nRepeatedCount < numberOfRepeating) || (numberOfRepeating == 0))
        {
            switch(direction)
            {
                case LineDirection.Up:
                    transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * speed, transform.position.z);
                    if (transform.position.y >= (center.position.y + radius))
                    {
                        direction = LineDirection.Right;
                    }
                    break;
                case LineDirection.Right:
                    transform.position = new Vector3(transform.position.x + Time.deltaTime * speed, transform.position.y, transform.position.z);
                    if (transform.position.x >= (center.position.x + radius))
                    {
                        direction = LineDirection.Down;
                    }
                    break;
                case LineDirection.Down:
                    transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * speed, transform.position.z);
                    if (transform.position.y <= (center.position.y - radius))
                    {
                        direction = LineDirection.Left;
                    }
                    break;
                case LineDirection.Left:
                    transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);
                    if (transform.position.x <= (center.position.x - radius))
                    {
                        direction = LineDirection.Up;
                        nRepeatedCount++;
                    }
                    break;
            }
        }
    }
    private void MoveEllipse() 
    {
        if ((nRepeatedCount < numberOfRepeating) || (numberOfRepeating == 0))
        {
            angle += speed * Time.deltaTime;
            transform.position = new Vector3(center.position.x + radiusX * Mathf.Cos(angle), center.position.y + radiusY * Mathf.Sin(angle), 0);
            if (angle > 2 * Mathf.PI)
            {
                angle -= 2 * Mathf.PI;
                nRepeatedCount++;
            }
        }
    }
    private void MoveSpiral() 
    {
        if ((nRepeatedCount < numberOfRepeating) || (numberOfRepeating == 0))
        {
            angle += speed * Time.deltaTime * nMoveDirection;
            float currentRadius = radius + 0.2f * angle;
            transform.position = new Vector3(center.position.x + currentRadius * Mathf.Cos(angle), center.position.y + currentRadius * Mathf.Sin(angle), 0);
            if (angle > 2 * Mathf.PI || angle < 0)
            {
                nRepeatedCount++;
                nMoveDirection = -nMoveDirection;
            }
        }
    }

}
