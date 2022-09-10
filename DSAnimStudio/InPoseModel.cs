using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class InPoseModel
{
    public List<InPoseSubmesh> submeshes = new List<InPoseSubmesh>();
    public List<InPoseBone> bones = new List<InPoseBone>();
}


public class InPoseSubmesh
{
    public List<InPoseVertex> Vertices = new List<InPoseVertex>();
    public List<InPoseFaceset> FaceSets = new List<InPoseFaceset>();
}

public class InPoseFaceset
{
    public InPoseFaceset(List<int> indices)
    {
        Indices = indices;
    }
    public List<int> Indices = new List<int>();
}

public class InPoseVertex
{
    public System.Numerics.Vector3 Position;
    public System.Numerics.Vector3 Normal;
    //public System.Numerics.Vector3 Binormal;
    //public System.Numerics.Vector4 Bitangent;
    public System.Numerics.Vector4 BoneIndices;
    public System.Numerics.Vector4 BoneWeights;
    //public System.Numerics.Vector4 BoneIndicesBank;
}

public class InPoseBone
{
    public string Name;
    public short ParentIndex;
    //public System.Numerics.Vector3 Translation;
    //public System.Numerics.Vector3 Rotation;
    //public System.Numerics.Vector3 Scale;
    public InPoseMatrix4x4 ReferenceMatrix;
    public InPoseMatrix4x4 CurrentMatrix;
}

public class InPoseMatrix4x4
{
    public float M11;
    public float M12;
    public float M13;
    public float M14;
    public float M21;
    public float M22;
    public float M23;
    public float M24;
    public float M31;
    public float M32;
    public float M33;
    public float M34;
    public float M41;
    public float M42;
    public float M43;
    public float M44;

    public InPoseMatrix4x4(Matrix m)
    {
        M11 = m.M11;
        M12 = m.M12;
        M13 = m.M13;
        M14 = m.M14;

        M21 = m.M21;
        M22 = m.M22;
        M23 = m.M23;
        M24 = m.M24;

        M31 = m.M31;
        M32 = m.M32;
        M33 = m.M33;
        M34 = m.M34;

        M41 = m.M41;
        M42 = m.M42;
        M43 = m.M43;
        M44 = m.M44;
    }
}

