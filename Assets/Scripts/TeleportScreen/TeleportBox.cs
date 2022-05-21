using UnityEngine;

/// <summary>
/// Class <c>TeleportBox</c> allows the objectû to move between the edges of the screen
/// </summary>
/// 

public class TeleportBox
{
    enum SIDE { left, up, right, down }

    private float[] xCoord;
    private float[] yCoord;

    public TeleportBox(Vector2 boxSize)
    {
        xCoord = new float[2] { -1 * boxSize.x / 2, boxSize.x / 2 };
        yCoord = new float[2] { -1 * boxSize.y / 2, boxSize.y / 2 };
    }

    public void HaveOnCollisionExit(Collider2D collider)
    {
        TeleportingObject(collider.gameObject.transform, WhatSide(collider.gameObject.transform.position));       
    }

    private void TeleportingObject(Transform otherColliderTransform, SIDE contactSide)
    {
        if (contactSide == SIDE.down || contactSide == SIDE.up)
        {
            otherColliderTransform.position = new Vector3(otherColliderTransform.position.x, -1 * otherColliderTransform.position.y, otherColliderTransform.position.z);
        }
        else
        {
            otherColliderTransform.position = new Vector3( -1 * otherColliderTransform.position.x, otherColliderTransform.position.y, otherColliderTransform.position.z);
        }
        
    }

    private SIDE WhatSide(Vector2 otherColliderPoint)
    {
        if (otherColliderPoint.x < xCoord[0])
        {
            // left side
            return SIDE.left;
        }
        else if (otherColliderPoint.x > xCoord[1]) return SIDE.right;
        else if (otherColliderPoint.y < yCoord[0]) return SIDE.down;
        else return SIDE.up;
    }
}

