using UnityEngine;
using System.Collections.Generic;

public class MoveHands : MonoBehaviour
{
    [Header("Rigged model")]
    [SerializeField]
    ModelJoint[] modelJoints;

    /// <summary> Model bones </summary> Dictionary with joints
    Dictionary<nuitrack.JointType, ModelJoint> jointsRigged = new Dictionary<nuitrack.JointType, ModelJoint>();

    void Start()
    {
        for (int i = 0; i < modelJoints.Length; i++)
        {
            modelJoints[i].baseRotOffset = modelJoints[i].bone.rotation;
            jointsRigged.Add(modelJoints[i].jointType, modelJoints[i]);

            //Adding base distances between the child bone and the parent bone 
            if (modelJoints[i].parentJointType != nuitrack.JointType.None)
                AddBoneScale(modelJoints[i].jointType, modelJoints[i].parentJointType);
        }
    }

    void AddBoneScale(nuitrack.JointType targetJoint, nuitrack.JointType parentJoint)
    {
        //take the position of the model bone
        Vector3 targetBonePos = jointsRigged[targetJoint].bone.position;
        //take the position of the model parent bone  
        Vector3 parentBonePos = jointsRigged[parentJoint].bone.position;
        jointsRigged[targetJoint].baseDistanceToParent = Vector3.Distance(parentBonePos, targetBonePos);
        //record the Transform of the model parent bone
        jointsRigged[targetJoint].parentBone = jointsRigged[parentJoint].bone;
        //extract the parent bone from the hierarchy to make it independent
        jointsRigged[targetJoint].parentBone.parent = transform.root;
    }


    void Update()
    {
        //If a skeleton is detected, process the model
        if (CurrentUserTracker.CurrentSkeleton != null) ProcessSkeleton(CurrentUserTracker.CurrentSkeleton);
    }

    void ProcessSkeleton(nuitrack.Skeleton skeleton)
    {
        foreach (var riggedJoint in jointsRigged)
        {
            //Get joint from the Nuitrack
            nuitrack.Joint joint = skeleton.GetJoint(riggedJoint.Key);

            //Get modelJoint
            ModelJoint modelJoint = riggedJoint.Value;

            //Bone position
            Vector3 newPos = Quaternion.Euler(0f, 180f, 0f) * (0.001f * joint.ToVector3());
            modelJoint.bone.position = newPos;

            //Bone rotation
            Quaternion jointOrient = Quaternion.Inverse(CalibrationInfo.SensorOrientation) * (joint.ToQuaternionMirrored()) * modelJoint.baseRotOffset;
            modelJoint.bone.rotation = jointOrient;

            //Bone scale
            if (modelJoint.parentBone != null)
            {
                //Take the Transform of a parent bone
                Transform parentBone = modelJoint.parentBone;
                //calculate how many times the distance between the child bone and its parent bone has changed compared to the base distance (which was recorded at the start)
                float scaleDif = modelJoint.baseDistanceToParent / Vector3.Distance(newPos, parentBone.position);
                //change the size of the bone to the resulting value (On default bone size (1,1,1))
                parentBone.localScale = Vector3.one / scaleDif;
            }
        }
    }
}