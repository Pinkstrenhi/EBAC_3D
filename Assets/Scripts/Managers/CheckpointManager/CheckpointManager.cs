using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using UnityEngine.Serialization;

public class CheckpointManager : Singleton<CheckpointManager>
{
    public int lastCheckpointKey = 0;
    public List<CheckpointBase> checkpoints;

    public bool HasCheckpoint()
    {
        return lastCheckpointKey > 0;
    }
    public void SaveCheckpoint(int checkpoint)
    {
        if (checkpoint > lastCheckpointKey)
        {
            lastCheckpointKey = checkpoint;
        }
    }

    public Vector3 GetPositionLastCheckpoint()
    {
        var checkpoint = checkpoints.Find(i => i.key == lastCheckpointKey);
        return checkpoint.transform.position;
    }
}
