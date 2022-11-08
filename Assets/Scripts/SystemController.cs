using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SystemController : MonoBehaviour
{
    private GameObject[]  laserPointers;
    private GameObject[] mirrors;
    private GameObject[] walls;
    private GameObject checkPoint;
    private int mirrorsCount = 4;
    public List<GameObject> editMirrors;
    public GameObject mirrorsNr;
    public GameObject mirrorWarning;
    private int wallsCount = 3;
    public List<GameObject> editWalls;
    public GameObject wallNr;
    public GameObject wallWarning;
    private bool adminState = false;
    
    public void changeAdminMode()
    {
        laserPointers = GameObject.FindGameObjectsWithTag("LaserPointer");
        foreach(GameObject pointer in laserPointers )
        {
            pointer.GetComponent<ObjectManipulator>().enabled = !adminState;
        }
        mirrors = GameObject.FindGameObjectsWithTag("Mirror");
        foreach (GameObject mirror in mirrors)
        {
            mirror.GetComponent<BoundsControl>().enabled = !adminState;
        }
        walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach( GameObject wall in walls)
        {
            wall.GetComponent<BoundsControl>().enabled = !adminState;
            wall.GetComponent<ObjectManipulator>().enabled = !adminState;
        }
        checkPoint = GameObject.Find("CheckPoint");
        checkPoint.GetComponent<ObjectManipulator>().enabled = !adminState;

        adminState = !adminState;
        
    }
    public void addMirror()
    {
        if (adminState)
        {
            if (mirrorsCount < 10)
            {
                mirrorWarning.GetComponent<TextMeshPro>().text = "";
                mirrorsCount += 1;
                editMirrors[mirrorsCount - 5].SetActive(true);
                editMirrors[mirrorsCount - 5].GetComponent<BoundsControl>().enabled = adminState;
                mirrorsNr.GetComponent<TextMeshPro>().text = mirrorsCount.ToString();
            }
            else
            {
                mirrorWarning.GetComponent<TextMeshPro>().text = "Generate up to 10 mirrors";
            }
        }
        else
        {
            mirrorWarning.GetComponent<TextMeshPro>().text = "You should turn on admin mode first!";
        }
        

    }
    public void reduceMirror()
    {
        if (adminState)
        {
            if (mirrorsCount > 4)
            {
                mirrorWarning.GetComponent<TextMeshPro>().text = "";
                editMirrors[mirrorsCount - 5].GetComponent<BoundsControl>().enabled = !adminState;
                editMirrors[mirrorsCount - 5].SetActive(false);
                mirrorsCount -= 1;
                mirrorsNr.GetComponent<TextMeshPro>().text = mirrorsCount.ToString();
            }
            else
            {
                mirrorWarning.GetComponent<TextMeshPro>().text = "Minimum of 4 mirrors required";
            }
        }
        else
        {
            mirrorWarning.GetComponent<TextMeshPro>().text = "You should turn on admin mode first!";
        }


    }

    public void addWall()
    {
        if (adminState)
        {
            if (wallsCount < 10)
            {
                wallWarning.GetComponent<TextMeshPro>().text = "";
                wallsCount += 1;
                editWalls[wallsCount - 4].SetActive(true);
                editWalls[wallsCount - 4].GetComponent<BoundsControl>().enabled = adminState;
                editWalls[wallsCount - 4].GetComponent<ObjectManipulator>().enabled = adminState;
                wallNr.GetComponent<TextMeshPro>().text = wallsCount.ToString();
            }
            else
            {
                wallWarning.GetComponent<TextMeshPro>().text = "Generate up to 10 walls";
            }
        }
        else
        {
            wallWarning.GetComponent<TextMeshPro>().text = "You should turn on admin mode first!";
        }


    }
    public void reduceWall()
    {
        if (adminState)
        {
            if (wallsCount > 3)
            {
                wallWarning.GetComponent<TextMeshPro>().text = "";
                editWalls[wallsCount - 4].GetComponent<BoundsControl>().enabled = !adminState;
                editWalls[wallsCount - 4].GetComponent<ObjectManipulator>().enabled = !adminState;
                editWalls[wallsCount - 4].SetActive(false);
                wallsCount -= 1;
                wallNr.GetComponent<TextMeshPro>().text = wallsCount.ToString();
            }
            else
            {
                wallWarning.GetComponent<TextMeshPro>().text = "Minimum of 3 walls required";
            }
        }
        else
        {
            wallWarning.GetComponent<TextMeshPro>().text = "You should turn on admin mode first!";
        }


    }

}
