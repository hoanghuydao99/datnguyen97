using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosstrigger : MonoBehaviour
{
    //khoang cach du chuyen
    public Vector3 m_distance = new Vector3(5, 0, 0);

    public float m_speed = 0.5f;

    //vi tri dau tien
    private Vector3 m_startPosition;

    //vi tri ket thuc
    private Vector3 m_endPosition;

    private void Awake()
    {
        //vi tri hien tai la vi tri bat dau
        m_startPosition = transform.localPosition;

        //dat vi tri ket thuc tu vi tri bat dau va khoang cach di chuyen
        m_endPosition = m_startPosition + m_distance;
    }

    private void Update()
    {
        //tinh vi tri hien tai
        var t = Mathf.PingPong(Time.time + m_speed, 1);
        var newPosition = Vector3.Lerp(m_startPosition, m_endPosition, t);

        //tao vi tri hien tai
        transform.localPosition = newPosition;
    }
}
