using Assets.Scripts.Common;
using Common;
using System.Collections.Generic;
using UnityEngine;

public class TestsHolder : Singleton<TestsHolder>
{
    public List<GameObject> theoryTests;
    public List<GameObject> praticalTests;

    public List<GameObject> GetTests(string searchText, TestType type)
    {
        var newList = new List<GameObject>();

        foreach (var test in type == TestType.Pratical ? praticalTests : theoryTests)
        {
            if(searchText == "" || test.name.Contains(searchText))
            {
                newList.Add(test);
            }
        }

        return newList;
    }
}