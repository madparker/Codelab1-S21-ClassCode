using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class NYUFaculty : NYUStaff
{
    public string[] classes;

    public NYUFaculty(string name, string netId, int salary, string[] classes)
        : base(name, netId, salary)
    {
        this.classes = classes;
    }

    public override string showRecord()
    {
        string classString = "";

        foreach (var course in classes)
        {
            classString = course + ", ";
        }
        
        return base.showRecord() + "Classes: " + classString;
    }
}
