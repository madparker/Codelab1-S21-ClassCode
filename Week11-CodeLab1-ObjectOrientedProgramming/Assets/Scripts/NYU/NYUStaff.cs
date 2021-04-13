using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NYUStaff : NYUPerson
{
    public int salary;

    public NYUStaff(string name, string netId, int salary) : 
        base(name, netId)
    {
        this.type = "NYU Staff";
        this.salary = salary;
    }

    public override string showRecord()
    {
        return base.showRecord() + "Salary: " + salary + "\n";
    }
}
