using ContosoGamingAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoGamingAPI.BL
{
    public class LandMarkOperation:IOperation
    {
        Dictionary<string, LandMark> dicLandmarks = new Dictionary<string, LandMark>();
        public LandMark CurrentLandMark { get; set; }
        public int Stop { get; set; } = 0;
        public void CreateLandmarkNode(string _edge)
        {
           (string origin, string destination, int distance) node = ParseCollectiveNode(_edge);
            //make destination landmark////
            LandMark destination = new LandMark() { Name = node.destination, Distance = node.distance };
            // collection contain landmark
            if (dicLandmarks.ContainsKey(node.origin))
            {
                LandMark _existing = dicLandmarks[node.origin];
                _existing.ConnectedLandMark.Add(destination);
            }
            else
            {////new LandMark
                LandMark _newNode = new LandMark {Name= node.origin ,ConnectedLandMark=new List<LandMark> { destination } };
                dicLandmarks.Add(node.origin, _newNode);
            }
                   
           
        }

        (string origin, string destination,int distance) ParseCollectiveNode(string _edge)
        {
            char[] c = _edge.ToCharArray();
            string _origin = c[0].ToString();
            string _connecteddestination = c[1].ToString();
            int _distance = int.Parse(c[2].ToString());
            return (_origin, _connecteddestination, _distance);
        }

        public int CalculateDistance(string nodeTraverse)
        {
            int _distance = 0; 
            string[] nodelist = GetIndividualLandMarkName(nodeTraverse);
            for(int i=0; i< nodelist.Length-1;i++)
            {
                CurrentLandMark = dicLandmarks[nodelist[i]];
                if (i < nodelist.Length) {
                        LandMark objLandMark = CurrentLandMark.ConnectedLandMark.Find(landmark => landmark.Name == nodelist[i + 1]);
                    if (null != objLandMark)
                    {
                        _distance += objLandMark.Distance;
                        Stop++;
                    }
                    else
                    {
                        _distance = -1;
                        break;
                    }
                }
            }

            return _distance;
        }

        private string[] GetIndividualLandMarkName(string nodeTraverse)
        {
            return nodeTraverse.Split('-');
        }
    }


}
