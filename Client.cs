using System;
using System.Collections.Generic;
using System.IO;

namespace CSharp18_11
{
    public class Client
    {
        public static void Test(string path)
        {
            List<Component> comps = new List<Component>();
            using (var reader = new StreamReader(path))
            {
                char data;
                int n = Convert.ToInt32(reader.ReadLine()), parentIndex;
                for (int i = 0; i < n; i++)
                {
                    data = reader.ReadLine()[0];
                    if (data > 'a')
                        comps.Add(new Leaf(data));
                    else
                        comps.Add(new Composite(data));
                }

                for (int childIndex = 0; childIndex < n; childIndex++)
                {
                    parentIndex = Convert.ToInt32(reader.ReadLine());
                    if (parentIndex != -1)
                        comps[parentIndex].AddComponent(comps[childIndex]);
                }
            }

            foreach (Component component in comps)
            {
                Console.WriteLine(component.Operation());
            }
        }
    }
}