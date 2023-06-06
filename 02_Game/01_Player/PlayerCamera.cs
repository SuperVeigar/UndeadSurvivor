using UnityEngine;

namespace SuperVeigar
{
    public class PlayerCamera : MonoBehaviour
    {
        private readonly Vector2 MAP_SIZE = new Vector2(50, 50);     // zero point is (0,0)
        public GameObject target;
        public float distance;
        private float height;
        private float width;
        private Vector2 center;

        private void Start()
        {
            Init();
        }

        private void Update()
        {
            transform.position = Clamp(target.gameObject.transform.position + Vector3.forward * distance);
        }

        private void Init()
        {
            height = Camera.main.orthographicSize;
            width = height * Screen.width / Screen.height;
        }

        private Vector3 Clamp(Vector3 position)
        {
            float lx = MAP_SIZE.x - width;
            float clampX = Mathf.Clamp(position.x, -lx + center.x, lx + center.x);

            float ly = MAP_SIZE.y - height;
            float clampY = Mathf.Clamp(position.y, -ly + center.y, ly + center.y);

            position.x = clampX;
            position.y = clampY;

            return position;
        }
    }
}

