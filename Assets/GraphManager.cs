using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphManager : MonoBehaviour
{
    
    [SerializeField] 
    private GameObject cube;
    [SerializeField, Range(10, 250)]
    private int resolution = 10;

    private enum GraphTypeEnum
    {
        Squared,
        Cubed,
        Quad,
        Pent,
        Sext,
        Sqrt
    };

    [SerializeField]
    private GraphTypeEnum graphType;
    [SerializeField]
    private bool negativeGraph = false;

    private int tempResolution;
    private GraphTypeEnum tempEnum;
    private bool tempNegGraph;
    

    // Update is called once per frame
    void Update()
    {
        if(ValueChange())
        {
            ResetGraph();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        CreatePoints();
    }


    // Creates the points on the graph based on the type of graph
    private void CreatePoints()
    {
        for(float x = -resolution; x<=resolution; x++)
        {
            var tempCube = Instantiate(cube);
            tempCube.transform.localScale = new Vector3(tempCube.transform.localScale.x/(Mathf.Sqrt(resolution)), tempCube.transform.localScale.y/(Mathf.Sqrt(resolution)), tempCube.transform.localScale.z/(Mathf.Sqrt(resolution)));
            tempCube.transform.position = new Vector2((x/resolution), GraphFunction(x/resolution)-tempCube.transform.localScale.y/2);
        }
    }


    // Returns the y of function(x) based on the graph type
    private float GraphFunction(float x)
    {
        float y = 0;

        switch (graphType)
        {
            case GraphTypeEnum.Squared:
                y = (x*x);
            break;
            
            case GraphTypeEnum.Cubed:
                y = (x*x*x);
            break;

            case GraphTypeEnum.Quad:
                y = (x*x*x*x);
            break;

            case GraphTypeEnum.Pent:
                y = (x*x*x*x*x);
            break;

            case GraphTypeEnum.Sext:
                y = (x*x*x*x*x*x);
            break;

            case GraphTypeEnum.Sqrt:
                y = Mathf.Sqrt(x);
            break;
        }

        if(negativeGraph)
        {
            return -y;
        }
        else 
        {
            return y;
        }
    }


    // Clears the graph of all points
    private void ClearGraph()
    {
        foreach(GameObject dot in GameObject.FindGameObjectsWithTag("Dot"))
        {
            Destroy(dot);
        }
    }


    private void SetValues(int res, GraphTypeEnum graphEnum)
    {
        // Sets variables values to know when there have been changes
        tempResolution = res;
        tempEnum = graphEnum;
        tempNegGraph = negativeGraph;

    }


    private bool ValueChange()
    {
        // Checks to see if a value has changed
        if(tempResolution != resolution)
        {
            return true;
        } else if(tempEnum != graphType)
        {
            return true;
        } else if(tempNegGraph != negativeGraph)
        {
            return true;
        }

        return false;
    }


    private void ResetGraph()
    {
        ClearGraph();
        CreatePoints();
        SetValues(resolution, graphType);
    }
}
