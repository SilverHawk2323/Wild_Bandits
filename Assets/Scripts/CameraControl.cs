using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    public float zoom;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Camera>().orthographicSize = zoom;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}
