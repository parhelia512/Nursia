using DigitalRiseModel;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Nursia.Standard
{
	public class MeshNode : MeshNodeBase
	{
		[Browsable(false)]
		[JsonIgnore]
		public DrMeshPart Mesh { get; set; }

		protected override DrMeshPart RenderMesh => Mesh;
	}
}
