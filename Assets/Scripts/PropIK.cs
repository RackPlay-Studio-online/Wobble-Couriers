using System.Collections.Generic;
using UnityEngine;

public class PropIK : MonoBehaviour
{
    public List<Transform> player1HandIK = new List<Transform>();
    public List<Transform> player2HandIK = new List<Transform>();

    public List<SpringJoint> springJoints = new List<SpringJoint>();
}
