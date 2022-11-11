using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIType 
{
    
    private string _name;
    private string _path;

    public UIType(string uIType,string objPath)
    {
        _name = uIType;
        _path = objPath;
    }

    public string Name { get => _name; }
    public string Path { get => _path; }

}
