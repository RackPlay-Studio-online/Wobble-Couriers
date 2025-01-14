using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerHandIK : MonoBehaviour
{
    public TwoBoneIKConstraint rightBoneIKConstraint;
    public TwoBoneIKConstraint leftBoneIKConstraint;

    public List<Transform> handTargets;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AssignHandTargets();
    }

    private void Update() {
        AssignHandTargets();
    }

    void AssignHandTargets()
    {
        rightBoneIKConstraint.data.target.position = handTargets[0].position;
        leftBoneIKConstraint.data.target.position = handTargets[1].position;
    }
}
