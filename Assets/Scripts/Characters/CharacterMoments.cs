using UnityEngine;

namespace Characters
{
    class CharacterMoments : MonoBehaviour
    {
        static Vector3 HumanMovement(string key)
        {
            switch (key)
            {
                case "W":
                    return Vector3.up;
                case "A":
                    return Vector3.left;
                case "S":
                    return Vector3.down;
                case "D":
                    return Vector3.right;
            }

            return new Vector3(0, 0, 0);
        }
    }
}