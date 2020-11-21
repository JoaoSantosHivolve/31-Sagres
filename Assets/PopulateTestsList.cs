using Common;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopulateTestsList : MonoBehaviour
{
    private TestType m_TestType;
    public TestType testType
    { 
        get => m_TestType;
        set
        {
            m_TestType = value;
            PopulateGrid();
        }
    }

    public TMP_InputField searchBarInput;
    
    private List<GameObject> m_GridElements;
    private GridLayoutGroup m_Grid;
    private RectTransform m_Scrollview;

    private void Awake()
    {
        m_GridElements = new List<GameObject>();
        m_Grid = GetComponent<GridLayoutGroup>();
        m_Scrollview = transform.parent.parent.GetComponent<RectTransform>();
    }

    public void PopulateGrid()
    {
        ClearGrid();

        var testList = TestsHolder.Instance.GetTests(searchBarInput.text, testType);
        var width = m_Scrollview.rect.width;
        var height = m_Scrollview.rect.height;
        m_Grid.cellSize = new Vector2(width, height /6);

        foreach (var test in testList)
        {
            var display = Instantiate(test, transform);
            m_GridElements.Add(display);
        }
    }


    public void ClearGrid()
    {
        if (m_GridElements == null || m_GridElements.Count == 0)
            return;

        foreach (var element in m_GridElements)
            Destroy(element.gameObject);

        m_GridElements = new List<GameObject>();
    }

    public void SetTestType(int value)
    {
        testType = value == 0 ? TestType.Pratical : TestType.Theory;
    }
}