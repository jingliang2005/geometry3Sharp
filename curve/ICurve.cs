using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace g3
{

	public interface IParametricCurve3d
	{
		bool IsClosed {get;}

		// can call SampleT in range [0,ParamLength]
		double ParamLength {get;}
		Vector3d SampleT(double t);
		Vector3d TangentT(double t);        // returns normalized vector

		bool HasArcLength {get;}
		double ArcLength {get;}
		Vector3d SampleArcLength(double a);

		void Reverse();

		IParametricCurve3d Clone();		
	}




    public interface ISampledCurve3d
    {
        int VertexCount { get; }
        int SegmentCount { get; }
        bool Closed { get; }

        Vector3d GetVertex(int i);
        Segment3d GetSegment(int i);

        IEnumerable<Vector3d> Vertices { get; }
    }




	/// <summary>
	/// 参数曲线2d接口。
	/// </summary>
	public interface IParametricCurve2d
	{
		bool IsClosed {get;}

		// can call SampleT in range [0,ParamLength]
		/// <summary>
		/// 参数长度,可以在[0，Param Length]范围内调用Sample
		/// </summary>
		double ParamLength {get;}
		Vector2d SampleT(double t);
		/// <summary>
		/// 切线,返回归一化向量
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		Vector2d TangentT(double t);        // returns normalized vector
		/// <summary>
		/// 有弧长
		/// </summary>
		bool HasArcLength {get;}
		/// <summary>
		/// 弧长
		/// </summary>
		double ArcLength {get;}
		Vector2d SampleArcLength(double a);

		void Reverse();

        bool IsTransformable { get; }
        void Transform(ITransform2 xform);

        IParametricCurve2d Clone();
	}

	/// <summary>
	/// 多曲线2d接口。
	/// </summary>
	public interface IMultiCurve2d
    {
        ReadOnlyCollection<IParametricCurve2d> Curves { get; }
    }

}
