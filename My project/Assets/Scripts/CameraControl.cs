using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public Transform StartCamera;
    public Transform bg1;
    public Transform bg2;
    public float n = 5;

    private float size;
    private float initialTargetPos;

    private Vector3 cameraTargetPos = new Vector3();
    private Vector3 bg1TargetPos = new Vector3();
    private Vector3 bg2TargetPos = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        size = bg1.GetComponent<BoxCollider2D>().size.y;
        initialTargetPos = target.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPos = SetPos(cameraTargetPos, initialTargetPos, target.position.y+n, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.030f);
        n=0;
        
        if (transform.position.y >= bg2.position.y)
        {
            bg1.position = SetPos(bg1TargetPos, bg1.position.x, bg2.position.y + size, bg1.position.z);
            SwitchBg();
        }
        if (transform.position.y < bg1.position.y)
        {
            bg2.position = SetPos(bg2TargetPos, bg2.position.x, bg1.position.y - size, bg2.position.z);
            SwitchBg();
        }
        
    }

    private void SwitchBg()
    {
        Transform temp = bg1;
        bg1 = bg2;
        bg2 = temp;
    }

    private Vector3 SetPos(Vector3 pos, float x, float y, float z)
    {
        pos.x = x;
        pos.y = y;
        pos.z = z;
        return pos;
    }
}
