using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;

namespace Ranta.Publish
{
    public class IISProxy
    {
        public void StopAppPool(string appPoolName)
        {
            Invoke(appPoolName, "stop");
        }

        public void StartAppPool(string appPoolName)
        {
            Invoke(appPoolName, "start");
        }

        public void RecycleAppPoolName(string appPoolName)
        {
            Invoke(appPoolName, "recycle");
        }

        private void Invoke(string appPoolName, string methodName)
        {
            DirectoryEntry entry = new DirectoryEntry("IIS://localhost/W3SVC/AppPools");

            entry.Children.Find(appPoolName);

            foreach (DirectoryEntry item in entry.Children)
            {
                Console.WriteLine(item.Name);

                if (item.Name.Equals("TheWeb"))
                {
                    item.Invoke(methodName);
                }
            }
        }
    }
}
