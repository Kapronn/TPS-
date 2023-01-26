using UnityEngine;
using UnityEditor.Animations.Rigging;
using UnityEngine.Animations.Rigging;

public class ActionStateManager : MonoBehaviour
    {
        [HideInInspector] public ActionBaseState CurrentState;
        public ReloadState ReloadState = new ReloadState();
        public DefaultState DefaultState = new DefaultState();

        public GameObject currentWeapon;
        [HideInInspector] public WeaponManager ammo;
        [HideInInspector] public Animator animator;
        private AudioSource _audioSource;

        public MultiAimConstraint rHandAim;
        public TwoBoneIKConstraint lHandIK;
        void Start()
        {
            SwitchState(DefaultState);
            ammo = currentWeapon.GetComponent<WeaponManager>();
            _audioSource = currentWeapon.GetComponent<AudioSource>();
            animator = GetComponent<Animator>();
        }

       
        void Update()
        {
        CurrentState.UpdateState(this);
        }
        public void SwitchState(ActionBaseState state)
        {
            CurrentState = state;
            CurrentState.EnterState(this);
        }

        public void WeaponReloaded()
        {
            ammo.Reload();
            rHandAim.weight = 1;
            lHandIK.weight = 1;
            SwitchState(DefaultState);
        }

        public void MagOut()
        {
            _audioSource.PlayOneShot(ammo.magOutSound);
        }

        public void MagIn()
        {
            _audioSource.PlayOneShot(ammo.magInSound);
        }

        public void ReleaseSlide()
        {
            _audioSource.PlayOneShot(ammo.releaseSlidSound);
        }
    }
