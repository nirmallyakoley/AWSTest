using ContosoGamingAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoGamingAPI.Helper;

namespace ContosoGamingAPI.BL
{
    public class LandMarkOperation:IOperation
    {
       private Dictionary<string, LandMark> dicLandmarks ;
        public LandMarkOperation()
        {
            dicLandmarks = new Dictionary<string, LandMark>();
        }
       public int Stop { get; set; } = 0;
        public void CreateLandmarkNode(string _edge)
        {
            try
            {
                (string origin, string destination, int distance) node = Helper.Helper.ParseCollectiveNode(_edge);

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
                    LandMark _newNode = new LandMark { Name = node.origin, ConnectedLandMark = new List<LandMark> { destination } };
                    dicLandmarks.Add(node.origin, _newNode);
                }
            }
            catch(Exception ex) {
                throw ex;
            }
                   
           
        }

        

        public int CalculateDistance(string nodeTraverse)
        {
            LandMark _currentLadMark = null;
            int _distance = 0;
            try
            {
                string[] nodelist = Helper.Helper.GetIndividualLandMarkName(nodeTraverse);
                for (int i = 0; i < nodelist.Length - 1; i++)
                {
                    try
                    {
                        _currentLadMark = dicLandmarks[nodelist[i]];
                    }
                    catch
                    {
                        _distance = -1;
                        break;
                    }
                    if (i < nodelist.Length)
                    {
                        LandMark objLandMark = _currentLadMark.ConnectedLandMark.Find(landmark => landmark.Name == nodelist[i + 1]);
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
            catch (Exception ex)
            {
                throw ex;
            }

           
        }

       
    }


}
