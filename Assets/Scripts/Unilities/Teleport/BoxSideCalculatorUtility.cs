using UnityEngine;

namespace Utilities.Teleporting
{
    public static class BoxSideCalculatorUtility
    {
        public static SIDE CalculateSideOfBoxWhenContact(Vector2 boxSize, Vector2 otherObjectPoint)
        {
            float[] xCoord = new float[2] { -1 * boxSize.x / 2, boxSize.x / 2 };
            float[] yCoord = new float[2] { -1 * boxSize.y / 2, boxSize.y / 2 };

            if (otherObjectPoint.x < xCoord[0])
            {
                // left side
                return SIDE.left;
            }
            else if (otherObjectPoint.x > xCoord[1]) return SIDE.right;
            else if (otherObjectPoint.y < yCoord[0]) return SIDE.down;
            else return SIDE.up;
        }
    }
}

