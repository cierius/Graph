using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphManager : MonoBehaviour
{
    
    [SerializeField] 
    private GameObject cube;

    private enum GraphTypeEnum
    {
        Squared,
        Cubed,
        Quad,
        Pent,
        Sext
    };

    [SerializeField]
    private GraphTypeEnum graphType;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
