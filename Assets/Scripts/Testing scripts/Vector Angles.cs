using Meta.WitAi.TTS.Integrations;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class VectorAngles : MonoBehaviour
{
    public GameObject lineA, lineB, lineC, lineD;
    public GameObject vectorAStartPos, vectorAEndPos, vectorBStartPos,  vectorBEndPos, vectorCStartPos, vectorCEndPos, vectorDStartPos, vectorDEndPos ;
    private Vector3[] vectorA, vectorB, vectorC, vectorD;
    private LineRenderer lrA, lrB, lrC, lrD;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lrA = lineA.GetComponent<LineRenderer>();
        lrB = lineB.GetComponent<LineRenderer>();
        lrC = lineC.GetComponent<LineRenderer>();
        lrD = lineD.GetComponent<LineRenderer>();

        vectorA = new Vector3[3];
        vectorB = new Vector3[3];
        vectorC = new Vector3[3];
        vectorD = new Vector3[3];
    }

    // Update is called once per frame
    void Update()
    {
        vectorA[0] = vectorAStartPos.transform.position;
        vectorA[1] = vectorAEndPos.transform.position;
        vectorA[2] = vectorA[1] - vectorA[0];

        vectorB[0] = vectorBStartPos.transform.position;
        vectorB[1] = vectorBEndPos.transform.position; 
        vectorB[2] = vectorB[1] - vectorB[0];    

        vectorC[0] = vectorCStartPos.transform.position;
        vectorC[1] = vectorCEndPos.transform.position; 
        vectorC[2] = vectorC[1] - vectorC[0];   

        vectorD[0] = vectorCStartPos.transform.position;

        Quaternion angle = Quaternion.FromToRotation(vectorA[2], vectorB[2]);
        vectorD[2] = angle * vectorC[2] * 2f;
        vectorDEndPos.transform.position = vectorD[0] + vectorD[2];
        vectorD[1] = vectorDEndPos.transform.position;


        vectorDStartPos = vectorCStartPos;

        for(int i = 0; i < 2; i++)
        {
            lrA.SetPosition(i, vectorA[i]);
            lrB.SetPosition(i, vectorB[i]);
            lrC.SetPosition(i, vectorC[i]);
            lrD.SetPosition(i, vectorD[i]);
        } 
    }
}
