﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAnimStudio.TaeEditor
{
    public class TaeTransport
    {
        public Rectangle Rect = new Rectangle(0, 0, 64, 64);

        public TaeEditorScreen MainScreen;

        List<TransportButton> Buttons = new List<TransportButton>();

        TaePlaybackCursor PlaybackCursor => MainScreen.Graph.PlaybackCursor;

        int ButtonCageThickness = 4;
        int ButtonSeparatorThickness = 2;
        int ButtonSize = 22;

        AnimationExportData data_to_export = new AnimationExportData();

        public TaeTransport(TaeEditorScreen mainScreen)
        {
            MainScreen = mainScreen;

            Buttons.Add(new TransportButton()
            {
                GetDebugText = () => "EXPORT ANIMATION 2",
                CustomWidth = 120,
                GetActiveBackColor = () => new Color(0, 100, 0, 255),
                GetHoverBackColor = () => new Color(0, 150, 0, 255),
                GetPressedBackColor = () => new Color(175, 210, 175, 255),
                OnClick = () =>
                {
                    if (data_to_export.bones?.Count == 0)
                        foreach (var boneInfo in Scene.MainModel.SkeletonFlver.FlverSkeleton)
                        {

                            boneInfo.bone.CurrentMatrix = new InPoseMatrix4x4(boneInfo.CurrentMatrix);
                            data_to_export.bones.Add(boneInfo.bone);

                        }

                    data_to_export.timeLength = PlaybackCursor.MaxTime;

                    int lastFrame = (int)PlaybackCursor.MaxFrame;
                    var currentFrame = (int)PlaybackCursor.CurrentFrame;
                    var currentTime = PlaybackCursor.CurrentTime;


                    var keyframe = new InPoseKeyframe(currentFrame, currentTime);
                    foreach (var boneInfo in Scene.MainModel.SkeletonFlver.FlverSkeleton)
                    {

                        var curentMatrix = new InPoseMatrix4x4(boneInfo.CurrentMatrix);
                        keyframe.boneDisplacements.Add(new InPoseBoneDisplacement(boneInfo.bone.Name, boneInfo.bone.ParentIndex, curentMatrix));
                    }

                    

                    data_to_export.keyframes.Add(keyframe);

                    MainScreen.TransportNextFrame();

                    if (currentFrame == lastFrame)
                    {
                        string json = JsonConvert.SerializeObject(data_to_export);
                        File.WriteAllText(@"C:\\Users\\codri\\Desktop\\animation_export.json", json);

                        #region ResetAnimation
                        //PlaybackCursor.IsPlaying = false;
                        //PlaybackCursor.CurrentTime = 0;
                        //MainScreen.Graph?.ViewportInteractor?.CurrentModel?.AnimContainer?.ResetAll();
                        //PlaybackCursor.StartTime = 0;
                        //MainScreen.Graph.ViewportInteractor.OnScrubFrameChange(forceCustomTimeDelta: 0);
                        //MainScreen.Graph.ViewportInteractor.CurrentModel.AnimContainer.ResetRootMotion();

                        //MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.RightWeaponModel0?.AnimContainer?.ResetRootMotion();
                        //MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.RightWeaponModel1?.AnimContainer?.ResetRootMotion();
                        //MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.RightWeaponModel2?.AnimContainer?.ResetRootMotion();
                        //MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.RightWeaponModel3?.AnimContainer?.ResetRootMotion();

                        //MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.LeftWeaponModel0?.AnimContainer?.ResetRootMotion();
                        //MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.LeftWeaponModel1?.AnimContainer?.ResetRootMotion();
                        //MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.LeftWeaponModel2?.AnimContainer?.ResetRootMotion();
                        //MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.LeftWeaponModel3?.AnimContainer?.ResetRootMotion();

                        //MainScreen.Graph.ViewportInteractor.ResetRootMotion();
                        //MainScreen.Graph.ScrollToPlaybackCursor(1);
                        //PlaybackCursor.IgnoreCurrentRelativeScrub();
                        #endregion
                        data_to_export = new AnimationExportData();
                        data_to_export.timeLength = PlaybackCursor.MaxTime;
                    }

                }
            });

            Buttons.Add(new TransportButton()
            {
                GetDebugText = () => "EXPORT ANIMATION",
                CustomWidth = 120,
                GetActiveBackColor = () => new Color(0, 100, 0, 255),
                GetHoverBackColor = () => new Color(0, 150, 0, 255),
                GetPressedBackColor = () => new Color(175, 210, 175, 255),
                OnClick = () =>
                {
                    #region ResetAnimation
                    //PlaybackCursor.IsPlaying = false;
                    //PlaybackCursor.CurrentTime = 0;
                    //MainScreen.Graph?.ViewportInteractor?.CurrentModel?.AnimContainer?.ResetAll();
                    //PlaybackCursor.StartTime = 0;
                    //MainScreen.Graph.ViewportInteractor.OnScrubFrameChange(forceCustomTimeDelta: 0);
                    //MainScreen.Graph.ViewportInteractor.CurrentModel.AnimContainer.ResetRootMotion();

                    //MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.RightWeaponModel0?.AnimContainer?.ResetRootMotion();
                    //MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.RightWeaponModel1?.AnimContainer?.ResetRootMotion();
                    //MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.RightWeaponModel2?.AnimContainer?.ResetRootMotion();
                    //MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.RightWeaponModel3?.AnimContainer?.ResetRootMotion();

                    //MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.LeftWeaponModel0?.AnimContainer?.ResetRootMotion();
                    //MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.LeftWeaponModel1?.AnimContainer?.ResetRootMotion();
                    //MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.LeftWeaponModel2?.AnimContainer?.ResetRootMotion();
                    //MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.LeftWeaponModel3?.AnimContainer?.ResetRootMotion();

                    //MainScreen.Graph.ViewportInteractor.ResetRootMotion();
                    //MainScreen.Graph.ScrollToPlaybackCursor(1);
                    //PlaybackCursor.IgnoreCurrentRelativeScrub();
                    #endregion
                    AnimationExportData data = new AnimationExportData();

                    foreach (var boneInfo in Scene.MainModel.SkeletonFlver.FlverSkeleton)
                    {

                        boneInfo.bone.CurrentMatrix = new InPoseMatrix4x4(boneInfo.CurrentMatrix);
                        data.bones.Add(boneInfo.bone);

                    }


                    int lastFrame = (int)PlaybackCursor.MaxFrame;
                    int currentFrame = 0;
                    do
                    {
                        currentFrame = (int)PlaybackCursor.CurrentFrame;
                        var currentTime = PlaybackCursor.CurrentTime;
                        


                        var keyframe = new InPoseKeyframe(currentFrame, currentTime);
                        foreach (var boneInfo in Scene.MainModel.SkeletonFlver.FlverSkeleton)
                        {

                            var curentMatrix = new InPoseMatrix4x4(boneInfo.CurrentMatrix);
                            keyframe.boneDisplacements.Add(new InPoseBoneDisplacement(boneInfo.bone.Name, boneInfo.bone.ParentIndex, curentMatrix));
                        }

                        data.keyframes.Add(keyframe);
                        string json_keyframe = JsonConvert.SerializeObject(keyframe);
                        File.WriteAllText($@"C:\\Users\\codri\\Desktop\\Animation\\frame_{currentFrame}.json", json_keyframe);


                        MainScreen.TransportNextFrame();
                    } while (currentFrame != lastFrame);


                    string json = JsonConvert.SerializeObject(data);
                    File.WriteAllText(@"C:\\Users\\codri\\Desktop\\animation_export.json", json);

                }

            });


            Buttons.Add(new TransportButton()
            {
                GetDebugText = () => "EXPORT POSE",
                CustomWidth = 120,
                GetActiveBackColor = () => new Color(0, 100, 0, 255),
                GetHoverBackColor = () => new Color(0, 150, 0, 255),
                GetPressedBackColor = () => new Color(175, 210, 175, 255),
                OnClick = () =>
                {
                    var submeshes = new List<FlverSubmeshRenderer>();
                    if (Scene.MainModel.IS_PLAYER)
                    {
                        List<NewMesh> armorMeshes = new List<NewMesh>();
                        var chr = Scene.MainModel.ChrAsm;
                        if (chr.ArmsMesh?.Submeshes != null)
                            submeshes.AddRange(chr.ArmsMesh.Submeshes);
                        if (chr.BodyMesh?.Submeshes != null)
                            submeshes.AddRange(chr.BodyMesh.Submeshes);
                        if (chr.FacegenMesh?.Submeshes != null)
                            submeshes.AddRange(chr.FacegenMesh.Submeshes);
                        if (chr.FaceMesh?.Submeshes != null)
                            submeshes.AddRange(chr.FaceMesh.Submeshes);
                        if (chr.HeadMesh?.Submeshes != null)
                            submeshes.AddRange(chr.HeadMesh.Submeshes);
                        if (chr.LegsMesh?.Submeshes != null)
                            submeshes.AddRange(chr.LegsMesh.Submeshes);
                    }
                    else
                    {
                        submeshes = Scene.MainModel.MainMesh.Submeshes;
                    }

                    InPoseModel toExport = new InPoseModel();

                    foreach (var submesh in submeshes)
                    {
                        var get_mesh_vertices = new FlverShaderVertInput[submesh.VertBuffer.VertexCount];
                        submesh.VertBuffer.GetData<FlverShaderVertInput>(get_mesh_vertices);

                        InPoseSubmesh ipSubmesh = new InPoseSubmesh();
                        List<InPoseVertex> vertices = new List<InPoseVertex>();
                        ipSubmesh.Vertices = get_mesh_vertices.Select(v => new InPoseVertex
                        {
                            Position = new System.Numerics.Vector3(v.Position.X, v.Position.Y, v.Position.Z),
                            Normal = new System.Numerics.Vector3(v.Normal.X, v.Normal.Y, v.Normal.Z),
                            //Binormal = new System.Numerics.Vector3(v.Binormal.X, v.Binormal.Y, v.Binormal.Z),
                            //Bitangent = new System.Numerics.Vector4(v.Bitangent.X, v.Bitangent.Y, v.Bitangent.Z, v.Bitangent.W),
                            BoneIndices = new System.Numerics.Vector4(v.BoneIndices.X, v.BoneIndices.Y, v.BoneIndices.Z, v.BoneIndices.W),
                            BoneWeights = new System.Numerics.Vector4(v.BoneWeights.X, v.BoneWeights.Y, v.BoneWeights.Z, v.BoneWeights.W),
                            //BoneIndicesBank = new System.Numerics.Vector4(v.BoneIndicesBank.X, v.BoneIndicesBank.Y, v.BoneIndicesBank.Z, v.BoneIndicesBank.W),
                        }).ToList();
                        foreach (var fs in submesh.MeshFacesets)
                        {
                            ipSubmesh.FaceSets.Add(new InPoseFaceset(fs.Indices));
                        }

                        toExport.submeshes.Add(ipSubmesh);
                    }

                    foreach (var boneInfo in Scene.MainModel.SkeletonFlver.FlverSkeleton)
                    {

                        boneInfo.bone.CurrentMatrix = new InPoseMatrix4x4(boneInfo.CurrentMatrix);
                        toExport.bones.Add(boneInfo.bone);


                    }

                    string json = JsonConvert.SerializeObject(toExport);
                    File.WriteAllText(@"C:\\Users\\codri\\Desktop\\export.json", json);

                }
            });

            Buttons.Add(new TransportButton()
            {
                GetDebugText = () => "|<<",
                GetIsEnabled = () => PlaybackCursor.IsPlaying || (PlaybackCursor.CurrentTime != 0),
                OnClick = () =>
                {
                    PlaybackCursor.IsPlaying = false;
                    PlaybackCursor.CurrentTime = 0;
                    MainScreen.Graph?.ViewportInteractor?.CurrentModel?.AnimContainer?.ResetAll();
                    PlaybackCursor.StartTime = 0;
                    MainScreen.Graph.ViewportInteractor.OnScrubFrameChange(forceCustomTimeDelta: 0);
                    MainScreen.Graph.ViewportInteractor.CurrentModel.AnimContainer.ResetRootMotion();

                    MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.RightWeaponModel0?.AnimContainer?.ResetRootMotion();
                    MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.RightWeaponModel1?.AnimContainer?.ResetRootMotion();
                    MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.RightWeaponModel2?.AnimContainer?.ResetRootMotion();
                    MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.RightWeaponModel3?.AnimContainer?.ResetRootMotion();

                    MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.LeftWeaponModel0?.AnimContainer?.ResetRootMotion();
                    MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.LeftWeaponModel1?.AnimContainer?.ResetRootMotion();
                    MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.LeftWeaponModel2?.AnimContainer?.ResetRootMotion();
                    MainScreen.Graph.ViewportInteractor.CurrentModel.ChrAsm?.LeftWeaponModel3?.AnimContainer?.ResetRootMotion();

                    MainScreen.Graph.ViewportInteractor.ResetRootMotion();
                    MainScreen.Graph.ScrollToPlaybackCursor(1);
                    PlaybackCursor.IgnoreCurrentRelativeScrub();
                },
                GetHotkey = b => MainScreen.Input.KeyHeld(Keys.Home),
            });

            Buttons.Add(new TransportButton()
            {
                GetDebugText = () => "[]",
                GetIsEnabled = () => PlaybackCursor.CurrentTime != PlaybackCursor.StartTime,//MainScreen.Graph.PlaybackCursor.IsPlaying,
                OnClick = () =>
                {
                    var start = PlaybackCursor.StartTime;
                    PlaybackCursor.IsPlaying = false;
                    PlaybackCursor.CurrentTime = start;
                    //MainScreen.Graph.ViewportInteractor.OnScrubFrameChange(forceCustomTimeDelta: 0);
                    MainScreen.Graph.PlaybackCursor.UpdateScrubbing();
                    //MainScreen.Graph.ViewportInteractor.ResetRootMotion((float)MainScreen.Graph.PlaybackCursor.StartTime);
                    MainScreen.Graph.ScrollToPlaybackCursor(1);
                },
                GetHotkey = b => (MainScreen.Input.ShiftHeld && !MainScreen.Input.AltHeld && !MainScreen.Input.CtrlHeld) && MainScreen.Input.KeyHeld(Keys.Space),
            });

            Buttons.Add(new TransportButton()
            {
                GetDebugText = () => PlaybackCursor.IsPlaying ? "||" : ">",
                GetIsEnabled = () => true,
                OnClick = () => PlaybackCursor.Transport_PlayPause(),
                GetHotkey = b => (!MainScreen.Input.ShiftHeld && !MainScreen.Input.AltHeld && !MainScreen.Input.CtrlHeld) && MainScreen.Input.KeyDown(Keys.Space),
            });

            Buttons.Add(new TransportButton()
            {
                GetDebugText = () => ">>|",
                GetIsEnabled = () => PlaybackCursor.IsPlaying || (PlaybackCursor.CurrentTime != PlaybackCursor.MaxTime),
                OnClick = () =>
                {
                    PlaybackCursor.IsPlaying = false;
                    PlaybackCursor.CurrentTime = PlaybackCursor.MaxTime;
                    PlaybackCursor.StartTime = PlaybackCursor.MaxTime;
                    MainScreen.Graph.PlaybackCursor.UpdateScrubbing();
                    //MainScreen.Graph.ViewportInteractor.ResetRootMotion((float)MainScreen.Graph.PlaybackCursor.MaxTime);
                    MainScreen.Graph.ScrollToPlaybackCursor(1);
                },
                GetHotkey = b => MainScreen.Input.KeyHeld(Keys.End),
            });

            Buttons.Add(new TransportButtonSeparator());

            Buttons.Add(new TransportButton()
            {
                GetDebugText = () => MainScreen.Config.LoopEnabled_BeforeCombo ? "[LOOP]" : "[ONCE]",
                GetIsEnabled = () => (MainScreen.Graph?.ViewportInteractor?.CurrentComboIndex ?? -1) < 0,
                OnClick = () => MainScreen.Config.LoopEnabled_BeforeCombo = MainScreen.Config.LoopEnabled = !MainScreen.Config.LoopEnabled,
                GetHotkey = b => (!MainScreen.Input.ShiftHeld && !MainScreen.Input.AltHeld && MainScreen.Input.CtrlHeld) && MainScreen.Input.KeyDown(Keys.L),
                CustomWidth = 48,
                GetActiveBackColor = () => MainScreen.Config.LoopEnabled_BeforeCombo ? new Color(0, 100, 0, 255) : new Color(150, 0, 0, 255),
                GetHoverBackColor = () => MainScreen.Config.LoopEnabled_BeforeCombo ? new Color(0, 150, 0, 255) : new Color(200, 0, 0, 255),
                GetPressedBackColor = () => MainScreen.Config.LoopEnabled_BeforeCombo ? new Color(175, 210, 175, 255) : new Color(255, 130, 130, 255),
            });

            Buttons.Add(new TransportButtonSeparator());

            Buttons.Add(new TransportButton()
            {
                GetDebugText = () => "<|",
                GetIsEnabled = () => true,
                OnClick = () => MainScreen.TransportPreviousFrame(),
                GetHotkey = b =>
                {
                    if (MainScreen.Input.KeyUp(Keys.Left))
                    {
                        b.prevState = b.state = TransportButton.TransportButtonState.Normal;
                    }
                    return MainScreen.Input.KeyHeld(Keys.Left);
                },
            });

            Buttons.Add(new TransportButton()
            {
                GetDebugText = () => "|>",
                GetIsEnabled = () => true,
                OnClick = () => MainScreen.TransportNextFrame(),
                GetHotkey = b =>
                {
                    if (MainScreen.Input.KeyUp(Keys.Right))
                    {
                        b.prevState = b.state = TransportButton.TransportButtonState.Normal;
                    }
                    return MainScreen.Input.KeyHeld(Keys.Right);
                },
            });

        }

        public void LoadContent(ContentManager c)
        {

        }

        public void Update(float elapsedSeconds)
        {
            if (MainScreen.Graph == null)
                return;

            //// Count + 1 because for example 4 buttons would have these cages: |B|B|B|B|
            //// Notice 5 |'s but only 4 B's
            //int buttonCageWidth = ((Buttons.Count + 1) * ButtonCageThickness) + (ButtonSize * Buttons.Count);

            int buttonCageWidth = ButtonCageThickness;

            foreach (var thing in Buttons)
            {
                if (thing.IsSeparator)
                {
                    buttonCageWidth += (thing.CustomWidth ?? ButtonSeparatorThickness);
                    buttonCageWidth += ButtonCageThickness;
                }
                else
                {
                    buttonCageWidth += (thing.CustomWidth ?? ButtonSize);
                    buttonCageWidth += ButtonCageThickness;
                }
            }

            int buttonCageHeight = ButtonSize + (ButtonCageThickness * 2);
            int buttonCageStartX = Rect.Width - buttonCageWidth - 8;
            int buttonCageStartY = (int)Math.Round((Rect.Height / 2.0) - (buttonCageHeight / 2.0));

            int horizontalOffset = buttonCageStartX;

            for (int i = 0; i < Buttons.Count; i++)
            {
                if (Buttons[i].IsSeparator)
                {
                    horizontalOffset += ButtonCageThickness;

                    Buttons[i].Rect = new Rectangle(horizontalOffset,
                    buttonCageStartY + ButtonCageThickness,
                    Buttons[i].CustomWidth ?? ButtonSeparatorThickness,
                    ButtonSize);

                    horizontalOffset += ButtonSeparatorThickness;
                }
                else
                {
                    horizontalOffset += ButtonCageThickness;

                    Buttons[i].Rect = new Rectangle(horizontalOffset,
                    buttonCageStartY + ButtonCageThickness,
                    (Buttons[i].CustomWidth ?? ButtonSize),
                    ButtonSize);

                    horizontalOffset += (Buttons[i].CustomWidth ?? ButtonSize);

                }


                Buttons[i].Update(MainScreen.Input, this);
            }
        }

        public void Draw(GraphicsDevice gd, SpriteBatch sb, Texture2D boxTex, SpriteFont smallFont)
        {
            if (MainScreen.Graph == null)
                return;

            var oldViewport = gd.Viewport;
            gd.Viewport = new Viewport(Rect.DpiScaled());
            {
                sb.Begin(transformMatrix: Main.DPIMatrix);
                try
                {
                    var str = MainScreen.Graph.PlaybackCursor.GetFrameCounterText(MainScreen.Config.LockFramerateToOriginalAnimFramerate);
                    //sb.Draw(boxTex, new Rectangle(0, 0, Rect.Width, Rect.Height), Color.DarkGray);
                    var strSize = smallFont.MeasureString(str);

                    sb.DrawString(smallFont, str, new Vector2(8, (float)Math.Round((Rect.Height / 2.0) - (strSize.Y / 2))), Color.Yellow);

                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        Buttons[i].Draw(sb, boxTex, smallFont);
                    }
                }
                finally { sb.End(); }
            }
            gd.Viewport = oldViewport;
        }

        public class TransportButtonSeparator : TransportButton
        {
            public override bool IsSeparator => true;
        }

        public class TransportButton
        {
            public enum TransportButtonState
            {
                Normal,
                Hover,
                HoldingClick
            }

            public virtual bool IsSeparator => false;

            public Rectangle Rect;

            public Func<string> GetDebugText;
            public Func<bool> GetIsEnabled;
            public Action OnClick;

            public TransportButtonState state;

            public string InfoName = "?ButtonName?";
            public string InfoDescription = "?ButtonDesc?";

            public Func<TransportButton, bool> GetHotkey;

            public int? CustomWidth = null;

            public TransportButtonState prevState = TransportButtonState.Normal;

            public Func<Color> GetActiveBackColor = null;
            public Func<Color> GetHoverBackColor = null;
            public Func<Color> GetPressedBackColor = null;
            public Func<Color> GetInactiveBackColor = null;

            public Func<Color> GetActiveForeColor = null;
            public Func<Color> GetHoverForeColor = null;
            public Func<Color> GetPressedForeColor = null;
            public Func<Color> GetInactiveForeColor = null;

            private bool prevMouseHover;

            public void Update(FancyInputHandler input, TaeTransport parentTransport)
            {
                if (IsSeparator)
                    return;

                if (!(GetIsEnabled?.Invoke() ?? true) || Rect.IsEmpty)
                {
                    state = prevState = TransportButtonState.Normal;
                    return;
                }

                bool hotkeyPressed = GetHotkey?.Invoke(this) ?? false;

                var relativeMousePos = input.MousePositionPoint - parentTransport.Rect.Location;

                bool mouseHover = Rect.Contains(relativeMousePos);

                if (mouseHover)
                {
                    if (input.LeftClickDown && state != TransportButtonState.HoldingClick)
                    {
                        state = TransportButtonState.HoldingClick;
                    }
                    else if (!input.LeftClickHeld)
                    {
                        state = TransportButtonState.Hover;
                    }
                }
                else
                {

                    if (prevMouseHover)
                    {
                        state = prevState = TransportButtonState.Normal;
                    }


                }

                //if (input.LeftClickHeld && !hotkeyPressed)
                //    prevState = state;

                if (hotkeyPressed)
                {
                    state = TransportButtonState.HoldingClick;
                }
                else if (!mouseHover)
                {
                    state = TransportButtonState.Normal;
                }

                if (state != TransportButtonState.HoldingClick && prevState == TransportButtonState.HoldingClick)
                {
                    OnClick?.Invoke();
                }

                prevState = state;
                prevMouseHover = mouseHover;
            }

            public void Draw(SpriteBatch sb, Texture2D boxTex, SpriteFont smallFont)
            {
                if (Rect.IsEmpty)
                    return;

                if (IsSeparator)
                {
                    sb.Draw(boxTex, Rect, Color.DarkGray * 0.35f);

                    return;
                }

                Color bgColor = Color.DarkGray;
                Color fgColor = Color.White;

                if (state == TransportButtonState.Normal)
                {
                    bgColor = GetActiveBackColor?.Invoke() ?? Color.Gray;
                    fgColor = GetActiveForeColor?.Invoke() ?? Color.White;
                }
                else if (state == TransportButtonState.Hover)
                {
                    bgColor = GetHoverBackColor?.Invoke() ?? Color.DarkGray;
                    fgColor = GetHoverForeColor?.Invoke() ?? Color.White;
                }
                else if (state == TransportButtonState.HoldingClick)
                {
                    bgColor = GetPressedBackColor?.Invoke() ?? Color.White;
                    fgColor = GetPressedForeColor?.Invoke() ?? Color.Black;
                }

                if (!(GetIsEnabled?.Invoke() ?? true))
                {
                    bgColor = GetInactiveBackColor?.Invoke() ?? (bgColor * 0.5f);
                    fgColor = GetInactiveForeColor?.Invoke() ?? (fgColor * 0.5f);
                }

                sb.Draw(boxTex, Rect, bgColor);

                string dbgTxt = GetDebugText?.Invoke();

                if (dbgTxt != null)
                {
                    var txtSize = smallFont.MeasureString(dbgTxt);
                    sb.DrawString(smallFont, dbgTxt, new Vector2(
                        (float)Math.Round(Rect.X + (Rect.Width / 2f) - (txtSize.X / 2)),
                        (float)Math.Round(Rect.Y + (Rect.Height / 2f) - (txtSize.Y / 2))), fgColor);
                }


            }
        }
    }
}
