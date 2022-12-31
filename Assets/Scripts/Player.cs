using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public PathManager pathManager;
    public UIManager UIManager;

    public Animator animator;
    public GameObject Effect;
    public GameObject forparticle;
    public GameObject barrier;
    Rigidbody rb;

    public float playerSpeed;
    public bool isFall = false;

    private Vector3 _dir;
    private float _roty = 0;

    void Start() {
        _dir = Vector3.zero;
        rb = GetComponent<Rigidbody>();
    }
    void Update() {
        Movement();
        IncreasePlayerSpeedAndAnimSpeed();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Point")) {
            Destroy(other.gameObject);
            animator.SetTrigger("Point");
            UIManager.score += 5;
            var _instantiatedEff = Instantiate(Effect, forparticle.transform.position, forparticle.transform.rotation);
            Destroy(_instantiatedEff, 1.5f);
        }

        if (other.CompareTag("Jump")) {
            animator.SetTrigger("Jump");
            StartCoroutine(ResetJumpAnimation());
        }
    }
    private void OnTriggerExit(Collider other) {

        if (other.gameObject.CompareTag("Jump")) {
            StartCoroutine(AddDelay());
            other.gameObject.AddComponent<Rigidbody>();
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.CompareTag("Path")) {
            pathManager.SpawnPath();
            UIManager.score++;
            collision.gameObject.AddComponent<Rigidbody>();

            Destroy(collision.gameObject, 3f);
            StartCoroutine(ResetPointAnim());

        }

    }

    void Movement() {

        transform.rotation = Quaternion.Euler(0, _roty, 0);
        transform.Translate(_dir * playerSpeed * Time.deltaTime);

        if (transform.position.y < 1.48f) {
            isFall = true;
            animator.SetTrigger("isFall");
            return;

        } else if (transform.position.y > 1.47999f) {


            if (Input.GetMouseButtonDown(0)) {

                animator.SetTrigger("isMove");
                _dir = Vector3.forward;

                if (transform.localRotation.y == 0) {
                    _roty = -90;
                } else {
                    _roty = 0;
                }
            }
        }

        if (isFall) {
            return;
        }




    }
    void IncreasePlayerSpeedAndAnimSpeed() {

        if (UIManager.score > 100 && UIManager.score < 200) {
            playerSpeed = 4.5f;
            animator.SetFloat("PickUpSpeed", 1.25f);
            animator.SetFloat("RunningSpeed", 1.30f);
        } else if (UIManager.score > 200 && UIManager.score < 300) {
            playerSpeed = 5f;
            animator.SetFloat("PickUpSpeed", 1.40f);
            animator.SetFloat("RunningSpeed", 1.35f);
        } else if (UIManager.score > 300 && UIManager.score < 400) {
            playerSpeed = 5.2f;
            animator.SetFloat("PickUpSpeed", 1.50f);
            animator.SetFloat("RunningSpeed", 1.4f);
        } else if (UIManager.score > 400 && UIManager.score < 500) {
            playerSpeed = 5.4f;
            animator.SetFloat("PickUpSpeed", 1.60f);
            animator.SetFloat("RunningSpeed", 1.45f);
        } else if (UIManager.score > 500 && UIManager.score < 600) {
            playerSpeed = 5.6f;
            animator.SetFloat("PickUpSpeed", 1.70f);
            animator.SetFloat("RunningSpeed", 1.50f);
        } else if (UIManager.score > 600 && UIManager.score < 700) {
            playerSpeed = 5.8f;
            animator.SetFloat("PickUpSpeed", 1.80f);
        } else if (UIManager.score > 700 && UIManager.score < 800) {
            playerSpeed = 6f;
        } else if (UIManager.score > 800 && UIManager.score < 900) {
            playerSpeed = 6.2f;
        } else if (UIManager.score > 900 && UIManager.score < 1000) {
            playerSpeed = 6.5f;
        }
    }
    IEnumerator ResetJumpAnimation() {
        yield return new WaitForSeconds(0.05f);
        animator.ResetTrigger("Jump");
    }
    IEnumerator ResetPointAnim() {
        yield return new WaitForSeconds(0.05f);
        animator.ResetTrigger("Point");
    }
    IEnumerator AddDelay() {
        yield return new WaitForSeconds(1f);
    }


}

