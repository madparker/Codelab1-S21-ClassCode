using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NYUStudent : NYUPerson
{

    public float GPA = 4.0f;

    public NYUStudent(string name, string netId, float gpa) :
        base(name, netId)
    {
        this.type = "NYU Student";
        this.GPA = gpa;
    }

    public override string showRecord()
    {
        return base.showRecord() + "GPA: " + GPA + "\n";
    }
}
