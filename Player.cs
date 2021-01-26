using UnityEngine;

namespace Scenes.GamePlay
{
    public class Player : MonoBehaviour {
        float _moveSpeed;

        [SerializeField] private LayerMask platformsLayerMask;
        [SerializeField] private LayerMask platformsLayerMask2;
        Rigidbody2D _rb;
        private BoxCollider2D _boxCollider2D;

        private void Awake()
        {
            _rb = transform.GetComponent<Rigidbody2D>();
            _boxCollider2D = transform.GetComponent<BoxCollider2D>();

        }



        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
            if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
            {
                float jumpVelocity = 13f;
                _rb.velocity = Vector2.up * jumpVelocity;
            
            }
            HandleMovement();
        }

        private bool IsGrounded()
        {
            var bounds = _boxCollider2D.bounds;
            RaycastHit2D raycastHit2d = Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, .05f, platformsLayerMask);
            return raycastHit2d.collider != null;
        }

        private void HandleMovement()
        {
            _moveSpeed = 7f;
            if (Input.GetKey(KeyCode.S))
            {
                _rb.velocity = new Vector2(0, (_rb.velocity.y - (_moveSpeed/2)));
            }
            if (Input.GetKey(KeyCode.A)) {
                _rb.velocity = new Vector2(-_moveSpeed, _rb.velocity.y);
            } else{
                if (Input.GetKey(KeyCode.D)) {
                    _rb.velocity = new Vector2(+_moveSpeed, _rb.velocity.y);
                } else {
                    _rb.velocity = new Vector2(0, _rb.velocity.y);
                }
            }
        }

    }
}
