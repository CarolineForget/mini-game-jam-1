using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollText : MonoBehaviour
{
    [SerializeField] private float scrollX = 0;
    [SerializeField] private float scrollY = 0.5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        float OffsetX = Time.fixedTime * scrollX;
        float OffsetY = Time.fixedTime * scrollY;

        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);
    }
}
