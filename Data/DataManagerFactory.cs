using System.Configuration;
using System.Reflection;

namespace Data
{
    public static class DataManagerFactory
    {
        static ObjectFactory s_objectFactory;

        static DataManagerFactory()
        {
            string assemblyString = "Data.SQL";
            string overriddenDataAssembly = ConfigurationManager.AppSettings["OverriddenDataAssembly"];
            if (!string.IsNullOrEmpty(overriddenDataAssembly))
                assemblyString = overriddenDataAssembly;

            s_objectFactory = new ObjectFactory(Assembly.Load(assemblyString));
        }

        public static T GetDataManager<T>() where T : class, IDataManager
        {
            return s_objectFactory.CreateObjectFromType<T>();
        }
    }
}
