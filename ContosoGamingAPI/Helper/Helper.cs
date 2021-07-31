using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoGamingAPI.Helper
{
    public class Helper
    {
        public static (string origin, string destination, int distance) ParseCollectiveNode(string _edge)
        {
            char[] c = _edge.ToCharArray();
            string _origin = c[0].ToString();
            string _connecteddestination = c[1].ToString();
            int _distance = int.Parse(c[2].ToString()); 
            return (_origin, _connecteddestination, _distance);
        }
        public static string[] GetIndividualLandMarkName(string nodeTraverse)
        {
            return nodeTraverse.Split('-');
        }
    }

}
