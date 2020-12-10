using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newmove : MonoBehaviour
{
    //컨트롤 모드
    private enum ControlMode
    {
        Tank
    }

    //점프 높이
    [SerializeField] private float m_jumpForce = 4f;
    //이동 속도 
    [SerializeField] private float m_moveForce = 0.2f;
    //애니메이터 설정
    [SerializeField] private Animator m_animator = null;
    //리지드 바디 설정 
    [SerializeField] private Rigidbody m_rigidBody = null;
    //초기 컨트롤 모드를 Tank로 설정
    [SerializeField] private ControlMode m_controlMode = ControlMode.Tank;

    private bool m_wasGrounded;
    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 0.25f;
    private bool m_jumpInput = false;

    private bool m_isGrounded;

    private List<Collider> m_collisions = new List<Collider>();

    //코드에 연결된 리지드 바디와 애니메이션을 깨움
    private void Awake()
    {
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { gameObject.GetComponent<Animator>(); }
    }

    //??~
    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!m_collisions.Contains(collision.collider))
                {
                    m_collisions.Add(collision.collider);
                }
                m_isGrounded = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if (validSurfaceNormal)
        {
            m_isGrounded = true;
            if (!m_collisions.Contains(collision.collider))
            {
                m_collisions.Add(collision.collider);
            }
        }
        else
        {
            if (m_collisions.Contains(collision.collider))
            {
                m_collisions.Remove(collision.collider);
            }
            if (m_collisions.Count == 0) { m_isGrounded = false; }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isGrounded = false; }
    }
    //~??


    private void Update()
    {
        if (transform.position.z < -10.6f)
        {
            SceneManager.LoadScene("Die");
        }

        //위치 변경 - 왼쪽
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * m_moveForce * Time.deltaTime);
        }

        //위치변경 - 오른쪽
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * m_moveForce * Time.deltaTime);
        }

        //m_jumpInput 이 false고  GetKey-UpArrow가 눌렸을 때 m_jumpInput 을 true 변경
        if (!m_jumpInput && Input.GetKey(KeyCode.UpArrow))
        {
            m_jumpInput = true;
        }

        if (transform.position.z < -9.59f)
        {
            //앞으로 감
            transform.Translate(new Vector3(0, 0, 0.1f*Time.deltaTime));
        }

    }

    private void FixedUpdate()
    {
        m_animator.SetBool("Grounded", m_isGrounded);

        switch (m_controlMode)
        {
            //컨트롤 모드가 Tank 일때 TankUpdate 함수 실행
            case ControlMode.Tank:
                TankUpdate();
                break;

            default:
                Debug.LogError("Unsupported state");
                break;
        }

        m_wasGrounded = m_isGrounded;
        m_jumpInput = false;
    }

    private void TankUpdate()
    {
        //달리는 애니메이션 속도 설정 두번째 인자는 0f에서 1f까지 입력. 숫자가 클수록 움직임이 빨라짐
        m_animator.SetFloat("MoveSpeed", 1f);
        JumpingAndLanding();
    }

    //점프와 땅(트리거) 수정용 코드
    private void JumpingAndLanding()
    {
        bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

        if (jumpCooldownOver && m_isGrounded && m_jumpInput)
        {
            m_jumpTimeStamp = Time.time;
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
        }

        //아래는 애니메이션 트리거 수정용 인듯
        if (!m_wasGrounded && m_isGrounded)
        {
            m_animator.SetTrigger("Land");
        }

        if (!m_isGrounded && m_wasGrounded)
        {
            m_animator.SetTrigger("Jump");
        }
    }
}