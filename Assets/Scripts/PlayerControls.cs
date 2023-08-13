// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""FPSControl"",
            ""id"": ""3a792d79-4075-4c12-a034-c8388a6bc5a0"",
            ""actions"": [
                {
                    ""name"": ""MouseX"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8d83e410-6d0e-46eb-b6b8-ae950c1786d0"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseY"",
                    ""type"": ""PassThrough"",
                    ""id"": ""72d60bbe-1121-4499-9b8c-ea0933be7acd"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""344b2493-7f61-47eb-9fb8-4b0c89e2a8d1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""PassThrough"",
                    ""id"": ""fab02e68-015f-474b-a3f5-4f6f055b985b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""26c6c358-72e5-435d-b3c6-c0594db5ba3e"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04ed195f-b544-4d1d-b7dd-96ec73e4ad6b"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a1d6a8c1-9615-4578-a390-0910caff28c0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""75d94b6c-954a-4633-826d-b68ba7987d62"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d6f19953-a1a3-41cd-bf3e-164a6dd0768a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3b4945f3-4d44-440a-8f44-98be8bd4e6fe"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c6853179-c066-4d8b-a538-47965dc3c754"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e73850e1-55d9-47c3-9d43-8127600ecb25"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Actions"",
            ""id"": ""64970f27-77ee-48ee-8501-f7f3365f682f"",
            ""actions"": [
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""d684c948-f2d6-4852-8f34-bca6d6829113"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""6851e766-660c-4b76-a4ba-aa99e9868522"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch Flashlight"",
                    ""type"": ""Button"",
                    ""id"": ""0571f7e4-9277-4b57-b1b5-987b56eee449"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TurnOnCheat"",
                    ""type"": ""Button"",
                    ""id"": ""3e4c6db2-cfe7-47bd-b916-d82a9b1be9a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2ca464fa-3ea6-42b6-8328-6bf91796492c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35cce722-8a83-492b-b483-b41f66ea55f1"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch Flashlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9bf58aab-6ec2-4ade-9e91-5130af728423"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""941648f4-2b20-401a-9e7f-26747361cc37"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnOnCheat"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""0ecc80fd-7107-4e74-96f6-5b97248e96ce"",
            ""actions"": [
                {
                    ""name"": ""Switch Pad"",
                    ""type"": ""Button"",
                    ""id"": ""c837fbda-0c32-4441-b236-d166215adca7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""2ecdb85b-456d-4191-b0c6-d6a26a5c4f57"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""5bcc0b50-1e77-4116-b7f3-e4538b927a31"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7f4187c3-8535-4a94-bbf1-4a1051c07d30"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch Pad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05d55afe-b06a-439e-997c-5b6632461d1b"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae35eff4-3715-45b0-aff2-73552d2ab191"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // FPSControl
        m_FPSControl = asset.FindActionMap("FPSControl", throwIfNotFound: true);
        m_FPSControl_MouseX = m_FPSControl.FindAction("MouseX", throwIfNotFound: true);
        m_FPSControl_MouseY = m_FPSControl.FindAction("MouseY", throwIfNotFound: true);
        m_FPSControl_Movement = m_FPSControl.FindAction("Movement", throwIfNotFound: true);
        m_FPSControl_Crouch = m_FPSControl.FindAction("Crouch", throwIfNotFound: true);
        // Actions
        m_Actions = asset.FindActionMap("Actions", throwIfNotFound: true);
        m_Actions_Action = m_Actions.FindAction("Action", throwIfNotFound: true);
        m_Actions_Drop = m_Actions.FindAction("Drop", throwIfNotFound: true);
        m_Actions_SwitchFlashlight = m_Actions.FindAction("Switch Flashlight", throwIfNotFound: true);
        m_Actions_TurnOnCheat = m_Actions.FindAction("TurnOnCheat", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_SwitchPad = m_Menu.FindAction("Switch Pad", throwIfNotFound: true);
        m_Menu_Exit = m_Menu.FindAction("Exit", throwIfNotFound: true);
        m_Menu_Restart = m_Menu.FindAction("Restart", throwIfNotFound: true);
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

    // FPSControl
    private readonly InputActionMap m_FPSControl;
    private IFPSControlActions m_FPSControlActionsCallbackInterface;
    private readonly InputAction m_FPSControl_MouseX;
    private readonly InputAction m_FPSControl_MouseY;
    private readonly InputAction m_FPSControl_Movement;
    private readonly InputAction m_FPSControl_Crouch;
    public struct FPSControlActions
    {
        private @PlayerControls m_Wrapper;
        public FPSControlActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseX => m_Wrapper.m_FPSControl_MouseX;
        public InputAction @MouseY => m_Wrapper.m_FPSControl_MouseY;
        public InputAction @Movement => m_Wrapper.m_FPSControl_Movement;
        public InputAction @Crouch => m_Wrapper.m_FPSControl_Crouch;
        public InputActionMap Get() { return m_Wrapper.m_FPSControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FPSControlActions set) { return set.Get(); }
        public void SetCallbacks(IFPSControlActions instance)
        {
            if (m_Wrapper.m_FPSControlActionsCallbackInterface != null)
            {
                @MouseX.started -= m_Wrapper.m_FPSControlActionsCallbackInterface.OnMouseX;
                @MouseX.performed -= m_Wrapper.m_FPSControlActionsCallbackInterface.OnMouseX;
                @MouseX.canceled -= m_Wrapper.m_FPSControlActionsCallbackInterface.OnMouseX;
                @MouseY.started -= m_Wrapper.m_FPSControlActionsCallbackInterface.OnMouseY;
                @MouseY.performed -= m_Wrapper.m_FPSControlActionsCallbackInterface.OnMouseY;
                @MouseY.canceled -= m_Wrapper.m_FPSControlActionsCallbackInterface.OnMouseY;
                @Movement.started -= m_Wrapper.m_FPSControlActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_FPSControlActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_FPSControlActionsCallbackInterface.OnMovement;
                @Crouch.started -= m_Wrapper.m_FPSControlActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_FPSControlActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_FPSControlActionsCallbackInterface.OnCrouch;
            }
            m_Wrapper.m_FPSControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseX.started += instance.OnMouseX;
                @MouseX.performed += instance.OnMouseX;
                @MouseX.canceled += instance.OnMouseX;
                @MouseY.started += instance.OnMouseY;
                @MouseY.performed += instance.OnMouseY;
                @MouseY.canceled += instance.OnMouseY;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
            }
        }
    }
    public FPSControlActions @FPSControl => new FPSControlActions(this);

    // Actions
    private readonly InputActionMap m_Actions;
    private IActionsActions m_ActionsActionsCallbackInterface;
    private readonly InputAction m_Actions_Action;
    private readonly InputAction m_Actions_Drop;
    private readonly InputAction m_Actions_SwitchFlashlight;
    private readonly InputAction m_Actions_TurnOnCheat;
    public struct ActionsActions
    {
        private @PlayerControls m_Wrapper;
        public ActionsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Action => m_Wrapper.m_Actions_Action;
        public InputAction @Drop => m_Wrapper.m_Actions_Drop;
        public InputAction @SwitchFlashlight => m_Wrapper.m_Actions_SwitchFlashlight;
        public InputAction @TurnOnCheat => m_Wrapper.m_Actions_TurnOnCheat;
        public InputActionMap Get() { return m_Wrapper.m_Actions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionsActions set) { return set.Get(); }
        public void SetCallbacks(IActionsActions instance)
        {
            if (m_Wrapper.m_ActionsActionsCallbackInterface != null)
            {
                @Action.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnAction;
                @Action.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnAction;
                @Action.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnAction;
                @Drop.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnDrop;
                @Drop.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnDrop;
                @Drop.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnDrop;
                @SwitchFlashlight.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSwitchFlashlight;
                @SwitchFlashlight.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSwitchFlashlight;
                @SwitchFlashlight.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSwitchFlashlight;
                @TurnOnCheat.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnTurnOnCheat;
                @TurnOnCheat.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnTurnOnCheat;
                @TurnOnCheat.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnTurnOnCheat;
            }
            m_Wrapper.m_ActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Action.started += instance.OnAction;
                @Action.performed += instance.OnAction;
                @Action.canceled += instance.OnAction;
                @Drop.started += instance.OnDrop;
                @Drop.performed += instance.OnDrop;
                @Drop.canceled += instance.OnDrop;
                @SwitchFlashlight.started += instance.OnSwitchFlashlight;
                @SwitchFlashlight.performed += instance.OnSwitchFlashlight;
                @SwitchFlashlight.canceled += instance.OnSwitchFlashlight;
                @TurnOnCheat.started += instance.OnTurnOnCheat;
                @TurnOnCheat.performed += instance.OnTurnOnCheat;
                @TurnOnCheat.canceled += instance.OnTurnOnCheat;
            }
        }
    }
    public ActionsActions @Actions => new ActionsActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_SwitchPad;
    private readonly InputAction m_Menu_Exit;
    private readonly InputAction m_Menu_Restart;
    public struct MenuActions
    {
        private @PlayerControls m_Wrapper;
        public MenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @SwitchPad => m_Wrapper.m_Menu_SwitchPad;
        public InputAction @Exit => m_Wrapper.m_Menu_Exit;
        public InputAction @Restart => m_Wrapper.m_Menu_Restart;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @SwitchPad.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnSwitchPad;
                @SwitchPad.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnSwitchPad;
                @SwitchPad.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnSwitchPad;
                @Exit.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnExit;
                @Restart.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnRestart;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SwitchPad.started += instance.OnSwitchPad;
                @SwitchPad.performed += instance.OnSwitchPad;
                @SwitchPad.canceled += instance.OnSwitchPad;
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    public interface IFPSControlActions
    {
        void OnMouseX(InputAction.CallbackContext context);
        void OnMouseY(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
    }
    public interface IActionsActions
    {
        void OnAction(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
        void OnSwitchFlashlight(InputAction.CallbackContext context);
        void OnTurnOnCheat(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnSwitchPad(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
    }
}
