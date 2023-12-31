//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/200_Scripts/201_GameManager/InputMap.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputMap: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMap"",
    ""maps"": [
        {
            ""name"": ""Fighting"",
            ""id"": ""92db921a-dd2d-4ebf-b22c-e44170c7a514"",
            ""actions"": [
                {
                    ""name"": ""Direction"",
                    ""type"": ""Value"",
                    ""id"": ""a8aeaf74-0019-4e58-8fa1-e5f733e1f1b3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""OpenUIStats"",
                    ""type"": ""Button"",
                    ""id"": ""fdb2edce-79f1-420d-9729-41c53e82675c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShootHarpoon"",
                    ""type"": ""Button"",
                    ""id"": ""c27d0ac0-477d-4a78-a15a-d28d183ca2ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a827a5a4-ffce-4446-ba81-b3976e8c019e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ForceHarpoonBack"",
                    ""type"": ""Button"",
                    ""id"": ""6943b5af-c585-49a3-9bcb-8e2addc41c98"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ChangeActionMap"",
                    ""type"": ""Button"",
                    ""id"": ""61143ffd-c8ee-474a-91fb-b0afe02114c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a89113a3-64b9-4a61-a539-0d0add5f5a89"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a3d1bd1f-2c8b-4ba8-8dcd-99a91634caf7"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""767fffb5-026f-4ee5-88bd-a51347db9ac8"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a83512f4-0719-4ab7-ac38-d071419790b0"",
                    ""path"": ""<Keyboard>/#(Q)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fd050ea2-9cec-4579-b6ce-c39410a9ff9b"",
                    ""path"": ""<Keyboard>/#(D)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""486a87dc-87b2-4641-b57e-2e2b0bc10e37"",
                    ""path"": ""<Keyboard>/#(P)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenUIStats"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7e2ff14-e1e8-4f68-8ea5-75225435cc7b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootHarpoon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""929b64fa-d313-4f1e-ab1b-2f3416035ccc"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ff00b4d3-17ba-4652-996d-efe4d597255b"",
                    ""path"": ""<Keyboard>/#(Z)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d90d3e6a-6a8f-4793-aa20-0803417cf66b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1fe90561-0024-4066-9f1e-201814aa925d"",
                    ""path"": ""<Keyboard>/#(Q)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1a0d4b62-7ddd-48b1-9695-e1a40c1f4549"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""731e3426-ab76-4c8e-9223-1f9abb4a40ef"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ForceHarpoonBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3cebae18-150b-47aa-aeae-69a072453df2"",
                    ""path"": ""<Keyboard>/#(M)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeActionMap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Exploring"",
            ""id"": ""a3548b58-b847-461f-a7f6-c9f9d89487d6"",
            ""actions"": [
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Button"",
                    ""id"": ""709a4bf4-a5df-42d1-8c9f-db370f754b76"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OpenUIStats"",
                    ""type"": ""Button"",
                    ""id"": ""b8e41af2-018c-4cea-96c5-fa4804030c68"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ForceHarpoonBack"",
                    ""type"": ""Button"",
                    ""id"": ""ac108b1c-3e85-4e16-882f-f4c2c368ea2e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShootHarpoon"",
                    ""type"": ""Button"",
                    ""id"": ""c86934ba-1a50-4dc2-acc8-7224dcb0f7fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Breaking"",
                    ""type"": ""Button"",
                    ""id"": ""a58568c4-382b-446d-9da4-1dcd1f9c3a88"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""483b799d-3436-4f81-b1c2-78d5741987e2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ChangeActionMap"",
                    ""type"": ""Button"",
                    ""id"": ""f4938401-b80e-4471-a932-6413ae7d18de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CameraMovement "",
                    ""type"": ""PassThrough"",
                    ""id"": ""0168a754-8af2-4f3f-805b-a91751a43faa"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""59f8fe2a-a665-4a13-8d29-a3975d5aac6c"",
                    ""path"": ""<Keyboard>/#(Z)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6298d14-d7f9-4c95-94e5-6ccb32c07951"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eca1d480-9824-4e14-a690-bccbb53cff71"",
                    ""path"": ""<Keyboard>/#(S)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Breaking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35ac6af0-c7ad-4356-9974-9aba55fee8ad"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Breaking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""04dae03f-bbe0-4eb7-8b69-3acd1d9dc1f6"",
                    ""path"": ""2DVector"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""df10ecf5-5931-4126-b6d0-a6d701f4168f"",
                    ""path"": ""<Keyboard>/#(Q)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9bc17df5-6987-471b-b69f-6edd03dac4a3"",
                    ""path"": ""<Keyboard>/#(D)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""13084340-097a-44a3-93ce-2cff00c9252c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""22f5084d-44b4-4b14-83e4-daf87f6aa5f4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootHarpoon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7a199a2-acbd-4809-a6e4-2bfdb148c369"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ForceHarpoonBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d38ff99c-54d5-4e2a-a7b3-9ce9a9ff5177"",
                    ""path"": ""<Keyboard>/#(P)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenUIStats"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""912c3c8b-98b9-4295-986e-a64e5de3c5b8"",
                    ""path"": ""<Keyboard>/#(M)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeActionMap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""930cb6fb-37e4-4005-8c03-e68176158408"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement "",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85e13ff3-7039-42a6-a3d9-214ff1ecde6e"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement "",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Fighting
        m_Fighting = asset.FindActionMap("Fighting", throwIfNotFound: true);
        m_Fighting_Direction = m_Fighting.FindAction("Direction", throwIfNotFound: true);
        m_Fighting_OpenUIStats = m_Fighting.FindAction("OpenUIStats", throwIfNotFound: true);
        m_Fighting_ShootHarpoon = m_Fighting.FindAction("ShootHarpoon", throwIfNotFound: true);
        m_Fighting_Move = m_Fighting.FindAction("Move", throwIfNotFound: true);
        m_Fighting_ForceHarpoonBack = m_Fighting.FindAction("ForceHarpoonBack", throwIfNotFound: true);
        m_Fighting_ChangeActionMap = m_Fighting.FindAction("ChangeActionMap", throwIfNotFound: true);
        // Exploring
        m_Exploring = asset.FindActionMap("Exploring", throwIfNotFound: true);
        m_Exploring_Accelerate = m_Exploring.FindAction("Accelerate", throwIfNotFound: true);
        m_Exploring_OpenUIStats = m_Exploring.FindAction("OpenUIStats", throwIfNotFound: true);
        m_Exploring_ForceHarpoonBack = m_Exploring.FindAction("ForceHarpoonBack", throwIfNotFound: true);
        m_Exploring_ShootHarpoon = m_Exploring.FindAction("ShootHarpoon", throwIfNotFound: true);
        m_Exploring_Breaking = m_Exploring.FindAction("Breaking", throwIfNotFound: true);
        m_Exploring_Movement = m_Exploring.FindAction("Movement", throwIfNotFound: true);
        m_Exploring_ChangeActionMap = m_Exploring.FindAction("ChangeActionMap", throwIfNotFound: true);
        m_Exploring_CameraMovement = m_Exploring.FindAction("CameraMovement ", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Fighting
    private readonly InputActionMap m_Fighting;
    private List<IFightingActions> m_FightingActionsCallbackInterfaces = new List<IFightingActions>();
    private readonly InputAction m_Fighting_Direction;
    private readonly InputAction m_Fighting_OpenUIStats;
    private readonly InputAction m_Fighting_ShootHarpoon;
    private readonly InputAction m_Fighting_Move;
    private readonly InputAction m_Fighting_ForceHarpoonBack;
    private readonly InputAction m_Fighting_ChangeActionMap;
    public struct FightingActions
    {
        private @InputMap m_Wrapper;
        public FightingActions(@InputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Direction => m_Wrapper.m_Fighting_Direction;
        public InputAction @OpenUIStats => m_Wrapper.m_Fighting_OpenUIStats;
        public InputAction @ShootHarpoon => m_Wrapper.m_Fighting_ShootHarpoon;
        public InputAction @Move => m_Wrapper.m_Fighting_Move;
        public InputAction @ForceHarpoonBack => m_Wrapper.m_Fighting_ForceHarpoonBack;
        public InputAction @ChangeActionMap => m_Wrapper.m_Fighting_ChangeActionMap;
        public InputActionMap Get() { return m_Wrapper.m_Fighting; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FightingActions set) { return set.Get(); }
        public void AddCallbacks(IFightingActions instance)
        {
            if (instance == null || m_Wrapper.m_FightingActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_FightingActionsCallbackInterfaces.Add(instance);
            @Direction.started += instance.OnDirection;
            @Direction.performed += instance.OnDirection;
            @Direction.canceled += instance.OnDirection;
            @OpenUIStats.started += instance.OnOpenUIStats;
            @OpenUIStats.performed += instance.OnOpenUIStats;
            @OpenUIStats.canceled += instance.OnOpenUIStats;
            @ShootHarpoon.started += instance.OnShootHarpoon;
            @ShootHarpoon.performed += instance.OnShootHarpoon;
            @ShootHarpoon.canceled += instance.OnShootHarpoon;
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @ForceHarpoonBack.started += instance.OnForceHarpoonBack;
            @ForceHarpoonBack.performed += instance.OnForceHarpoonBack;
            @ForceHarpoonBack.canceled += instance.OnForceHarpoonBack;
            @ChangeActionMap.started += instance.OnChangeActionMap;
            @ChangeActionMap.performed += instance.OnChangeActionMap;
            @ChangeActionMap.canceled += instance.OnChangeActionMap;
        }

        private void UnregisterCallbacks(IFightingActions instance)
        {
            @Direction.started -= instance.OnDirection;
            @Direction.performed -= instance.OnDirection;
            @Direction.canceled -= instance.OnDirection;
            @OpenUIStats.started -= instance.OnOpenUIStats;
            @OpenUIStats.performed -= instance.OnOpenUIStats;
            @OpenUIStats.canceled -= instance.OnOpenUIStats;
            @ShootHarpoon.started -= instance.OnShootHarpoon;
            @ShootHarpoon.performed -= instance.OnShootHarpoon;
            @ShootHarpoon.canceled -= instance.OnShootHarpoon;
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @ForceHarpoonBack.started -= instance.OnForceHarpoonBack;
            @ForceHarpoonBack.performed -= instance.OnForceHarpoonBack;
            @ForceHarpoonBack.canceled -= instance.OnForceHarpoonBack;
            @ChangeActionMap.started -= instance.OnChangeActionMap;
            @ChangeActionMap.performed -= instance.OnChangeActionMap;
            @ChangeActionMap.canceled -= instance.OnChangeActionMap;
        }

        public void RemoveCallbacks(IFightingActions instance)
        {
            if (m_Wrapper.m_FightingActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IFightingActions instance)
        {
            foreach (var item in m_Wrapper.m_FightingActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_FightingActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public FightingActions @Fighting => new FightingActions(this);

    // Exploring
    private readonly InputActionMap m_Exploring;
    private List<IExploringActions> m_ExploringActionsCallbackInterfaces = new List<IExploringActions>();
    private readonly InputAction m_Exploring_Accelerate;
    private readonly InputAction m_Exploring_OpenUIStats;
    private readonly InputAction m_Exploring_ForceHarpoonBack;
    private readonly InputAction m_Exploring_ShootHarpoon;
    private readonly InputAction m_Exploring_Breaking;
    private readonly InputAction m_Exploring_Movement;
    private readonly InputAction m_Exploring_ChangeActionMap;
    private readonly InputAction m_Exploring_CameraMovement;
    public struct ExploringActions
    {
        private @InputMap m_Wrapper;
        public ExploringActions(@InputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Accelerate => m_Wrapper.m_Exploring_Accelerate;
        public InputAction @OpenUIStats => m_Wrapper.m_Exploring_OpenUIStats;
        public InputAction @ForceHarpoonBack => m_Wrapper.m_Exploring_ForceHarpoonBack;
        public InputAction @ShootHarpoon => m_Wrapper.m_Exploring_ShootHarpoon;
        public InputAction @Breaking => m_Wrapper.m_Exploring_Breaking;
        public InputAction @Movement => m_Wrapper.m_Exploring_Movement;
        public InputAction @ChangeActionMap => m_Wrapper.m_Exploring_ChangeActionMap;
        public InputAction @CameraMovement => m_Wrapper.m_Exploring_CameraMovement;
        public InputActionMap Get() { return m_Wrapper.m_Exploring; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ExploringActions set) { return set.Get(); }
        public void AddCallbacks(IExploringActions instance)
        {
            if (instance == null || m_Wrapper.m_ExploringActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ExploringActionsCallbackInterfaces.Add(instance);
            @Accelerate.started += instance.OnAccelerate;
            @Accelerate.performed += instance.OnAccelerate;
            @Accelerate.canceled += instance.OnAccelerate;
            @OpenUIStats.started += instance.OnOpenUIStats;
            @OpenUIStats.performed += instance.OnOpenUIStats;
            @OpenUIStats.canceled += instance.OnOpenUIStats;
            @ForceHarpoonBack.started += instance.OnForceHarpoonBack;
            @ForceHarpoonBack.performed += instance.OnForceHarpoonBack;
            @ForceHarpoonBack.canceled += instance.OnForceHarpoonBack;
            @ShootHarpoon.started += instance.OnShootHarpoon;
            @ShootHarpoon.performed += instance.OnShootHarpoon;
            @ShootHarpoon.canceled += instance.OnShootHarpoon;
            @Breaking.started += instance.OnBreaking;
            @Breaking.performed += instance.OnBreaking;
            @Breaking.canceled += instance.OnBreaking;
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @ChangeActionMap.started += instance.OnChangeActionMap;
            @ChangeActionMap.performed += instance.OnChangeActionMap;
            @ChangeActionMap.canceled += instance.OnChangeActionMap;
            @CameraMovement.started += instance.OnCameraMovement;
            @CameraMovement.performed += instance.OnCameraMovement;
            @CameraMovement.canceled += instance.OnCameraMovement;
        }

        private void UnregisterCallbacks(IExploringActions instance)
        {
            @Accelerate.started -= instance.OnAccelerate;
            @Accelerate.performed -= instance.OnAccelerate;
            @Accelerate.canceled -= instance.OnAccelerate;
            @OpenUIStats.started -= instance.OnOpenUIStats;
            @OpenUIStats.performed -= instance.OnOpenUIStats;
            @OpenUIStats.canceled -= instance.OnOpenUIStats;
            @ForceHarpoonBack.started -= instance.OnForceHarpoonBack;
            @ForceHarpoonBack.performed -= instance.OnForceHarpoonBack;
            @ForceHarpoonBack.canceled -= instance.OnForceHarpoonBack;
            @ShootHarpoon.started -= instance.OnShootHarpoon;
            @ShootHarpoon.performed -= instance.OnShootHarpoon;
            @ShootHarpoon.canceled -= instance.OnShootHarpoon;
            @Breaking.started -= instance.OnBreaking;
            @Breaking.performed -= instance.OnBreaking;
            @Breaking.canceled -= instance.OnBreaking;
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @ChangeActionMap.started -= instance.OnChangeActionMap;
            @ChangeActionMap.performed -= instance.OnChangeActionMap;
            @ChangeActionMap.canceled -= instance.OnChangeActionMap;
            @CameraMovement.started -= instance.OnCameraMovement;
            @CameraMovement.performed -= instance.OnCameraMovement;
            @CameraMovement.canceled -= instance.OnCameraMovement;
        }

        public void RemoveCallbacks(IExploringActions instance)
        {
            if (m_Wrapper.m_ExploringActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IExploringActions instance)
        {
            foreach (var item in m_Wrapper.m_ExploringActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ExploringActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ExploringActions @Exploring => new ExploringActions(this);
    public interface IFightingActions
    {
        void OnDirection(InputAction.CallbackContext context);
        void OnOpenUIStats(InputAction.CallbackContext context);
        void OnShootHarpoon(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnForceHarpoonBack(InputAction.CallbackContext context);
        void OnChangeActionMap(InputAction.CallbackContext context);
    }
    public interface IExploringActions
    {
        void OnAccelerate(InputAction.CallbackContext context);
        void OnOpenUIStats(InputAction.CallbackContext context);
        void OnForceHarpoonBack(InputAction.CallbackContext context);
        void OnShootHarpoon(InputAction.CallbackContext context);
        void OnBreaking(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnChangeActionMap(InputAction.CallbackContext context);
        void OnCameraMovement(InputAction.CallbackContext context);
    }
}
