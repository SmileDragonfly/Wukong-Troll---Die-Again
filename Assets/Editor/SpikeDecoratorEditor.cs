using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static SpikeDecorator;
using UnityEngine.TextCore.Text;

[CustomEditor(typeof(SpikeDecorator))]
public class SpikeDecoratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SpikeDecorator myTarget = (SpikeDecorator)target;
        // trajectoryLine
        myTarget.trajectoryLine = (TrajectoryLine)EditorGUILayout.EnumPopup("Trajectory Line", myTarget.trajectoryLine);
        if(myTarget.trajectoryLine == TrajectoryLine.Ellipse)
        {
            myTarget.center = (Transform)EditorGUILayout.ObjectField("Center", myTarget.center, typeof(Transform), true);
            myTarget.speed = EditorGUILayout.FloatField("Speed", myTarget.speed);
            myTarget.numberOfRepeating = EditorGUILayout.IntField("Numer Of Repeating", myTarget.numberOfRepeating);
            myTarget.radiusX = EditorGUILayout.FloatField("Radius X", myTarget.radiusX);
            myTarget.radiusY = EditorGUILayout.FloatField("Radius Y", myTarget.radiusY);
        }
        else
        {
            myTarget.center = (Transform)EditorGUILayout.ObjectField("Center", myTarget.center, typeof(Transform), true);
            myTarget.speed = EditorGUILayout.FloatField("Speed", myTarget.speed);
            myTarget.numberOfRepeating = EditorGUILayout.IntField("Numer Of Repeating", myTarget.numberOfRepeating);
            myTarget.radius = EditorGUILayout.FloatField("Radius", myTarget.radius);
        }
        // Save change to object
        if (GUI.changed)
        {
            EditorUtility.SetDirty(myTarget);
        }
    }
}

