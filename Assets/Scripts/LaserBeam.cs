using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LaserBeam
{
    Vector3 pos, dir;
    GameObject laserObj;
    LineRenderer laser;
    List<Vector3> laserIndices = new List<Vector3>();
    string pointerName;



    public LaserBeam(Vector3 pos, Vector3 dir, Material material, string name)
    {
        this.laser = new LineRenderer();
        this.pointerName = name;
        this.laserObj = new GameObject();
        this.laserObj.name = "Laser Beam-"+name;
        this.pos = pos;
        this.dir = dir;

        this.laser = this.laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        this.laser.startWidth = 0.02f;
        this.laser.endWidth = 0.02f;
        this.laser.material = material;
        if (name == "Laser Pointer-1")
        {
            this.laser.startColor = Color.green;
            this.laser.endColor = Color.green;
        }
        else
        {
            this.laser.startColor = Color.red;
            this.laser.endColor = Color.red;
        }


        CastRay(pos, dir, laser);
    }

    void CastRay(Vector3 pos, Vector3 dir, LineRenderer laser)
    {
        laserIndices.Add(pos);
        Ray ray = new Ray(pos, dir);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 30))
        {
            CheckHit(hit, dir, laser);
        }
        else
        {
            laserIndices.Add(ray.GetPoint(30));
            UpdateLaser();
        }
    }

    void UpdateLaser()
    {
        int count = 0;
        laser.positionCount = laserIndices.Count;
        foreach (Vector3 idx in laserIndices)
        {
            laser.SetPosition(count, idx);
            count++;
        }
    }

    void CheckHit(RaycastHit hitInfo, Vector3 direction, LineRenderer laser)
    {
        if (hitInfo.collider.gameObject.tag == "Mirror")
        {
            Vector3 pos = hitInfo.point;
            Vector3 dir = Vector3.Reflect(direction, hitInfo.normal);
            CastRay(pos, dir, laser);
        }
        else if(hitInfo.collider.gameObject.tag == "CheckPoint-Laser Pointer-1" && this.pointerName =="Laser Pointer-1")
        {
            hitInfo.collider.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            laserIndices.Add(hitInfo.point);
            UpdateLaser();
        }
        else if (hitInfo.collider.gameObject.tag == "CheckPoint-Laser Pointer-2" && this.pointerName == "Laser Pointer-2")
        {
            hitInfo.collider.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            laserIndices.Add(hitInfo.point);
            UpdateLaser();
        }
        else
        {
            laserIndices.Add(hitInfo.point);
            UpdateLaser();
        }

    }
}
