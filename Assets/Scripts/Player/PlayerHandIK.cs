using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerHandIK : MonoBehaviour
{
    public TwoBoneIKConstraint rightBoneIKConstraint;
    public TwoBoneIKConstraint leftBoneIKConstraint;
    public List<Transform> handTargets;

    private void Start()
    {
        AssignHandTargets();
    }

    private void Update()
    {
        AssignHandTargets();
    }

    void AssignHandTargets()
    {
        if (handTargets.Count >= 2)
        {
            rightBoneIKConstraint.data.target.position = handTargets[0].position;
            leftBoneIKConstraint.data.target.position = handTargets[1].position;
        }
    }
}