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
            EditorGUILayout.ObjectField("Center", myTarget.center, typeof(Transform), true);
            EditorGUILayout.FloatField("Speed", myTarget.speed);
            EditorGUILayout.IntField("Num Repeat", myTarget.numberOfRepeating);
            EditorGUILayout.FloatField("Radius X", myTarget.radiusX);
            EditorGUILayout.FloatField("Radius Y", myTarget.radiusY);
        }
        else
        {
            EditorGUILayout.ObjectField("Center", myTarget.center, typeof(Transform), true);
            EditorGUILayout.FloatField("Speed", myTarget.speed);
            EditorGUILayout.IntField("Num Repeat", myTarget.numberOfRepeating);
            EditorGUILayout.FloatField("Radius", myTarget.radius);
        }
        // Save change to object
        if (GUI.changed)
        {
            EditorUtility.SetDirty(myTarget);
        }
    }
}

