using UnityComponents.Common;
using UnityEngine;

namespace Utilities.Spawner
{
    public static class SpawnerUtility
    {

        public static Vector3 GetPositionToSpawn(StaticData data)
        {
            Vector3 position;

            float[] xCoord = new float[2] { -1 * data.SpawnerRectX, data.SpawnerRectX };
            float[] yCoord = new float[2] { -1 * data.SpawnerRectY, data.SpawnerRectY };

            int sideIndex = Random.Range(1, 5);

            if (sideIndex == 1)
            {
                // left side
                position = new Vector3(xCoord[0], Random.Range(yCoord[0], yCoord[1]), 0f);
            }
            else if (sideIndex == 2)
            {
                // up side
                position = new Vector3(Random.Range(xCoord[0], xCoord[1]), yCoord[1], 0f);
            }
            else if (sideIndex == 3)
            {
                // right side
                position = new Vector3(xCoord[1], Random.Range(yCoord[0], yCoord[1]), 0f);
            }
            else
            {
                // down side
                position = new Vector3(Random.Range(xCoord[0], xCoord[1]), yCoord[0], 0f);
            }

            return position;
        }

        public static Vector3 GetVelocityToSpawn(StaticData data)
        {
            return new Vector3(Random.Range(data.SpawnerMinVelocity, data.SpawnerMaxVelocity), Random.Range(data.SpawnerMinVelocity, data.SpawnerMaxVelocity), 0f).normalized;
        }

        public static Vector3 GetRotationToSpawn(StaticData data)
        {
            return new Vector3(0f, 0f, Random.Range(data.SpawnerMinRotation, data.SpawnerMaxRotation));
        }
    }

    public struct EnemyParams
    {
        public Vector3 Position;
        public Vector3 Velocity;
        public Vector3 Rotation;
    }
}

