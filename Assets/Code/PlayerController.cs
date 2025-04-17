using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    [Header("Player Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 12f;

    public Transform groundCheck;
    public LayerMask groundLayer;

    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2.0f;
    [SerializeField] private float coyoteTime = 0.3f;


    private Rigidbody2D rb;
    private bool _isGrounded;
    private float _horizontal;
    private bool _isJumping;
    private float _jumpVelocity;
    private float _lastGroundedTime;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _jumpVelocity = jumpForce;
    }

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");

        if (IsGrounded())
        {
            _lastGroundedTime = Time.time;

        }

        if (!_isJumping && (IsGrounded() || IsInCoyoteTime()) && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, _jumpVelocity);
            _isJumping = true;
        }

        if (Input.GetButtonUp("Jump"))
        {
            _isJumping = false;
        }
    }

    void FixedUpdate()
    {
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * (Physics2D.gravity.y * Time.fixedDeltaTime * fallMultiplier);
        }
        else if (rb.linearVelocity.y > 0 && !_isJumping)
        {
            rb.linearVelocity += Vector2.up * (Physics2D.gravity.y * Time.fixedDeltaTime * lowJumpMultiplier);
        }

        rb.linearVelocity = new Vector2(_horizontal * moveSpeed, rb.linearVelocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    private bool IsInCoyoteTime()
    {
        return Time.time - _lastGroundedTime <= coyoteTime;
    }
}