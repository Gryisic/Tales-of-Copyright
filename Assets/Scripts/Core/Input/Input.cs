// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Core/Input/Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Core.Input
{
    public class @PlayerInput : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""Adventure"",
            ""id"": ""6f4569a5-f161-4a4e-a6de-50af24839937"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""218729e0-8b7a-4cdd-8d29-89a180391b2b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""b4d43642-48b2-4a21-8393-5d24c556838f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Direction Vector"",
                    ""id"": ""db1f7092-dfc4-40cc-9baa-524541d430b6"",
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
                    ""id"": ""b490e574-233d-493f-87f7-2bcfc6dad9e9"",
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
                    ""id"": ""e6e5ae80-3b0a-4333-aa46-37187df975df"",
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
                    ""id"": ""c68eb00f-0701-4efa-8960-ec2bc51a9f58"",
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
                    ""id"": ""8215b8be-2bd5-4b2b-9751-7f482774804d"",
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
                    ""id"": ""98ebb913-9ebe-49b6-9e6e-046de75dcc43"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Battle"",
            ""id"": ""36e47a0d-b156-4d96-a0d0-89ffdf9c6179"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""74c19644-1e42-4b70-bae1-b3ed6709ed10"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""f753b1fa-4fc8-409b-9214-c612d93de0cc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Guard"",
                    ""type"": ""Button"",
                    ""id"": ""f56ebd63-c012-4211-bca2-02861deb867a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill"",
                    ""type"": ""Button"",
                    ""id"": ""5b534498-06c8-4bb6-bec3-ff67c8ab9e1e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CycleClockwise"",
                    ""type"": ""Button"",
                    ""id"": ""e0259bd5-5d10-4d4c-a47f-dd7fe8a8b6cf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CycleCounterclockwise"",
                    ""type"": ""Button"",
                    ""id"": ""04f67904-bfaa-434a-b29d-e88f47214a7e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TargetSelection"",
                    ""type"": ""Button"",
                    ""id"": ""25edaedf-bfb8-4eff-9501-2a568780852f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NextPartyMember"",
                    ""type"": ""Button"",
                    ""id"": ""02c72fe2-5cc4-47c2-b5c9-23c505bfa518"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PreviousPartyMember"",
                    ""type"": ""Button"",
                    ""id"": ""621c5156-66d0-4777-b46c-2fb6716bf610"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Direction Vector"",
                    ""id"": ""2699b1bd-1808-4a9a-a9a0-62e9c1ce8e38"",
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
                    ""id"": ""ebb57234-bcba-4609-a8dc-023947bb8187"",
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
                    ""id"": ""a8dd5034-0bbd-4f4f-a255-ea225dd49725"",
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
                    ""id"": ""b73ba5e8-5e0a-4442-92c4-e5bd14bd657d"",
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
                    ""id"": ""566c22da-4e9b-4c16-95ab-6bf0bea3d012"",
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
                    ""id"": ""57ff2c1b-1ca5-4f6d-b541-8c4ff48465db"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""946b96de-7eca-4eca-8335-817922ac8eb7"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Guard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44377785-ca65-4bd9-bca0-b16e308b8a7b"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b3c2017-f1dc-4d18-9755-14acf8ef2493"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleClockwise"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""622b22d4-14f1-4c3b-a4e6-e287516db686"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleClockwise"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8486ee2-e9ca-4a34-b89e-2e15c565619a"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleCounterclockwise"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11702f47-094d-433a-8ea2-ea4148ad35fd"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleCounterclockwise"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97c38dfc-d821-454a-b7af-ed1a463e450c"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TargetSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05ec6bab-dc8c-48e6-86f1-fc5722434eb1"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextPartyMember"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ceb505a2-033e-41c5-91c1-5aa8f9698dfb"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PreviousPartyMember"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""0be8bf32-b20f-41ac-9146-88f5278cc108"",
            ""actions"": [
                {
                    ""name"": ""TrackedDeviceOrientation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""622f89f9-a3f6-4389-8179-28a33174c72b"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDevicePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1339431f-a7a5-4a89-b583-fae1c593203c"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b5eeb2e6-aaf4-4614-a9ab-541cf7698624"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""38a9f38b-0d3a-4d50-bc72-bd52e152b5bf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b3b82fd2-dd0c-4bac-8ead-8a18c91b719b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""ca2bcf6f-121a-4803-bd58-4e72c5fefd16"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""05aba9bc-3e22-403b-9ef3-0568e9a496c0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""3d4a46e2-3cd9-4946-958b-b534fe38716f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""be97e819-a93b-41e8-937b-b3a349a58b32"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""c6d6ff74-fff8-42b4-a075-6fee7cdc2b58"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""75468731-8e6f-46fe-a2b5-1a5e4826231e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0f250693-4ed2-49a1-b668-ea3c10a9b9bd"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ac4e02c3-5eed-405c-a922-1cd7cba0eecc"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a43af423-8710-4565-b6c0-ba93be9e46d5"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""313647e7-0bb6-4cd9-a28b-b367db69f2d7"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""85c2c0f4-2774-40e8-b43b-fd432183d659"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7da12737-2bb8-45c1-862b-99e593e35777"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ef16d077-05d8-45fd-8e1e-77cfc806e1b8"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""16040d66-e1d5-44ca-a00e-f0b9b519e7a8"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""10d8e950-4ff4-4a7b-81f9-bb8dc7cf8bbd"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""bc8f35c4-5a61-447a-9c31-6bfaec5c2bab"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d4618653-1796-4854-9e7f-c49e3ff16ce7"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d92244c3-a1a3-4287-8bac-4df91ff157e1"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3a309558-46b1-4660-b0b8-cff86ff6e2bd"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cb17c588-6e16-44e6-b116-447e3d382de5"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""d4f22638-0d29-4c95-a9be-814e6e721fc9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c915fa50-7a39-424f-b04e-ed9535537154"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3653b06c-e52a-482f-bb1b-25496bffadd3"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""cc0b8039-30fa-441b-bf70-268f996e69c9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d62d771f-fa40-44c7-b453-f5864060fbc7"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c668d34f-c7aa-49ee-9c09-25166ada6c8f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e099e07d-6a04-44dc-8ef0-6e97039b5548"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c5e9c45a-75e6-4a90-ad80-926c707ec5b4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ef6dad84-c624-4c74-a28d-4aa52afdb931"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3d28447f-bc1a-4a64-859e-70ccbffb1484"",
                    ""path"": ""*/{Submit}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c43961f-7d2c-4e75-a04e-7f57ea803dc4"",
                    ""path"": ""*/{Cancel}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5620a82-8cbe-487d-98db-0ffddf13e9a0"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5eb5280-c800-4e15-93c2-9c1bcefead14"",
                    ""path"": ""<Pen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e781a4e-0fa8-45e0-bbfb-cb81e5e184ae"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d27563fb-6710-49f5-a701-2480c3a71989"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9365d1bb-59ea-4966-80c0-bf0c2bc233e0"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3f2a378-0aa5-4d76-b0e0-2eb56730392e"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""26ba789d-587e-49cb-bea2-cf79f75319c0"",
                    ""path"": ""<XRController>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdedb31e-bc3b-4473-bb58-2ddc6ba30b0e"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""ScrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f60678b-017c-4de9-a67e-04bd320cd634"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""MiddleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76d0e9cd-06b9-4acf-9fd0-43693ab93d8d"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""feba7fe6-c205-4596-b672-bb529f994df6"",
                    ""path"": ""<XRController>/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDevicePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b55a91dc-0618-40ef-84d4-459bb473a3c0"",
                    ""path"": ""<XRController>/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDeviceOrientation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Adventure
            m_Adventure = asset.FindActionMap("Adventure", throwIfNotFound: true);
            m_Adventure_Movement = m_Adventure.FindAction("Movement", throwIfNotFound: true);
            m_Adventure_Interact = m_Adventure.FindAction("Interact", throwIfNotFound: true);
            // Battle
            m_Battle = asset.FindActionMap("Battle", throwIfNotFound: true);
            m_Battle_Movement = m_Battle.FindAction("Movement", throwIfNotFound: true);
            m_Battle_Attack = m_Battle.FindAction("Attack", throwIfNotFound: true);
            m_Battle_Guard = m_Battle.FindAction("Guard", throwIfNotFound: true);
            m_Battle_Skill = m_Battle.FindAction("Skill", throwIfNotFound: true);
            m_Battle_CycleClockwise = m_Battle.FindAction("CycleClockwise", throwIfNotFound: true);
            m_Battle_CycleCounterclockwise = m_Battle.FindAction("CycleCounterclockwise", throwIfNotFound: true);
            m_Battle_TargetSelection = m_Battle.FindAction("TargetSelection", throwIfNotFound: true);
            m_Battle_NextPartyMember = m_Battle.FindAction("NextPartyMember", throwIfNotFound: true);
            m_Battle_PreviousPartyMember = m_Battle.FindAction("PreviousPartyMember", throwIfNotFound: true);
            // UI
            m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
            m_UI_TrackedDeviceOrientation = m_UI.FindAction("TrackedDeviceOrientation", throwIfNotFound: true);
            m_UI_TrackedDevicePosition = m_UI.FindAction("TrackedDevicePosition", throwIfNotFound: true);
            m_UI_RightClick = m_UI.FindAction("RightClick", throwIfNotFound: true);
            m_UI_MiddleClick = m_UI.FindAction("MiddleClick", throwIfNotFound: true);
            m_UI_ScrollWheel = m_UI.FindAction("ScrollWheel", throwIfNotFound: true);
            m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
            m_UI_Point = m_UI.FindAction("Point", throwIfNotFound: true);
            m_UI_Cancel = m_UI.FindAction("Cancel", throwIfNotFound: true);
            m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
            m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
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

        // Adventure
        private readonly InputActionMap m_Adventure;
        private IAdventureActions m_AdventureActionsCallbackInterface;
        private readonly InputAction m_Adventure_Movement;
        private readonly InputAction m_Adventure_Interact;
        public struct AdventureActions
        {
            private @PlayerInput m_Wrapper;
            public AdventureActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Adventure_Movement;
            public InputAction @Interact => m_Wrapper.m_Adventure_Interact;
            public InputActionMap Get() { return m_Wrapper.m_Adventure; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(AdventureActions set) { return set.Get(); }
            public void SetCallbacks(IAdventureActions instance)
            {
                if (m_Wrapper.m_AdventureActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_AdventureActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_AdventureActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_AdventureActionsCallbackInterface.OnMovement;
                    @Interact.started -= m_Wrapper.m_AdventureActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_AdventureActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_AdventureActionsCallbackInterface.OnInteract;
                }
                m_Wrapper.m_AdventureActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                }
            }
        }
        public AdventureActions @Adventure => new AdventureActions(this);

        // Battle
        private readonly InputActionMap m_Battle;
        private IBattleActions m_BattleActionsCallbackInterface;
        private readonly InputAction m_Battle_Movement;
        private readonly InputAction m_Battle_Attack;
        private readonly InputAction m_Battle_Guard;
        private readonly InputAction m_Battle_Skill;
        private readonly InputAction m_Battle_CycleClockwise;
        private readonly InputAction m_Battle_CycleCounterclockwise;
        private readonly InputAction m_Battle_TargetSelection;
        private readonly InputAction m_Battle_NextPartyMember;
        private readonly InputAction m_Battle_PreviousPartyMember;
        public struct BattleActions
        {
            private @PlayerInput m_Wrapper;
            public BattleActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Battle_Movement;
            public InputAction @Attack => m_Wrapper.m_Battle_Attack;
            public InputAction @Guard => m_Wrapper.m_Battle_Guard;
            public InputAction @Skill => m_Wrapper.m_Battle_Skill;
            public InputAction @CycleClockwise => m_Wrapper.m_Battle_CycleClockwise;
            public InputAction @CycleCounterclockwise => m_Wrapper.m_Battle_CycleCounterclockwise;
            public InputAction @TargetSelection => m_Wrapper.m_Battle_TargetSelection;
            public InputAction @NextPartyMember => m_Wrapper.m_Battle_NextPartyMember;
            public InputAction @PreviousPartyMember => m_Wrapper.m_Battle_PreviousPartyMember;
            public InputActionMap Get() { return m_Wrapper.m_Battle; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(BattleActions set) { return set.Get(); }
            public void SetCallbacks(IBattleActions instance)
            {
                if (m_Wrapper.m_BattleActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnMovement;
                    @Attack.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnAttack;
                    @Attack.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnAttack;
                    @Attack.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnAttack;
                    @Guard.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnGuard;
                    @Guard.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnGuard;
                    @Guard.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnGuard;
                    @Skill.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnSkill;
                    @Skill.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnSkill;
                    @Skill.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnSkill;
                    @CycleClockwise.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnCycleClockwise;
                    @CycleClockwise.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnCycleClockwise;
                    @CycleClockwise.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnCycleClockwise;
                    @CycleCounterclockwise.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnCycleCounterclockwise;
                    @CycleCounterclockwise.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnCycleCounterclockwise;
                    @CycleCounterclockwise.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnCycleCounterclockwise;
                    @TargetSelection.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnTargetSelection;
                    @TargetSelection.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnTargetSelection;
                    @TargetSelection.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnTargetSelection;
                    @NextPartyMember.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnNextPartyMember;
                    @NextPartyMember.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnNextPartyMember;
                    @NextPartyMember.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnNextPartyMember;
                    @PreviousPartyMember.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnPreviousPartyMember;
                    @PreviousPartyMember.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnPreviousPartyMember;
                    @PreviousPartyMember.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnPreviousPartyMember;
                }
                m_Wrapper.m_BattleActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Attack.started += instance.OnAttack;
                    @Attack.performed += instance.OnAttack;
                    @Attack.canceled += instance.OnAttack;
                    @Guard.started += instance.OnGuard;
                    @Guard.performed += instance.OnGuard;
                    @Guard.canceled += instance.OnGuard;
                    @Skill.started += instance.OnSkill;
                    @Skill.performed += instance.OnSkill;
                    @Skill.canceled += instance.OnSkill;
                    @CycleClockwise.started += instance.OnCycleClockwise;
                    @CycleClockwise.performed += instance.OnCycleClockwise;
                    @CycleClockwise.canceled += instance.OnCycleClockwise;
                    @CycleCounterclockwise.started += instance.OnCycleCounterclockwise;
                    @CycleCounterclockwise.performed += instance.OnCycleCounterclockwise;
                    @CycleCounterclockwise.canceled += instance.OnCycleCounterclockwise;
                    @TargetSelection.started += instance.OnTargetSelection;
                    @TargetSelection.performed += instance.OnTargetSelection;
                    @TargetSelection.canceled += instance.OnTargetSelection;
                    @NextPartyMember.started += instance.OnNextPartyMember;
                    @NextPartyMember.performed += instance.OnNextPartyMember;
                    @NextPartyMember.canceled += instance.OnNextPartyMember;
                    @PreviousPartyMember.started += instance.OnPreviousPartyMember;
                    @PreviousPartyMember.performed += instance.OnPreviousPartyMember;
                    @PreviousPartyMember.canceled += instance.OnPreviousPartyMember;
                }
            }
        }
        public BattleActions @Battle => new BattleActions(this);

        // UI
        private readonly InputActionMap m_UI;
        private IUIActions m_UIActionsCallbackInterface;
        private readonly InputAction m_UI_TrackedDeviceOrientation;
        private readonly InputAction m_UI_TrackedDevicePosition;
        private readonly InputAction m_UI_RightClick;
        private readonly InputAction m_UI_MiddleClick;
        private readonly InputAction m_UI_ScrollWheel;
        private readonly InputAction m_UI_Click;
        private readonly InputAction m_UI_Point;
        private readonly InputAction m_UI_Cancel;
        private readonly InputAction m_UI_Submit;
        private readonly InputAction m_UI_Navigate;
        public struct UIActions
        {
            private @PlayerInput m_Wrapper;
            public UIActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @TrackedDeviceOrientation => m_Wrapper.m_UI_TrackedDeviceOrientation;
            public InputAction @TrackedDevicePosition => m_Wrapper.m_UI_TrackedDevicePosition;
            public InputAction @RightClick => m_Wrapper.m_UI_RightClick;
            public InputAction @MiddleClick => m_Wrapper.m_UI_MiddleClick;
            public InputAction @ScrollWheel => m_Wrapper.m_UI_ScrollWheel;
            public InputAction @Click => m_Wrapper.m_UI_Click;
            public InputAction @Point => m_Wrapper.m_UI_Point;
            public InputAction @Cancel => m_Wrapper.m_UI_Cancel;
            public InputAction @Submit => m_Wrapper.m_UI_Submit;
            public InputAction @Navigate => m_Wrapper.m_UI_Navigate;
            public InputActionMap Get() { return m_Wrapper.m_UI; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
            public void SetCallbacks(IUIActions instance)
            {
                if (m_Wrapper.m_UIActionsCallbackInterface != null)
                {
                    @TrackedDeviceOrientation.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                    @TrackedDeviceOrientation.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                    @TrackedDeviceOrientation.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                    @TrackedDevicePosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                    @TrackedDevicePosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                    @TrackedDevicePosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                    @RightClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                    @RightClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                    @RightClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                    @MiddleClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                    @MiddleClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                    @MiddleClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                    @ScrollWheel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                    @ScrollWheel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                    @ScrollWheel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                    @Click.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                    @Click.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                    @Click.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                    @Point.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                    @Point.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                    @Point.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                    @Cancel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                    @Cancel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                    @Cancel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                    @Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                    @Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                    @Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                    @Navigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                    @Navigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                    @Navigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                }
                m_Wrapper.m_UIActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @TrackedDeviceOrientation.started += instance.OnTrackedDeviceOrientation;
                    @TrackedDeviceOrientation.performed += instance.OnTrackedDeviceOrientation;
                    @TrackedDeviceOrientation.canceled += instance.OnTrackedDeviceOrientation;
                    @TrackedDevicePosition.started += instance.OnTrackedDevicePosition;
                    @TrackedDevicePosition.performed += instance.OnTrackedDevicePosition;
                    @TrackedDevicePosition.canceled += instance.OnTrackedDevicePosition;
                    @RightClick.started += instance.OnRightClick;
                    @RightClick.performed += instance.OnRightClick;
                    @RightClick.canceled += instance.OnRightClick;
                    @MiddleClick.started += instance.OnMiddleClick;
                    @MiddleClick.performed += instance.OnMiddleClick;
                    @MiddleClick.canceled += instance.OnMiddleClick;
                    @ScrollWheel.started += instance.OnScrollWheel;
                    @ScrollWheel.performed += instance.OnScrollWheel;
                    @ScrollWheel.canceled += instance.OnScrollWheel;
                    @Click.started += instance.OnClick;
                    @Click.performed += instance.OnClick;
                    @Click.canceled += instance.OnClick;
                    @Point.started += instance.OnPoint;
                    @Point.performed += instance.OnPoint;
                    @Point.canceled += instance.OnPoint;
                    @Cancel.started += instance.OnCancel;
                    @Cancel.performed += instance.OnCancel;
                    @Cancel.canceled += instance.OnCancel;
                    @Submit.started += instance.OnSubmit;
                    @Submit.performed += instance.OnSubmit;
                    @Submit.canceled += instance.OnSubmit;
                    @Navigate.started += instance.OnNavigate;
                    @Navigate.performed += instance.OnNavigate;
                    @Navigate.canceled += instance.OnNavigate;
                }
            }
        }
        public UIActions @UI => new UIActions(this);
        public interface IAdventureActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
        }
        public interface IBattleActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnAttack(InputAction.CallbackContext context);
            void OnGuard(InputAction.CallbackContext context);
            void OnSkill(InputAction.CallbackContext context);
            void OnCycleClockwise(InputAction.CallbackContext context);
            void OnCycleCounterclockwise(InputAction.CallbackContext context);
            void OnTargetSelection(InputAction.CallbackContext context);
            void OnNextPartyMember(InputAction.CallbackContext context);
            void OnPreviousPartyMember(InputAction.CallbackContext context);
        }
        public interface IUIActions
        {
            void OnTrackedDeviceOrientation(InputAction.CallbackContext context);
            void OnTrackedDevicePosition(InputAction.CallbackContext context);
            void OnRightClick(InputAction.CallbackContext context);
            void OnMiddleClick(InputAction.CallbackContext context);
            void OnScrollWheel(InputAction.CallbackContext context);
            void OnClick(InputAction.CallbackContext context);
            void OnPoint(InputAction.CallbackContext context);
            void OnCancel(InputAction.CallbackContext context);
            void OnSubmit(InputAction.CallbackContext context);
            void OnNavigate(InputAction.CallbackContext context);
        }
    }
}
