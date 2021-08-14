using System;
using System.Numerics;
using SharpNav;
using SharpNav.IO.Json;
using SharpNav.Pathfinding;

namespace QuixTest{
    public class Test{
        private bool hasGenerated = true;
        private NavMesh navMesh;
        private bool interceptExceptions;

		private NavMeshQuery navMeshQuery;
        private NavPoint startPt;

        public Test(){
             var model = new ObjModel("Tests/testNuevo.obj");
            var settings = NavMeshGenerationSettings.Default;
            settings.CellSize = 10;
            settings.AgentHeight = 1.7f;
            settings.AgentRadius = 1.5f;

            //generate the mesh
            navMesh = NavMesh.Generate(model.GetTriangles(), settings);

			navMeshQuery = new NavMeshQuery(navMesh,2048);

			Vector3 c = new Vector3(0, 0, 0);
			Vector3 e = new Vector3(5, 5, 5);
			navMeshQuery.FindNearestPoly(ref c, ref e,out startPt);

            Console.WriteLine(startPt.Position);
        }

    }
}