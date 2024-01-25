using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using withersdk.ISB.Department;
using withersdk.ISB.Tests;

namespace withersdk.ISB
{
    public sealed class Tester
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IDepartment this[string name] { get => Departments.FirstOrDefault(x => x.Name == name); }

        public List<IDepartment> Departments { get; set; }
        public Tester(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Departments = new List<IDepartment>();
        }

        public static Tester Build(string testerName, params string[] departmentsNames)
        {
            List<IDepartment> departments = new List<IDepartment>();
            foreach (var departmentName in departmentsNames)
            {
                departments.Add(new DefaultDepartment(departmentName));
            }
            var tester = new Tester(testerName);
            foreach (var department in departments)
            {
                department.Add(new AccessControlTest());
                department.Add(new AntivirusTest());
                department.Add(new RemoteWorkTest());
                department.Add(new InformationInfrastructureTest());
                tester.Departments.Add(department);
            }
            return tester;
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Tester Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<Tester>(json);
        }
    }
}
