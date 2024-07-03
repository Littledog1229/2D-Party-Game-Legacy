// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace PartyGame.Input
{
    public class @PlayerInput : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""99d1f35a-5291-4cf8-a90f-dbe2281b2fe4"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""dca7f3be-7aa1-4503-b18a-b5d3e7bd4f94"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""XMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ccac4242-5f8e-463c-8a45-a4b62157e1f8"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""bbbdc7f7-1708-4945-90ef-7deac09f7cf2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3138f5a2-6657-4950-bf20-3353ae14b0b9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FireWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""77859677-8735-45c3-93b3-79363a07eac1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RandomColor"",
                    ""type"": ""Button"",
                    ""id"": ""85a4fa7f-8fbe-4a68-bf6c-9dee581397a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3fa856c2-9471-4c1a-9114-899302e42d3c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c22e6ad0-84e2-4344-8fd9-79b6bc0afd5e"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4a1c93a-a415-4701-bf43-72a223b9eae4"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""497dafc3-ddd9-45e3-a3d3-3b46f03633b2"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keys"",
                    ""id"": ""2563442b-e752-4f26-8ecb-cff3bbf88ec0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keys"",
                    ""id"": ""b3460c61-e8bf-4f23-bbd2-9dae70f5433f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5bb8961f-d8c0-4a48-b808-bdb6e73dadd2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""XMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""eaa2e291-5205-4f6b-9d59-e39410bc1020"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""XMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""aa73e050-4a3d-4816-a539-8fe3cbf9792e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""76547983-4270-47b0-a94d-4036de3e010e"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""XMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""45b5ca14-2d75-4e55-8e4a-7b35fe76a279"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""XMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6a7251f9-1c6e-42b3-a46c-5235a7661a64"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3d3f2be-9e1c-4e87-b8ed-9d8e4acbbef9"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9fc8139a-bab4-4aa2-8b41-f1acc6fa92e5"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3754dcf4-d204-44a9-8eca-a5088f3c3036"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2153081b-1db9-4c35-b5a7-150539d52ee3"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""FireWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da9a69ca-d383-4146-a171-a7e20b3c1c06"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""FireWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d41709a0-dede-460e-b668-1ae39ceeeab2"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RandomColor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8786f9bf-0848-4ae7-84e0-d54abb8db4ae"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RandomColor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Pre-game"",
            ""id"": ""4a68292e-d247-4ab5-9c30-89629f40d831"",
            ""actions"": [
                {
                    ""name"": ""Leave"",
                    ""type"": ""Button"",
                    ""id"": ""d471240b-b1f1-4fd8-b558-a5fca05096a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RandomColor"",
                    ""type"": ""Button"",
                    ""id"": ""ca703f61-b68f-4158-8ced-88b88af93e4a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""48740dca-a649-42df-adf4-99dafa8138e2"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Leave"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""feda76c7-7852-433a-94d2-29cac6f73942"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Leave"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1d2555e-c8bb-49c2-b7e4-f9383cd0e363"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RandomColor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b0d43b1-a180-4a9e-8471-70ce5e7e9f46"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RandomColor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
            m_Player_XMovement = m_Player.FindAction("XMovement", throwIfNotFound: true);
            m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
            m_Player_Aim = m_Player.FindAction("Aim", throwIfNotFound: true);
            m_Player_FireWeapon = m_Player.FindAction("FireWeapon", throwIfNotFound: true);
            m_Player_RandomColor = m_Player.FindAction("RandomColor", throwIfNotFound: true);
            // Pre-game
            m_Pregame = asset.FindActionMap("Pre-game", throwIfNotFound: true);
            m_Pregame_Leave = m_Pregame.FindAction("Leave", throwIfNotFound: true);
            m_Pregame_RandomColor = m_Pregame.FindAction("RandomColor", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // Player
        private readonly InputActionMap m_Player;
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_Player_Jump;
        private readonly InputAction m_Player_XMovement;
        private readonly InputAction m_Player_Dash;
        private readonly InputAction m_Player_Aim;
        private readonly InputAction m_Player_FireWeapon;
        private readonly InputAction m_Player_RandomColor;
        public struct PlayerActions
        {
            private @PlayerInput m_Wrapper;
            public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Jump => m_Wrapper.m_Player_Jump;
            public InputAction @XMovement => m_Wrapper.m_Player_XMovement;
            public InputAction @Dash => m_Wrapper.m_Player_Dash;
            public InputAction @Aim => m_Wrapper.m_Player_Aim;
            public InputAction @FireWeapon => m_Wrapper.m_Player_FireWeapon;
            public InputAction @RandomColor => m_Wrapper.m_Player_RandomColor;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @XMovement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnXMovement;
                    @XMovement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnXMovement;
                    @XMovement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnXMovement;
                    @Dash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                    @Dash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                    @Dash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                    @Aim.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                    @Aim.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                    @Aim.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                    @FireWeapon.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFireWeapon;
                    @FireWeapon.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFireWeapon;
                    @FireWeapon.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFireWeapon;
                    @RandomColor.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRandomColor;
                    @RandomColor.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRandomColor;
                    @RandomColor.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRandomColor;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @XMovement.started += instance.OnXMovement;
                    @XMovement.performed += instance.OnXMovement;
                    @XMovement.canceled += instance.OnXMovement;
                    @Dash.started += instance.OnDash;
                    @Dash.performed += instance.OnDash;
                    @Dash.canceled += instance.OnDash;
                    @Aim.started += instance.OnAim;
                    @Aim.performed += instance.OnAim;
                    @Aim.canceled += instance.OnAim;
                    @FireWeapon.started += instance.OnFireWeapon;
                    @FireWeapon.performed += instance.OnFireWeapon;
                    @FireWeapon.canceled += instance.OnFireWeapon;
                    @RandomColor.started += instance.OnRandomColor;
                    @RandomColor.performed += instance.OnRandomColor;
                    @RandomColor.canceled += instance.OnRandomColor;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);

        // Pre-game
        private readonly InputActionMap m_Pregame;
        private IPregameActions m_PregameActionsCallbackInterface;
        private readonly InputAction m_Pregame_Leave;
        private readonly InputAction m_Pregame_RandomColor;
        public struct PregameActions
        {
            private @PlayerInput m_Wrapper;
            public PregameActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Leave => m_Wrapper.m_Pregame_Leave;
            public InputAction @RandomColor => m_Wrapper.m_Pregame_RandomColor;
            public InputActionMap Get() { return m_Wrapper.m_Pregame; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PregameActions set) { return set.Get(); }
            public void SetCallbacks(IPregameActions instance)
            {
                if (m_Wrapper.m_PregameActionsCallbackInterface != null)
                {
                    @Leave.started -= m_Wrapper.m_PregameActionsCallbackInterface.OnLeave;
                    @Leave.performed -= m_Wrapper.m_PregameActionsCallbackInterface.OnLeave;
                    @Leave.canceled -= m_Wrapper.m_PregameActionsCallbackInterface.OnLeave;
                    @RandomColor.started -= m_Wrapper.m_PregameActionsCallbackInterface.OnRandomColor;
                    @RandomColor.performed -= m_Wrapper.m_PregameActionsCallbackInterface.OnRandomColor;
                    @RandomColor.canceled -= m_Wrapper.m_PregameActionsCallbackInterface.OnRandomColor;
                }
                m_Wrapper.m_PregameActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Leave.started += instance.OnLeave;
                    @Leave.performed += instance.OnLeave;
                    @Leave.canceled += instance.OnLeave;
                    @RandomColor.started += instance.OnRandomColor;
                    @RandomColor.performed += instance.OnRandomColor;
                    @RandomColor.canceled += instance.OnRandomColor;
                }
            }
        }
        public PregameActions @Pregame => new PregameActions(this);
        private int m_GamepadSchemeIndex = -1;
        public InputControlScheme GamepadScheme
        {
            get
            {
                if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
                return asset.controlSchemes[m_GamepadSchemeIndex];
            }
        }
        private int m_KeyboardSchemeIndex = -1;
        public InputControlScheme KeyboardScheme
        {
            get
            {
                if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
                return asset.controlSchemes[m_KeyboardSchemeIndex];
            }
        }
        public interface IPlayerActions
        {
            void OnJump(InputAction.CallbackContext context);
            void OnXMovement(InputAction.CallbackContext context);
            void OnDash(InputAction.CallbackContext context);
            void OnAim(InputAction.CallbackContext context);
            void OnFireWeapon(InputAction.CallbackContext context);
            void OnRandomColor(InputAction.CallbackContext context);
        }
        public interface IPregameActions
        {
            void OnLeave(InputAction.CallbackContext context);
            void OnRandomColor(InputAction.CallbackContext context);
        }
    }
}